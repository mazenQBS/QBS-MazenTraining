using System;
using System.Collections.Generic;
using System.Text;
using QBS_training_restaurant;

namespace QBS_training_Help
{
#pragma warning disable S1118 // Utility classes should not have public constructors
    public class Help
    {
        public static int Space(StringBuilder word, int totalSize)
            {  return totalSize - word.Length;  }

        public static int  Half_Space(StringBuilder word, int totalSize) {         
            return totalSize - word.Length;
              }
        public static StringBuilder Done_Message_Format(StringBuilder messag) {


            StringBuilder result = new StringBuilder();
            result.AppendLine()
                  .Append("****************************************************************************************************")
                  .Append(' ', Half_Space(messag, 100))                  
                  .Append(messag)
                  .AppendLine()
                  .Append("****************************************************************************************************");            
            return result;
        }
    }

    


}


