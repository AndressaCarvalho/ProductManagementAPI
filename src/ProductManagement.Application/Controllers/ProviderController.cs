using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Helpers;
using ProductManagement.Domain.DTOs.Entities;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;
using ProductManagement.Service.Validators;

namespace ProductManagement.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProviderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IProviderService<ProviderEntity> _providerService;

        public ProviderController(IMapper mapper, IProviderService<ProviderEntity> providerService)
        {
            _mapper = mapper;
            _providerService = providerService;
        }

        [HttpGet]
        public IActionResult Get(int? skip, int? take)
        {
            try
            {
                var result = _providerService.Get(skip, take);

                var prov = _mapper.Map<List<ProviderEntityDTO>>(result);

                return Ok(prov);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id == 0)
                return NotFound();

            try
            {
                var result = _providerService.GetById(id);

                var prov = _mapper.Map<ProviderEntityDTO>(result);

                return Ok(prov);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProviderEntity provider)
        {
            if (provider == null)
                return NotFound();

            try
            {
                if (!string.IsNullOrEmpty(provider.Cnpj))
                    provider.Cnpj = ProviderHelper.RemoveCnpjMask(provider.Cnpj);

                var result = _providerService.Add<ProviderValidator>(provider).Id;

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProviderEntity provider)
        {
            if (provider == null)
                return NotFound();

            if (provider.Id <= 0)
                return BadRequest("Please enter the provider ID.");

            try
            {
                if (!string.IsNullOrEmpty(provider.Cnpj))
                    provider.Cnpj = ProviderHelper.RemoveCnpjMask(provider.Cnpj);

                var result = _providerService.Update(provider);

                var prov = _mapper.Map<ProviderEntityDTO>(result);

                return Ok(prov);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}