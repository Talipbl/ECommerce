using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Domain
{
    public class AggregateRoot<TId> : IEntity
    {
        public TId Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public AggregateRoot()
        {
            Id = default;
        }

        public AggregateRoot(TId id)
        {
            Id = id;
        }
    }
}
