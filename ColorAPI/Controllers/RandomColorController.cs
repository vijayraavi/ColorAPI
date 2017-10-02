using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ColorAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/RandomColor")]
    public class RandomColorController : Controller
    {
        IColorService _colorService;

        public RandomColorController (IColorService colorService)
        {
            _colorService = colorService;
        }


        // GET: api/RandomColor
        [HttpGet]
        public IActionResult Get()
        {
 //         string[] strColors = { "blue", "lightblue", "darkblue" };
           string[] strColors = { "green", "lightgreen", "darkgreen" };

            Random r = new Random();
            int rInt = r.Next(strColors.Length);

            return Ok(strColors[rInt]); 
        }  

    }
}
