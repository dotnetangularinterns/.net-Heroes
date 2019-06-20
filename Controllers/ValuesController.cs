using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myservice.models;

namespace myservice.Controllers
{
    [Route("api/heros")]
    [ApiController]
    public class ValuesController : Controller
    {
        // GET api/values
/*        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2","value3", "values4" };
        }
*/
        // GET api/values
        [HttpGet]

        public ActionResult<IEnumerable<Hero>> Heros()
        {
            return HeroList.getInstance().listHero();
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody] Hero value)
        {
            int id = HeroList.getInstance().genId();
            value.Id = id;
            HeroList.getInstance().addHero(value);
            Console.WriteLine("Added " + value.Name);
            return Json(value);
        }


        // PUT api/values/5
        [HttpPut]
        public JsonResult Put(Hero hero)
        {
            HeroList.getInstance().updateHero(hero);

            return Json(hero);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            HeroList.getInstance().removeHero(id);

            return Json(id);
        }
    }
}
