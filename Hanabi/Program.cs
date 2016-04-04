using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Hanabi
{
    class Bugaichuk_Oleg
    {
        static string enteriesCards;
        static string[] firstPlayersCard = new string[5];
        static string[] secondPlayersCard = new string[5];
        static string[] deck = new string[15];
        static bool rezult = false;
        static StreamReader str = new StreamReader("1-1.in");
        static int countPlayingCards = 0;

        static void Main(string[] args)
        {
            for (;;)
            {
                if(string.IsNullOrEmpty(EnterData()))
                    break;

                for (; (enteriesCards.Length < 60 || !enteriesCards.Contains("Start new game with deck"));)
                {
                    Console.WriteLine("Не правильно введены данные. Введите команду 'Start new game with deck' и перечислите карты на руках через пробел. Пример: Start new game with deck R1 R2 R3 R4 R5 B1 B2 B3 B4 B5 W1 W2");
                    EnterData();
                }
                enteriesCards = enteriesCards.Remove(0, 25);

                UpdateDeck.Update(enteriesCards);

                firstPlayersCard = UpdateDeck.firstPlayer;//массив карт на руках первого ингрока
                secondPlayersCard = UpdateDeck.secondPlayer;//массив карт на руках второго игрока
                deck = UpdateDeck.Update(enteriesCards);//массив карт оставшихся в колоде
                int countCourse = 0;//подсчет ходов
                
                

                for (int course = 1; ; course++)
                {
                    string command ;
                    command = Console.ReadLine();
                   

                    if (command.Contains("Play card"))
                    {
                        rezult = CommandPlayCard.PlayCard(firstPlayersCard, secondPlayersCard, deck, command, course);
                        if (rezult == false)
                            countPlayingCards++;

                    }

                    //if (command.Contains("l;jjj;jjjjjj"))
                      //  CommandTellRank.TellRank();

                    if (command.Contains("Tell color"))
                       rezult=CommandTellColor.TellColor(firstPlayersCard, secondPlayersCard, command, course);

                    if (command.Contains("Drop card"))
                        CommandDropCard.DropCard(firstPlayersCard, secondPlayersCard, deck, command, course);

                    if (rezult == true)
                    {
                        countCourse++;
                        break;
                    }
                    else
                    {
                        countCourse++;
                    }
                    

                }

                Console.WriteLine("Turn: {0}, cards: {1}, with risk: 0", countCourse, countPlayingCards);
                for (int i = 0; i <= 4; i++)
                {
                    CommandPlayCard.redCrads[i] = 0;
                    CommandPlayCard.blueCards[i] = 0;
                    CommandPlayCard.whiteCards[i] = 0;
                    CommandPlayCard.yellowCards[i] = 0;
                    CommandPlayCard.greenCards[i] = 0;
                    countPlayingCards = 0;
                    CommandTellColor.blueColor[i] = 0;
                    CommandTellColor.greenColor[i] = 0;
                    CommandTellColor.redColor[i] = 0;
                    CommandTellColor.whiteColor[i] = 0;
                    CommandTellColor.yellowColor[i] = 0;
                }

                
                
                
            }
            
        }


        static string EnterData()//метод ввода начальных данных
        {
           
                enteriesCards = Console.ReadLine();
           
                return enteriesCards;
        }

       

        

    }

    
  


    class UpdateDeck
    {
        public static string[] firstPlayer = new string[5];//карты первого игрока
        public static string[] secondPlayer = new string[5];//карты второго игрока
        
        
        public static string[] Update(string enteriesCards)//метод разделения введенных данных на карты игроков
        {
            //счетчики для циклов
            int j = 0;
            int s = 15;
            int k = 0;


            for (int i = 0; i <= 4; i++)
            {
                firstPlayer[i] = enteriesCards.Substring(j, 2);
                j += 3;
            }


            for (int i = 0; i <= 4; i++)
            {
                secondPlayer[i] = enteriesCards.Substring(s, 2);
                s += 3;
            }

            string a = enteriesCards.Remove(0, 30);
            string[] deck = new string[(a.Length / 3) + 1 ];//остальная колода



            for (int i = 0; i <= (a.Length / 3); i++)
            {
                deck[i] = a.Substring(k, 2);
                k += 3;
            }

            return deck;
            

        }

        
    }
}
