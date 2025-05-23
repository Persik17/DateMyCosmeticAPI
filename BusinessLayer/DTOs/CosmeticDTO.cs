﻿namespace BusinessLayer.DTOs
{
    public class CosmeticDTO
    {
        public string Id { get; set; }
        public string TelegramAccountId { get; set; }
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime? OpenedDate { get; set; }
    }
}