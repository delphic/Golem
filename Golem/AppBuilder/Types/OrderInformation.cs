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
        public IEnumerable<string> GetOrderedSubDirectories(string path)
        {
            var result = new List<string>();

            foreach (var item in this[path])
            {
                if (item.Type.Equals(OrderItemType.Directory)) result.Add(item.Path);
            }

            return result;
        }

        public IEnumerable<string> GetOrderedFiles(string path)
        {
            var result = new List<string>();

            foreach (var item in this[path])
            {
                if (item.Type.Equals(OrderItemType.File)) result.Add(item.Path);
            }

            return result;
        }
    }
}
