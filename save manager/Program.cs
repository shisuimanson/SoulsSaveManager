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
                              " └─────────────────────────────────────────────────────────────────────────────────────────────────────┘"
                              ); 

            Console.WriteLine(" ┌─────────────────────────────────────────────────────────────────────────────────────────────────────┐");

            for (int i = 0; i < GameList.SoulsGameList.Count; i++)
            {
                Console.WriteLine($" │$> [{i + 1}]> {GameList.SoulsGameList[i]}" + 
                    $"{new string(' ', (GameList.SoulsGameList.Max(x => x.Length) - GameList.SoulsGameList[i].Length) + 59)}│");
            }

            Console.WriteLine(" └─────────────────────────────────────────────────────────────────────────────────────────────────────┘");
            Console.SetCursorPosition(4, Console.CursorTop - 10);

            Manager.GameSelection();
        }
    }
}
