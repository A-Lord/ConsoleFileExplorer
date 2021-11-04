using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleFileExplorer
{
    public class FolderView
    {
        private int _curentIndex;
        private int _totalItems = 0;
        private string _currentDirectory;
        private string _parentDirectory;
        public string ParentDirectory {  get {  return _parentDirectory; } }
        public string CurrentDirectory {  get {  return _currentDirectory; } set {  _currentDirectory = value; } }
        public int TotalItems {  get {  return _totalItems; } set {  _totalItems = value; } }
        public int CurentIndex {  get {  return _curentIndex; } set {  _curentIndex = value; } }
        private string _currentFileName;
        public string CurrentFileName {  get {  return _currentFileName; } }
        public FolderView(string currentDirectory)
        {
            _currentDirectory = currentDirectory;
            UpdateTotalItems();
            CurentIndex = 0;
        }
        public void UpdateTotalItems()
        {
            TotalItems = Directory.GetFileSystemEntries(CurrentDirectory).Length;
        }
        public void Up()
        {
           
            if (CurentIndex > 0)
                CurentIndex--;
        }
        public void Down()
        {
                if (CurentIndex < TotalItems - 1)
                CurentIndex++;
        }
        public void ReadFile()
        {
            

            if (File.Exists(CurrentFileName))
            {
                Console.WriteLine($"Open:");
                using var fs = new FileStream(CurrentFileName, FileMode.Open, FileAccess.Read);
                using var sr = new StreamReader(fs);
                string line = String.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

        }
        public void PrintList()
        {
            Console.Clear();
            string[] explorer = Directory.GetFileSystemEntries(CurrentDirectory);
            //var explorer = explorer2.GetDirectories();
            //var entries = explorer2.GetFileSystemEntries(Directory.GetCurrentDirectory());
            foreach (string explorerPath in explorer)
            {
                if (explorerPath == explorer[CurentIndex])
                {
                    ChangeColor.ChangeColors(ConsoleColor.Blue);
                    _currentFileName = explorerPath;
                }
                if (File.Exists(explorerPath))
                {
                    Console.WriteLine($"-{Path.GetFileName(explorerPath)}");
                }
                else if (Directory.Exists(explorerPath))
                {
                    Console.WriteLine($"#{Path.GetFileName(explorerPath)}");
                }
                Console.ResetColor();
            }

        }
    }
}
