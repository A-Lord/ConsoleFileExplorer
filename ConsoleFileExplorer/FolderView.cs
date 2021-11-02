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
        public int TotalItems {  get {  return _totalItems; } set {  _totalItems = value; } }
        public int CurentIndex {  get {  return _curentIndex; } set {  _curentIndex = value; } }
        public FolderView()
        {
            CurentIndex = 0;
        }
        
        public void GetUserInput()
        {
            

            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.UpArrow)
                    if (CurentIndex > 0)
                    CurentIndex--;
            if (input.Key == ConsoleKey.DownArrow)
                    if (CurentIndex < TotalItems + 1)
                CurentIndex++;
            
            
        }

        

        public void PrintList(DirectoryInfo explorer2)
        {
            Console.Clear();
            var explorer = Directory.GetFileSystemEntries(explorer2.ToString());
            //var explorer = explorer2.GetDirectories();
            //var entries = explorer2.GetFileSystemEntries(Directory.GetCurrentDirectory());
            foreach (string explorerPath in explorer)
            {
                if (explorerPath == explorer[CurentIndex])
                {
                    ChangeColor.ChangeColors(ConsoleColor.Blue);
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
