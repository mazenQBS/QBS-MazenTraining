using System;
using System.Collections.Generic;
using System.Globalization;

namespace QBS_training
{
    class Program
    {
        static string decisionMassage() {
            return  "press 1 to add new record\n" +
                    "press q to exit and show result";
        }
      
        static void Main(string[] args)
        {
 
            List < Student > std= new List<Student>();
            bool flag = true;
            int numvberOfStudent = 0;

            Console.WriteLine("Hello \n" + decisionMassage());

            while (flag)
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Enter student name : ");
                        string stdname = Console.ReadLine();
                        Student newStudent = new Student(stdname);
                        std.Add(newStudent);
                        std[numvberOfStudent].fill();
                        numvberOfStudent++;
                        Console.WriteLine(decisionMassage());
                        break;

                    case "q":
                        foreach (Student x in std) 
                        {
                            Console.WriteLine(x.titel()) ;
                            Console.WriteLine(x.print()) ;
                        }
                        
                        Console.WriteLine(Student.topStudent(std));
                        flag = false;
                        break;


                    default:
                        Console.WriteLine("wrong answer \n" + decisionMassage());
                        break;
                }

          






        }
    }
}
