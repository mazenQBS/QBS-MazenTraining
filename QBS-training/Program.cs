using System;
using System.Collections.Generic;
using System.Globalization;
using QBS_training_School;
using QBS_training_restaurant;

namespace QBS_training
{
     class Program
    {
        protected Program() { }
        static string decisionMassageAll() {
            return  "press 1 to class room\n" +
                    "press 2 to stydent";
        }
        static string decisionMassageClassRoom()
        {
            return "press 1 to add classroom\n" +
                    "press 2 to delet classroom\n" +
                    "press 3 to add subject to specific classroom\n" +
                    "press 4 to add subject to all classroom\n" +
                    "press 5 to delete subject to specific classroom\n" +
                    "press 6 to delete subject to all classroom\n"+
                    "press 7 to print classroom details\n"
                    ;

        }

        static string decisionMassageStudent()
        {
            return  "press 1 to add Student\n" +
                    "press 2 to delete Student\n" +
                    "press 3 to Edit Student name\n" +
                    "press 4 to Edit Student mark\n" +
                    "press 5 to Print student details\n"
                   ;

        }

        static string decisionMassageSubLoop() {
            return 
               "press 1 to show list again\n" +
               "press any thing else to Back to main menu\n" 
               
              ;
        }

        static string decisionMassageMainLoop()
        {
            return
               "press 1 to show list again\n" +
               "press any thing else to end\n"

              ;
        }

        static void printChefType(Chef chef) {

            Console.WriteLine(chef.PrintChefOfTheOrder());
        
        }

        static string typeOfFood() {
            return "1-italian food\n 2-indian food\n 3-arabic food\n";
        }

