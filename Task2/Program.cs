using System;
using System.IO;

namespace Task2
{
    class Program
    {
        public static string[,] stepsPlayers = new string[3, 3];
        public const string mapFile = "map.txt";
        static void Main(string[] args)
        {
            bool gameOver = false;
            string player = "X";
            Console.Title = "TicTacToe";

            ReadMap();
            InstallationMapGame();
            
            Console.WriteLine("\nПриветствуем Вас в нашей игре Крестики Нолики!");
            Console.WriteLine("Введите номер ячейки игрового поля. Число от 1 до 9");
            int savePositionX = 0;
            while (!gameOver)
            {
                int savePositionY = Console.CursorTop + 1;

                Console.Write($"Ваш ход '{player}': ");
                try
                {
                    int inputPlayer = Convert.ToInt32(Console.ReadLine());
                    if (inputPlayer < 0 || inputPlayer > 9)
                    {
                        Console.Write("Введите число от 1 до 9! ");
                        continue;
                    }
                    else if (InsertMap(inputPlayer, player))
                    {
                        gameOver = CheckGame();
                        if (gameOver)
                        {
                            Console.Clear();
                            Console.Write("Игра закончена! Результат ничья!");
                        }
                        else
                        {
                            if (WinGame())
                            {
                                gameOver = true;
                                Console.Clear();
                                Console.WriteLine($"Победил игрок {player}");
                                break;
                            }
                            Console.SetCursorPosition(savePositionX, savePositionY);
                            player = (player == "X") ? "O" : "X";
                        }
                    }
                }
                catch
                {
                    Console.Write("Введите числовое значение! ");
                    continue;
                }
            }
            Console.Write("Для выхода нажмите 'Enter'");
            Console.ReadKey();
}
        public static void ReadMap()
        {
            try
            {
                StreamReader sr = new StreamReader(mapFile);
                string[] mapLines = File.ReadAllLines(mapFile);
                foreach (string map in mapLines)
                {
                    Console.WriteLine(map);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Environment.Exit(0);
            }
        }
        public static void InstallationMapGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    stepsPlayers[i, j] = " ";
                }
            }
        }
        public static bool InsertMap(int _inputPlayer, string _player)
        {
            int positionX;
            int positionY;

            int i = 0;
            int j = 0;

            switch (_inputPlayer)
            {
                case 1:
                    positionX = 2;
                    positionY = 1;
                    break;
                case 2:
                    positionX = 6;
                    positionY = 1;
                    j = 1;
                    break;
                case 3:
                    positionX = 10;
                    positionY = 1;
                    j = 2;
                    break;
                case 4:
                    positionX = 2;
                    positionY = 3;
                    i = 1;
                    break;
                case 5:
                    positionX = 6;
                    positionY = 3;
                    i = 1;
                    j = 1;
                    break;
                case 6:
                    positionX = 10;
                    positionY = 3;
                    i = 1;
                    j = 2;
                    break;
                case 7:
                    positionX = 2;
                    positionY = 5;
                    i = 2;
                    break;
                case 8:
                    positionX = 6;
                    positionY = 5;
                    i = 2;
                    j = 1;
                    break;
                case 9:
                    positionX = 10;
                    positionY = 5;
                    i = j = 2;
                    break;
                default:
                    positionX = 0;
                    positionY = 0;
                    break;
            }
            if (InsertGame(i, j, _player))
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(_player);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool InsertGame(int i, int j, string input)
        {
            if (stepsPlayers[i, j] != " ")
            {
                Console.Write("Ячейка уже занята! ");
                return false;
            }
            else
            {
                stepsPlayers[i, j] = input;
                return true;
            }
        }
        private static bool CheckGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (stepsPlayers[i, j] == " " || WinGame())
                    {
                        return false;
                    }
                }
            }
            return true; 
        }
        public static bool WinGame()
        {
            for (int i = 0; i < 3; i++)
            {
                if (stepsPlayers[i, 0] != " " && stepsPlayers[i, 0] == stepsPlayers[i, 1] && stepsPlayers[i, 1] == stepsPlayers[i, 2])
                {
                    return true;
                }
            }
            for (int j = 0; j < 3; j++)
            {
                if (stepsPlayers[0, j] != " " && stepsPlayers[0, j] == stepsPlayers[1, j] && stepsPlayers[1, j] == stepsPlayers[2, j])
                {
                    return true;
                }
            }
            if (stepsPlayers[0, 0] != " " && stepsPlayers[0, 0] == stepsPlayers[1, 1] && stepsPlayers[1, 1] == stepsPlayers[2, 2])
            {
                return true;
            }
            if (stepsPlayers[2, 0] != " " && stepsPlayers[2, 0] == stepsPlayers[1, 1] && stepsPlayers[1, 1] == stepsPlayers[0, 2])
            {
                return true;
            }
            return false;
        }
    }
}

