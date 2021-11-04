using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFileExplorer
{
    public class ConsoleExplorer
    {
        private ViewState _viewState = ViewState.List;
        private FolderView _folderViewer = new FolderView(Directory.GetCurrentDirectory());
       
        public void run()
        {
            //DirectoryInfo explorer = new DirectoryInfo(Directory.GetCurrentDirectory());

            while (true)
            {
                
                if (_viewState == ViewState.List)
                {
                    _folderViewer.PrintList();
                    GetUserInput();
                }
                else if (_viewState == ViewState.FileView)
                {
                    
                    _folderViewer.ReadFile();
                    Console.WriteLine("```Tryck på valfri tangent för att gå tillbaka till listan```");
                    Console.ReadKey();
                    _viewState = ViewState.List;
                }
                else if(_viewState == ViewState.CreateFile)
                {
                    CreateFile();
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
        }
        private void ChangeFolderView(string newfolder)
        {
            if (Directory.Exists(newfolder))
            {
                _folderViewer = new FolderView(newfolder);
            }
        }
        private void CreateFile()
        {
            List<string> txtFileContent = new List<string>();
            string inputTxt;
            Console.WriteLine("Write name of new txt file");
            string txtFileName = Console.ReadLine() + ".txt";
            Console.WriteLine("Write the text lines you want in the file, enter a empty line to create the file");
            bool emptyLine = false;
            while (emptyLine == false)
            {
                inputTxt = Console.ReadLine();
                if (inputTxt == "")
                {
                    emptyLine = true;
                }
                else
                {
                    txtFileContent.Add(Console.ReadLine());
                }     
            }
            
            using (StreamWriter sw = File.CreateText(_folderViewer.CurrentDirectory + txtFileName))
            {
                foreach (string line in txtFileContent)
                {
                    sw.WriteLine(line);
                }
            }
            _folderViewer.UpdateTotalItems();
            _viewState = ViewState.List;
        }
    }
}

