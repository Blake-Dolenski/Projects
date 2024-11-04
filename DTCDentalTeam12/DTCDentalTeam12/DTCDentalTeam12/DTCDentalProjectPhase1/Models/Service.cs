/*  AUTHOR: Team 12 (Jackson Wiese & Blake Dolenski)
 *  COURSE: ISTM 415.501
 *  FORM:   Service.cs
 *  PURPOSE: Represents the details of services.
 *  INPUT:  Data from patient side.
 *  PROCESS: Navigation properties
 *  OUTPUT: Service objects
 *  HONOR CODE: "On my honor, as an Aggie, I have neither
 *  given nor received unauthorized aid on this academic work."
 */

using System.ComponentModel.DataAnnotations;

namespace DTCDentalProjectPhase1.Models
{
    public class Service
    {

        public int ServiceID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string ServiceDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        public decimal? ServiceCost { get; set; }
    }
}
