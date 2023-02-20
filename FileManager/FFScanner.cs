using BaseClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// Can scan files within folders and can exculde or incude certain files
/// </summary>
public class FFScaner : BaseClass
{
    #region class info
    /// <summary>
    /// Gets version of the class
    /// </summary>
    /// <returns>Version</returns>
    public string getVersion() { return "1.0.1.7"; }
    #endregion
    #region methods
    /// <summary>
    /// List all files in master directory
    /// </summary>
    /// <param name="mainPath">Sets the path to start the scanning for files</param>
    /// <param name="endsWith">Sort only this ending</param>
    /// <param name="doesNotEndWith">If true will exculde selceted files</param>
    /// <returns>List of file path names</returns>
    public static List<string> ScanFiles(string mainPath, string endsWith = null, bool doesNotEndWith = false)
    {
        List<string> returnList = new List<string>();
        List<string> folders = Directory.GetDirectories(mainPath).ToList();

        for (int director = 0; director < folders.Count; director++) // cycle though main folder list and find sub folders
        {
            string[] tmp = Directory.GetDirectories(folders[director]);
            for (int i = 0; i < tmp.Length; i++) // cycle though sub folders
            {
                folders.Add(tmp[i]);
            }
        }
        folders.Add(mainPath);

        foreach (string item in folders) // cycle though folders and find files
        {
            string[] tmp = Directory.GetFiles(item);
            foreach (string file in tmp) // add each file in every folder
            {
                if (endsWith == null) returnList.Add(file);
                else if (!doesNotEndWith && file.EndsWith(endsWith)) returnList.Add(file); // default adding
                else if (doesNotEndWith && !file.EndsWith(endsWith)) returnList.Add(file); // exculding
            }
        }
        return returnList;
    }
    /// <summary>
    /// List all files in master directory
    /// </summary>
    /// <param name="mainPath">Sets the path to start the scanning for files</param>
    /// <param name="endsWith">Sort only these endings</param>
    /// <param name="doesNotEndWith">If true will exculde selceted files</param>
    /// <returns>List of file path names</returns>
    public static List<string> ScanFiles(string mainPath, string[] endsWith, bool doesNotEndWith = false)
    {
        List<string> returnList = new List<string>();
        List<string> folders = Directory.GetDirectories(mainPath).ToList();

        for (int director = 0; director < folders.Count; director++) // cycle though main folder list and find sub folders
        {
            string[] tmp = Directory.GetDirectories(folders[director]);
            for (int i = 0; i < tmp.Length; i++) // cycle though sub folders
            {
                folders.Add(tmp[i]);
            }
        }
        folders.Add(mainPath);

        foreach (string item in folders) // cycle though folders and find files
        {
            string[] tmp = Directory.GetFiles(item);
            foreach (string file in tmp) // add each file in every folder
            {
                if (endsWith == null) returnList.Add(file);
                else
                {
                    int index = -1;
                    foreach (var item1 in endsWith) // master loop to find if the file ends with the array (endswith) items
                        if (file.EndsWith(item1)) // finds if the file ends with any item in the array
                            index = Array.IndexOf(endsWith, item1); // if it does then return a positive number relative to the endswith array
                    if (index != -1) // if found
                    { if (!doesNotEndWith) returnList.Add(file); } // default adding
                    else if (doesNotEndWith) returnList.Add(file); // if not found and suspose to exculde then add
                }
            }
        }
        return returnList;
    }
    #endregion
}