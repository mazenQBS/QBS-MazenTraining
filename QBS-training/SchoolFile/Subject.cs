using System;
using System.Collections.Generic;

namespace QBS_training.SchoolFile
{
    internal class Subject
    {
        private string SubjectName { get; set; }
        
        public int Mark { get; private set; }
        
        public List<Subject> SubjectList;
        
        public Subject()
        {
            SubjectList = new List<Subject>();
            SubjectName = "";  
            Mark = 0;
        }

        /// <summary>
        /// It adds a subject and the SubjectName of the subject =subjectName and sets the zero Mark as the default value
        /// </summary>
        /// <param name="subjectName"></param>
        public void AddSubject(string subjectName)
        {
            SubjectList.Add(new Subject(){SubjectName = subjectName});
        }

        /// <summary>
        /// It adds a subject and the SubjectName of the subject =subjectName and the Mark of the subject=mark
        /// </summary>
        /// <param name="subjectName"></param>
        /// <param name="mark"></param>
        public void AddSubject(string subjectName, int mark)
        {
            SubjectList.Add(new Subject() { SubjectName = subjectName, Mark = mark });
        }

        /// <summary>
        /// Deletes the subject based on the SubjectName
        /// </summary>
        /// <param name="subjectName"></param>
        public void DeleteSubject(string subjectName)
        {
            if (!IsExist(subjectName))
                Console.WriteLine("this subjects does not exist");
            else
                SubjectList.RemoveAt(IndexOfSubject(subjectName));
        } 

        /// <summary>
        /// return the size of subject list 
        /// Or we can say the number of subject
        /// </summary>
        /// <returns></returns>
        public int Length()
        {
            return SubjectList.Count;
        }

        /// <summary>
        /// return the index as int location in subject list based on the SubjectName
        /// </summary>
        /// <param name="subjectName"></param>
        /// <returns></returns>
        public int IndexOfSubject(string subjectName)
        {
            int index;

            for (index = 0; index < SubjectList.Count; index++)
            {
                if (SubjectList[index].SubjectName == subjectName)
                {
                    return index;
                }
            }

            return -1;
        }

        /// <summary>
        /// return true if the subject is exist in list based on the SubjectName
        /// or return false if not
        /// </summary>
        /// <param name="subjectName"></param>
        /// <returns></returns>
        private bool IsExist(string subjectName)
        {
            return IndexOfSubject(subjectName) != -1;
        }

        /// <summary>
        /// Modifies the subject Mark based on the SubjectName
        /// </summary>
        /// <param name="subjectName"></param>
        /// <param name="mark"></param>
        public void EditMark(string subjectName, int mark)
        {
            int index = IndexOfSubject(subjectName);
            SubjectList[index].Mark = mark;
        }

        /// <summary>
        /// This method calculates the sum of all Mark
        /// 
        /// </summary>
        /// <returns></returns>
        public int TotalMarks()
        {
            int sum = 0;
            foreach (Subject x in SubjectList)
            {
                sum += x.Mark;
            }

            return sum;
        }

        /// <summary>
        /// This method return names of subject as a string
        /// </summary>
        /// <returns></returns>
        public string SubjectTitle()
        {
            string result = "";
            foreach (Subject x in SubjectList)
            {
                result += "  |  " + x.SubjectName;
            }

            return result;
        }
    }
}
