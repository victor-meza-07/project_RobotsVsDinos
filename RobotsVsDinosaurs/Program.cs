﻿using System;

namespace RobotsVsDinosaurs
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine gameEngine = new GameEngine();
            while (true) 
            {
                gameEngine.Start();
            }
            
        }
    }
}
