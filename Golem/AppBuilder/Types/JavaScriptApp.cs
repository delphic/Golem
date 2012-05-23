using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Golem
{
    public class JavaScriptApp
    {
        #region Declarations

        public string Name { get; set; }
        public string RootDirectory { get; set; }
        public string OutputDirectory { get; set; }
        public OrderInformation OrderInformation { get; set; }
        public bool IncludeLowerCase { get; set; } // Include Lowercase file names in generated return statements

        #endregion 
                
        #region Constructor 

        public JavaScriptApp(
            string name,
            string rootDirectory,
            string outputDirectory,
            bool includeLowerCase)
        {
            if (String.IsNullOrEmpty(name)) { throw new ArgumentNullException("name"); }
            if (String.IsNullOrEmpty(rootDirectory)) { throw new ArgumentNullException("rootDirectory"); }
            if (String.IsNullOrEmpty(outputDirectory)) { throw new ArgumentNullException("outputDirectory"); }
            this.Name = name;
            this.RootDirectory = rootDirectory;
            this.OutputDirectory = outputDirectory;
            this.IncludeLowerCase = includeLowerCase;
            this.OrderInformation = BuildInitialOrderInformation();
        }
        public JavaScriptApp() { }

        #endregion
        
        #region Private Methods

        private OrderInformation BuildInitialOrderInformation()
        {
            var orderInfo = new OrderInformation();

            BuildOrderInformationForDirectory(this.RootDirectory, orderInfo);

            return orderInfo;
        }

        private void BuildOrderInformationForDirectory(string path, OrderInformation orderInfo)
        {
            var subDirectorys = Directory.EnumerateDirectories(path);
            var filePaths = Directory.EnumerateFiles(path);
            var contents = new List<OrderItem>();

            foreach (var directory in subDirectorys)
            {
                BuildOrderInformationForDirectory(directory, orderInfo);
                contents.Add(new OrderItem(directory, OrderItemType.Directory));
            }
            foreach (var filePath in filePaths)
            {
                if (Path.GetExtension(filePath) == ".js")
                {
                    contents.Add(new OrderItem(filePath, OrderItemType.File));
                }
            }
            orderInfo.Add(path, contents);
        }

        #endregion
    }
}
