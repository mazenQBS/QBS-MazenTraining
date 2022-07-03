using System;
using System.Collections.Generic;
using System.Text;

namespace QBS_training
{
    class School {
        public string schoolName { get; set; }
        List<ClassRoom> CRList = new List<ClassRoom>();
        public School(string schoolName)  { this.schoolName = schoolName; }

        public void addClassRoom(string classRoomName) {
            ClassRoom newClassRoom = new ClassRoom(classRoomName);
            CRList.Add(newClassRoom);
        }

        public void deleteClassRoom(string classRoomName) {
            CRList.RemoveAt(indexOfCRList(classRoomName));

        }

        public void addSubjectToClassRoom(string classRoomName,string subjectName) 
        {
            ClassRoom CR = CRList[indexOfCRList(classRoomName)];
            CR.subjects.addSbj(subjectName);
        
        }

        public void addSubjectToAllClassRoom(string subjectName) 
        {
            foreach (ClassRoom x in CRList) { x.subjects.addSbj(subjectName); }
        }

        public void deleteSubjectFromClassRoom(string classRoomName, string subjectName) 
        {
            ClassRoom CR = CRList[indexOfCRList(classRoomName)];
            CR.subjects.deleteSbj(subjectName);

        }

        public void deleteSubjectFromAllClassRoom(string subjectName) 
        { foreach (ClassRoom x in CRList) { x.subjects.deleteSbj(subjectName); } }

        public void addStudent(string studentName,string classRoomName) {
            CRList[indexOfCRList(classRoomName)].addStudent(studentName);
        }

        public void deleteStudent(string studentName,string classRoomName) {
            CRList[indexOfCRList(classRoomName)].deleteStudend(studentName);
        }

        public void editStudentName(string studentName,string classRoomName,string newStudentName) {
            Student toEdit=CRList[indexOfCRList(classRoomName)].getStudent(studentName);
            toEdit.name = newStudentName;
        }

        public void editStudentMark(string studentName, string classRoomName, string subjectName,int subjectMark)
        {
            Student toEdit = CRList[indexOfCRList(classRoomName)].getStudent(studentName);
            toEdit.setMarkOfSubject(subjectName,subjectMark);
        }

        public  String printClassRoomDetails(string classRoom) {
            return "classroom name : " + CRList[indexOfCRList(classRoom)].CRname + "\n" +
            "=================================================================" +
            "subject in this classroom : \n" + CRList[indexOfCRList(classRoom)].subjects.sbjTitle() + "\n" +
            "=================================================================" +
            "student in this classroom : \n" + CRList[indexOfCRList(classRoom)].studentListName();
            

        }

        public string studentDatails(string studentName,string classRoomName ) {
            Student st = CRList[indexOfCRList(classRoomName)].getStudent(studentName);
            ClassRoom cr = CRList[indexOfCRList(classRoomName)];
            return 

                "\n=====================================================================\n"+
                "student information"+
                "\n=====================================================================\n"+
                "This student's name is "+st.name+"studying in classroom"+cr.CRname+

                "\n=====================================================================\n"+
                "Student marks"+
                "\n=====================================================================\n"+
                st.titel()+"\n"+
                st.print()
                ;
        }
        public int indexOfCRList(string classRoomName) {
            int i;

            for (i = 0; i < CRList.Count; i++)
                if (CRList[i].CRname == classRoomName)
                    return i;

            return -1;
        }

        






    }

    class Student {
        public string name { get; set; }
        public Subject subjects { get; set; }

        public Student(String name,Subject subjects) {
                this.name = name;
                this.subjects = subjects;
            }

        /// <summary>
        /// This method calculates the student's average based on the total marks divided by the number of subjects return it
        /// </summary>
        /// <returns></returns>
        public double Avereage() { return ((double)Total() / subjects.length()); }

        /// <summary>
        /// This method calculates the s total marks and return it
        /// </summary>
        /// <returns></returns>
        public int Total() { return subjects.totalMarks(); }

