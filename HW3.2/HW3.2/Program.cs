﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3._2
{
    class Program
    {
        public static bool isInputFinished = true;
        public static void Start()
        {

            Console.WriteLine("Please enter students and their marks: (enter 'stop' to finish)");
            Dictionary<string, int> students = new Dictionary<string, int>();

            while (isInputFinished)
            {
                try
                {


                    string EnteredStr = Console.ReadLine();
                    if (EnteredStr == "stop")
                    {
                        isInputFinished = false;
                        break;
                    }

                    string[] surname_key = EnteredStr.Split(new char[] { ':' });
                    string studentSurname = surname_key[0];
                    int studentMark = Convert.ToInt32(surname_key[1]);
                    if (studentMark < 1 || studentMark > 5)
                    {
                        Console.WriteLine("Mark should be a number from 1 to 5. Try again");
                        continue;
                    }
                    students.Add(studentSurname, studentMark);


                }
                catch (System.IndexOutOfRangeException e)
                {
                    Console.WriteLine("Input has wrong format! Desired format: 'Surname:Mark'");
                    Console.WriteLine("Mark should be a number from 1 to 5'");
                    continue;
                }
            }

            
            Console.WriteLine();
            DictionaryDisplay(students);
            
        }

        public static void DictionaryDisplay(Dictionary<string, int> dic)
        {
           
            
            while (true)
            {
                Console.WriteLine("Please enter surname to see student's mark or a mark to see all students with it:");
            Console.WriteLine("Or enter 'exit' to exit");
                
                try{

                string temp = Console.ReadLine();
                if (temp == "exit")
                {
                    isInputFinished = false;
                    break;
                }

                if (isDigit(temp) == true)
                {
                    int count = 0;
                    int mark = Convert.ToInt32(temp);
                    Console.WriteLine($"Students with {mark} mark:");
                    foreach (var item in dic)
                    {
                            
                        if (item.Value == mark)
                        {
                                
                            Console.Write($"{item.Key}" + " ");
                               
                        }
                        else{
                            count++;
                            
                            }
                        Console.WriteLine();
                    }

                    if(count==dic.Count){
                        Console.WriteLine($"There are no students with {mark} mark");
                            
                    }

                    
                }
                else
                {
                    Console.WriteLine($"Student {temp} received a {dic[temp]}");
                    
                    Console.WriteLine();                    
                    
                }
                } catch(System.FormatException e2){
                    Console.WriteLine("Input has wrong format");
                    Console.WriteLine();
                    continue;
                } catch(System.Collections.Generic.KeyNotFoundException e3){
                    Console.WriteLine("Input has wrong format");
                    Console.WriteLine();
                    continue;
                }


            }
        }

        public static bool isDigit(string str)
        {
            for(int i = 0; i < str.Length; i++)
            {
                if(str[i] >= '0' && str[i] <= '9')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            
            return true;


        }
        static void Main(string[] args)
        {
            Start();

            

            Console.ReadLine();
        }
    }
}
