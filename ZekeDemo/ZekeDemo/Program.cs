using System;

namespace ZekeDemo
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Zeke game = new Zeke())
            {
                game.Run();
            }
        }
    }
#endif
}

