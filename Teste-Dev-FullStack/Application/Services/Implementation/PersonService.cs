using System;
using Teste_Dev_FullStack.Application.DTOs;
using Teste_Dev_FullStack.Application.Services.Interfaces;
using Teste_Dev_FullStack.Domain.Entities;
using Teste_Dev_FullStack.Domain.Enums;
using Teste_Dev_FullStack.Domain.Erros;
using Teste_Dev_FullStack.Domain.Interfaces.Repositories;
using Teste_Dev_FullStack.Domain.ResultPattern;
using Teste_Dev_FullStack.Infraestructure.UnityOfWork;

namespace Teste_Dev_FullStack.Application.Services.Implementation
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ITransectionRepository _transectionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IPersonRepository personRepository, ITransectionRepository transacaoRepository,IUnitOfWork unitOfWork)
        {
            _personRepository = personRepository;
            _transectionRepository = transacaoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PersonDto>> CreateAsync(CreatePersonDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return Result<PersonDto>.Failure(
                    GeneralExcept.Validation("Nome é obrigatório")
                );

            if (dto.Age < 0)
                return Result<PersonDto>.Failure(
                    GeneralExcept.Validation("Idade inválida")
                );

            var person = new Person(dto.Name, dto.Age);

            await _personRepository.AddAsync(person);
            await _unitOfWork.CommitAsync();

            return Result<PersonDto>.Success(new PersonDto
            (
                Id: person.Id,
                Name: person.Name,
                Age: person.Age
            ));
        }

        public async Task<Result<IEnumerable<PersonDto>>> GetAllAsync()
        {
            var persons =  await _personRepository.GetAllAsync();

            var result = persons.Select(p => new PersonDto
            (
                Id: p.Id,
                Name: p.Name,
                Age: p.Age
            ));

            return Result<IEnumerable<PersonDto>>.Success(result);
        }

        public async Task<Result<IEnumerable<PersonTotalsDto>>> GetPersonsTotalsAsync()
        {
            var person = await  _personRepository.GetTotalsGroupedByPersonAsync();

            if (person == null || !person.Any())
                return Result<IEnumerable<PersonTotalsDto>>.Failure(
                    GeneralExcept.NotFound("Nenhuma pessoa encontrada")
                );

            var transactions = await _transectionRepository.GetAllAsync();

            if (transactions == null)
                return Result<IEnumerable<PersonTotalsDto>>.Failure(
                    GeneralExcept.NotFound("Nenhuma transação encontrada")
                );

            var result =  person.Select(p => new PersonTotalsDto
            (
                PersonId: p.Id,
                Name: p.Name,
                TotalIncome: transactions
                    .Where(t => t.PersonId == p.Id && t.TransectionType == ETransectionType.Expense)
                    .Sum(t => t.Amount),
                TotalExpense: transactions
                    .Where(t => t.PersonId == p.Id && t.TransectionType == ETransectionType.Income)
                    .Sum(t => t.Amount),
                TotalBalance: transactions
                    .Where(t => t.PersonId == p.Id)
                    .Sum(t => t.TransectionType == ETransectionType.Income ? t.Amount : -t.Amount)
            ));

            return  Result<IEnumerable<PersonTotalsDto>>.Success(result);    

        }


        public async Task<Result<bool>> DeleteAsync(Guid id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
                return Result<bool>.Failure(
                    GeneralExcept.NotFound("Pessoa não encontrada")
                );

            if (await _transectionRepository.HasTransacoesAsync(id))
            {
                await _transectionRepository.DeleteByPersonIdAsync(id);
            }

            await _personRepository.DeleteAsync(person);
            await _unitOfWork.CommitAsync();

            return Result<bool>.Success(true);
        }
    }

}
