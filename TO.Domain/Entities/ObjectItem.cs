using System.Collections.Generic;

namespace TO.Domain.Entities
{
    public sealed class ObjectItem
    {
        public ObjectItem()
        {
            Attributes = new HashSet<AttributeValue>();
        }

        public int ObjectItemId { get; set; }

        public string ObjectItemName { get; set; }

        public int InterfaceId { get; set; }

        public ICollection<AttributeValue> Attributes { get; private set; }

        public Interface Interface { get; set; }
    }
}
