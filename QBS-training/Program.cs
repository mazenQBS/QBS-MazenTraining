using System;
using System.Text;
using QBS_training.ChefFile;
using QBS_training_School;


namespace QBS_training
{
     class Program
    {
        protected Program() { }
        static string DecisionMassageAll() {
            return  "press 1 to class room\n" +
                    "press 2 to stydent";
        }
        static string DecisionMassageClassRoom()
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

        static string DecisionMassageStudent()
        {
            return  "press 1 to add Student\n" +
                    "press 2 to delete Student\n" +
                    "press 3 to Edit Student name\n" +
                    "press 4 to Edit Student mark\n" +
                    "press 5 to Print student details\n"
                   ;

        }

        static string DecisionMassageSubLoop() {
            return 
               "press 1 to show list again\n" +
               "press any thing else to Back to main menu\n" 
               
              ;
        }

        static string DecisionMassageMainLoop()
        {
            return
               "press 1 to show list again\n" +
               "press any thing else to end\n"

              ;
        }
        
        static void ToStudent() { 
        
        
         

            School s1 = new School("QBS");

            ///////////////////////////////////////////////////////////////////////
            s1.addClassRoom("a");
            s1.addSubjectToClassRoom("a","math");
            s1.addStudent("mazen","a");


            ///////////////////////////////////////////////////////////////////////


            bool flag = true;
            while (flag)
            {
                Console.WriteLine(DecisionMassageAll());
                int decision = Convert.ToInt32(Console.ReadLine());

                switch (decision)
                {
                    //class room
                    case 1:

                        bool d2Flag = true;
                        while (d2Flag)
                        {
                            Console.WriteLine(DecisionMassageClassRoom());
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

                            Console.WriteLine(DecisionMassageSubLoop());
                            int des1 = Convert.ToInt32(Console.ReadLine());

                            d2Flag = des1 == 1;
                                

                        }
                        break;//end case 1

                    case 2:
                        bool d3Flag = true;
                        while (d3Flag)
                        {
                            Console.WriteLine(DecisionMassageStudent());
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

                            Console.WriteLine(DecisionMassageSubLoop());
                            int des2 = Convert.ToInt32(Console.ReadLine());
                           
                            d3Flag = des2 == 1;
                        }
                        break;


                }

                Console.WriteLine(DecisionMassageMainLoop());
                int des = Convert.ToInt32(Console.ReadLine());

                flag = des == 1;
               

            }

        
        }

        static void ToChef() {
            ChefUserControl chef = new ChefUserControl();
            Chef inChef = new IndianChef();
            Chef arChef = new ArabicChef();
            Chef itChef = new ItalianChef();


            chef.UserMenu.ChefDerivedClass = inChef;
            chef.UserMenu.AddChoice( 1, new StringBuilder("indian food") );
            chef.UserMenu.ChefDerivedClass = arChef;
            chef.UserMenu.AddChoice( 2, new StringBuilder("arabic food") );
            chef.UserMenu.ChefDerivedClass = itChef;
            chef.UserMenu.AddChoice( 3, new StringBuilder("italian food") );

            Console.WriteLine(chef.UserMenu.ToString());
            Console.Write("Choose the type of food you like : ");
            int choice = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine( chef.GetObject(choice).ToStringChefResponsible() );

        }

        static void Main(string[] args)
        {

            ToChef();
            


        }
    }

     
}
