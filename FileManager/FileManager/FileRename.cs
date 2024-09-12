using System.IO;
using System.Text.RegularExpressions;

namespace FileManager
{
    /// <summary>
    /// Renames a single file dynamically
    /// </summary>
    public class FileRename
    {
        #region class info
        /// <summary>
        /// Gets version of the class
        /// </summary>
        /// <returns>Version</returns>
        public string getVersion() { return "1.0.2"; }
        #endregion
        #region constructors
        /// <summary>
        /// Makes a new FileRename
        /// </summary>
        /// <param name="fullFilePath">Single file path+name</param>
        public FileRename(string fullFilePath)
        {
            fi = new FileInfo(fullFilePath);
        }
        #endregion
        #region vars
        FileInfo fi;
        #endregion
        #region methods
        /// <summary>
        /// Renames the file, extension incuded (will not save double extension)
        /// </summary>
        /// <param name="newName">Sets the name to change the file to</param>
        public void ReName(string newName)
        {
            if (newName.EndsWith(fi.Extension)) newName = newName.Substring(0, newName.Length - fi.Extension.Length);
            string newFile = fi.DirectoryName + "\\" + newName + fi.Extension;
            File.Move(fi.FullName, newFile);
            fi = new FileInfo(newFile);
        }
        /// <summary>
        /// Renames the file, removing .,_()[]
        /// </summary>
        public void RemoveSpecial()
        {
            Regex pat = new Regex("[.,_()[\\]]");
            string newName = pat.Replace(fi.Name.Substring(0, fi.Name.LastIndexOf(".")), " ");
            ReName(newName);
        }
        /// <summary>
        /// Renames the file, removing custom pattern
        /// </summary>
        public void RemoveSpecial(Regex chars)
        {
            string newName = chars.Replace(fi.Name.Substring(0, fi.Name.LastIndexOf(".")), " ");
            ReName(newName);
        }
        /// <summary>
        /// Renames the file, removing spaces
        /// </summary>
        /// <param name="all">If true, file will not contian space</param>
        public void RemoveSpaces(bool all = false)
        {
            Regex pat;
            string newName;
            if (all)
            {
                pat = new Regex("([ ]{4}|[ ]{3}|[ ]{2}|[ ]{1})");
                newName = pat.Replace(fi.Name.Substring(0, fi.Name.LastIndexOf(".")), "");
            }
            else
            {
                pat = new Regex("([ ]{4}|[ ]{3}|[ ]{2})");
                newName = pat.Replace(fi.Name.Substring(0, fi.Name.LastIndexOf(".")), " ");
            }
            ReName(newName);
        }
        #endregion
        #region properties
        /// <summary>
        /// Get the FileInfo object
        /// </summary>
        public FileInfo Fi { get { return fi; } }
        #endregion
    }
}
