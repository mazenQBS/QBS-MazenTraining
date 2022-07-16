using System.Text;
using QBS_training_Help;

namespace QBS_training.ChefFile
{
    
        public class ArabicChef : Chef
        {
            public override StringBuilder ToStringChefResponsible()
            { return Help.DoneMessageFormat(new StringBuilder("The order is prepared by an expert chef in the Arabic dish")); }

        }



    
}
