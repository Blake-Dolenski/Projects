/*  AUTHOR: Team 12 (Jackson Wiese & Blake Dolenski)
 *  COURSE: ISTM 415.501
 *  FORM:   AppointmentType.cs
 *  PURPOSE: Represents the details of an appointment type.
 *  INPUT:  Types of appointments listed in specification.
 *  PROCESS: Navigation properties
 *  OUTPUT: Appointment type objects
 *  HONOR CODE: "On my honor, as an Aggie, I have neither
 *  given nor received unauthorized aid on this academic work."
 */

using System.ComponentModel.DataAnnotations;

namespace DTCDentalProjectPhase1.Models
{
    public class AppointmentType
    {
        public int TypeID { get; set; }

        [Required(ErrorMessage = "Appointment name is required.")]
        public string AppointmentName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Appointment duration is required.")]
        public int? Duration { get; set; }
    }
}
