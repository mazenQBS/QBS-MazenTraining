using System.Collections.Generic;


namespace QBS_training.SchoolFile
{
    public class School
    {
        private List<Classroom> _classrooms;
        private string Name { get; set; }

        public School(string name)
        {
            Name = name;
            _classrooms = new List<Classroom>();
        }

        /// <summary>
        /// This method is adding a classroom to the school
        /// </summary>
        /// <param name="classroomName">The Name of the class to be added</param>
        public void AddClassroom(string classroomName)
        {
            _classrooms.Add(new Classroom(classroomName));
        }

        /// <param name="classroomName"></param>
        public void DeleteClassroom(string classroomName)
        {
            _classrooms.RemoveAt(IndexOfClassroom(classroomName));
        }

        public void AddSubjectToClassroom(SubjectInfo subjectInfo)
        {
            _classrooms[IndexOfClassroom(subjectInfo.ClassroomName)]
            .Subjects.AddSubject(subjectInfo.SubjectName);
        }

        public void AddSubjectToAllClassroom(string subjectName)
        {
            foreach (var classroom in _classrooms)
            {
                classroom.Subjects.AddSubject(subjectName);
            }
        }

        public void DeleteSubjectFromClassroom(SubjectInfo subjectInfo)
        {
            _classrooms[IndexOfClassroom(subjectInfo.ClassroomName)]
            .Subjects.DeleteSubject(subjectInfo.SubjectName);
        }

        public void DeleteSubjectFromAllClassroom(string subjectName)
        {
            foreach (var classroom in _classrooms)
            {
                classroom.Subjects.DeleteSubject(subjectName);
            }
        }

        public void AddStudentToSchool(StudentInfo studentInfo)
        {
            _classrooms[IndexOfClassroom(studentInfo.BelongsClassroom)]
            .AddStudentToClassroom(studentInfo.StudentName);
        }

        public void DeleteStudentFromSchool(StudentInfo studentInfo)
        {
            _classrooms[IndexOfClassroom(studentInfo.BelongsClassroom)].
                DeleteStudentFromClassroom(studentInfo.StudentName);
        }

        public void EditStudentName(StudentInfo studentInfo, string newStudentName)
        {
            var student = _classrooms[IndexOfClassroom(studentInfo.BelongsClassroom)].GetStudent(studentInfo.StudentName);
            student.Name = newStudentName;
        }
        public void EditStudentMark(StudentInfo studentInfo, string subjectName, int subjectMark)
        {
            var student = _classrooms[IndexOfClassroom(studentInfo.BelongsClassroom)]
                .GetStudent(studentInfo.StudentName);

            student.SetMark(subjectName, subjectMark);
        }
        public string ToStringClassroomsDetails(string classroomName)
        {
            var classroom = _classrooms[IndexOfClassroom(classroomName)];

            return "classroom Name : " + classroom.Name + "\n" +
                   "=================================================================" +
                   "subject in this classroom : \n" + classroom.Subjects.SubjectTitle() + "\n" +
                   "=================================================================" +
                   "student in this classroom : \n" + classroom.ListOfStudentsNames();
        }

        public string ToStringStudentDetails(StudentInfo studentInfo)
        {
            var student = _classrooms[IndexOfClassroom(studentInfo.BelongsClassroom)].GetStudent(studentInfo.StudentName);
            var classroom = _classrooms[IndexOfClassroom(studentInfo.BelongsClassroom)];
            return
                "\n=====================================================================\n" +
                "student information" +
                "\n=====================================================================\n" +
                "This student's Name is " + student.Name + " studying in classroom " + classroom.Name +
                "\n=====================================================================\n" +
                "Student marks" +
                "\n=====================================================================\n" +
                student.HeadOfStudentDetails() + "\n" +
                student.ToStringStudentDetails()
                ;
        }

        private int IndexOfClassroom(string classRoomName)
        {
            int i;

            for (i = 0; i < _classrooms.Count; i++)
            {
                if (_classrooms[i].Name == classRoomName)
                    return i;
            }

            return -1;
        }
    }
}