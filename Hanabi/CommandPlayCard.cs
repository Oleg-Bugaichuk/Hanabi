using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hanabi
{
    class CommandPlayCard
    {
        public static int[] redCrads = new int[5];//красные сыграные карты
        public static int[] whiteCards = new int[5];//белые сыграные карты
        public static int[] blueCards = new int[5];//синие сыграные карты
        public static int[] yellowCards = new int[5];//желтые сыграные карты
        public static int[] greenCards = new int[5];//зеленные сыграные карты
   
        

        public static bool PlayCard(string[] firstPlayerCards, string[] secondPlayerCards, string[] deck, string command, int course)
        {
            bool rezult = false;
            int value;

            command = command.Remove(0, 10);
            
            value = Convert.ToInt32(command.Substring(0));
            

            if (course % 2 != 0)
            {
               rezult= Play(firstPlayerCards,rezult , value, deck);
            }
            else
            {
                rezult = Play(secondPlayerCards, rezult, value, deck);    
            }

            

            return rezult;
        }


        //изменяется в зависимости от того какой игрок ходит
        private static bool Play(string[] playerForVoidPlay, bool rezult, int value, string[] deckForVoidPlay)
        {
            
            int worth;// достоинство карты

            worth = Convert.ToInt32(playerForVoidPlay[value].Substring(1));
            if (playerForVoidPlay[value].Contains("R"))
            {
                for (int i = 0; i <= 4; i++)
                {

                    if (worth > 1)
                    {
                        if (redCrads[i] == worth - 1)
                        {
                            redCrads[i + 1] = worth;
                            break;
                        }
                        else
                        {
                            rezult = true;
                            
                        }

                    }
                    else
                    {

                        redCrads[i] = worth;
                        break;
                    }

                }

            }
            if (playerForVoidPlay[value].Contains("W"))
            {
                for (int i = 0; i <= 4; i++)
                {
                    if (worth > 1)
                    {
                        if (whiteCards[i] == worth - 1)
                        {
                            whiteCards[i + 1] = worth;
                            break;
                        }
                        else
                        {
                            rezult = true;
                           
                        }
                    }
                    else
                    {
                        whiteCards[i] = worth;
                        break;
                    }
                }

            }

            if (playerForVoidPlay[value].Contains("B"))
            {
                for (int i = 0; i <= 4; i++)
                {
                    if (worth > 1)
                    {
                        if (blueCards[i] == worth - 1)
                        {
                            blueCards[i + 1] = worth;
                            break;
                        }
                        else
                        {
                            rezult = true;
                            
                        }
                    }
                    else
                    {
                        blueCards[i] = worth;
                        break;
                    }
                }

            }

            if (playerForVoidPlay[value].Contains("Y"))
            {
                for (int i = 0; i <= 4; i++)
                {

                    if (worth > 1)
                    {
                        if (yellowCards[i] == worth - 1)
                        {
                            yellowCards[i + 1] = worth;
                            break;
                        }
                        else
                        {
                            rezult = true;
                           
                        }
                    }
                    else
                    {

                        yellowCards[i] = worth;
                        break;
                    }
                }

            }
            if (playerForVoidPlay[value].Contains("G"))
            {
                for (int i = 0; i <= 4; i++)
                {

                    if (worth > 1)
                    {
                        if (greenCards[i] == worth - 1)
                        {
                            greenCards[i + 1] = worth;
                            break;
                        }
                        else
                        {
                            rezult = true;
                            
                        }
                    }
                    else
                    {
                        greenCards[i] = worth;
                        break;
                    }
                }

            }

           if (rezult == false)
           { 
                int countForDeck = 0;
                playerForVoidPlay[value] = null;
                
                for (int i = 0; i <= deckForVoidPlay.Length; i++)
                {
                    if (deckForVoidPlay[countForDeck] == null)
                    {
                        countForDeck++;
                    }
                    else
                    {
                        playerForVoidPlay[value] = deckForVoidPlay[countForDeck];
                        deckForVoidPlay[countForDeck] = null;
                        break;
                    }

                }
            }
            

            return rezult;


        }
    }
            
}

