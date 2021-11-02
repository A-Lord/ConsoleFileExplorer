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
        public int curentIndex {  get {  return _curentIndex; } set {  _curentIndex = value; } }
        public FolderView()
        {
            curentIndex = 0;
        }
        
        public void GetUserInput()
        {
            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.UpArrow)
                _curentIndex++;
            if (input.Key == ConsoleKey.DownArrow)
                _curentIndex--;
        }

        

        public void PrintList(DirectoryInfo explorer2)
        {
            var explorer = Directory.GetFileSystemEntries(explorer2.ToString());
            //var explorer = explorer2.GetDirectories();
            //var entries = explorer2.GetFileSystemEntries(Directory.GetCurrentDirectory());
            foreach (string explorerPath in explorer)
            {
                if (File.Exists(explorerPath))
                {
                    Console.WriteLine($"-{Path.GetFileName(explorerPath)}");
                }
                else if (Directory.Exists(explorerPath))
                {
                    Console.WriteLine($"#{Path.GetFileName(explorerPath)}");
                }
            }

        }
    }
}
