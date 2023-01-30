using api_mimic.Models;
using api_mimic.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace api_mimic.Controllers
{
    [ApiController]
    [Route("api/v1/words")]
    public class WordsController : ControllerBase
    {  
        private readonly WordsRepository _repository;

        public WordsController(WordsRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpGet]
        public ActionResult FindAll()
        {
            return repository.FindAll();
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
            if (context.name == word.name)
            {
                return BadRequest();
            }
            context.name = word.name;
            context.score = word.score;
            context.active = word.active;
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
