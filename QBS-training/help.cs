using System.Collections.Generic;
using System.Text;
using QBS_training.SchoolFile;


namespace QBS_training_Help
{
    public class Help
    {
        public static int SpaceSize(StringBuilder messag, int totalSize)
            {  return totalSize - messag.Length;  }

        public static int  HalfSpaceSize(StringBuilder messag, int totalSize) {         
            return SpaceSize(messag,totalSize)/2;
              }
        public static StringBuilder DoneMessageFormat(StringBuilder messag) {


            StringBuilder result = new StringBuilder();
            result.AppendLine()
                  .Append("****************************************************************************************************")
                  .AppendLine()
                  .Append(' ', HalfSpaceSize(messag, 100))                  
                  .Append(messag)
                  .AppendLine()
                  .Append("****************************************************************************************************");            
            return result;
        }

        public static bool isEmptyList<T>(List<T> std)
        {
            return std == null;
        }
    }

    


}


