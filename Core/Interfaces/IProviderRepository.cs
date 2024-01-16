using Core.Entities;

namespace Core.Interfaces
{
    public interface IProviderRepository
    {
        Task<List<ProviderEntity>> GetAll();
        Task<ProviderEntity> GetProviderById(string nit);
        Task AddProvider(ProviderEntity newProvider);
        Task DeleteProviderById(string nit);
        Task UpdateProvider(ProviderEntity updatedProvider);
    }
}