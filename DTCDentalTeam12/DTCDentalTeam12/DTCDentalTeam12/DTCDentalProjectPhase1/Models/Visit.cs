/*  AUTHOR: Team 12 (Jackson Wiese & Blake Dolenski)
 *  COURSE: ISTM 415.501
 *  FORM:   Visit.cs
 *  PURPOSE: Represents the details of a dental visit.
 *  INPUT:  Data from dentist and patient.
 *  PROCESS: Navigation properties
 *  OUTPUT: Visit objects
 *  HONOR CODE: "On my honor, as an Aggie, I have neither
 *  given nor received unauthorized aid on this academic work."
 */

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DTCDentalProjectPhase1.Models
{
    public class Visit
    {
        public int VisitID { get; set; }

        [Required(ErrorMessage = "Dentist ID is required.")]
        public int DentistID { get; set; }

        [ValidateNever]
        public Dentist Dentist { get; set; } = null!;


        [Required(ErrorMessage = "Patient ID is required.")]
        public int PatientID { get; set; }

        [ValidateNever]
        public Patient Patient { get; set; } = null!;

        [Required(ErrorMessage = "Visit date is required.")]
        public DateTime? VisitDate { get; set; } 
    }
}
