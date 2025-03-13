using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;

namespace RealEstate_Dapper_Api.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("ListCategory")]
        public async Task<IActionResult> CategoryList() {
            var values = await _categoryRepository.GetAllCategory();
            return Ok(values);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryDto createCategoryDto) {
            await _categoryRepository.CreateCategory(createCategoryDto);
            return Ok("Kategori başarılı bir şekilde eklendi");
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id) {
            await _categoryRepository.DeleteCategory(id);
            return Ok("Kategori başarıyla silindi");
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto) {
            await _categoryRepository.UpdateCategory(updateCategoryDto);
            return Ok("Kategori Başarıyla Güncellendi");
        }

        [HttpGet("GetCategoryById/{id}")]
        public async Task<IActionResult> GetCategoryById(int id) {
            return Ok(await _categoryRepository.GetCategoryById(id));
        }
    }
}
