using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Widget
    {
        public Widget()
        {
            Id = Guid.NewGuid();
            DateTimeCreated = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Must be at least 5 charachters", MinimumLength = 5)]
        [RegularExpression(@"^[A-Za-z0-9_]+$", ErrorMessage = "Name must contain only letters a-z, numbers and underscore _")]
        public string Name { get; set; }

        [Range(1, 1000000, ErrorMessage = "Price must be between 1 and 1000000")]
        public float Price { get; set; }

        [Required]
        public DateTime DateTimeCreated { get; set; }
    }
}