        /// <summary>
        /// This method returns the student's assessment with symbols as a string
        /// </summary>
        /// <returns></returns>
        public string Grade()
        {
            int grade = Convert.ToInt32(Avereage());

            if (grade >= 85 && grade <= 100)
                return "HD";
            else if (grade >= 75 && grade <= 84)
                return "DN";
            else if (grade >= 65 && grade <= 74)
                return "CR";
            else if (grade >= 50 && grade <= 64)
                return "HD";
            else
                return "";
        }

        /// <summary>
        /// This method finds the highest score among the list of students and returns its name
        /// </summary>
        /// <param name="std">List of students to find the highest average student</param>
        /// <returns></returns>
        public static string topStudent(List<Student> std)
        {

            if (Student.isEmptyList(std))
                return "No students have been added";

            double max = std[0].Avereage();
            string stdName = std[0].name;

            foreach (Student x in std)
            {
                if (x.Avereage() > max) { max = x.Avereage(); stdName = x.name; }
            }

            return "topper student name : " + stdName + "  who's average is maximum : " + max.ToString("0.#####");
        }

        /// <summary>
        ///this method return true if list is empty
        ///and return false if not
        /// </summary>
        /// <param name="std">the List you wish to determine if empty</param>
        /// <returns></returns>
        public static bool isEmptyList(List<Student> std) { return std == null; }

        /// <summary>
        ///  This method edit subject mark to new value
        /// and receive the subject whose value is to be changed
        /// and set sbjMark as the subject mark
        /// </summary>
        /// <param name="sbjName">subject whose value is to be changed</param>
        /// <param name="mark">set sbjMark as the new value of subject mark</param>
        public void setMarkOfSubject(string sbjName, int mark)
        {
            subjects.editMark(sbjName, mark);
        }

        /// <summary>
        /// This method return Student name,marks,Total,Avereage and Grade of subject as a string
        /// </summary>
        /// <returns></returns>
        public string print()
        {

            string result = name;
            foreach (Subject x in subjects.sbjList)
            { result += "  |  " + x.mark; }
            result += "  |  " + Total() + "  |  " + Avereage().ToString("0.#####") + "  |  " + Grade();

            return result;
        }

        /// <summary>
        /// This method return "name",subject name,"Total","Avereage" and "Grade" of subject as a string
        /// </summary>
        /// <returns></returns>
        public string titel()
        {
            return "name" + subjects.sbjTitle() + "    |    " + "Total" + "    |    " + "Avereage" + "    |    " + "Grade";
        }





    }

    class Subject {

        string _Name;
        int _mark;

        public List<Subject> sbjList = new List<Subject>();
        public Subject() { }

        /// <summary>
        /// This constructor receives the name of the subject and sets the zero as the default value
        /// </summary>
        /// <param name="sbjName">name of the subject</param>
        public Subject(string sbjName)
        {
            _Name = sbjName;
            mark = 0;
        }

        /// <summary>
        /// this methode to set and get value of subject name
        /// </summary>
        public string sbjName { get; set;}

        /// <summary>
        /// this methode to set and get value of subject mark
        /// </summary>
        public int mark{ get; set; }

        /// <summary>
        /// this methode to set and get value of subject list
        /// </summary>
        //public List<Subject> sbjList { get; set; }

        /// <summary>
        /// It adds a subject and the name of the subject =sbjName and sets the zero mark as the default value
        /// </summary>
        /// <param name="sbjName">The name of the subject to be add</param>
        public void addSbj(string sbjName) {
            sbjList.Add(new Subject(sbjName));
        }

        /// <summary>
        /// It adds a subject and the name of the subject =sbjName and the mark of the subject=sbjmark
        /// </summary>
        /// <param name="sbjName">The name of the subject to be add</param>
        /// <param name="sbjmark">The mark of the subject to be add</param>
        public void addSbj(string sbjName,int sbjmark)
        {
            Subject newSbj = new Subject(sbjName);
            newSbj.mark = sbjmark;
            sbjList.Add(newSbj);
        }

