using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Tools
{
    public class Folder
    {
        public static void CreateFolder(string Path)
        {
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
        }
        public static void DeleteFolder(string Path)
        {
            try
            {
                if (Directory.Exists(Path))
                {
                    RemoveFolder(new DirectoryInfo(Path));//xóa bên trong
                    Directory.Delete(Path, true);// xóa thu mục hiện hành
                }
            }
            catch
            {


            }
        }
        public static void DeleteFile(string Path)
        {
            if (File.Exists(Path))
                File.Delete(Path);
        }
        public static void MoveFolder(string sourcePath, string destPath)
        {
            if (Directory.Exists(sourcePath))
            {
                DeleteFolder(sourcePath);
                Directory.Move(sourcePath, destPath);
            }
        }
        private static void RemoveFolder(DirectoryInfo directoryInfo)
        {
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo subfolder in directoryInfo.GetDirectories())
            {
                RemoveFolder(subfolder);
            }
        }
        public static void CreateFile(string Path, string text)
        {
            FileInfo file = new FileInfo(Path);
            StreamWriter writer = new StreamWriter(Path);
            writer.Write(text);
            writer.Close();
        }
    }
}
