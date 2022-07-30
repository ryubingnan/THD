namespace THD.DataAccess.Models.Abstract
{
    public abstract class EntityBase : IEntity<int>
    {
        public virtual int Id { get; set; }
    }
}
