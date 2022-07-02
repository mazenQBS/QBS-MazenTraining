using System;
using System.Collections.Generic;
using System.Text;

namespace QBS_training
{
    class Student
    {
        string _name;
        Subject _subjects=new Subject();

        /// <summary>
        /// this methode to set and get value of Student name
        /// </summary
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// this methode to set and get value of Student subjects
        /// </summary
        public Subject subjects {
            get { return _subjects; }
            set { foreach (Subject x in value.sbjList  ) 
                    {_subjects.sbjList = x.sbjList;} }
        }

        /// <summary>
        /// This constructor sets the name's empty string as the default value
        /// </summary>
        public Student(){
            name="";
            subjects = new Subject();
        }

        /// <summary>
        /// This constructor receives the name and assigns it to the name
        /// </summary>
        /// <param name="Name"></param>
        public Student(string Name)
        {
            name = Name;
            subjects = new Subject();
        }

        /// <summary>
        /// This constructor receives the name and list of subject and assigns it to the name and subject member
        /// </summary>
        /// <param name="Name"></param>
        public Student(string Name,List<Subject> sbj)
        {
            name = Name;
            subjects = new Subject();
            foreach (Subject x in sbj) {subjects.addSbj(x.sbjName,x.mark);}
        }

        /// <summary>
        /// This method fills in students' mark by asking the user (Console.ReadLine())
        /// </summary>
        public void fill()
        {
            Console.Write("Enter the number of subject to be added : ");
            int numOfSbj = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= numOfSbj; i++)
            {
                Console.Write("Enter the name of subject " + i + " : ");
                string sbjName = Console.ReadLine();
                Console.Write("Do you want to add a mark ? y/n  ");
                string decision = Console.ReadLine();
                if (decision == "n")
                    addSubject(sbjName);
                else if (decision == "y")
                {
                    Console.Write("Enter the mark : ");
                    int mark = Convert.ToInt32(Console.ReadLine());
                    addSubject(sbjName,mark);
                }

            }
            //foreach (subject x in subjects.sbjList)
            //{
            //    Console.Write("enter degree of " +x.sbjName + " : ");
            //    x.mark = Convert.ToInt32(Console.ReadLine());
            //}
        }

        /// <summary>
        /// This method calculates the student's average based on the total marks divided by the number of subjects return it
        /// </summary>
        /// <returns></returns>
        public double Avereage() {   return ((double)Total() / subjects.length());  }

        /// <summary>
        /// This method calculates the s total marks and return it
        /// </summary>
        /// <returns></returns>
        public int Total() { return subjects.totalMarks() ;}

        /// <summary>
        /// This method returns the student's assessment with symbols as a string 
        /// </summary>
        /// <returns></returns>
        public string Grade(){
            int grade =Convert.ToInt32(Avereage());

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
        /// This method return Student name,marks,Total,Avereage and Grade of subject as a string
        /// </summary>
        /// <returns></returns>
        public string print() {

            string result = name;
            foreach (Subject x in subjects.sbjList) 
                {result += "    |    "+x.mark; }
            result+= "    |    " + Total() + "    |    " + Avereage().ToString("0.#####") + "    |    " + Grade(); ;
            
            return result;
        }

        /// <summary>
        /// This method return "name",subject name,"Total","Avereage" and "Grade" of subject as a string
        /// </summary>
        /// <returns></returns>
        public string titel() 
        {
            return "name"+subjects.sbjTitle()+ "    |    " + "Total" + "    |    " + "Avereage" + "    |    " + "Grade";
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
                if (x.Avereage() > max) {   max = x.Avereage();   stdName= x.name;  }
            }

            return "topper student name : " + stdName + "  who's average is maximum : " + max.ToString("0.#####");
        }

        /// <summary>
        /// This method add subject to specific student 
        /// and receive the subject name and set sbjtName as the subject name
        /// and set zero as the default value for the mark
        /// </summary>
        /// <param name="subjectName">set sbjtName as the subject name</param>
        public void addSubject(string sbjtName)
        {
            subjects.addSbj(sbjtName);
            
        }

        /// <summary>
        /// This method add subject to specific student 
        /// and receive the subject name and set sbjtName as the subject name
        /// and set sbjMark as the subject mark
        /// </summary>
        /// <param name="sbjtName">set sbjtName as the subject name</param>
        /// <param name="sbjMark">set sbjMark as the subject mark</param>
        public void addSubject(string sbjName,int sbjMark)
        {   //Error
            
            subjects.addSbj(sbjName,sbjMark);
        }

        /// <summary>
        ///  This method edit subject mark to new value
        /// and receive the subject whose value is to be changed
        /// and set sbjMark as the subject mark
        /// </summary>
        /// <param name="sbjName">subject whose value is to be changed</param>
        /// <param name="mark">set sbjMark as the new value of subject mark</param>
        public void setMarkOfSubject(string sbjName,int mark) {
            subjects.editMark(sbjName, mark);
        }

        /// <summary>
        ///this method return true if list is empty 
        ///and return false if not
        /// </summary>
        /// <param name="std">the List you wish to determine if empty</param>
        /// <returns></returns>
        public static bool isEmptyList(List<Student> std) { return std == null; }

        /// <summary>
        /// Determine if this object is empty
        /// </summary>
        /// <returns></returns>
        public bool isEmpty() {
            return name == "" && subjects == null;
        }


    }

    class Subject {

        string _Name;
        int _mark;
        List<Subject> _sbjlist = new List<Subject>();
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
        public string sbjName { get => _Name; set => _Name = value;}

        /// <summary>
        /// this methode to set and get value of subject mark
        /// </summary>
        public int mark{ get => _mark; set =>_mark = value; }

        /// <summary>
        /// this methode to set and get value of subject list
        /// </summary>
        public List<Subject> sbjList { get => _sbjlist; set => _sbjlist = value; }

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
        public void removeSbj(string sbjName) {

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
        public int length() { return _sbjlist.Count; }

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
            foreach (Subject x in sbjList) { result += "    |    " + x.sbjName; }
            return result;
        }

         

    }

    class Science {
        string _name;
        Subject _subjects = new Subject();

        public Science() { 
        }

        public Science(string name)
        {
        }

        public Science(string name, List<Subject> subject)
        {
            int x;
            int y;
        }

        public void gethubb() {
            
            

        }


    }
}
