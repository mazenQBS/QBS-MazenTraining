using System.Text;

namespace QBS_training.ChefFile
{
    public interface IUserMenu
    {
        public void AddChoice(object choiceNumber, StringBuilder titleOfChoice);
        public void DeleteChoice(object choiceNumber);
        public int IndexOf(object choiceNumber);

    }
}
