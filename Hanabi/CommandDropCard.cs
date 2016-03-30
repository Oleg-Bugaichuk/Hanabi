using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hanabi
{
    class CommandDropCard
    {
        
        static int value = 0;
        
        public static void DropCard(string[] firstPlayerCards, string[] secondPlayerCards, string[] deck, string command, int course)
        {
            command = command.Remove(0, 10);
            value = Convert.ToInt32(command.Substring(0));
            
            if (course % 2 != 0)
            {
                Drop(firstPlayerCards, deck, value);
            }
            else
            {
                Drop(secondPlayerCards, deck, value);
            }

            
        }

        
        public static void Drop(string[] player, string[] deckForDroping, int value)
        {
            player[value] = null;
            for (int i = 0; i <= deckForDroping.Length - 1;)
            {
                if (deckForDroping[i] == null)
                {
                    i++;
                }
                else
                {
                    player[value] = deckForDroping[i];
                    deckForDroping[i] = null;
                    break;
                }

            }
        }


    }
}
