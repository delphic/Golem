using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Golem.AppBuilder.Config
{
    public class OrderInformationItem
    {
        public string Key { get; set; }
        public List<OrderItem> Items { get; set; }

        #region Constructors

        public OrderInformationItem() { }
        public OrderInformationItem(string key, List<OrderItem> items)
        {
            this.Key = key;
            this.Items = items;
        }

        #endregion
    }
}
