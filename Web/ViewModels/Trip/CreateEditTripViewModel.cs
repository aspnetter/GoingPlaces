using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Trip
{
    public class CreateEditTripViewModel : IValidatableObject
    {
        [Display(Name = "Going to")]
        [DataType(DataType.Text)]
        [MaxLength(64)]
        [Required(ErrorMessage = "Destination is required")]
        public string ToCountryCity { get; set; }

        [Display(Name = "Start from")]
        [DataType(DataType.Text)]
        [MaxLength(64)]
        [Required(ErrorMessage = "Starting location is required")]
        public string FromCountryCity { get; set; }

        [Display(Name = "Leave on")]
        [DataType(DataType.Date)]        
        [Required(ErrorMessage = "Leave on date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Return on")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Return on date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Notes")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //if (StartDate < DateTime.Now)
            //{
            //    yield return new ValidationResult("Trip start date cannot be in the past");
            //}
            if (EndDate < StartDate)
            {
                yield return new ValidationResult("Return date cannot be earlier than start date");
            }
        }
    }
}
