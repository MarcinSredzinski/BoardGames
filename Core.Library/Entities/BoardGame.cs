using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Library.Entities
{
    public class BoardGame : BaseEntity, IValidatableObject
    {
        [Required]
        public string Name { get; set; }
        [Range(0, int.MaxValue)]
        public int MinNumberOfPlayers { get; set; }
        [Range(0, int.MaxValue)]
        public int MaxNumberOfPlayers { get; set; }
        [Range(0, 99)]
        public int MinimalAge { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (MaxNumberOfPlayers < MinNumberOfPlayers)
                results.Add(new ValidationResult("Maximal number of players must be bigger than minimal number of players!"));

            return results;
        }
    }
}
