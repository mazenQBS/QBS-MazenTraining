using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QBS_training.LinqFile
{
    class Emploee
    {
       

        public int Mark
        {
            get;
            set;
        }

        public string Name { get; set; }

        public int Id { get; set; }

        public void Show()
        {
           List< Emploee> emploees=new List<Emploee>();

           emploees.Add(new Emploee() { Name = "mazen" , Mark = 95 ,Id=1});
           emploees.Add(new Emploee() { Name = "amer", Mark = 75 ,Id=2});
           emploees.Add(new Emploee() { Name = "ali", Mark = 65 ,Id=3});
           emploees.Add(new Emploee() { Name = "ahmad", Mark = 85 ,Id=4});

           //var empQuery = from emp in emploees
           //               where emp.Mark!=85
           //               select new {emp.Id,emp.Name}  ;
           // //Employees.Take (100)


           // foreach (var x in empQuery)
           //    Console.WriteLine("id : "+x.Id+"  Name : "+x.Name);
           Console.WriteLine(emploees[1].Name);
           

        }

        public void run()
        {
          Show();

        }







    }
}
