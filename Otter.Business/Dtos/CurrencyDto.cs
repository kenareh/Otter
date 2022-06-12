using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Otter.Business.Dtos
{
    public class CurrencyDto : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [StringLength(5)]
        public string Title { get; set; }

        [Required]
        [StringLength(5)]
        public string TitleRRRR { get; set; }

        public string LatinName { get; set; }

        [Required]
        [Range(50, 500)]
        public int Age { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Title.Length < 3)
            {
                yield return new ValidationResult("نام کاربری نمیتواند Test باشد", new[] { nameof(LatinName) });
                yield return new ValidationResult("نام sdfsfsfsfsf نمیتواند Test باشد", new[] { nameof(LatinName) });
            }
        }
    }
}