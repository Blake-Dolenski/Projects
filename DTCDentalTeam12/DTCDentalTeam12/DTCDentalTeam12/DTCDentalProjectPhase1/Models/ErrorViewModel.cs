/*  AUTHOR: Team 12 (Jackson Wiese & Blake Dolenski)
 *  COURSE: ISTM 415.501
 *  FORM:   ErrorViewModel.cs
 *  PURPOSE: Defines an empty field box.
 *  INPUT:  None
 *  PROCESS: None
 *  OUTPUT: None
 *  HONOR CODE: "On my honor, as an Aggie, I have neither
 *  given nor received unauthorized aid on this academic work."
 */

namespace DTCDentalProjectPhase1.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}