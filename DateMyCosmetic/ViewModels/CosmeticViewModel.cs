namespace DateMyCosmeticAPI.ViewModels
{
    public class CosmeticViewModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Guid UserId { get; set; }
    }
}
