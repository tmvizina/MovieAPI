using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace MovieAPI.Models
{
    public class MovieDAL
    {
        public string CallAPI(string searchType, string title)
        {
            
            string key = "2133fdb8";
            string url = @$"http://www.omdbapi.com/?{searchType}={title}&apikey={key}";
            //This allows us to do either kind of search by choosing via the front end of the program.

            HttpWebRequest request = WebRequest.CreateHttp(url);
            //300 generally mean the server has moved or there has been a redirect
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string json = rd.ReadToEnd();
            rd.Close();
            return json;

        }
    
    public Movie GetMovie(string title)
        {
            string json =CallAPI("t", title);
            Movie m =JsonConvert.DeserializeObject<Movie>(json);
            return m;
        }


        public Movie GetMovieList(string title)
        {
            string json = CallAPI("t", title);
            Movie m = JsonConvert.DeserializeObject<Movie>(json);
            return m;
        }

    }
}
