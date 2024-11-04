/*  AUTHOR: Team 12 (Jackson Wiese & Blake Dolenski)
 *  COURSE: ISTM 415.501
 *  FORM:   Appointment.cs
 *  PURPOSE: Represents the details of a dental appointment.
 *  INPUT:  Data from dentist and patient.
 *  PROCESS: Navigation properties
 *  OUTPUT: Appointment objects
 *  HONOR CODE: "On my honor, as an Aggie, I have neither
 *  given nor received unauthorized aid on this academic work."
 */

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTCDentalProjectPhase1.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }

        [Required(ErrorMessage = "Dentist ID is required.")]
        public int DentistID { get; set; }                    // foreign key property
        [ValidateNever]
        public Dentist Dentist { get; set; } = null!;         // navigation property

        [Required(ErrorMessage = "Patient ID is required.")]
        public int PatientID { get; set; }                    // foreign key property

        [ValidateNever]

        public Patient Patient { get; set; } = null!;         // navigation property

        [Required(ErrorMessage = "Appointment Type ID is required.")]
        public int TypeID { get; set; }                       // foreign key property


        [ValidateNever]
        public AppointmentType AppointmentType { get; set; } = null!; // foreign key property

        [Required(ErrorMessage = "Appointment Date is required.")]
        public DateTime? AppointmentDate { get; set; } 

        [Required(ErrorMessage = "Appointment start time is required.")]
        public DateTime? StartTime { get; set; } 
    }
}
