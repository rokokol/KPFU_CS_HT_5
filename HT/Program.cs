using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace HT
{
    class MainClass 
    {
        /// <summary>
        /// The path to images
        /// </summary>
        static string PATH = "../../data/images/{0}.jpeg";
        /// <summary>
        /// Writes " > " in start of the line.
        /// </summary>
        static void Offer()
        {
            Console.Write("> ");
        }

        /// <summary>
        /// Writes a number of the task.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="number">Number of the task.</param>
        static void Message(string message, int number)
        {
            Console.WriteLine("\nLet's check problem #{0}\nThis program {1}\nPress any to continue...", number, message);
            Console.ReadKey();
        }

        /// <summary>
        /// Reads the input int. If input incorrect it ass user to try again.
        /// </summary>
        /// <returns>The input int.</returns>
        /// <param name="positiveFlag">If set to <c>true</c> input must be positive.</param>
        /// <param name="nonZero">If set to <c>true</c> input must not be zero.</param>
        static int ReadInt(bool positiveFlag, bool nonZero)
        {
            int result = 1;
            bool term = true;
            while (term)
            {
                Offer();
                bool convert = int.TryParse(Console.ReadLine(), out result);
                bool positive = (result >= 0) || !positiveFlag;
                bool noZero = (result != 0) || !nonZero;
                if (convert && positive && noZero)
                {
                    term = false;
                }
                else if (!positive)
                {
                    Console.WriteLine("The input must be positive. Please, try again:");
                }
                else
                {
                    Console.WriteLine("Incorrect input. Please, try again:");
                }
            }
            return result;
        }

        struct AnAdequateImageStructToAdequatePeople
        {
            public string path;
            public Image image;
            public AnAdequateImageStructToAdequatePeople(string path)
            {
                this.path = path;
                image = Image.FromFile(path);
            }
        }

        struct Student
        {
            public string name;
            public string surname;
            public DateTime birthday;
            public string exam;
            public int score;

            static public Dictionary<int, Student> Remove(Dictionary<int, Student> studs, string input)
            {
                for (int i = 0; i < studs.Count; i++)
                {
                    if ($"{studs[i].surname};{studs[i].name}".Equals(input))
                    {
                        studs.Remove(i);
                        break;
                    }
                }

                return studs;
            }

            static public Dictionary<int, Student> Sort(Dictionary<int, Student> studs)
            {
                return studs = studs.OrderBy(s => s.Value.score).ToDictionary(x => x.Key, x => x.Value);
            }
            static public void List(Dictionary<int, Student> studs)
            {
                Console.WriteLine($"Список всех {studs.Count} студентов:");
                foreach (KeyValuePair<int, Student> st in studs)
                {
                    Console.WriteLine($"{st.Key} - {st.Value.ToString()}");
                }
            }
            static public Student DoStudent(string input)
            {
                string[] info = input.Split(';');
                string[] date = info[2].Split('.');
                return new Student(info[0], info[1], new DateTime(int.Parse(date[0]), int.Parse(date[1]),
                     int.Parse(date[2])), info[3], int.Parse(info[4]));
            }

            public Student(string name, string surname, DateTime birthday, string exam, int score)
            {
                this.name = name;
                this.surname = surname;
                this.birthday = birthday;
                this.exam = exam;
                this.score = score;
            }

            public string ToString()
            {
                return $"Студент {surname} {name}, экзамен: {exam} {score}, ДР: {birthday.Day}/{birthday.Month}/{birthday.Year}";
            }
        }

        static public bool DeepFirstSearch(Node start, int search, out Node result)
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(start);
            while (stack.Count != 0)
            {
                Node current = stack.Pop();
                if (current.value == search)
                {
                    result = current;
                    return true;
                }

                foreach (Node node in current.neighbors)
                {
                    stack.Push(node);
                }
            }
            result = new Node();
            return false;
        }

        public struct Node
        {
            public int value { get; set; }
            public List<Node> neighbors;

            public Node(int value, params Node[] neighbors)
            {
                this.value = value;
                this.neighbors = new List<Node>(neighbors);
            }

            public string ToString()
            {
                return value.ToString();
            }
        }

        public static void Main(string[] args)
        {
            void Problem1()
            {
                Message("shuffles an array of 32 pairs of images and prints it", 1);
                List<AnAdequateImageStructToAdequatePeople> list = new List<AnAdequateImageStructToAdequatePeople>();
                for (int i = 1; i <= 32; i++)
                {
                    list.Add(new AnAdequateImageStructToAdequatePeople(string.Format(PATH, i)));
                    list.Add(new AnAdequateImageStructToAdequatePeople(string.Format(PATH, i)));
                }
                Random rnd = new Random();
                for (int i = 0; i < 64; i++)
                {
                    int n = rnd.Next(0, 63);
                    AnAdequateImageStructToAdequatePeople temp = list[n];
                    list[i] = list[n];
                    list[n] = list[i];
                }
                Console.WriteLine("The shuffled array:");
                for (int i = 0; i < 64; i++)
                {
                    Console.WriteLine($"Number {i + 1}: {list[i].path}");
                }
            }

            void Problem2()
            {
                Message("reads info about students from the file", 2);
                string[] file = File.ReadAllLines("../../data/Students.txt");
                Dictionary<int, Student> studs = new Dictionary<int, Student>();
                for (int i = 0; i < 10; i ++)
                {
                    studs.Add(i, Student.DoStudent(file[i]));
                }
                bool term = true;
                while (term)
                {
                    Console.WriteLine("Введите \"Добавить Имя;Фамилия;Год.Месяц.День;Название_экзамена;БаллПоЭкзамену\" чтобы добавить студента," +
                        "\"Список\", чтобы вывести список студентов, \"Сортировать\" чтобы сортировать студентов по их баллам ," +
                        "\"Удалить Фамилия;Имя\" чтобы удалить студента по имени и фамилии, или \"Стоп\" чтобы завершить:");
                    Offer();
                    string[] input = Console.ReadLine().Trim().Split(' ');
                    switch (input[0].ToLower())
                    {
                        case "добавить": studs.Add(studs.Count + 1, Student.DoStudent(input[1])); break;
                        case "список": Student.List(studs); break;
                        case "сортировать": studs = Student.Sort(studs); break;
                        case "удалить": studs = Student.Remove(studs, input[1]); break;
                        case "стоп": term = false; break;
                        default: Console.WriteLine("Неверный ввод"); break;
                    }
                }
            }

            void Problem4()
            {
                Message("do deep-first search of the graph", 4);
                Node a = new Node(1);
                Node b = new Node(2, a);
                Node c = new Node(3, b, a);
                Node d = new Node(4, b, c);
                Node e = new Node(5, a);
                Node f = new Node(6, e);
                List<Node> nodes = new List<Node>
                {
                    a, b, c, d, e, f
                };
                DeepFirstSearch(a, 6, out Node g);
                Console.WriteLine(g.value);
                DeepFirstSearch(a, 100, out g);
                Console.WriteLine(g.value);
            }

            bool run = true;
            while (run)
            {
                Console.WriteLine();
                Console.WriteLine("||===========================<\\\\>===========================||");
                Console.WriteLine("Please, input a number of a task (1-4) or type \"exit\" to stop:");
                Offer();
                switch (Console.ReadLine().ToLower().Trim())
                {
                    case "1": Problem1(); break;
                    case "2": Problem2(); break;
                    //case "3": Problem3(); break;
                    case "4": Problem4(); break;
                    case "exit": run = false; break;
                    default: Console.WriteLine("This is not a command or a number of task"); break;
                }
            }
        }
    }
}
