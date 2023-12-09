using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul16
{
    internal class Program
    {
        static string path = @"C:\\Users\\qznur\\OneDrive\\Документы\\TNSShort";
        
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            if (di.Exists)
            {
                Dictionary<string, int> dic = new Dictionary<string, int>();
                foreach (FileInfo item in di.GetFiles())
                {
                    if (!dic.ContainsKey(item.Extension))
                    {
                        dic.Add(item.Extension, 0);
                    }
                }
                foreach (var item in dic)
                {
                    Console.WriteLine(item.Key);
                }
                string selectedEx = " ";
                Console.Write("Выберите рассширение: ");
                selectedEx = Console.ReadLine();
                Dictionary<string, string> dire = new Dictionary<string, string>();
                foreach (FileInfo item in di.GetFiles("*." + selectedEx))
                {
                    Console.WriteLine(item.Name);
                    foreach (char letter in item.Name)
                    {
                        if(!(letter >= 192 && letter <= 225))
                        {
                            if(dire.ContainsKey(letter.ToString()))
                            {
                                dire.Add(letter.ToString(), "");
                            }
                        }
                    }
                }

                for (int i = 0; i < dire.Count; i++)
                {
                    Console.Write("«{0}» заменить на (пользователь вводит на что заменить)", dire.ElementAt(i).Key);
                    dire[dire.ElementAt(i).Key] = Console.ReadLine();
                }
            }
        }
    }
}
