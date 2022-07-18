using System;
using System.Text;
using QBS_training.ChefFile;
using QBS_training.LinqFile;
using QBS_training.SchoolFile;


namespace QBS_training
{
    class Program
    {
        protected Program()
        {
        }

        private static void ToStudent()
        {
            var school = new School("QBS");

            ///////////////////////////////////////////////////////////////////////
            school.AddClassroom("a");
            school.AddSubjectToClassroom(new SubjectInfo("a","math"));
            school.AddStudentToSchool(new StudentInfo("mazen", "a"));


            ///////////////////////////////////////////////////////////////////////



            do
            {
                switch (MainListOptionNumber())
                {
                    //class room


                    case 1:

                        ClassroomList(school);

                            break; //end case 1

                    case 2:
                        
                        StudentList(school);

                            break;
                }
            }
            while (IsOptionGoToMainMenu());
        }

        private static void StudentList(School school)
        {
            do
            {
                switch (StudentListOptionNumber())
                {
                    case 1:
                        AddStudent(school);

                        break; //end case 1

                    case 2:
                        DeleteStudent(school);

                        break; //end case 2

                    case 3:
                        EditStudentName(school);

                        break; //end case 3

                    case 4:
                        EditStudentMark(school);

                        break; //end case 4

                    case 5:
                        StudentDetails(school);

                        break; //end case 4
                }
            } while (IsOptionShowListAgain());
        }

        private static void ClassroomList(School school)
        {
            do
            {
                switch (ClassroomListOptionNumber())
                {
                    case 1:

                        AddClassroom(school);

                        break; //end case 1

                    case 2:
                        DeleteClassroom(school);
                        break; //end case 2

                    case 3:

                        AddSubject(school);

                        break; //end case 3

                    case 4:
                        AddSubjectToAllClassroom(school);

                        break; //end case 4

                    case 5:
                        DeleteSubject(school);

                        break; //end case 5

                    case 6:
                        DeleteSubjectFromAllClassroom(school);
                        break; //end case 6

                    case 7:

                        ClassroomsDetails(school);

                        break;
                }
            } while (IsOptionShowListAgain());
        }

        private static int StudentListOptionNumber()
        {
            Console.WriteLine(SchoolDecisionMassage.DecisionMassageStudent());
            int decision3 = Convert.ToInt32(Console.ReadLine());
            return decision3;
        }

        private static bool IsOptionGoToMainMenu()
        {
            Console.WriteLine(SchoolDecisionMassage.DecisionMassageMainLoop());
            var goToMainMenu = Convert.ToInt32(Console.ReadLine()) == (int)Option.MainMenu;
            return goToMainMenu;
        }

        private static int MainListOptionNumber()
        {
            Console.WriteLine(SchoolDecisionMassage.DecisionMassageAll());
            int decision = Convert.ToInt32(Console.ReadLine());
            return decision;
        }

        private static bool IsOptionShowListAgain()
        {
            Console.WriteLine(SchoolDecisionMassage.DecisionMassageSubLoop());
            var showListAgain = Convert.ToInt32(Console.ReadLine()) == (int)Option.ShowListAgain;
            return showListAgain;
        }

        private static int ClassroomListOptionNumber()
        {
            Console.WriteLine(SchoolDecisionMassage.DecisionMassageClassRoom());
            int decision2 = Convert.ToInt32(Console.ReadLine());
            return decision2;
        }

        private static void StudentDetails(School school)
        {
            Console.Write("Enter classroom Name : ");
            string classRoomToPrint = Console.ReadLine();

            Console.Write("Enter student Name : ");
            string studentNameToPrint = Console.ReadLine();

            Console.WriteLine(school.ToStringStudentDetails(new StudentInfo(studentNameToPrint, classRoomToPrint)));
        }

        private static void EditStudentMark(School school)
        {
            Console.Write("Enter classroom Name : ");
            var classRoomToEditMark = Console.ReadLine();

            Console.Write("Enter student Name : ");
            var studentNameToEditMark = Console.ReadLine();

            Console.Write("Enter subject Name : ");
            var subjectName = Console.ReadLine();

            Console.Write("Enter Mark : ");
            var mark = Convert.ToInt32(Console.ReadLine());


            school.EditStudentMark(new StudentInfo(studentNameToEditMark, classRoomToEditMark), subjectName, mark);
        }

