using System;
using System.Collections.Generic;
using System.Linq;
using QBS_training_Help;

namespace QBS_training.SchoolFile
{
    internal class Student
    {
        public string Name { get; set; }

        private Subject Subjects { get; set; }

        public Student(string name, Subject subjects)
        {
            Name = name;
            Subjects = subjects;
        }

        /// <summary>
        /// This method calculates the student's average based on the total marks divided by the number of subjects return it
        /// </summary>
        /// <returns></returns>
        private double Average()
        {
            return ((double)Total() / Subjects.Length());
        }

        /// <summary>
        /// This method calculates the s total marks and return it
        /// </summary>
        /// <returns></returns>
        private int Total()
        {
            return Subjects.TotalMarks();
        }

        /// <summary>
        /// This method returns the student's assessment with symbols as a string
        /// </summary>
        /// <returns></returns>
        private string Grade()
        {
            var grade = (int)(Convert.ToInt32(Average()) / 10.0 + 0.5);

            if (grade == 5) grade++;
            else if (grade == 10) grade--;

            return char.ConvertFromUtf32(10 - grade + 64);
        }

        /// <summary>
        /// This method finds the highest score among the list of students and returns its Name
        /// </summary>
        /// <param name="students"></param>
        /// <returns></returns>
        public static string TopStudent(List<Student> students)
        {
            if (Help.isEmptyList(students))
                return "No students have been added";

            var max = students[0].Average();
            var stdName = students[0].Name;

            foreach (var x in students.Where(x => x.Average() > max))
            {
                max = x.Average();
                stdName = x.Name;
            }


            return "topper student Name : " + stdName + "  who's average is maximum : " + max.ToString("0.#####");
        }

        /// <summary>
        ///  This method edit subject Mark to new value
        /// and receive the subject whose value is to be changed
        /// and set sbjMark as the subject Mark
        /// </summary>
        /// <param name="subjectName">subject whose value is to be changed</param>
        /// <param name="mark">set sbjMark as the new value of subject Mark</param>
        public void SetMark(string subjectName, int mark)
        {
            Subjects.EditMark(subjectName, mark);
        }

        /// <summary>
        /// This method return Student Name,marks,Total,Average and Grade of subject as a string
        /// </summary>
        /// <returns></returns>
        public string ToStringStudentDetails()
        {
            var result = Name;
            foreach (var subject in Subjects.SubjectList)
            {
                result += "  |  " + subject.Mark;
            }

            result += "  |  " + Total() + "  |  " + Average().ToString("0.#####") + "  |  " + Grade();

            return result;
        }

        /// <summary>
        /// This method return "Name",subject Name,"Total","Average" and "Grade" of subject as a string
        /// </summary>
        /// <returns></returns>
        public string HeadOfStudentDetails()
        {
            return "Name" + Subjects.SubjectTitle() + "    |    " + "Total" + "    |    " + "Average" + "    |    " +
                   "Grade";
        }
    }
}