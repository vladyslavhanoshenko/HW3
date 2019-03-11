using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class Program
    {
        public static bool isStudentInputFinished = true;
        public static bool isExitButtonPressed = true;

        public static Dictionary<string,List<Student>> group = new Dictionary<string, List<Student>>();
        public static void DisplayGroup()
        {

        }

        public static List<Student> CreateNewStudent()
        {
            List<Student> studentTemp = new List<Student>();

            string surname;
            int yearOfBirth;
            while (isStudentInputFinished)
            {
                try
                 {


                Console.WriteLine("Please enter students in format 'Surname1:YearOfBirth1, Surname2:YearOfBirth2'");

                //Console.WriteLine("Or enter 'exit' to exit");
                string temp1 = Console.ReadLine();

                string[] mixSurnameAndYears = temp1.Split(new char[] { ':' });
                surname = mixSurnameAndYears[0];
                yearOfBirth = Convert.ToInt32(mixSurnameAndYears[1]);

                studentTemp.Add(new Student(surname, yearOfBirth));

                Console.Write("Students added");
                Console.WriteLine("Enter 'submit' to stop input or 'continue' to continue input");

                temp1 = Console.ReadLine();
                if (temp1 == "submit")
                {
                    isStudentInputFinished = false;
                    break;
                }
                else if (temp1 == "continue")
                {
                    continue;
                }


                }
                catch(System.IndexOutOfRangeException e1){
                    Console.WriteLine("Wrong input. Try again");
            }
            }
            return studentTemp;
        }
                

            

        

        public static List<Student> CreateNewGroup(string groupName)
        {
            Console.WriteLine("There are no group with 'new group' code. Do you want to add it? (y/n)");
            string temp = Console.ReadLine();


            List<Student> studentTemp = new List<Student>();


            if (temp == "y" || temp == "Y")
            {
                studentTemp = CreateNewStudent();
                group.Add(groupName, studentTemp);
                Console.WriteLine($"Group {groupName} is added! ");








            }

            


            return studentTemp;
        }

        public static bool CheckGroup(string temp)
        {
            try
            {


                if (temp == "exit")
                {
                    return false;
                }

                foreach (var item in group)
                {
                    if (temp == item.Key)
                    {
                        foreach (var test in item.Value)
                        {
                            Console.Write(test.Surname + ":" + test.YearOfBirth + " ");
                        }
                        Console.WriteLine();
                        continue;

                    }
                    else
                    {
                        CreateNewGroup(temp);
                        break;

                    }
                }
            }catch(System.InvalidOperationException e2){
                Console.WriteLine("stop");
}
            return true;
        }
        


        static void Main(string[] args)
        {
            Student s1 = new Student("Horbachenko", 1995);
            Student s2 = new Student("Hanoshenko", 2001);
            List<Student> students = new List<Student>();
            students.Add(s1);
            students.Add(s2);
            string key1 = "TV21";
            group.Add(key1, students);

            while (isExitButtonPressed)
            {


                Console.WriteLine("Please enter group code. Enter 'exit' to exit:");
                string temp = Console.ReadLine();

                CheckGroup(temp);
                
            }


            Console.ReadLine();
        }
    }

    class Student
    {
        private string surname;
        private int yearOfBirth;

        public Student() { }

        public Student(string surname, int yearOfBirth)
        {
            this.surname = surname;
            this.yearOfBirth = yearOfBirth;
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public int YearOfBirth
        {
            get { return yearOfBirth; }
            set { yearOfBirth = value; }
        }

        public void DisplayInfo()
        {
            Console.WriteLine(Surname + ":" + YearOfBirth);
        }
    }
}
