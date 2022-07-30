namespace THD.DataAccess.Models.Abstract
{
    public interface IEntity
    {
    }

    public interface IEntity<T> : IEntity where T : struct
    {
        int Id { get; set; }
    }
}
