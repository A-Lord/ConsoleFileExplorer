using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleFileExplorer
{
    public class ConsoleExplorer
    {
        
        public void run()
        {
            FolderView folderviewer = new FolderView();
            while (true)
            {
                DirectoryInfo explorer = new DirectoryInfo(Directory.GetCurrentDirectory());
                folderviewer.PrintList(explorer);
                folderviewer.GetUserInput();
            }
    
        }

        

        
        
    }
    
}

