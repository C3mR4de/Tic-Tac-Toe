using System;

namespace Крестики_нолики
{
    class Program
    {
        static class Game
        {
            static char[,] Field = new char[3, 3] {
                {'1', '2', '3'},
                {'4', '5', '6'},
                {'7', '8', '9'}
            };

            static bool IsCrossesTurn = true;
            static int TotalMoves = 0;

            static void DrawField()
            {
                Console.WriteLine("#=#=#=#=#=#=#");
                Console.WriteLine("# {0} # {1} # {2} #", Field[0, 0], Field[0, 1], Field[0, 2]);
                Console.WriteLine("#=#=#=#=#=#=#");
                Console.WriteLine("# {0} # {1} # {2} #", Field[1, 0], Field[1, 1], Field[1, 2]);
                Console.WriteLine("#=#=#=#=#=#=#");
                Console.WriteLine("# {0} # {1} # {2} #", Field[2, 0], Field[2, 1], Field[2, 2]);
                Console.WriteLine("#=#=#=#=#=#=#");
            }

            public static void Process()
            {
                while (true)
                {
                    int Coordinate;

                    DrawField();

                    for (int i = 0; i < 3; i++)
                    {
                        if (Field[i, 0] == Field[i, 1] && Field[i, 1] == Field[i, 2])
                        {
                            if (Field[i, 0] == 'X')
                                Console.WriteLine("\nКрестики выиграли!");
                            else if (Field[i, 0] == '0')
                                Console.WriteLine("\nНолики выиграли!");

                            Console.ReadKey(true);
                            Environment.Exit(0);
                        }
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        if (Field[0, i] == Field[1, i] && Field[1, i] == Field[2, i])
                        {
                            if (Field[0, i] == 'X')
                                Console.WriteLine("\nКрестики выиграли!");
                            else if (Field[0, i] == '0')
                                Console.WriteLine("\nНолики выиграли!");

                            Console.ReadKey(true);
                            Environment.Exit(0);
                        }
                    }


                    if (Field[0, 0] == Field[1, 1] && Field[1, 1] == Field[2, 2])
                    {
                        if (Field[0, 0] == 'X')
                            Console.WriteLine("Крестики выиграли!");
                        else if (Field[0, 0] == '0')
                            Console.WriteLine("Нолики выиграли!");

                        Console.ReadKey(true);
                        Environment.Exit(0);
                    }

                    if (Field[2, 0] == Field[1, 1] && Field[1, 1] == Field[0, 2])
                    {
                        if (Field[2, 0] == 'X')
                            Console.WriteLine("\nКрестики выиграли!");
                        else if (Field[2, 0] == '0')
                            Console.WriteLine("\nНолики выиграли!");

                        Console.ReadKey(true);
                        Environment.Exit(0);
                    }

                    if (TotalMoves == 9)
                    {
                        Console.WriteLine("\nНичья!");
                        Environment.Exit(0);
                    }

                    try
                    {
                        if (IsCrossesTurn)
                            Console.WriteLine("\nХод крестиков");
                        else
                            Console.WriteLine("\nХод ноликов");

                        Console.Write("Введите номер клетки: ");
                        Coordinate = int.Parse(Console.ReadLine());

                        if (Coordinate < 1 || Coordinate > 9)
                        {
                            throw new Exception();
                        }

                        int x = (Coordinate - 1) % 3;
                        int y = (Coordinate - 1) / 3;

                        if (Field[y, x] != 'X' && Field[y, x] != '0')
                        {
                            if (IsCrossesTurn)
                                Field[y, x] = 'X';
                            else
                                Field[y, x] = '0';

                            TotalMoves++;
                            IsCrossesTurn = !IsCrossesTurn;
                        }
                        else
                        {
                            Console.WriteLine("Эта клетка уже занята!");
                            Console.ReadKey(true);
                        }

                        Console.Clear();

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Неверно введены данные!");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Game.Process();
        }
    }
}