using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Teste_Dev_FullStack.Domain.Enums;

namespace Teste_Dev_FullStack.Domain.Entities
{
    public class Transection
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public ETransectionType TransectionType { get; set; }
        [Required]
        public Guid PersonId { get; set; }
        [Required]
        public Guid CategoryId { get; set; }

        public Transection(decimal amount, string description, ETransectionType transectionType, Guid personId, Guid categoryId)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            Description = description;
            TransectionType = transectionType;
            PersonId = personId;
            CategoryId = categoryId;
        }
    }
}
