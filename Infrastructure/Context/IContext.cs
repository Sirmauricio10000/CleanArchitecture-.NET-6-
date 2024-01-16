using Core.Entities;
using MongoDB.Driver;

namespace Infrastructure.Context
{
    public interface IContext
    {
        IMongoCollection<ProviderEntity> Providers { get;  }
    }
}