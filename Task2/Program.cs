using System;
using System.IO;

namespace Task2
{
    class Program
    {
        public static string[,] historyGame = new string[3, 3]; // массив игрового поля

        static void Main(string[] args)
        {
            bool gameOver = false;

            string player = "X";

            Console.Title = "TicTacToe";

            if (!ReadMap())
            {
                Console.WriteLine("Файл игрового поля не найден! (map.txt)");
            }
            else
            {
                InstallationHistoryGame();

                Console.WriteLine("\nПриветствуем Вас в нашей игре Крестики Нолики!");
                Console.WriteLine("Введите номер ячейки игрового поля. Число от 1 до 9");

                int savePositionX = 0; // Сохранение позиции курсора "X"
                while (!gameOver)
                {
                    int savePositionY = Console.CursorTop + 1;   // Сохранение позиции курсора "Y" с переносом на следующую строку, для истории

                    Console.Write($"Ваш ход '{player}': ");
                    try
                    {
                        int inputPlayer = Convert.ToInt32(Console.ReadLine());
                        if (inputPlayer < 0 || inputPlayer > 9)
                        {
                            Console.Write("Введите число от 1 до 9! ");
                            continue;
                        }
                        else if (InsertMap(inputPlayer, player)) // Записываем в массив ход игрока
                        {
                            if (gameOver = CheckGame())
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
        }

        public static bool ReadMap() // Выводим игровое поле из файла
        {
            string mapFile = "map.txt";
            try
            {
                StreamReader sr = new StreamReader(mapFile);
                string[] mapLines = File.ReadAllLines(mapFile);
                foreach (string map in mapLines)
                {
                    Console.WriteLine(map);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void InstallationHistoryGame() // Инициализируем массив для хода игрока
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    historyGame[i, j] = " ";
                }
            }
        }

        public static bool InsertMap(int _inputPlayer, string _player) // вставка символа игрока на игровое поле
        {
            int positionX; // позиция курсора по X

            int positionY; // позиция курсора по Y

            int i = 0; // позиция в массиве
            int j = 0;

            switch (_inputPlayer) // определение координат для вставки символа игрока
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

        public static bool InsertGame(int i, int j, string input) // Записываем в массив ход игрока
        {
            if (historyGame[i, j] != " ")
            {
                Console.Write("Ячейка уже занята! ");
                return false;
            }
            else
            {
                historyGame[i, j] = input;
                return true;
            }
        }

        private static bool CheckGame() // смотрим использовали ли игроки все свои ходы
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (historyGame[i, j] == " ")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool WinGame() // Проверяем кто победил
        {
            for (int i = 0; i < 3; i++) // строки
            {
                if (historyGame[i, 0] != " " && historyGame[i, 0] == historyGame[i, 1] && historyGame[i, 1] == historyGame[i, 2])
                {
                    return true;
                }
            }

            for (int j = 0; j < 3; j++) // столбцы
            {
                if (historyGame[0, j] != " " && historyGame[0, j] == historyGame[1, j] && historyGame[1, j] == historyGame[2, j])
                {
                    return true;
                }
            }

            if (historyGame[0, 0] != " " && historyGame[0, 0] == historyGame[1, 1] && historyGame[1, 1] == historyGame[2, 2])
            {
                return true;
            }

            if (historyGame[2, 0] != " " && historyGame[2, 0] == historyGame[1, 1] && historyGame[1, 1] == historyGame[0, 2])
            {

                return true;
            }
            return false;
        }

    }
}

