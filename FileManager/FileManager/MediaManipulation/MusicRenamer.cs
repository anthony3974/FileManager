using BaseClassLibrary;
using System.Text.RegularExpressions;

namespace FileManager.MediaManipulation
{
    /// <summary>
    /// Renames mp3 (recommended (works with any file extention))
    /// Removes (128 k) and Official Music Video Audio lyric ([])
    /// </summary>
    public class MusicRenamer : FileRenamer, BaseClass
    {
        #region class info
        /// <summary>
        /// Gets version of the class
        /// </summary>
        /// <returns>Version</returns>
        public new string getVersion() { return "1"; }
        #endregion
        #region constructor
        /// <summary>
        /// Makes a new MusicRenamer using FileRenamer
        /// </summary>
        /// <param name="fullFilePaths">Array files path+name</param>
        public MusicRenamer(string[] fullFilePaths) : base(fullFilePaths)
        {
        }
        #endregion
        #region methods
        /// <summary>
        /// Removes the (128 k)
        /// Removes the Official Music Video Audio lyric ([])
        /// </summary>
        public void Fix()
        {
            for (int i = 0; i < fr.Length; i++)
            {
                string nameToEdit = fr[i].Fi.Name;

                Regex pat = new Regex("( \\(\\d{1,3} [a-z]{1,4}\\))|( \\(\\d{1,3}(k|K)\\))");
                nameToEdit = pat.Replace(nameToEdit, ""); // removing (128 k)

                pat = new Regex("( (\\(|\\[)official music video(\\)|\\]))|( (\\(|\\[)official lyric video(\\)|\\]))|( (\\(|\\[)official video(\\)|\\]))|( (\\(|\\[)official audio(\\)|\\]))|( (\\(|\\[)official music(\\)|\\]))|( (\\(|\\[)audio(\\)|\\]))|( (\\(|\\[)lyric video(\\)|\\]))|( (\\(|\\[)lyrics & music(\\)|\\]))|( (\\(|\\[) live(\\)|\\]))|( (\\(|\\[)live(\\)|\\]))|( (\\(|\\[)with lyrics(\\)|\\]))|( (\\(|\\[) lyrics(\\)|\\]))|(lyrics)", RegexOptions.IgnoreCase);
                nameToEdit = pat.Replace(nameToEdit, ""); // removing Official Music Video Audio lyric ([])                                                                                                                                                                                                                                                                                                                                need smaller last

                fr[i].ReName(nameToEdit);
            }
        }
        #endregion
    }
}
