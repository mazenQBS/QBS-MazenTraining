namespace QBS_training.SchoolFile
{
    public class StudentInfo
    {
        public StudentInfo(string studentName, string belongsClassroom)
        {
            StudentName = studentName;
            BelongsClassroom = belongsClassroom;
        }

        public string StudentName { get; private set; }
        public string BelongsClassroom { get; private set; }
    }
}