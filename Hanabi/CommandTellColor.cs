using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanabi
{
    class CommandTellColor
    {
        public static int[] redColor = new int[5];
        public static int[] greenColor = new int[5];
        public static int[] blueColor = new int[5];
        public static int[] whiteColor = new int[5];
        public static int[] yellowColor = new int[5];
         
        

        public static bool TellColor(string[] firstPlayerCards, string[] secondPlayerCards, string command, int course)
        {
            command = command.Remove(0, 11);
            string color = command.Remove(1);
            bool rezult = false;
            
            if (course % 2 != 0)
            {
                switch (color)
                { 
                    case "R":
                        command = command.Remove(0, 14);
                        Tell(firstPlayerCards, command, color, redColor, rezult);
                        break;
                    case "G":
                        command = command.Remove(0, 16);
                        Tell(firstPlayerCards, command, color, greenColor, rezult);
                        break;
                    case "Y":
                        command = command.Remove(0, 17);
                        Tell(firstPlayerCards, command, color, yellowColor, rezult);
                        break;
                    case "B":
                        command = command.Remove(0, 15);
                        Tell(firstPlayerCards, command, color, blueColor, rezult);
                        break;
                    case "W":
                        command = command.Remove(0, 16);
                        Tell(firstPlayerCards, command, color, whiteColor, rezult);
                        break;
                }
                
            }
            else
            {
                switch (color)
                {
                    case "R":
                        command = command.Remove(0, 14);
                        Tell(secondPlayerCards, command, color, redColor, rezult);
                        break;
                    case "G":
                        command = command.Remove(0, 16);
                        Tell(secondPlayerCards, command, color, greenColor, rezult);
                        break;
                    case "Y":
                        command = command.Remove(0, 17);
                        Tell(secondPlayerCards, command, color, yellowColor, rezult);
                        break;
                    case "B":
                        command = command.Remove(0, 15);
                        Tell(secondPlayerCards, command, color, blueColor, rezult);
                        break;
                    case "W":
                        command = command.Remove(0, 16);
                        Tell(secondPlayerCards, command, color, whiteColor, rezult);
                        break;
                }
            }

            return rezult;

        }


        static void Tell(string[] player, string value, string color, int[] tellingColor, bool rezult)
        {

            
            int[] position;
            int j = 0;//счетчик для выбора позиции в строке команды. для выбора подстроки(указанной в комманде, позиции карты)
            int countValue;

            
                    
            countValue = value.Length / 2;
            position = new int[countValue + 1];

            for (int i = 0; i <= countValue; i++)//позиции указанных карт
            {
                position[i] = int.Parse(value.Substring(j, 1));
                j += 2;
            }

            for(int i = 0; i<= countValue; i++)
            {
                if (player[position[i]].Contains(color))
                {
                    for (int k = 0; k <= 4; )
                    {
                        if (tellingColor[k] == 0)
                        {
                            tellingColor[k] = position[i];
                            break;
                        }
                        else
                            k++;
                    }
                }
                else
                {
                    rezult = true;
                    break;
                }

            }
                   
       
        }

    }
}
