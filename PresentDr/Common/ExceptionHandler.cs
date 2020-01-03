using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PresentDr.Common
{
    class ExceptionHandler
    {
        public static void InsertException(int ExNumber, string ExMessage, string ExSource, string ExDate)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter("Exception.txt", true, System.Text.Encoding.UTF8);
                sw.WriteLine("/**************************");
                sw.WriteLine("Message: \" {0} \"", ExMessage);
                sw.WriteLine("Date: {0}, Number {1} at {2}", ExDate, ExNumber, ExSource);
                sw.Flush();
            }
            catch (System.Exception)
            {

            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

    }
}
