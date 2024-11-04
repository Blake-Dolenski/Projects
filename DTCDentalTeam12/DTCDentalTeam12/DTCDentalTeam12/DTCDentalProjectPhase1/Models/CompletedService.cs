/*  AUTHOR: Team 12 (Jackson Wiese & Blake Dolenski)
 *  COURSE: ISTM 415.501
 *  FORM:   CompletedService.cs
 *  PURPOSE: Represents the details of a all the past services completed.
 *  INPUT:  On dentist end.
 *  PROCESS: Navigation properties
 *  OUTPUT: Completed service objects
 *  HONOR CODE: "On my honor, as an Aggie, I have neither
 *  given nor received unauthorized aid on this academic work."
 */

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTCDentalProjectPhase1.Models
{
    public class CompletedService
    {

        [Key]  // This is a primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-generated value
        public int CompletedServiceID { get; set; }


        // Service
        [Required(ErrorMessage = "Visit ID is required")]
        public int ServiceID { get; set; }

        [ValidateNever]
        public Service Service { get; set; } = null!;


        //Visit
        [Required(ErrorMessage = "Date completed is required.")]
        public int VisitID { get; set; }

        [ValidateNever]
        public Visit Visit { get; set; } = null!;

        //Completed Date
        public DateTime? CompletedDate { get; set; }

    }
}
