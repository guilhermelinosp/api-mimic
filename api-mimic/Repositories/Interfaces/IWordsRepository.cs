using api_mimic.Models;

namespace api_mimic.Repositories.Interfaces
{
    public interface IWordsRepository
    {
        List<Word> FindAll();

        List<Word> FindByDate(DateTime date);

        List<Word> FindByActive(bool active);

        Word Find(Guid id);

        Word ActiveOrInactive(Guid id);

        void Create(Word word);

        void Update(Word word);

        void Delete(Guid id);

       

    }
}