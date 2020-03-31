using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        // public string Index() 
        // { 
        //     return "Hello mn";
        // }
        public IActionResult Index() 
        { 
            var movies = new List<Movie>() {
                new Movie() {
                    Title = "Thor"
                },
                new Movie() {
                    Title = "Iron Man"
                },
                new Movie() {
                    Title = "Avenger"
                },
            };
            
            return View(movies);
        }
    }
}