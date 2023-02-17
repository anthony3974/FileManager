using BaseClassLibrary;
using System.Text.RegularExpressions;

namespace FileManager
{
    /// <summary>
    /// Renames many files dynamically
    /// (Array of FileRename)
    /// </summary>
    public class FileRenamer : BaseClass
    {
        #region class info
        /// <summary>
        /// Gets version of the class
        /// </summary>
        /// <returns>Version</returns>
        public string getVersion() { return "1"; }
        #endregion
        #region constructor
        /// <summary>
        /// Makes a new FileRenamer
        /// </summary>
        /// <param name="fullFilePaths">Array files path+name</param>
        public FileRenamer(string[] fullFilePaths)
        {
            fr = new FileRename[fullFilePaths.Length]; // make a new FileRename array
            for (int i = 0; i < fullFilePaths.Length; i++)
                fr[i] = new FileRename(fullFilePaths[i]); // fill the array
        }
        #endregion
        #region vars
        internal FileRename[] fr;
        #endregion
        #region methods
        /// <summary>
        /// Renames the files, removing .,_()[]
        /// </summary>
        public void RemoveSpecial()
        {
            for (int i = 0; i < fr.Length; i++)
                fr[i].RemoveSpecial();
        }
        /// <summary>
        /// Renames the files, removing custom pattern
        /// </summary>
        public void RemoveSpecial(Regex chars)
        {
            for (int i = 0; i < fr.Length; i++)
                fr[i].RemoveSpecial(chars);
        }
        /// <summary>
        /// Renames the files, removing spaces
        /// </summary>
        /// <param name="all">If true, file will not contian space</param>
        public void RemoveSpaces(bool all = false)
        {
            for (int i = 0; i < fr.Length; i++)
                fr[i].RemoveSpaces(all);
        }
        #endregion
    }
}
