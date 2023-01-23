using api_mimic.Database;
using api_mimic.Models;

using Microsoft.AspNetCore.Mvc;

namespace api_mimic.Controllers;

[ApiController]
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
        return new JsonResult(_context.Words);
    }

    [Route("{id}")]
    [HttpGet]
    public ActionResult FindById(int id)
    {
        var wordDB = _context.Words.FirstOrDefault(x => x.id == id);
        if (wordDB == null)
        {
            return NotFound();
        }
        return new JsonResult(wordDB);
    }

    

    [Route("")]
    [HttpPost]
    public ActionResult Create([FromBody]Word word)
    {
        var wordDB = _context.Words.FirstOrDefault(x => x.name == word.name);
        if (wordDB != null)
        {
            return BadRequest();
        }
        word.created = DateTime.Now;
        word.updated = DateTime.Now;
        _context.Words.Add(word);
        _context.SaveChanges();
        return new JsonResult(word);
    }

    [Route("{id}")]
    [HttpPut]
    public ActionResult Update(int id,[FromBody] Word word)
    {
        var wordDB = _context.Words.FirstOrDefault(x => x.id == id);
        if (wordDB == null)
        {
             return NotFound();
        }

        if (wordDB.name == word.name)
        {
            return BadRequest();
        }
        
        wordDB.name = word.name;
        wordDB.score = word.score;
        wordDB.active = word.active;
        wordDB.created = DateTime.Now;
        wordDB.updated = DateTime.Now;
        _context.SaveChanges();
        return new JsonResult(wordDB);
    }
    
    [Route("{id}")]
    [HttpDelete]
    public ActionResult Delete(int id)
    {
        var wordDB = _context.Words.FirstOrDefault(x => x.id == id);
        if (wordDB == null)
        {
             return NotFound();
        }
        _context.Words.Remove(wordDB);
        _context.SaveChanges();
        return Ok();
    }
}
