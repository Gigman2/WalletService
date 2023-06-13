namespace WalletService.Dtos
{
    public class WalletCreateDto
    {
        public string? Name { get; set; }

        public string? Type { get; set; }

        public string? AccountNumber { get; set; }

        public string? AccountScheme { get; set; }

        public string? Owner { get; set; }
    }

    public class WalletReadDto : WalletCreateDto
    {
        public Guid Id { get; set; }

        public string? CreatedAt { get; set; }
    }

    public class WalletUpdateDto : WalletCreateDto
    {
        public string? CreatedAt { get; set; }
    }
}