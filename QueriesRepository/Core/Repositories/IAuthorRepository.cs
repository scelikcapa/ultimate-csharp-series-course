using QueriesRepository.Core.Domain;

namespace QueriesRepository.Core.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author GetAuthorWithCourses(int id);
    }
}