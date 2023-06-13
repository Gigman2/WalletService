using WalletService.Models;
namespace WalletService.Repositories
{
    public interface IWalletRepo
    {
        void CreateWallet(Wallet wallet);
        bool SaveChanges();

        IEnumerable<Wallet> GetWallets();

        Task<Wallet> GetWalletById(Guid id);

    }
}