using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace laba_5
{
    class cruds
    {

        private List<String> workersList;
        public void search(String param)
        {
            
                if (workersList == null)
                    workersList = System.IO.File.ReadLines("D:\\text.txt").ToList();
                workersList.ForEach(delegate (String values)
                {
                    //values.StartsWith
                    if (values.ToUpper().Contains(param.ToUpper()))
                    {
                        Console.WriteLine(values);
                    }
                });

            
        }
        public void deleteWorker(String position, String FirstName, String SecondName, String Name)
        {
            if (workersList == null)
                workersList = System.IO.File.ReadLines("D:\\text.txt").ToList();
            workersList.ForEach(delegate (String values)
        {
            if (values.ToUpper().Contains(position.ToUpper()))
                if (values.ToUpper().Contains(FirstName.ToUpper()))
                    if (values.Contains(SecondName))
                        if (values.Contains(Name))
                        {
                            workersList.Remove(values);
                            System.IO.File.WriteAllLines("D:\\text.txt", workersList);
                        }
        });
        }
        public void addWorker(String position, String FirstName, String SecondName, String Name)
        {
            if (workersList == null)
                workersList = System.IO.File.ReadLines("D:\\text.txt").ToList();
            String newWorker = position + " " + FirstName + " " + SecondName + " " + Name;
            if (!workersList.Contains(newWorker,StringComparer.CurrentCultureIgnoreCase))
            {
                workersList.Add(newWorker);
                System.IO.File.WriteAllLines("D:\\text.txt", workersList);

            }
        }
        public void showAll()
        {
            workersList = System.IO.File.ReadLines("D:\\text.txt").ToList();
            workersList.ForEach(Print);
        }
        public void deletePosition(String position)
        {
            if (workersList == null)
                workersList = System.IO.File.ReadLines("D:\\text.txt").ToList();
            workersList.ForEach(delegate (String values)
            {
                if (values.ToUpper().StartsWith(position.ToUpper()))
                {
                    workersList.Remove(values);
                }
            });
            System.IO.File.WriteAllLines("D:\\text.txt", workersList);
        }
        public void showPosition(String position)
        {
            if (workersList == null)
                workersList = System.IO.File.ReadLines("D:\\text.txt").ToList();
            workersList.ForEach(delegate (String values)
            {
                //values.StartsWith
                if (values.ToUpper().StartsWith(position.ToUpper()))
                {
                    Console.WriteLine(values);
                }
            });
     
        }
        public void Print(string s)
        {
            Console.WriteLine(s);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            cruds c = new cruds();
            String position;
            String FirstName;
            String SecondName;
            String Name;
            while (true)
            {
                Console.WriteLine("\n\nВыберите действие: \n" +
                                "1 - Просмотреть работников\n" +
                                "2 - Удалить работника\n" +
                                "3 - Вывести группу\n" +
                                "4 - Удалить группу\n" +
                                "5 - Добавить работника\n"+
                                "6-  Поиск по значению\n"+
                                "0 - Выход"
                                );
                String value = Console.ReadLine();
                value.Trim();
                switch (value)
                {
                    case "0":
                        return;
                    case "1":
                        c.showAll();
                        break;
                    case "2":

                        Console.WriteLine("Введите должность");
                        position = Console.ReadLine();
                        Console.WriteLine("Введите Фамилию");
                        FirstName = Console.ReadLine();
                        Console.WriteLine("Введите отчество");
                        SecondName = Console.ReadLine();
                        Console.WriteLine("Введите имя");
                        Name = Console.ReadLine();
                        c.deleteWorker(position, FirstName, SecondName, Name);
                        break;
                    case "3":
                        Console.WriteLine("Введите группу");
                        position = Console.ReadLine();
                        c.showPosition(position);
                        break;
                    case "4":
                        Console.WriteLine("Введите группу");
                        position = Console.ReadLine();
                        c.deletePosition(position);
                        break;
                    case "5":
                        Console.WriteLine("Введите должность");
                        position = Console.ReadLine();
                        Console.WriteLine("Введите Фамилию");
                        FirstName = Console.ReadLine();
                        Console.WriteLine("Введите отчество");
                        SecondName = Console.ReadLine();
                        Console.WriteLine("Введите имя");
                        Name = Console.ReadLine();
                        c.addWorker(position, FirstName, SecondName, Name);
                        break;
                    case "6":
                        Console.WriteLine("Введите параметр :");
                        String param=Console.ReadLine();
                        c.search(param);
                        break;
                   
                 

                }
                
            }

        }
    }

}
