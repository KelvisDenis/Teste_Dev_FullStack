using System.ComponentModel.DataAnnotations;
using Teste_Dev_FullStack.Domain.Enums;

namespace Teste_Dev_FullStack.Domain.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public EPurposeCategory PurposeCategory { get; set; }

        public Category(string description, EPurposeCategory purposeCategory)
        {
            Id = Guid.NewGuid();
            Description = description;
            PurposeCategory = purposeCategory;
        }
    }
}
