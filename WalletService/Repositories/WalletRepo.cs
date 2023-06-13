using WalletService.Data;
using WalletService.Models;

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
                throw new ArgumentNullException(nameof(wallet));
            }

            dbContext.Add(wallet);
        }

        public async Task<Wallet> GetWalletById(Guid id)
        {
            var wallet = await dbContext.Wallets.FindAsync(id);
            if (wallet == null)
            {
                throw new ArgumentNullException(nameof(wallet));
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