namespace QBS_training.SchoolFile
{
    class SchoolDecisionMassage
    {
        public static string DecisionMassageAll()
        {
            return "press 1 to class room\n" +
                   "press 2 to student";
        }

        public static string DecisionMassageClassRoom()
        {
            return "press 1 to Show classroom\n" +
                   "press 2 to delete classroom\n" +
                   "press 3 to Show subject to specific classroom\n" +
                   "press 4 to Show subject to all classroom\n" +
                   "press 5 to delete subject to specific classroom\n" +
                   "press 6 to delete subject to all classroom\n" +
                   "press 7 to ToStringStudentDetails classroom details\n"
                ;
        }

        public static string DecisionMassageStudent()
        {
            return "press 1 to Show Student\n" +
                   "press 2 to delete Student\n" +
                   "press 3 to Edit Student Name\n" +
                   "press 4 to Edit Student Mark\n" +
                   "press 5 to ToStringStudentDetails student details\n"
                ;
        }

        public static string DecisionMassageSubLoop()
        {
            return
                "press 1 to show list again\n" +
                "press any thing else to Back to main menu\n"
                ;
        }

        public static string DecisionMassageMainLoop()
        {
            return
                "press 1 to show list again\n" +
                "press any thing else to end\n"
                ;
        }
    }
}