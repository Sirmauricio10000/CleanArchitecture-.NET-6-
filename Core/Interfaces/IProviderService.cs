using Core.Entities;

namespace Core.Interfaces
{
    public interface IProviderService
    {
        Task<List<ProviderEntity>> GetAll();
        Task<ProviderEntity> GetProviderById(string nit);
        Task AddProvider(ProviderEntity newProvider);
        Task<bool> DeleteProviderById(string nit);
        Task<bool> UpdateProvider(ProviderEntity updatedProvider);
    }
}