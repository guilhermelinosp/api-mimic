using api_mimic.Database;
using api_mimic.Models;
using api_mimic.Repositories.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace api_mimic.Repositories
{
    public class WordsRepository : IWordsRepository
    {
        private readonly MimicContext _context;
        public WordsRepository(MimicContext context)
        {
            _context = context;
        }

        Word IWordsRepository.Find(Guid id)
        {
            var context = _context.Words.FirstOrDefault(x => x.id == id);
            if (context == null)
            {
                return NotFound();
            }

            return context;
        }

        List<Word> IWordsRepository.FindAll()
        {
            if (_context.Words == null)
            {
                return NotFound();
            }

            return new JsonResult(_context.Words);
        }

        List<Word> IWordsRepository.FindByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        List<Word> IWordsRepository.FindByActive(bool active)
        {
            throw new NotImplementedException();
        }


        void IWordsRepository.ActiveOrInactive(Guid id)
        {
            throw new NotImplementedException();
        }

        void IWordsRepository.Update(Guid id,Word word)
        {
            throw new NotImplementedException();
        }

        void IWordsRepository.Create(Word word)
        {
            throw new NotImplementedException();
        }

        void IWordsRepository.Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}