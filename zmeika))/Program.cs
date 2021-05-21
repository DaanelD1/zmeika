using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame {
    class Game
    {
        static readonly int x = 80;
        static readonly int y = 26;


        static Walls walls;
        static Snake snake;
        static FoodFactory foodFactory;
        static Timer time;

        static void Main()
        {
            Console.SetWindowSize(x + 1, y + 1);
            Console.SetBufferSize(x + 1, y + 1);
            Console.CursorVisible = false;

            walls = new Walls(x, y, "!!!");
            snake = new SnakeGame(x / 2, y / 2, 3);

            foodFactory(x, y, ":)");
            foodFactory.CreateFood();

            time = new Timer(Loop, null, 0, 200);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.Rotation(key.Key);
                }
            }
        }
        static void Loop(objekt obj)
        {
            if (walls.IsHit(snake.GetHead()) || snake.IsHit(snake.GetHead()))
            {
                time.Change(0, Timeout.Infinite);
            }
        }
    }
}

