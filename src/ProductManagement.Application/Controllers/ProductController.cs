using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Domain.DTOs.Entities;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;
using ProductManagement.Service.Validators;

namespace ProductManagement.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IProductService<ProductEntity> _productService;

        public ProductController(IMapper mapper, IProductService<ProductEntity> productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get(int? skip, int? take)
        {
            try
            {
                var result = _productService.Get(skip, take);

                var prod = _mapper.Map<List<ProductEntityDTO>>(result);

                return Ok(prod);
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
                var result = _productService.GetById(id);

                var prod = _mapper.Map<ProductEntityDTO>(result);

                return Ok(prod);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("status/{status}")]
        public IActionResult GetByStatus(bool status, int? skip, int? take)
        {
            try
            {
                var result = _productService.GetByStatus(status, skip, take);

                var prod = _mapper.Map<List<ProductEntityDTO>>(result);

                return Ok(prod);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("providerId/{providerId}")]
        public IActionResult GetByProviderId(int providerId, int? skip, int? take)
        {
            try
            {
                var result = _productService.GetByProviderId(providerId, skip, take);

                var prod = _mapper.Map<List<ProductEntityDTO>>(result);

                return Ok(prod);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductEntity product)
        {
            if (product == null)
                return NotFound();

            try
            {
                var result = _productService.Add<CreateProductValidator>(product).Id;

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProductEntity product)
        {
            if (product == null)
                return NotFound();

            if (product.Id <= 0)
                return BadRequest("Please enter the product ID.");

            try
            {
                var result = _productService.Update<UpdateProductValidator>(product);

                var prod = _mapper.Map<ProductEntityDTO>(result);

                return Ok(prod);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            try
            {
                _productService.Delete(new ProductEntity
                {
                    Id = id,
                    Status = false
                });

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}