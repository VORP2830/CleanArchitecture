using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            try
            {
                var products = await _productService.GetProducts();
                if (products == null)
                {
                    return NoContent();
                }
                return Ok(products);
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao recuperar produtos.");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            try
            {
                var product = await _productService.GetById(id);
                if (product == null)
                {
                    return NoContent();
                }
                return Ok(product);
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao recuperar produto.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO model)
        {
            try
            {
                await _productService.Add(model);
                return Ok("Produto adicionado com sucesso");
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao tentar adicionar um produto.");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDTO model)
        {
            try
            {
                await _productService.Update(model);
                return Ok("Produto atualizado com sucesso.");
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao tentar atualizar produto.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.Remove(id);
                return Ok("produto excluido com sucesso.");
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao tentar excluir produto.");
            }
        }
    }
}