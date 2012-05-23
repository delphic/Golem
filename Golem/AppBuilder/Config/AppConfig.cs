using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Golem.AppBuilder.Config
{
    [XmlRoot("App")]
    public class AppConfig
    {
        #region Properties

        public string Name { get; set; }
        public string RootDirectory { get; set; }
        public string OutputDirectory { get; set; }
        public List<OrderInformationItem> OrderInformationItems { get; set; }
        public bool IncludeLowercase { get; set; }

        #endregion

        #region Constructors

        public AppConfig() { }
        public AppConfig(
            string name, 
            string rootDirectory, 
            string outputDirectory, 
            OrderInformation orderInformation, 
            bool includeLowercase)
        {
            this.Name = name;
            this.RootDirectory = rootDirectory;
            this.OutputDirectory = outputDirectory;
            var orderInformationItems = new List<OrderInformationItem>();
            foreach (var key in orderInformation.Keys)
            {
                orderInformationItems.Add(new OrderInformationItem(key, orderInformation[key]));
            }
            this.OrderInformationItems = orderInformationItems;
            this.IncludeLowercase = includeLowercase;
        }

        #endregion 

        #region Helpers

        public OrderInformation GetOrderInformation()
        {
            var result = new OrderInformation();
            foreach (OrderInformationItem item in this.OrderInformationItems)
            {
                result.Add(item.Key, item.Items);
            }
            return result;
        }

        #endregion
    }
}
