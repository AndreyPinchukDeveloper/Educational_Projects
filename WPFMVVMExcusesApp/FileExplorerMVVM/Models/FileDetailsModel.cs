using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FileExplorerMVVM.Models
{
    public class FileDetailsModel
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public PathGeometry FileIcon { get; set; }
        public string FileExtension { get; set; }
        public string FileSize { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedOn { get; set; }
        public string AccessedOn { get; set; }

        public bool IsDirectory { get; set; }
        public bool IsReadonly { get; set; }
        public bool IsHidden { get; set; }
        public bool IsImage { get; set; }
        public bool IsVideo { get; set; }
        public bool IsSelected { get; set; }
        public bool IsPinned { get; set; }

        internal string _Type { get; set; }
        public string Type => _Type = IsDirectory ? "Folder" : "File";

        internal bool IsFileHidden(string fileName)
        {
            var attribute = FileAttributes.Normal;
            try
            {
                attribute = File.GetAttributes(fileName);
            }
            catch (Exception)
            {

                throw;
            }
            return attribute.HasFlag(FileAttributes.Hidden);
        }

        internal bool IsDirectoryMethod(string fileName)
        {
            var attribute = FileAttributes.Normal;
            try
            {
                attribute = File.GetAttributes(fileName);
            }
            catch (Exception)
            {

                throw;
            }
            return attribute.HasFlag(FileAttributes.Directory);
        }

        internal bool IsFileReadOnly(string path)
        {
            try
            {
                if (Directory.Exists(path))
                    return (FileSystem.GetDirectoryInfo(path).Attributes & FileAttributes.ReadOnly) != 0;
                return (FileSystem.GetFileInfo(path).Attributes & FileAttributes.ReadOnly) != 0;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
            catch (DirectoryNotFoundException)
            {
                return false;
            }
        }
    }
}
