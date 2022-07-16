namespace QBS_training.SchoolFile
{
    public class SubjectInfo
    {
        public SubjectInfo(string classroomName, string subjectName)
        {
            ClassroomName = classroomName;
            SubjectName = subjectName;
        }

        public string ClassroomName { get; private set; }
        public string SubjectName { get; private set; }
    }
}