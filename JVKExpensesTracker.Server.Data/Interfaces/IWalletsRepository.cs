
namespace JVKExpensesTracker.Server.Data.Interfaces;


public interface IWalletsRepository
{
    Task<IEnumerable<Wallet>> ListByUserIdAsync(string userId); 

    Task<Wallet?> GetByIdAsync(string walletId, string userId);
}
