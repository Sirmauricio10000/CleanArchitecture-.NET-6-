using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly IContext _context;
        public ProviderRepository(IContext context)
        {
            _context = context;
        }

        public async Task AddProvider(ProviderEntity newProvider)
        {
            await _context.Providers.InsertOneAsync(newProvider);
        }

        public async Task<List<ProviderEntity>> GetAll()
        {
            var providers = await _context.Providers.Find(_ => true).ToListAsync();
            return providers;
        }

        public async Task<ProviderEntity> GetProviderById(string nit)
        {
            var filter = Builders<ProviderEntity>.Filter.Eq(x => x.Nit, nit);
            return await _context.Providers.Find(filter).FirstOrDefaultAsync();
        }

        public async Task DeleteProviderById(string nit)
        {
            var filter = Builders<ProviderEntity>.Filter.Eq("Nit", nit);
            await _context.Providers.DeleteOneAsync(filter);
        }

        public async Task UpdateProvider(ProviderEntity updatedProvider)
        {
            var filter = Builders<ProviderEntity>.Filter.Eq("_id", updatedProvider.Nit);


            var update = Builders<ProviderEntity>.Update
            .Set(x => x.BusinessName, updatedProvider.BusinessName)
            .Set(x => x.Address, updatedProvider.Address)
            .Set(x => x.ContactName, updatedProvider.ContactName)
            .Set(x => x.Active, updatedProvider.Active)
            .Set(x => x.ContactEmail, updatedProvider.ContactEmail)
            .Set(x => x.Email, updatedProvider.Email);


            await _context.Providers.UpdateOneAsync(filter, update);
        }

    }
}