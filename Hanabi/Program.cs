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
                int countPlayingCards = 0;//подсчет сыгранных карт.
                Console.WriteLine("Turn: {0}, Score: {1}, Finished: {2}", countCourse, countPlayingCards, rezult);
                CountCurentPlayer(firstPlayersCard, secondPlayersCard, countCourse);
                Console.WriteLine("Table: R{0} G{1} B{2} W{3} Y{4}", CommandPlayCard.redCardsForTable, CommandPlayCard.greenCardsForTable, CommandPlayCard.blueCardsForTable, CommandPlayCard.whiteCardsForTable, CommandPlayCard.yellowCardsForTable);

                for (int course = 1; ; course++)
                {
                    string command = Console.ReadLine().ToString();


                    if (command.Contains("Play card"))
                    {
                        rezult = CommandPlayCard.PlayCard(firstPlayersCard, secondPlayersCard, deck, command, course);
                        countPlayingCards++;
                    }
                    if (command.Contains("Tell rank"))
                        CommandTellRank.TellRank();
                    if (command.Contains("Tell color"))
                        CommandTellColor.TellColor(firstPlayersCard, secondPlayersCard, command, course);
                    if (command.Contains("Drop card"))
                        CommandDropCard.DropCard(firstPlayersCard, secondPlayersCard, deck, command, course);
                    if (rezult == true)
                        break;
                    countCourse++;
                    Console.WriteLine("Turn: {0}, Score: {1}, Finished: {2}", countCourse, countPlayingCards, rezult);
                    CountCurentPlayer(firstPlayersCard, secondPlayersCard, countCourse);
                    Console.WriteLine("Table: R{0} G{1} B{2} W{3} Y{4}", CommandPlayCard.redCardsForTable, CommandPlayCard.greenCardsForTable, CommandPlayCard.blueCardsForTable, CommandPlayCard.whiteCardsForTable, CommandPlayCard.yellowCardsForTable);

                }

                Console.WriteLine("Turn: {0}, cards: {1}, with risk: 0", countCourse, countPlayingCards);
                Console.WriteLine("Turn: {0}, Score: {1}, Finished: {2}", countCourse, countPlayingCards, rezult);
                CountCurentPlayer(firstPlayersCard, secondPlayersCard, countCourse);
                Console.WriteLine("Table: R{0} G{1} B{2} W{3} Y{4}", CommandPlayCard.redCardsForTable, CommandPlayCard.greenCardsForTable, CommandPlayCard.blueCardsForTable, CommandPlayCard.whiteCardsForTable, CommandPlayCard.yellowCardsForTable);
                
                
            }
            
        }


        static string EnterData()//метод ввода начальных данных
        {
            enteriesCards = Console.ReadLine();
            return enteriesCards;
        }

        static void CountCurentPlayer(string[] firstPlayer, string[] secondPlayer, int courseCount)
        {
            if (courseCount % 2 == 0)
            {
                Console.WriteLine("Current Player: " + firstPlayer[0] + " " + firstPlayer[1] + " " + firstPlayer[2] + " " + firstPlayer[3] + " " + firstPlayer[4]);
                Console.WriteLine("Next Player: " + secondPlayer[0] + " " + secondPlayer[1] + " " + secondPlayer[2] + " " + secondPlayer[3] + " " + secondPlayer[4]);
            }
            else
            {
                Console.WriteLine("Current Player: " + secondPlayer[0] + " " + secondPlayer[1] + " " + secondPlayer[2] + " " + secondPlayer[3] + " " + secondPlayer[4]);
                Console.WriteLine("Next Player: " + firstPlayer[0] + " " + firstPlayer[1] + " " + firstPlayer[2] + " " + firstPlayer[3] + " " + firstPlayer[4]);
            }
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
