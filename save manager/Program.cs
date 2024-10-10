using System.Drawing;

namespace save_manager
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Colorful.Console.ForegroundColor = Color.FromArgb(255, 151, 124, 163);
            Console.Title = "From Software Games Save Manager ";

            Console.WriteLine(" ┌─────$> Select supported games <$────────────────────────────────────────────────────────────────────┐\n" +
                              " │?>                                                                                                   │\n" +
                              " └─────────────────────────────────────────────────────────────────────────────────────────────────────┘\n" +
                              " ┌─────────────────────────────────────────────────────────────────────────────────────────────────────┐\n" +
                              " │$> [1]> Dark Souls Remastered                                                                        │\n" +
                              " │$> [2]> Dark Souls II                                                                                │\n" +
                              " │$> [3]> Dark Souls III                                                                               │\n" +
                              " │$> [4]> Sekiro: Shadow Die Twice                                                                     │\n" +
                              " │$> [5]> Elden Ring                                                                                   │\n" +
                              " └─────────────────────────────────────────────────────────────────────────────────────────────────────┘\n"
                              ); Console.SetCursorPosition(4, Console.CursorTop - 10);
            Manager.SelectGame();
        }
    }
}
