using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ConsoleFileExplorer
{
    public class ConsoleExplorer
    {
        private ViewState _viewState = ViewState.List;
        //private FolderView _folderViewer = new FolderView(@"E:\ConsoleFileExplorer\ConsoleFileExplorer\");
        private FolderView _folderViewer = new FolderView(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        
        public void run()
        {
            while (true)
            {
                if (_viewState == ViewState.FileView)
                {
                    _folderViewer.ReadFile();
                    _viewState = ViewState.List;
                }
                else if (_viewState == ViewState.CreateFile)
                {
                    CreateFile();
                }
                else if (_viewState == ViewState.List)
                {
                    _folderViewer.PrintList();
                    GetUserInput();
                }
            }
        }

        private void GetUserInput()
        {
            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.UpArrow)
                _folderViewer.Up();
            if (input.Key == ConsoleKey.DownArrow)
                _folderViewer.Down();
            if (input.Key == ConsoleKey.Spacebar)
                _viewState = ViewState.FileView;
            if (input.Key == ConsoleKey.Enter)
                ChangeFolderView(_folderViewer.CurrentFileName);
            if (input.Key == ConsoleKey.Backspace)
            {
                _viewState = ViewState.List;
                ChangeFolderView(_folderViewer.CurrentDirectory + "\\..");
            }
            if (input.Key == ConsoleKey.C)
                _viewState = ViewState.CreateFile;
            if (input.Key == ConsoleKey.D)
                DeleteFile();
        }
        private void ChangeFolderView(string newfolder)
        {
            if (Directory.Exists(newfolder))
            {
                _folderViewer = new FolderView(newfolder);
            }
        }
        private void DeleteFile()
        {
            if (File.Exists(_folderViewer.CurrentFileName) == true && Directory.Exists(_folderViewer.CurrentFileName) != true)
                {
                Console.WriteLine($"\n Are you sure you want to delete {Path.GetFileName(_folderViewer.CurrentFileName)} \n y/n:");
                ConsoleKeyInfo input = Console.ReadKey();
                if (input.Key == ConsoleKey.Y)
                {
                    File.Delete(_folderViewer.CurrentFileName);
                    Console.WriteLine($"{Path.GetFileName(_folderViewer.CurrentFileName)} Is deleted");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n\n Can't Delete folders");
                Console.WriteLine("```Tryck på valfri tangent för att gå tillbaka till listan```");
                Console.ReadKey();
            }
        }
        private void CreateFile()
        {
            List<string> txtFileContent = new List<string>();
            string inputTxt;
            Console.WriteLine("\n \n Write name of new txt file: \n");
            string txtFileName = Console.ReadLine() + ".txt";
            Console.WriteLine("Write the text lines you want in the file, enter a empty line to create the file\n");
            bool emptyLine = false;
            while (emptyLine == false)
            {
                inputTxt = Console.ReadLine();
                if (inputTxt == "")
                {
                    emptyLine = true;
                }

                else
                    txtFileContent.Add(inputTxt);
            }

            using (StreamWriter sw = File.CreateText(_folderViewer.CurrentDirectory + "\\" + txtFileName))
            {


                foreach (string line in txtFileContent)
                {
                    sw.WriteLine(line);
                }
            }
            _viewState = ViewState.List;
            _folderViewer.UpdateTotalItems();
        }
    }
}

