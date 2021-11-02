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
            DirectoryInfo explorer = new DirectoryInfo(Directory.GetCurrentDirectory());
            FolderView folderviewer = new FolderView();
            while (true)
            {
                folderviewer.TotalItems = explorer.GetFiles().Length;   
                folderviewer.PrintList(explorer);
                folderviewer.GetUserInput();
            }
    
        }

        

        
        
    }
    
}

