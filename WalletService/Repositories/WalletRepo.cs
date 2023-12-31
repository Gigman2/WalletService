using WalletService.Data;
using WalletService.Models;
using WalletService.Utils;

namespace WalletService.Repositories
{
    public class WalletRepo : IWalletRepo
    {
        private readonly AppDbContext dbContext;

        public WalletRepo(AppDbContext context)
        {
            dbContext = context;
        }
        public void CreateWallet(Wallet wallet)
        {
            if (wallet == null)
            {
                throw new ArgumentNullException(nameof(wallet), "Invalid payload sent");
            }

            dbContext.Add(wallet);
        }

        public Wallet GetWalletById(Guid id)
        {
            var wallet = dbContext.Wallets.Find(id);
            if (wallet == null)
            {
                throw new ArgumentNullException(nameof(wallet), "Wallet not found");
            }
            return wallet;
        }

        public IEnumerable<Wallet> GetWallets()
        {
            return dbContext.Wallets.ToList();
        }

        public bool SaveChanges()
        {
            return (dbContext.SaveChanges() >= 0);
        }
    }
}