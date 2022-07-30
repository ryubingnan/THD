using System;

namespace THD.DataAccess.Repositories.Abstract
{
    public class OrderCondition
    {
        public string Field { get; }

        public bool IsAsc { get; }

        public OrderCondition(string field, bool isAsc = true)
        {
            Field = field ?? throw new ArgumentNullException(nameof(field));
            IsAsc = isAsc;
        }
    }
}
