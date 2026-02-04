using System.ComponentModel.DataAnnotations;

namespace Teste_Dev_FullStack.Domain.Entities
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public Transection Transection { get; set; }

        public Person(string name, int age)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
        }

        public Person(string name, int age, Transection transection)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            Transection = transection;
        }
    }
}
