using WalletService.Models;

namespace WalletService.Data
{
    public class PrepDb
    {
        public static void PreparePopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Wallets.Any())
            {
                context.AddRange(
                    new Wallet() { Id = new Guid(), Name = "MTN Wallet", Type = "momo", AccountNumber = "0245268415", AccountScheme = "mtn", Owner = "0245268415", CreatedAt = DateTime.Now.ToString() },
                    new Wallet() { Id = new Guid(), Name = "Vodafone Wallet", Type = "momo", AccountNumber = "0502960152", AccountScheme = "vodafone", Owner = "0245268415", CreatedAt = DateTime.Now.ToString() }
                );

                context.SaveChanges();
            }
        }
    }
}