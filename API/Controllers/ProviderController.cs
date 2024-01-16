using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase{

        private readonly IProviderService _providerService;

        public ProviderController(IProviderService userService)
        {
            _providerService = userService;
        }

        [HttpGet]
        public async Task<List<ProviderEntity>> GetAll()
        {
            return await _providerService.GetAll();
        }

        [HttpGet("{nit}")]
        public async Task<ActionResult<ProviderEntity>> GetProviderByNit(string nit)
        {
            try
            {
                var result = await _providerService.GetProviderById(nit);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Proveedor no encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar proveedor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddProvider([FromBody] ProviderEntity newProvider)
        {
            try
            {
                await _providerService.AddProvider(newProvider);

                return Ok("Proveedor registrado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al registrar proveedor: {ex.Message}");
            }
        }

       [HttpDelete("{nit}")]
        public async Task<ActionResult> DeleteProvider(string nit)
        {
            try
            {
                var result = await _providerService.DeleteProviderById(nit);

                if (result)
                {
                    return Ok("Proveedor actualizado correctamente");
                }
                else
                {
                    return NotFound("Proveedor no encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar proveedor: {ex.Message}");
            }
        }


        [HttpPut]
        public async Task<ActionResult> UpdateProvider([FromBody] ProviderEntity updatedProvider)
        {
            try
            {
                var result = await _providerService.UpdateProvider(updatedProvider);

                if (result)
                {
                    return Ok("Proveedor actualizado correctamente");
                }
                else
                {
                    return NotFound("Proveedor no encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar proveedor: {ex.Message}");
            }
        }
    }
}