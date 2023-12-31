using WalletService.Models;
namespace WalletService.Repositories
{
    public interface IWalletRepo
    {
        void CreateWallet(Wallet wallet);
        bool SaveChanges();

        IEnumerable<Wallet> GetWallets();

        Wallet GetWalletById(Guid id);

    }
}