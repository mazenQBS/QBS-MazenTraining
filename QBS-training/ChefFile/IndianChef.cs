using System.Text;
using QBS_training_Help;

namespace QBS_training.ChefFile
{

    class IndianChef : Chef
    {
        public override StringBuilder ToStringChefResponsible()
        { return Help.DoneMessageFormat(new StringBuilder("The order is prepared by a chef who is an expert in the Indian dish")); }

    }

}
