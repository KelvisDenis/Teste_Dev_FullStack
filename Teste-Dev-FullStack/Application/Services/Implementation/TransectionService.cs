using Teste_Dev_FullStack.Application.DTOs;
using Teste_Dev_FullStack.Application.Services.Interfaces;
using Teste_Dev_FullStack.Domain.Entities;
using Teste_Dev_FullStack.Domain.Enums;
using Teste_Dev_FullStack.Domain.Erros;
using Teste_Dev_FullStack.Domain.Interfaces.Repositories;
using Teste_Dev_FullStack.Domain.ResultPattern;
using Teste_Dev_FullStack.Infraestructure.UnityOfWork;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class TransectionService : ITransectionService
{
    private readonly IPersonRepository _personRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ITransectionRepository _transectionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TransectionService(
        IPersonRepository personRepository,
        ICategoryRepository categoryRepository,
        ITransectionRepository transectionRepository,
        IUnitOfWork unitOfWork)
    {
        _personRepository = personRepository;
        _categoryRepository = categoryRepository;
        _transectionRepository = transectionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<TransectionDto>> CreateAsync(CreateTransectionDto dto)
    {
        if (dto.Value <= 0)
            return Result<TransectionDto>.Failure(
                GeneralExcept.Validation("Valor deve ser maior que zero")
            );

        var person = await _personRepository.GetByIdAsync(dto.PersonId);
        if (person == null)
            return Result<TransectionDto>.Failure(
                GeneralExcept.NotFound("Pessoa não encontrada")
            );

        if (person.Age < 18 && dto.Type == ETransectionType.Income)
            return Result<TransectionDto>.Failure(
                GeneralExcept.Validation("Menores de idade só podem registrar despesas")
            );

        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
        if (category == null)
            return Result<TransectionDto>.Failure(
                GeneralExcept.NotFound("Categoria não encontrada")
            );

        if (category.PurposeCategory != EPurposeCategory.Both &&
            category.PurposeCategory != (EPurposeCategory)dto.Type)
            return Result<TransectionDto>.Failure(
                GeneralExcept.Validation("Categoria incompatível com o tipo da transação")
            );

        if (dto.Type == ETransectionType.Expense &&
            category.Equals(EPurposeCategory.Income)
            )
            return Result<TransectionDto>.Failure(
                GeneralExcept.Validation("Categoria incompatível com o tipo da transação"));


        var transection = new Transection(
            dto.Value,
            dto.Description,
            dto.Type,
            dto.PersonId,
            dto.CategoryId
        );

        await _transectionRepository.AddAsync(transection);
        await _unitOfWork.CommitAsync();

        return Result<TransectionDto>.Success(new TransectionDto
        (
            Id : transection.Id,
            Description: transection.Description,
            Value : transection.Amount,
            Type: transection.TransectionType,
            PersonId: person.Id,
            CategoryId : transection.CategoryId
        ));
    }

    public async Task<Result<IEnumerable<TransectionDto>>> GetAllAsync()
    {
        var transections = await _transectionRepository.GetAllAsync();

        var result = transections.Select(t => new TransectionDto
        (
            Id : t.Id,
            Description: t.Description,
            Value: t.Amount,
            Type: t.TransectionType,
            CategoryId: t.CategoryId,
            PersonId: t.PersonId
        ));

        return Result<IEnumerable<TransectionDto>>.Success(result);
    }
}
