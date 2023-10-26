using System;
using System.Collections.Generic;
using System.Linq;

class MazeGame
{
    static char[,] Maze;
    static int PlayerX;
    static int PlayerY;
    static bool MazeSecret = false;
    static bool MazeCreated = false;
    static Random random = new Random();
    static ConsoleColor currentBackgroundColor = ConsoleColor.Gray;
    static ConsoleColor[] Colorpalette = { ConsoleColor.DarkYellow, ConsoleColor.DarkRed, ConsoleColor.DarkGreen, ConsoleColor.Black };

    static void Main()
    {
        StartGame();
    }

    static void StartGame()
    {
        for (int level = 1; level <= 100d; level++)
        {
            if (!MazeCreated)
            {
                PrepareMaze(level);
                MazeCreated = true;
            }

            if (level % 25 == 1)
            {
                currentBackgroundColor = Colorpalette[(level / 10) % Colorpalette.Length];
            }

            Console.BackgroundColor = currentBackgroundColor;
            Console.Clear();

            ShowMaze();

            Console.WriteLine($"Level {level}");
            Console.WriteLine("Labirenti görmek için bir tuşa basın...");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.KeyChar == 'h')
            {
                MazeSecret = !MazeSecret;
                ShowMaze();
            }
            else if (keyInfo.KeyChar == 'r')
            {
                PrepareMaze(level);
                ShowMaze();
                MazeCreated = true;
            }
            else if (keyInfo.KeyChar == 'i')
            {
                ShowHint();
                ShowMaze();
            }

            while (true)
            {
                keyInfo = Console.ReadKey(true);
                char MovementDirection = keyInfo.KeyChar;

                if (MovementDirection == 'h')
                {
                    MazeSecret = !MazeSecret;
                    ShowMaze();
                }
                else if (MovementDirection == 'r')
                {
                    PrepareMaze(level);
                    ShowMaze();
                    MazeCreated = true;
                }
                else if (MovementDirection == 'i')
                {
                    ShowHint();
                    ShowMaze();
                }
                else if (MovemenControl(MovementDirection))
                {
                    Console.BackgroundColor = currentBackgroundColor;
                    Console.Clear();
                    ShowMaze();

                    if (PlayerX == Maze.GetLength(1) - 2 && PlayerY == Maze.GetLength(0) - 2)
                    {
                        Console.WriteLine("Tebrikler! Çıkışa ulaştınız!");
                        MazeCreated = false;
                        break;
                    }

                    int Distance = Math.Abs(PlayerX - (Maze.GetLength(1) - 2)) + Math.Abs(PlayerY - (Maze.GetLength(0) - 2));
                    if (Distance <= 3)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Blue;

                    Console.WriteLine(Distance <= 3 ? "Sıcak" : "Soğuk");
                    Console.ResetColor();
                }
            }
        }

        Console.WriteLine("Oyun tamamlandı!");
    }

    static void SetTarget()
    {
        Maze[Maze.GetLength(0) - 2, Maze.GetLength(1) - 2] = ' ';
    }

    static void ShowHint()
    {
        if (MazeSecret)
            return;

        int TargetX = Maze.GetLength(1) - 2;
        int TargetY = Maze.GetLength(0) - 2;

        int tempX = PlayerX;
        int tempY = PlayerY;

        while (tempX != TargetX || tempY != TargetY)
        {
            Maze[tempY, tempX] = '.';
            if (tempX < TargetX) tempX++;
            else if (tempX > TargetX) tempX--;

            if (tempY < TargetY) tempY++;
            else if (tempY > TargetY) tempY--;
        }

    
        ShowMaze();
    }

    static void RandomStart()
    {
        do
        {
            PlayerX = random.Next(1, Maze.GetLength(1) - 1);
            PlayerY = random.Next(1, Maze.GetLength(0) - 1);
        } while (Maze[PlayerY, PlayerX] == '#' || (PlayerX == Maze.GetLength(1) - 2 && PlayerY == Maze.GetLength(0) - 2));
    }

    static bool MovemenControl(char Direction)
    {
        int TargetX = PlayerX;
        int TargetY = PlayerY;

        switch (Direction)
        {
            case 'w':
                TargetY--;
                break;
            case 's':
                TargetY++;
                break;
            case 'a':
                TargetX--;
                break;
            case 'd':
                TargetX++;
                break;
        }

        if (TargetX >= 0 && TargetX < Maze.GetLength(1) && TargetY >= 0 && TargetY < Maze.GetLength(0) && Maze[TargetY, TargetX] != '#')
        {
            PlayerX = TargetX;
            PlayerY = TargetY;
            return true;
        }

        return false;
    }

    static void PrepareMaze(int level)
    {
        int Size = 5 + level * 2;
        Maze = new char[Size, Size];

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Maze[i, j] = ' ';
            }
        }

        for (int i = 0; i < Size; i++)
        {
            Maze[i, 0] = '#';
            Maze[i, Size - 1] = '#';
            Maze[0, i] = '#';

            Maze[Size - 1, i] = '#';
        }

        for (int i = 1; i < Size - 1; i++)
        {
            for (int j = 1; j < Size - 1; j++)
            {
                if (random.Next(10) < 2)
                {
                    Maze[i, j] = '#';
                }
            }
        }

        RandomStart();
        SetTarget();
        Console.ForegroundColor = ConsoleColor.White;
    }

    static void ShowMaze()
    {
        Console.Clear();
        if (MazeSecret)
        {
            Console.Clear();
            Console.WriteLine("Labirent gizli. Göstermek için 'h' tuşuna basın.");
            return;
        }

        Console.ForegroundColor = ConsoleColor.White;

        for (int i = 0; i < Maze.GetLength(0); i++)
        {
            for (int j = 0; j < Maze.GetLength(1); j++)
            {
                if (i == PlayerY && j == PlayerX)
                    Console.Write('O');
                else
                    Console.Write(Maze[i, j]);
            }
            Console.WriteLine();
        }
        Console.SetCursorPosition(0, Maze.GetLength(0) + 2); 

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Çok Kolay/");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("Kolay/");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("Orta/");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Zor");
        Console.ResetColor();
        Console.WriteLine("İpucu İçin 'İ' Tuşuna Basıp Enter a basınız ");
        Console.WriteLine("Sıkışılırsa Veya Çıkmak İmkansızsa 'R' Tuşuna Enter a basınız ");
    }
}
