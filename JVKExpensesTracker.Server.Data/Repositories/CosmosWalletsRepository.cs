
namespace JVKExpensesTracker.Server.Data.Repositories;


public class CosmosWalletsRepository : IWalletsRepository
{
    private readonly CosmosClient _db;
    private const string DATABASE_NAME = "ExpensesTrackerDb";
    private const string CONTAINER_NAME = "Wallets";


    public CosmosWalletsRepository(CosmosClient db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Wallet>> ListByUserIdAsync(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new ArgumentNullException(nameof(userId));
        }

        var queryText = $"SELECT * FROM c WHERE c.userId = @userId";
        var query = new QueryDefinition(queryText).WithParameter("@userId", userId); // we use this to avoid sql injection

        // we can't directly acces the list, it under db and then under container, so we fetch container first
        var container = _db.GetContainer(DATABASE_NAME, CONTAINER_NAME);

        var iterator = container.GetItemQueryIterator<Wallet>(query);

        //var result = await iterator.ReadNextAsync();


        var result = new List<Wallet>();
        while (iterator.HasMoreResults)
        {
            var response = await iterator.ReadNextAsync();
            result.AddRange(response.ToList());
        }



        //var final_res = result.Resource;

        return result;
    }
}
