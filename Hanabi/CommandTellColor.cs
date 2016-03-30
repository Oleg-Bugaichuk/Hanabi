using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanabi
{
    class CommandTellColor
    {
        static string[] redColor = new string[5];
        static string[] greenColor = new string[5];
        static string[] blueColor = new string[5];
        static string[] whiteColor = new string[5];
        static string[] yellowColor = new string[5];
        static bool rezult = false;
        

        public static void TellColor(string[] firstPlayerCards, string[] secondPlayerCards, string command, int course)
        {
            command = command.Remove(0, 11);
            
            
            if (course % 2 != 0)
            {
                Tell(firstPlayerCards, command);
            }
            else
            {
                Tell(secondPlayerCards, command);
            }

        }


        static void Tell(string[] player, string value)
        { 
            if (value.Contains("Red"))
            {
                value = value.Remove(0, 14);
                int[] position = new int[(value.Length/2) +1];
                

                int k = 0; //счетчик для выбора символа

                
                
            }


        }





    }
}
