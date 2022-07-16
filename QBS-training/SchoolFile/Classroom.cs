using System.Collections.Generic;

namespace QBS_training.SchoolFile
{
    internal class Classroom
    {
        public string Name { get; set; }
        
        public Subject Subjects { get; set; }

        List<Student> Students;

        public Classroom()
        {
            Name = "";
            Subjects = new Subject();
            Students = new List<Student>();
        }

        public Classroom(string classroomName)
        {
            Name = classroomName;
            Subjects = new Subject();
            Students = new List<Student>();
        }

        public Classroom(string name, List<Subject> subjectList)
        {
            Name = name;
            this.Subjects = new Subject();
            Students = new List<Student>();
            this.Subjects.SubjectList = subjectList;
        }

        public void AddStudentToClassroom(string studentName)
        {
            Students.Add( new Student(studentName, Subjects) );
        }

        public void DeleteStudentFromClassroom(string studentName)
        {
            Students.RemoveAt(IndexOfStudent(studentName));
        }

        private int IndexOfStudent(string studentName)
        {
            int i;
            for (i = 0; i < Students.Count; i++)
                if (Students[i].Name == studentName)
                    return i;
            return -1;
        }

        public Student GetStudent(string studentName)
        {
            return Students[IndexOfStudent(studentName)];
        }

        public string ListOfStudentsNames()
        {
            string result = "";
            foreach (Student x in Students)
            {
                result += "  |  " + x.Name;
            }

            return result;
        }
    }
}
