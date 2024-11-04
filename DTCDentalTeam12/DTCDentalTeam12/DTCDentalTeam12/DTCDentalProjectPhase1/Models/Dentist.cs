/*  AUTHOR: Team 12 (Jackson Wiese & Blake Dolenski)
 *  COURSE: ISTM 415.501
 *  FORM:   Dentist.cs
 *  PURPOSE: Represents the details of a dentist.
 *  INPUT:  Dentist information.
 *  PROCESS: Navigation properties
 *  OUTPUT: Dentist objects
 *  HONOR CODE: "On my honor, as an Aggie, I have neither
 *  given nor received unauthorized aid on this academic work."
 */

using System.ComponentModel.DataAnnotations;

namespace DTCDentalProjectPhase1.Models
{
    public class Dentist
    {
        public int DentistID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string DentistFirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        public string DentistLastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required.")]
        public DateTime? HireDate { get; set; }

    }
}
