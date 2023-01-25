using api_mimic.Models;
using api_mimic.Repositories.Interfaces;

namespace api_mimic.Repositories
{
    public class WordsRepository : IWordsRepository
    {

        Word IWordsRepository.Find(Guid id)
        {
            throw new NotImplementedException();
        }

        List<Word> IWordsRepository.FindAll()
        {
            throw new NotImplementedException();
        }

        List<Word> IWordsRepository.FindByActive(bool active)
        {
            throw new NotImplementedException();
        }

        List<Word> IWordsRepository.FindByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        Word IWordsRepository.ActiveOrInactive(Guid id)
        {
            throw new NotImplementedException();
        }

        void IWordsRepository.Update(Word word)
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