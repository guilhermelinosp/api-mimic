using api_mimic.Models;

namespace api_mimic.Repositories.Interfaces
{
    public interface IWordsRepository
    {
        public List<Word> FindAll();
        public List<Word> FindByDate(DateTime date);
        public List<Word> FindByActive(bool active);
        public Word Find(Guid id);
        public void ActiveOrInactive(Guid id);
        public void Create(Word word);
        public void Update(Guid id ,Word word);
        public void Delete(Guid id);
    }
}