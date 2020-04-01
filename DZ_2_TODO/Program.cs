using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Text.Json;
//using Newtonsoft.Json.Linq;

namespace DZ_2_TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            string curDir = Directory.GetCurrentDirectory();
            string pathFile = Path.Combine(curDir, "ToDoList.txt");
            string text = "";

            if (File.Exists(pathFile))
            {
                // text = File.ReadAllText(pathFile);
                // Console.WriteLine(text);
            }
            else Console.WriteLine("File not exists");

            Console.WriteLine("Enter:");
            Console.WriteLine("1 to see TO DO list");
            Console.WriteLine("2 to add new task");
            Console.WriteLine("3 to add new reminder");
            Console.WriteLine("4 to delete ");
            Console.WriteLine("5 to edit");
            Console.WriteLine("0 to exit");
            string variant;
            int var;
            do
            {
                variant = Console.ReadLine();
                var = Convert.ToInt32(variant);
                switch (var)
                {
                    case 1:
                        ToDoList(pathFile);
                        break;
                    case 2:
                        AddTask(pathFile);
                        break;
                    case 3:
                        AddReminder(pathFile);
                        break;
                    case 4:
                        DeleteTask(pathFile);
                        break;
                    case 5:
                        EditTask(pathFile);
                        break;

                }
            }
            while (var!=0);
           
        }
        static void ToDoList(string pathFile)
        {
            string text = "";           
            if (File.Exists(pathFile))
            {
                text = File.ReadAllText(pathFile);
                Console.WriteLine(text);
            }
            else Console.WriteLine("File not exists");
        }
        static void AddTask(string pathFile)
        {           
            Task task = new Task();
            Console.WriteLine("Name:");
            task.name = Console.ReadLine();
            Console.WriteLine("Subject:");
            task.subject = Console.ReadLine();
            File.AppendAllText(pathFile, "Name: " + task.name + "   Subject: " + task.subject + "\n");
            //File.AppendAllText(pathFile, "\n");
        }
        public class Task
        {
            public string name { get; set; }
            public string subject { get; set; }
        }
        public class Reminder : Task
        {
            public string date { get; set; }

        }
        static void DeleteTask(string pathFile)
        {
            Console.WriteLine("Enter name of deleted task:");
            string text = Console.ReadLine();
            var re = File.ReadAllLines(pathFile, Encoding.Default).Where(s => !s.Contains(text));
            File.WriteAllLines(pathFile, re, Encoding.Default);

        }
        static void EditTask(string pathFile)
        {
            Console.WriteLine("Enter text what you need to edit:");
            string text = Console.ReadLine();
            Console.WriteLine("Enter new information:");
            string newText = Console.ReadLine();
            string re = File.ReadAllText(pathFile);
            re = re.Replace(text, newText);
            File.WriteAllText(pathFile, re);

        }
        static void AddReminder(string pathFile)
        {
            Reminder reminder = new Reminder();
            Console.WriteLine("Name:");
            reminder.name = Console.ReadLine();
            Console.WriteLine("Subject:");
            reminder.subject = Console.ReadLine();
            Console.WriteLine("Date MM.dd.yyyy:");
            reminder.date = Console.ReadLine();
            string s = DateTime.Now.ToString("MM/dd/yyyy");
            if (reminder.date == s)
            {
                File.AppendAllText(pathFile, "Name: " + reminder.name + "   Subject: " + reminder.subject + "   Date: " + reminder.date + " You need to do this today!!!" + "\n");
            }
            else File.AppendAllText(pathFile, "Name: " + reminder.name + "   Subject: " + reminder.subject + "   Date: " + reminder.date + "\n");

            //File.AppendAllText(pathFile, "\n");
        }

    }
}
