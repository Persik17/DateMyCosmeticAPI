using Microsoft.AspNetCore.Mvc;

namespace DateMyCosmetic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MiniAppController : ControllerBase
    {
        private readonly ILogger<MiniAppController> _logger;

        public MiniAppController(ILogger<MiniAppController> logger)
        {
            _logger = logger;
        }

        [HttpPost("SaveData")]
        public async Task<IActionResult> SaveData([FromBody] CosmeticDataModel data)
        {
            if (data == null)
            {
                return BadRequest("Data is null.");
            }

            _logger.LogInformation($"Received Name = {data.Name}, OpeningDate = {data.OpeningDate}, ExpirationDate = {data.ExpirationDate}");

            // Process your data here
            // Save to database, etc.

            return Ok(new { success = true, message = "Data saved successfully" });
        }

        [HttpGet("GetData")]
        public async Task<IActionResult> GetData()
        {
            // Retrieve data from database or other source
            //var data = new YourDataModel { SomeProperty = "Example Data" };

            return Ok(/*data*/);
        }

        public class CosmeticDataModel
        {
            public string Name { get; set; }
            public DateTime OpeningDate { get; set; }
            public DateTime ExpirationDate { get; set; }
        }
    }
}
