using Core.Entities;
using Core.Interfaces;

namespace Core.Services
{
    public class ProviderService : IProviderService{
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public Task<List<ProviderEntity>> GetAll()
        {
            return _providerRepository.GetAll();
        }

        public Task<ProviderEntity> GetProviderById(string nit)
        {
            return _providerRepository.GetProviderById(nit);
        }

        public async Task AddProvider(ProviderEntity newProvider)
        {
            await _providerRepository.AddProvider(newProvider);
        }

        public async Task<bool> DeleteProviderById(string nit)
        {
            var existingProvider = await _providerRepository.GetProviderById(nit);

            if (existingProvider == null)
            {
                return false; 
            }
            await _providerRepository.DeleteProviderById(nit);

            return true;
        }

        public async Task<bool> UpdateProvider(ProviderEntity updatedProvider)
        {
            var existingProvider = await _providerRepository.GetProviderById(updatedProvider.Nit);

            if (existingProvider == null)
            {
                return false; 
            }

            await _providerRepository.UpdateProvider(updatedProvider);

            return true; 
        }
    }
}