using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ColorAPI;

namespace ColorAPI.Controllers
{
    [Route("api/[controller]")]
    public class ColorsController : Controller
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        // GET api/colors
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_colorService.GetAll());
        }

        // GET api/colors/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ColorItem item = _colorService.GetById(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] ColorItem item)
        {
            if (item == null || item.Id == 0 || item.Name==null)
                return BadRequest();

            _colorService.AddItem(item);

            return Ok();
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string strName)
        {
            if (strName == null || id == 0)
                return BadRequest();

            _colorService.AddItem(new ColorItem { Id = id, Name = strName });

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            if (_colorService.DeleteById(id))
                return Ok();
            else
                return NotFound();
        }
    }
}