        private static void EditStudentName(School school)
        {
            Console.Write("Enter classroom Name : ");
            string classRoomToEditName = Console.ReadLine();

            Console.Write("Enter student Name : ");
            string studentNameToEditName = Console.ReadLine();

            Console.Write("Enter new student Name : ");
            string NewstudentNameToEditName = Console.ReadLine();

            school.EditStudentName(new StudentInfo(studentNameToEditName, classRoomToEditName), NewstudentNameToEditName);
        }

        private static void DeleteStudent(School school)
        {
            Console.Write("Enter student Name : ");
            string studentNameToDelete = Console.ReadLine();

            Console.Write("Enter classroom Name : ");
            string classRoomNameToDelete = Console.ReadLine();

            school.DeleteStudentFromSchool(new StudentInfo(studentNameToDelete, classRoomNameToDelete));
        }

        private static void ClassroomsDetails(School school)
        {
            Console.WriteLine("Enter Name Of classroom To show details");
            string classRoomName = Console.ReadLine();

            Console.WriteLine(school.ToStringClassroomsDetails(classRoomName));
        }

        private static void DeleteSubjectFromAllClassroom(School school)
        {
            Console.WriteLine("Enter a subject Name to delete to each classroom");
            string subjectNameToDeleteAll = Console.ReadLine();

            school.DeleteSubjectFromAllClassroom(subjectNameToDeleteAll);
        }

        private static void DeleteSubject(School school)
        {
            Console.WriteLine("Enter the classroom you want to delete a subject to");
            string classRoomNameToDeleteSubject = Console.ReadLine();

            Console.WriteLine("Enter Name Of subject  To delete");
            string subjectNameToDelete = Console.ReadLine();

            school.DeleteSubjectFromClassroom(new SubjectInfo(classRoomNameToDeleteSubject, subjectNameToDelete));
        }

        private static void AddSubjectToAllClassroom(School school)
        {
            Console.WriteLine("Enter a subject Name to Show to each classroom");
            string subjectNameToAddAll = Console.ReadLine();

            school.AddSubjectToAllClassroom(subjectNameToAddAll);
        }

        private static void AddSubject(School school)
        {
            Console.WriteLine("Enter the classroom you want to Show a subject to");
            string classRoomNameToAddSubject = Console.ReadLine();

            Console.WriteLine("Enter Name Of subject To Add");
            string subjectNameToAdd = Console.ReadLine();

            school.AddSubjectToClassroom(new SubjectInfo(classRoomNameToAddSubject, subjectNameToAdd));
        }

        private static void DeleteClassroom(School school)
        {
            Console.WriteLine("Enter Name Of classroom To Delete");
            string schoolNameToDelete = Console.ReadLine();

            school.DeleteClassroom(schoolNameToDelete);
        }

        private static void AddClassroom(School school)
        {
            Console.WriteLine("Enter Name Of classroom To Add");
            string schoolNameToAdd = Console.ReadLine();

            school.AddClassroom(schoolNameToAdd);
        }

        private static void AddStudent(School school)
        {
            Console.Write("Enter student Name : ");
            string studentNameToAdd = Console.ReadLine();

            Console.Write("Enter classroom Name : ");
            string classRoomNameToAdd = Console.ReadLine();

            school.AddStudentToSchool(new StudentInfo(studentNameToAdd, classRoomNameToAdd));
        }

        static void ToChef()
        {
            ChefUserControl chef = new ChefUserControl();
            Chef inChef = new IndianChef();
            Chef arChef = new ArabicChef();
            Chef itChef = new ItalianChef();


            chef.UserMenu.ChefDerivedClass = inChef;
            chef.UserMenu.AddChoice(1, new StringBuilder("indian food"));
            chef.UserMenu.ChefDerivedClass = arChef;
            chef.UserMenu.AddChoice(2, new StringBuilder("arabic food"));
            chef.UserMenu.ChefDerivedClass = itChef;
            chef.UserMenu.AddChoice(3, new StringBuilder("italian food"));

            Console.WriteLine(chef.UserMenu.ToString());
            Console.Write("Choose the type of food you like : ");
            int choice = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine(chef.GetObject(choice).ToStringChefResponsible());
        }

        static void Main(string[] args)
        {

           //ToStudent();
           ToChef();
           







        }
    }

    enum Option
    {
        MainMenu=1,
        ShowListAgain = 1,
        

    }
}