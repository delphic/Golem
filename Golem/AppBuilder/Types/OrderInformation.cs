using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Golem
{
    public enum OrderItemType { File, Directory, }

    public class OrderItem
    {
        public OrderItem(string path, OrderItemType type)
        {
            this.Path = path;
            this.Type = type;
        }
        public OrderItem() { }
        public string Path { get; set; }
        public OrderItemType Type { get; set; }
    }

    public class OrderInformation : Dictionary<string, List<OrderItem>>
    {
        public IDictionary<string, OrderItemType> GetOrderedItems(string path)
        {
            var result = new Dictionary<string, OrderItemType>();

            foreach (var item in this[path])
            {
                result.Add(item.Path, item.Type);
            }

            return result;
        }
    }
}