        static void toStudent() { 
        
        
         

            School s1 = new School("QBS");

            ///////////////////////////////////////////////////////////////////////
            s1.addClassRoom("a");
            s1.addSubjectToClassRoom("a","math");
            s1.addStudent("mazen","a");


            ///////////////////////////////////////////////////////////////////////


            bool flag = true;
            while (flag)
            {
                Console.WriteLine(decisionMassageAll());
                int decision = Convert.ToInt32(Console.ReadLine());

                switch (decision)
                {
                    //class room
                    case 1:

                        bool d2Flag = true;
                        while (d2Flag)
                        {
                            Console.WriteLine(decisionMassageClassRoom());
                            int decision2 = Convert.ToInt32(Console.ReadLine());
                        
                            switch (decision2)
                            {
                                case 1:

                                    Console.WriteLine("Enter Name Of classroom To Add");
                                    string schoolNameToAdd = Console.ReadLine();

                                    s1.addClassRoom(schoolNameToAdd);

                                    break;//end case 1

                                case 2:
                                    Console.WriteLine("Enter Name Of classroom To Delete");
                                    string schoolNameToDelete = Console.ReadLine();

                                    s1.deleteClassRoom(schoolNameToDelete);
                                    break;//end case 2

                                case 3:

                                    Console.WriteLine("Enter the classroom you want to add a subject to");
                                    string classRoomNameToAddSubject = Console.ReadLine();

                                    Console.WriteLine("Enter Name Of subject To Add");
                                    string subjectNameToAdd = Console.ReadLine();

                                    s1.addSubjectToClassRoom(classRoomNameToAddSubject,subjectNameToAdd);

                                    break;//end case 3

                                case 4:
                                    Console.WriteLine("Enter a subject name to add to each classroom");
                                    string subjectNameToAddAll = Console.ReadLine();

                                    s1.addSubjectToAllClassRoom(subjectNameToAddAll);

                                    break;//end case 4

                                case 5:
                                    Console.WriteLine("Enter the classroom you want to delete a subject to");
                                    string classRoomNameToDeleteSubject = Console.ReadLine();

                                    Console.WriteLine("Enter Name Of subject  To delete");
                                    string subjectNameToDelete = Console.ReadLine();

                                    s1.deleteSubjectFromClassRoom(classRoomNameToDeleteSubject, subjectNameToDelete);

                                    break;//end case 5

                                case 6:
                                    Console.WriteLine("Enter a subject name to delete to each classroom");
                                    string subjectNameToDeleteAll = Console.ReadLine();

                                    s1.deleteSubjectFromAllClassRoom(subjectNameToDeleteAll);
                                    break;//end case 6

                                case 7:

                                    Console.WriteLine("Enter Name Of classroom To print details");
                                    string classRoomName = Console.ReadLine();

                                    Console.WriteLine(s1.printClassRoomDetails(classRoomName));

                                    break;


                            }

                            Console.WriteLine(decisionMassageSubLoop());
                            int des1 = Convert.ToInt32(Console.ReadLine());

                            d2Flag = des1 == 1;
                                

                        }
                        break;//end case 1

                    case 2:
                        bool d3Flag = true;
                        while (d3Flag)
                        {
                            Console.WriteLine(decisionMassageStudent());
                            int decision3 = Convert.ToInt32(Console.ReadLine());

                            switch (decision3)
                            {
                                case 1:
                                    Console.Write("Enter student name : ");
                                    string studentNameToAdd = Console.ReadLine();

                                    Console.Write("Enter classroom name : ");
                                    string classRoomNameToAdd = Console.ReadLine();

                                    s1.addStudent(studentNameToAdd, classRoomNameToAdd);

                                    break;//end case 1

                                case 2:
                                    Console.Write("Enter student name : ");
                                    string studentNameToDelete = Console.ReadLine();

                                    Console.Write("Enter classroom name : ");
                                    string classRoomNameToDelete = Console.ReadLine();

                                    s1.deleteStudent(studentNameToDelete, classRoomNameToDelete);

                                    break;//end case 2

                                case 3:
                                    Console.Write("Enter classroom name : ");
                                    string classRoomToEditName = Console.ReadLine();

                                    Console.Write("Enter student name : ");
                                    string studentNameToEditName = Console.ReadLine();

                                    Console.Write("Enter new student name : ");
                                    string NewstudentNameToEditName = Console.ReadLine();

                                    s1.editStudentName(studentNameToEditName, classRoomToEditName, NewstudentNameToEditName);

                                    break;//end case 3

                                case 4:
                                    Console.Write("Enter classroom name : ");
                                    string classRoomToEditMark = Console.ReadLine();

                                    Console.Write("Enter student name : ");
                                    string studentNameToEditMark = Console.ReadLine();

                                    Console.Write("Enter subject name : ");
                                    string subjectName = Console.ReadLine();

                                    Console.Write("Enter mark : ");
                                    int mark = Convert.ToInt32(Console.ReadLine());

                                    s1.editStudentMark(studentNameToEditMark, classRoomToEditMark, subjectName, mark);

                                    break;//end case 4

                                case 5:
                                    Console.Write("Enter classroom name : ");
                                    string classRoomToPrint = Console.ReadLine();

                                    Console.Write("Enter student name : ");
                                    string studentNameToPrint = Console.ReadLine();

                                    Console.WriteLine(s1.printstudentDatails(studentNameToPrint, classRoomToPrint));

                                    break;//end case 4
                            }

                            Console.WriteLine(decisionMassageSubLoop());
                            int des2 = Convert.ToInt32(Console.ReadLine());
                           
                            d3Flag = des2 == 1;
                        }
                        break;


                }

                Console.WriteLine(decisionMassageMainLoop());
                int des = Convert.ToInt32(Console.ReadLine());

                flag = des == 1;
               

            }






            /*
             * 
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
                       // Student newStudent = new Student(stdname);
                       // std.Add(newStudent);
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

             */

        
        
        
        
        
        }

        static void toChef_old() {

            ItalianChef chef1 = new ItalianChef();

            IndianChef chef2 = new IndianChef();

            ArabicChef chef3 = new ArabicChef();


            bool flag = true;
            while (flag)
            {

                Console.WriteLine("Choose a type of food\n " + typeOfFood());
                int des = Convert.ToInt32(Console.ReadLine());
                switch (des)
                {

                    case 1:
                        printChefType(chef1);
                        break;
                    case 2:
                        printChefType(chef2);
                        break;
                    case 3:
                        printChefType(chef3);
                        break;
                }
                Console.WriteLine(decisionMassageMainLoop());
                int des2 = Convert.ToInt32(Console.ReadLine());
                flag = des2 == 1;

            }

        }

        static void toChef() {
            ChefUserControl chef = new ChefUserControl();
            Chef inChef = new IndianChef();
            Chef arChef = new ArabicChef();
            Chef itChef = new ItalianChef();



            chef.userMenu.addChoice(1, "indian food", inChef);
            chef.userMenu.addChoice(2, "arabic food", arChef);
            chef.userMenu.addChoice(3, "italian food", itChef);

            Console.WriteLine(chef.userMenu.ToString());
            Console.Write("Choose the type of food you like : ");
            int choice = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine(
                chef.userMenu.userMenuList[chef.userMenu.indexOf(choice)].objectDriver.PrintChefOfTheOrder()
            );

        }

        static void Main(string[] args)
        {


           toChef();

           
            


        }
    }
}
