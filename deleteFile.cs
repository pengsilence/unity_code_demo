using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace tools_code
{
    class deleteFile
    {
        public static string g_path;
        static void Main(string[] args)
        {
            Console.WriteLine("请输入要删除的路径:");
            string delpath = Console.ReadLine();
            g_path = delpath;
            deleteDirectory(delpath);
           
            Console.WriteLine("{0}删除成功~", delpath);
            return;           
        }

        public static void deleteDirectory(string srcPath)
        {
            string deleteDir = srcPath;
            if (!Directory.Exists(deleteDir))
            {
                Console.WriteLine("路径{0}不存在", deleteDir);
            }
            string[] delDir = Directory.GetFileSystemEntries(deleteDir);
            foreach (var item in delDir)
            {               
                if (File.Exists(item))
                {
                    Console.WriteLine("删除文件{0}", item);
                    File.Delete(item);
                }   
                if (Directory.Exists(item))
                {                   
                    Console.WriteLine("{0}", item);
                    deleteDirectory(item);
                    if (item == g_path)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("删除路径{0}", item);
                        Directory.Delete(item);
                    }
                }
            }

            return;
        }
    }
}
