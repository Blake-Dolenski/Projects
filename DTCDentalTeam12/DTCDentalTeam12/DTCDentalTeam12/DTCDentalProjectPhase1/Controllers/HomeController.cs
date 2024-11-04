/*  AUTHOR: Team 12 (Jackson Wiese & Blake Dolenski)
 *  COURSE: ISTM 415.501
 *  FORM:   HomeController.cs
 *  PURPOSE: Handle data between the view and the model.
 *  INPUT:  Handles data coming off the view and passing it to the model.
 *  PROCESS: HttpGet and HttpPost
 *  OUTPUT: None
 *  HONOR CODE: "On my honor, as an Aggie, I have neither
 *  given nor received unauthorized aid on this academic work."
 */

using DTCDentalProjectPhase1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DTCDentalProjectPhase1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// New instance of the HomeController class.
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Displays the main page of the application.
        /// </summary>
        /// <returns> Index.cshtml </returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Displays the about page of the application
        /// </summary>
        /// <returns> About.cshtml </returns>
        public IActionResult About()
        {
            return View();
        }

        /// <summary>
        /// Displays the privacy page of the application
        /// </summary>
        /// <returns> Privacy.cshtml</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Allows the user to see error message when error occurs.
        /// </summary>
        /// <returns> Error </returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}