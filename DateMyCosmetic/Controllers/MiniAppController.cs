using AutoMapper;
using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using DateMyCosmeticAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DateMyCosmeticAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MiniAppController : ControllerBase
    {
        private readonly ICosmeticService _cosmeticService;
        private readonly ITelegramAccountService _telegramAccountService;
        private readonly IMapper _mapper;

        public MiniAppController(ICosmeticService cosmeticService, ITelegramAccountService telegramAccountService, IMapper mapper)
        {
            _cosmeticService = cosmeticService;
            _telegramAccountService = telegramAccountService;
            _mapper = mapper;
        }

        [HttpGet("cosmetics/{id}")]
        public async Task<IActionResult> GetCosmetic(string id)
        {
            var cosmetic = await _cosmeticService.GetCosmeticAsync(id);
            if (cosmetic == null)
                return NotFound();

            return Ok(cosmetic);
        }

        [HttpGet("cosmetics")]
        public async Task<IActionResult> GetAllCosmetics()
        {
            var cosmetics = await _cosmeticService.GetAllCosmeticsAsync();
            return Ok(cosmetics);
        }

        [HttpPost("cosmetics")]
        public async Task<IActionResult> AddCosmetic([FromBody] CosmeticViewModel cosmeticViewModel, [FromQuery] string telegramId)
        {
            try
            {
                // Check if telegram account exists first
                var account = await _telegramAccountService.GetTelegramAccountAsync(telegramId);

                if (account == null)
                {
                    return BadRequest("Telegram Account doesn't exist.");
                }

                var cosmeticDTO = _mapper.Map<CosmeticDTO>(cosmeticViewModel);
                cosmeticDTO.TelegramAccountId = account.Id;

                await _cosmeticService.AddCosmeticAsync(cosmeticDTO);
                return CreatedAtAction(nameof(GetCosmetic), new { id = cosmeticDTO.Id }, cosmeticDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("cosmetics/{id}")]
        public async Task<IActionResult> UpdateCosmetic(string id, [FromBody] CosmeticViewModel cosmeticViewModel)
        {
            var cosmeticDTO = _mapper.Map<CosmeticDTO>(cosmeticViewModel);
            await _cosmeticService.UpdateCosmeticAsync(id, cosmeticDTO);
            return NoContent();
        }

        [HttpDelete("cosmetics/{id}")]
        public async Task<IActionResult> DeleteCosmetic(string id)
        {
            await _cosmeticService.DeleteCosmeticAsync(id);
            return NoContent();
        }

        [HttpPost("telegramAccount")]
        public async Task<IActionResult> AddTelegramAccount([FromBody] TelegramAccountDTO accountDTO)
        {
            try
            {
                // Check if the Telegram account already exists.
                var existingAccount = await _telegramAccountService.GetTelegramAccountAsync(accountDTO.TelegramId.ToString());
                if (existingAccount != null)
                {
                    return Conflict("Telegram account already exists.");
                }

                await _telegramAccountService.AddTelegramAccountAsync(accountDTO);
                return CreatedAtAction(nameof(GetTelegramAccount), new { telegramId = accountDTO.TelegramId }, accountDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("telegramAccount/{telegramId}")]
        public async Task<IActionResult> GetTelegramAccount(string telegramId)
        {
            var telegramAccount = await _telegramAccountService.GetTelegramAccountAsync(telegramId);
            if (telegramAccount == null)
            {
                return NotFound();
            }
            return Ok(telegramAccount);
        }
    }
}
