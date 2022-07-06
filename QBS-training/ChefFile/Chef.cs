using System.Text;


namespace QBS_training.ChefFile
{ 
    public abstract class Chef
    {
        public StringBuilder ChifName { get; set; }
        public StringBuilder FoodPlate { get; set; }
        public abstract StringBuilder ToStringChefResponsible();


    }



}
