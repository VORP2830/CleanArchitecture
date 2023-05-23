using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            try
            {
                var categories = await _categoryService.GetCategories();
                if (categories == null)
                {
                    return NoContent();
                }
                return Ok(categories);
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao recuperar categorias.");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoryById(int id)
        {
            try
            {
                var categories = await _categoryService.GetById(id);
                if (categories == null)
                {
                    return NoContent();
                }
                return Ok(categories);
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao recuperar categorias.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDTO model)
        {
            try
            {
                await _categoryService.Add(model);
                return Ok("Categoria adicionado com sucesso");
            }
            catch (System.Exception)
            {
            return BadRequest("Erro ao tentar adicionar uma categoria");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryDTO model)
        {
            try
            {
                await _categoryService.Update(model);
                return Ok("Categoria atualizada com sucesso");
            }
            catch (System.Exception)
            {
            return BadRequest("Erro ao tentar atualizar categoria");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryService.Remove(id);
                return Ok("Categoria excluida com sucesso");
            }
            catch (System.Exception)
            {
            return BadRequest("Erro ao tentar excluir categoria");
            }
        }
    }
}