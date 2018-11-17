using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TO.Domain.Entities;

namespace TO.Queries.Object.Get
{
    public class ObjectItemViewModel
    {
        public int ObjectItemId { get; set; }

        public string ObjectItemName { get; set; }

        public int InterfaceId { get; set; }

        public bool EditEnabled { get; set; }

        public ICollection<AttributeValue> Attributes { get; private set; }

        public static Expression<Func<ObjectItem, ObjectItemViewModel>> Projection
        {
            get
            {
                return p => new ObjectItemViewModel
                {
                    Attributes = p.Attributes,
                    InterfaceId = p.InterfaceId,
                    ObjectItemName = p.ObjectItemName
                };
            }
        }

        public static ObjectItemViewModel Create(ObjectItem product)
        {
            return Projection.Compile().Invoke(product);
        }
    }
}
