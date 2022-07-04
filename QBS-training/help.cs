using System;
using System.Collections.Generic;
using System.Text;
using QBS_training_restaurant;

namespace QBS_training_help
{
    public class Help
    {
        public static string space(string word, int totalSize)
        {
            string result = "";
            int spaceSize = totalSize - word.Length;

            for (int i = 0; i < spaceSize; i++) {
                result += " ";
            }
            return result;
        }

        public static string halfSpace(string word, int totalSize) {
            string result = "";
            int spaceSize = totalSize - word.Length;

            for (int i = 0; i < (spaceSize / 2); i++)
            {
                result += " ";
            }
            return result;

        }
        public static string doneMessageFormat(string messag) {

            string resut;
            resut = "\n****************************************************************************************************\n";
            resut += halfSpace(messag, 100);
            resut += messag + "\n****************************************************************************************************\n";
            return resut;
        }
    }

    


}


