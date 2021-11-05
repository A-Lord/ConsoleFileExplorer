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
        public string CurrentDirectory {  get {  return _currentDirectory; } set {  _currentDirectory = value; } }
        public int TotalItems {  get {  return _totalItems; } set {  _totalItems = value; } }
        public int CurentIndex {  get {  return _curentIndex; } set {  _curentIndex = value; } }
        private string _currentFileName;
        public string CurrentFileName {  get {  return _currentFileName; } }
        public FolderView(string currentDirectory)
        {
            _currentDirectory = currentDirectory;
            Directory.SetCurrentDirectory(currentDirectory);
            UpdateTotalItems();
            CurentIndex = 0;
            ChangeConsoleTitle(_currentDirectory);
        }
        public void UpdateTotalItems()
        {
            TotalItems = Directory.GetFileSystemEntries(CurrentDirectory).Length;
            if (_curentIndex >= TotalItems)
            {
                _curentIndex--;
            }
        }
        public void ChangeConsoleTitle(string newTitle)
        {
            if (File.Exists(CurrentFileName))
            Console.Title = "Target File: " + newTitle;
            if (Directory.Exists(CurrentFileName))
            Console.Title = "Target Folder: " + newTitle;
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
                Console.WriteLine(sr.ReadToEnd());
                Console.WriteLine("```Tryck på valfri tangent för att gå tillbaka till listan```");
                Console.ReadKey();
            }
        }
        public void PrintList()
        {
            Console.Clear();
            PrintLogo();
            Console.WriteLine();

            string[] explorer = Directory.GetFileSystemEntries(CurrentDirectory);
            var backGroundColor = ConsoleColor.Black;
            Console.WriteLine("You are in folder: \n" + _currentDirectory + "\n");
            for (int i = 0; i < _currentDirectory.Length + 10; i++)
            {
                Console.Write("▀");
            }
            Console.WriteLine("");

            foreach (string explorerPath in explorer)
            {
                if (explorerPath == explorer[CurentIndex])
                {
                    backGroundColor = ConsoleColor.DarkRed;
                    _currentFileName = explorerPath;
                    ChangeConsoleTitle(Path.GetFileName(CurrentFileName));
                }
                if (File.Exists(explorerPath))
                {
                    ChangeColor.ChangeTextColor(ConsoleColor.Green, "-");
                    ChangeColor.ChangeColors(backGroundColor, $"{Path.GetFileName(explorerPath)}");
                }
                else if (Directory.Exists(explorerPath))
                {
                    ChangeColor.ChangeTextColor(ConsoleColor.Red, "#");
                    ChangeColor.ChangeColors(backGroundColor, $"{Path.GetFileName(explorerPath)}");

                }
                backGroundColor = ConsoleColor.Black;
                Console.ResetColor();
            }
            Console.WriteLine("");
            
            for (int i = 0; i < _currentDirectory.Length + 10; i++)     
            { 
                Console.Write("▀");     
            }

            
        }
        private void PrintLogo()
        {
          
            ChangeColor.ChangeTextColor(ConsoleColor.Green, @"______ _ _        _____           _                    " + "\n");
            ChangeColor.ChangeTextColor(ConsoleColor.Green, @"|  ___(_) |      |  ___|         | |                    " + "\n");
            ChangeColor.ChangeTextColor(ConsoleColor.Green, @"| |_   _| | ___  | |____  ___ __ | | ___  _ __ ___ _ __ " + "\n");
            ChangeColor.ChangeTextColor(ConsoleColor.Green, @"|  _| | | |/ _ \ |  __\ \/ / '_ \| |/ _ \| '__/ _ \ '__|" + "\n");
            ChangeColor.ChangeTextColor(ConsoleColor.Green, @"| |   | | |  __/ | |___>  <| |_) | | (_) | | |  __/ |   " + "\n");
            ChangeColor.ChangeTextColor(ConsoleColor.Green, @"\_|   |_|_|\___| \____/_/\_\ .__/|_|\___/|_|  \___|_|   " + "\n");
            ChangeColor.ChangeTextColor(ConsoleColor.Green, @"                           | |                          " + "\n");
            ChangeColor.ChangeTextColor(ConsoleColor.Green, @"                           |_|                          " + "\n");
               
        }
    
    }
}
