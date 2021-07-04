using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;


namespace MovieAPI.Controllers
{
    public class HomeController : Controller
    {
        MovieDAL movieDAL = new MovieDAL();

        public IActionResult Index()
        {


            return View();
        }


        public IActionResult MovieSearch()
        {
            return View();
        }

       [ HttpPost ]
        public IActionResult MovieSearch(string title)
        {
            
            
           // string json =movieDAL.CallAPI(searchtype, title);

            Movie m = movieDAL.GetMovie(title);

            

            return View(m);
        }


        public IActionResult MovieNight()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieNight(string title1, string title2, string title3)
        {

            List<Movie> movienight = new List<Movie>();
            // string json =movieDAL.CallAPI(searchtype, title);

            Movie movie1 = movieDAL.GetMovieList(title1);
            Movie movie2 = movieDAL.GetMovieList(title2);
            Movie movie3 = movieDAL.GetMovieList(title3);

            movienight.Add(movie1);
            movienight.Add(movie2);
            movienight.Add(movie3);

            return View(movienight);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
