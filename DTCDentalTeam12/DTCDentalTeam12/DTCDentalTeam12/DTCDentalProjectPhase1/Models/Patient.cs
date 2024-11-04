/*  AUTHOR: Team 12 (Jackson Wiese & Blake Dolenski)
 *  COURSE: ISTM 415.501
 *  FORM:   Patient.cs
 *  PURPOSE: Represents the details of a patient.
 *  INPUT:  Data from patient.
 *  PROCESS: Navigation properties
 *  OUTPUT: Patient objects
 *  HONOR CODE: "On my honor, as an Aggie, I have neither
 *  given nor received unauthorized aid on this academic work."
 */

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DTCDentalProjectPhase1.Models
{
  
    public class Patient
    {
        public int PatientID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string PatientFirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        public string PatientLastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required.")]
        public string PatientStreetAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        public string PatientCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "State is required.")]
        public string PatientState { get; set; } = string.Empty;

        [Required(ErrorMessage = "Zip is required.")]
        public string PatientZip { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        public string PatientPhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        public string PatientEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Social Security Number is required.")]
        public string PatientSSN { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime? PatientDOB { get; set; }

        [Required(ErrorMessage = "Please identify if patient is 18 years or older.")]
        public bool PatientMinor { get; set; }

        
        public int? PatientHOHID { get; set; } 

        [ValidateNever]
        public Patient? PatientHOH { get; set; } = null!;


        public ICollection<Patient>? Dependents { get; set; } = new List<Patient>();


        public string PatientFullName => PatientLastName + ", " + PatientFirstName;   

        public string Slug => PatientFirstName + "-" + PatientLastName;  
    }

 
}
