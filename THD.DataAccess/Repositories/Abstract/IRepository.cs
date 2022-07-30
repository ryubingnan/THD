using THD.DataAccess.Models.Abstract;

namespace THD.DataAccess.Repositories.Abstract
{
    public interface IRepository
    {
    }

    public interface IRepository<T> : IBasicRepository<T>, IReadonlyRepository<T>
        where T : IEntity
    {
    }
}
