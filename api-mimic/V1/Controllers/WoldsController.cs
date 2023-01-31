using api_mimic.Database;
using api_mimic.V1.Models;

using Microsoft.AspNetCore.Mvc;

namespace api_mimic.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/words")]
    public class WordsController : ControllerBase
    {
        private readonly MimicContext _context;

        public WordsController(MimicContext context)
        {
            _context = context;
        }

        [Route("")]
        [HttpGet]
        public ActionResult FindAll()
        {
            var context = _context.Words;
            if (context == null)
            {
                return NotFound();
            }
            return new JsonResult(context);
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult FindById(Guid id)
        {
            var context = _context.Words.FirstOrDefault(x => x.id == id);
            if (context == null)
            {
                return NotFound();
            }
            return new JsonResult(context);
        }


        [Route("date")]
        [HttpGet]
        public ActionResult FindByDate(DateTime? date)
        {
            var context = _context.Words.AsQueryable();
            if (date.HasValue)
            {
                context = context.Where(x => x.created >= date.Value || x.updated >= date.Value);
            }
            return new JsonResult(context);
        }

        [Route("active")]
        [HttpGet]
        public ActionResult FindByActive(bool active)
        {
            var context = _context.Words.AsQueryable();
            if (active)
            {
                context = context.Where(x => x.active);
            }
            else
            {
                context = context.Where(x => !x.active);
            }
            return new JsonResult(context);
        }

        [Route("")]
        [HttpPost]
        public ActionResult Create([FromBody]Word word)
        {
            var context = _context.Words.FirstOrDefault(x => x.name == word.name);
            if (context != null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            word.id = Guid.NewGuid();
            word.active = true;
            word.created = DateTime.Now;
            word.updated = DateTime.Now;
            _context.Words.Add(word);
            _context.SaveChanges();
            return Ok();
        }


        [Route("{id}")]
        [HttpPut]
        public ActionResult Update(Guid id,[FromBody] Word word)
        {
            var context = _context.Words.FirstOrDefault(x => x.id == id);
            if (context == null)
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            if (context.name == word.name)
            {
                return BadRequest();
            }
            context.name = word.name;
            context.score = word.score;
            context.updated = DateTime.Now;
            _context.SaveChanges();
            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            var context = _context.Words.FirstOrDefault(x => x.id == id);
            if (context == null)
            {
                return NotFound();
            }
            _context.Words.Remove(context);
            _context.SaveChanges();
            return NoContent();
        }

        [Route("{id}")]
        [HttpPatch]
        public ActionResult ActiveOrInactive(Guid id)
        {
            var context = _context.Words.FirstOrDefault(x => x.id == id);
            if (context == null)
            {
                return NotFound();
            }

            if(context.active == true)
            {
                context.active = false;
            }
            else
            {
                context.active = true;
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
