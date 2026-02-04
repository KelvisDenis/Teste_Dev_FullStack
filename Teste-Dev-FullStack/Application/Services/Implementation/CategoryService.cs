using Teste_Dev_FullStack.Application.DTOs;
using Teste_Dev_FullStack.Application.Services.Interfaces;
using Teste_Dev_FullStack.Domain.Entities;
using Teste_Dev_FullStack.Domain.Erros;
using Teste_Dev_FullStack.Domain.Interfaces.Repositories;
using Teste_Dev_FullStack.Domain.ResultPattern;
using Teste_Dev_FullStack.Infraestructure.UnityOfWork;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Teste_Dev_FullStack.Application.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository,IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CategoryDto>> CreateAsync(CreateCategoryDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Description))
                return Result<CategoryDto>.Failure(
                    GeneralExcept.Validation("Descrição da categoria é obrigatória")
                );

            var category = new Category(dto.Description, dto.Purpose);

            await _categoryRepository.AddAsync(category);
            await _unitOfWork.CommitAsync();

            return Result<CategoryDto>.Success(new CategoryDto
            (
                category.Id,
                category.Description,
                category.PurposeCategory
            ));
        }

        public async Task<Result<IEnumerable<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            var result = categories.Select(c => new CategoryDto
            (
                c.Id,
                c.Description,
                c.PurposeCategory
            ));

            return Result<IEnumerable<CategoryDto>>.Success(result);
        }
    }

}
