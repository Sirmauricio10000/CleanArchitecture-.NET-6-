using Core.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Context
{
    public class Context : IContext{

        private readonly IMongoDatabase _database;

        public Context(IOptions<MongoDbSettingsEntity> options)
        {
            MongoClient _mongoClient = new MongoClient(options.Value.ConnectionString);
            _database = _mongoClient.GetDatabase(options.Value.DatabaseName);
        }
        
        public IMongoCollection<ProviderEntity> Providers => _database.GetCollection<ProviderEntity>("providers");
    }
}