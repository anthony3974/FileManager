using BaseClassLibrary;
using System.Text.RegularExpressions;

namespace FileManager.MediaManipulation
{
    /// <summary>
    /// Renames mp4 (recommended (works with any file extention))
    /// In format The.Movie.Name.YEAR.####p.source.code.code.#-[AAA.AA]-#.EXT
    /// Input file can be diffrent (should incude trailing p)
    /// Renames to "The Movie Name YEAR ####P.EXT
    /// </summary>
    public class MovieRenamer : FileRenamer, BaseClass
    {
        #region class info
        /// <summary>
        /// Gets version of the class
        /// </summary>
        /// <returns>Version</returns>
        public new string getVersion() { return "1.0.1"; }
        #endregion
        #region constructors
        /// <summary>
        /// Makes a new MovieRenamer using FileRenamer
        /// </summary>
        /// <param name="fullFilePaths">Array files path+name</param>
        public MovieRenamer(string[] fullFilePaths) : base(fullFilePaths)
        {
        }
        #endregion
        #region methods
        /// <summary>
        /// Removes special chars
        /// Removes multi spaces
        /// Removes everything after p and makes p upper
        /// </summary>
        public void Fix()
        {
            RemoveSpecial();
            RemoveSpaces();

            for (int i = 0; i < fr.Length; i++)
            {
                string nameToEdit = fr[i].Fi.Name;
                Match match = Regex.Match(nameToEdit, "\\d(P|p)");
                if (match.Success)
                {
                    nameToEdit = nameToEdit.Substring(0, match.Index + match.Length - 1); // chop
                    nameToEdit = nameToEdit.Insert(nameToEdit.Length, "P"); // make capital P
                    fr[i].ReName(nameToEdit);
                }
            }
        }
        #endregion
    }
}
