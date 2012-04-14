﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace Golem
{
    public class JavaScriptAppBuilderManager
    {
        private Dictionary<string, JavaScriptApp> _javaScriptApps = new Dictionary<string,JavaScriptApp>();

        public void AddApp(JavaScriptApp app)
        {
            _javaScriptApps.Add(app.Name, app);
        }

        public JavaScriptApp GetApp(string appName)
        {
            return _javaScriptApps[appName];
        }

        public void OverwriteApp(string appName, JavaScriptApp app)
        {
            _javaScriptApps[appName] = app;
        }

        public void RemoveApp(string appName)
        {
            _javaScriptApps.Remove(appName);
        }

        public void BuildApp(string appName)
        {
            var app = _javaScriptApps[appName];

            var fileContents = new StringBuilder();

            CreateModuleForDirectory(app.RootDirectory, fileContents, app, app.IncludeLowerCase, appName);
            
            using (var fileStream = new StreamWriter(app.OutputDirectory + @"\" + appName + ".js"))
            {
                fileStream.Write(fileContents.ToString());
            }
        }

        #region Private Building Functions

        // Dev Sug - Add \t to start of lines depending on 'depth'
        private void CreateModuleForDirectory(string path, StringBuilder output, JavaScriptApp app, bool includeLowerCase, string overrideName)
        {
            var subDirectorys = app.OrderInformation.GetOrderedSubDirectories(path);
            var filePaths = app.OrderInformation.GetOrderedFiles(path);
            var additionalReturnStatements = new List<string>();
          
            var nameSpace = overrideName ?? Path.GetFileName(path);
            output.AppendLine("var " + nameSpace + " = function(){");
            foreach (var subDirectory in subDirectorys)
            {
                 this.CreateModuleForDirectory(subDirectory, output, app, includeLowerCase, null);
            }

            foreach (var filePath in filePaths)
            {
                using (var fileStream = new StreamReader(filePath))
                {
                    readFile(fileStream, output, additionalReturnStatements);
                }
            }
           
            output.AppendLine(CreateReturnStatement(subDirectorys, filePaths, additionalReturnStatements, includeLowerCase));
            output.AppendLine("}();");
        }

        // TODO: this should really be a separate class that way it can be extended to be able to strip comments etc
        private void readFile(StreamReader fileStream, StringBuilder output, IList<string> additionalReturnStatments)
        {
            string currentLine;
            
            while (fileStream.Peek() >= 0)
            {
                currentLine = fileStream.ReadLine();
                
                if (currentLine.Contains("/*#return"))
                {
                    string additionalContent;
                    AddAdditionalReturnStatements(fileStream, output, additionalReturnStatments, currentLine, out additionalContent);
                    output.AppendLine(additionalContent);
                }
                else
                {
                    output.AppendLine(currentLine);
                }
            }

            output.AppendLine(""); // Just adding some spacing between the files for readability if not minified
        }

        private void AddAdditionalReturnStatements(
            StreamReader fileStream, 
            StringBuilder output, 
            IList<string> additionalReturnStatments, 
            string currentLine,
            out string additionalContent)
        {
            var firstIndex = currentLine.IndexOf("/*#return");
            string returnStatements;
            additionalContent = "";
            bool multiLine = false;
            
            // Check for stuff before the comment
            if (firstIndex - 1 > 0)
            {
                additionalContent = currentLine.Substring(0, firstIndex);
                currentLine = currentLine.Substring(firstIndex);
                firstIndex = 0;
            }

            // Get text until we find the end of the comment
            StringBuilder sb = new StringBuilder();
            if (currentLine.IndexOf("*/") < 0)
            {
                sb.AppendLine(currentLine);
                while (currentLine.IndexOf("*/") < 0 && fileStream.Peek() > 0)
                {
                    currentLine = fileStream.ReadLine();
                    sb.AppendLine(currentLine);
                }
                currentLine = sb.ToString(); // It's not really a line anymore
                multiLine = true;
            }

            var startOfStatements = firstIndex + "/*#return".Length;
            var lengthOfStatements = currentLine.IndexOf("*/") - startOfStatements;
            returnStatements = currentLine.Substring(startOfStatements, lengthOfStatements);

            // Check for stuff after the comment.
            if (currentLine.Length > currentLine.IndexOf("*/") + 2)
            {
                var startOfRest = currentLine.IndexOf("*/") + 2;
                var lengthOfRest = currentLine.Length - startOfRest;
                if (multiLine) { additionalContent += "\n\r"; }
                additionalContent += currentLine.Substring(startOfRest, lengthOfRest);
            }

            var splitStatements = returnStatements.Replace("\r", "").Split('\n');
            foreach (string statement in splitStatements)
            {
                string formattedStatement = RemoveEndOfLineComments(statement);
                if (!String.IsNullOrEmpty(formattedStatement))
                {
                    additionalReturnStatments.Add(formattedStatement);
                }
            }
        }

        private string RemoveEndOfLineComments(string input)
        {
            string result = input;
            if (result.IndexOf("//") >= 0)
            {
                result = result.Substring(0, result.IndexOf("//"));
            }
            return result.Trim();
        }

        private string CreateReturnStatement(IEnumerable<string> directories, IEnumerable<string> filesPaths, IEnumerable<string> additionalStatements, bool includeLowerCase)
        {
            // Dev Sug - Have a way of adding multiple items to the return statement of directories
            // TODO: Should check for duplicates
            // TODO: Should throw warnings if start with a small letter (against convention) 
            var returnStatement = new StringBuilder();
            returnStatement.Append("return {");
            foreach (var directory in directories)
            {
                var directoryName = Path.GetFileName(directory);
                returnStatement.Append(directoryName);
                returnStatement.Append(":");
                returnStatement.Append(directoryName);
                returnStatement.Append(",");
            }
            foreach (var filePath in filesPaths)
            {
                var fileName = Path.GetFileNameWithoutExtension(filePath);
                if (!includeLowerCase && !startsWithCapitalLetter(fileName))
                {
                    continue;
                }
                returnStatement.Append(fileName);
                returnStatement.Append(":");
                returnStatement.Append(fileName);
                returnStatement.Append(",");
            }
            foreach (var additionalStatement in additionalStatements)
            {
                if (additionalStatement.Contains(":") && additionalStatement.Contains(","))
                {
                    returnStatement.Append(additionalStatement);
                }
                else
                {
                    throw new ArgumentException("additional statement in incorrect form, needs to be of the form 'name: name,' but has value "+additionalStatement);
                    // TODO: Does the build process catch exceptions and display the info?
                }
            }
            returnStatement.Remove(returnStatement.Length - 1, 1);
            returnStatement.Append("};");
            return returnStatement.ToString();
        }

        private bool startsWithCapitalLetter(string compare)
        {
            var pattern = new Regex("^[A-Z].*");
            return pattern.IsMatch(compare);
        }
        
        #endregion

        // Elsewhere will be the filesystem watcher for each app which will call the building functions
    }
}