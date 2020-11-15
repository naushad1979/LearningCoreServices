using MongoDB.Driver;

namespace Supplier.Api.Database
{
    public sealed class DatabaseContext 
    {
        public DatabaseContext(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            DbContext = client.GetDatabase(databaseSettings.DatabaseName);
        }
        public IMongoDatabase DbContext { get; set; }
    }
}
