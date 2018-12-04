using System;
using System.Collections.Generic;
using System.IO;

namespace ServantSoftware.FolderLister
{
    public class FolderListService
    {
        /// <summary>
        /// Get a list of files in the specified folder
        /// </summary>
        /// <param name="folder">path of the folder</param>
        /// <param name="pattern">file pattern to use</param>
        /// <param name="recursive">flag indicating whether any subfolders should be included</param>
        /// <returns>An IEnumerable of filenames found</returns>
        public IEnumerable<string> GetFiles(string folder, string pattern = "*.*", bool recursive = false)
        {
            return Directory.EnumerateFiles(folder, pattern, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        }
    }
    
}