        /// <summary>
        /// Deletes the subject based on the name
        /// </summary>
        /// <param name="sbjName">The name of the subject to be removed</param>
        public void deleteSbj(string sbjName) {

            if (isExist(sbjName))
                Console.WriteLine("this subjects does not exist");
            else
                sbjList.RemoveAt(indexOf(sbjName));
        }

        /// <summary>
        /// return the size of subject list 
        /// Or we can say the number of subject
        /// </summary>
        /// <returns></returns>
        public int length() { return sbjList.Count; }

        /// <summary>
        /// return the index as int location in subject list based on the name
        /// </summary>
        /// <param name="sbjName">The name of the subject whose location you want to know</param>
        /// <returns></returns>
        public int indexOf(string sbjName) {
            int i;

            for (i = 0; i < sbjList.Count; i++)
                if (sbjList[i].sbjName == sbjName)
                    return i;

            return -1;
        }

        /// <summary>
        /// return true if the subject is exist in list based on the name
        /// or return false if not
        /// </summary>
        /// <param name="sbjName">The name of the subject  you want to know if is exist in list</param>
        /// <returns></returns>
        public bool isExist(string sbjName) { 
            if(indexOf(sbjName)==-1)
                return false;
            return true;
        }

        /// <summary>
        /// Modifies the subject mark based on the name
        /// </summary>
        /// <param name="sbjname">The name of the subject whose mark is to be modified</param>
        /// <param name="mark">new mark</param>
        public void editMark(string sbjname,int mark) {
            int index = indexOf(sbjname);
            sbjList[index].mark = mark;
        }

        /// <summary>
        /// This method calculates the sum of all mark
        /// </summary>
        /// <returns></returns>
        public int totalMarks() {
            int sum = 0;
            foreach (Subject x in sbjList) {sum += x.mark;}
            return sum;
        }

        /// <summary>
        /// This method return names of subject as a string
        /// </summary>
        /// <returns></returns>
        public string sbjTitle() {
            string result = "";
            foreach (Subject x in sbjList) { result += "  |  " + x.sbjName; }
            return result;
        }

         

    }

    class ClassRoom {
        public Subject subjects = new Subject();
        List<Student> students = new List<Student>();
        public ClassRoom() {
            CRname = "";
        }

        public ClassRoom(string classRoomName)
        {
            CRname = classRoomName;
        }

        public ClassRoom(string name, List<Subject> subjects)
        {
            CRname = name;
            this.subjects.sbjList = subjects;
        }

        /// <summary>
        /// this methode to set and get value of Science name
        /// </summary
        public string CRname{get;set;}

        /// <summary>
        /// this methode to set and get value of Science subjects
        /// </summary
        //public Subject subjects{get;set;}

        //public List<Student> students { get; set; }

        /// <summary>
        /// This method add subject to specific student 
        /// and receive the subject name and set sbjtName as the subject name
        /// and set sbjMark as the subject mark
        /// </summary>
        /// <param name="sbjtName">set sbjtName as the subject name</param>
        /// <param name="sbjMark">set sbjMark as the subject mark</param>

        public void addStudent(string studentName ) {
            Student newStd = new Student(studentName,subjects);
            students.Add(newStd);

        }

        public void deleteStudend(string studentName) {
            students.RemoveAt(indexOfStList(studentName));
        }

        public int indexOfStList(string studentName) {
            int i ;
            for (i=0; i < STListLength(); i++)
                if (students[i].name == studentName)
                    return i;
            return -1;
            
        }


        public int STListLength() {
            return students.Count;
        }

        public Student getStudent(string studentName) {
            return students[indexOfStList(studentName)];
        }

        public string studentListName() {

            string result = "";
            foreach (Student x in students) { result += "  |  " + x.name; }
            return result;
        }
        


        
    }
}
