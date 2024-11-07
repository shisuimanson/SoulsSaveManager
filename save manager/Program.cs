using System.Drawing;

namespace SoulsSaveManager
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Initialize();

            while (true)
            {
                SaveManager saveManager = null!;

                #region StartingProgram
                Console.WriteLine(" ┌─────$> Select supported games <$────────────────────────────────────────────────────────────────────┐\n" +
                                  " │?>                                                                                                   │\n" +
                                  " └─────────────────────────────────────────────────────────────────────────────────────────────────────┘"
                                  );

                Console.WriteLine(" ┌─────────────────────────────────────────────────────────────────────────────────────────────────────┐");

                for (int i = 0; i < SaveManager.SoulsGameList.Length; i++)
                {
                    Console.WriteLine($" │$> [{i + 1}]> {SaveManager.SoulsGameList[i]}" +
                        $"{new string(' ', (SaveManager.SoulsGameList.Max(x => x.Length) - SaveManager.SoulsGameList[i].Length) + 59)}│");
                }

                Console.WriteLine(" └─────────────────────────────────────────────────────────────────────────────────────────────────────┘");
                Console.SetCursorPosition(4, Console.CursorTop - 10);
                #endregion

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.Clear();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        saveManager = new SaveManager("Dark Souls: Prepare To Die Edition", WorkingPaths.DarkSoulsPreparePath, "NGBI/DarkSouls", "DarkSoulsPrepareToDieEdition_save");
                        break;

                    case ConsoleKey.D2:
                        saveManager = new SaveManager("Dark Souls: Remastered", WorkingPaths.DarkSoulsRemasteredPath, "NGBI/DARK SOULS REMASTERED", "DarkSoulsRemastered_save");
                        break;

                    case ConsoleKey.D3:
                        saveManager = new SaveManager("Dark Souls II", WorkingPaths.DarkSoulsIIPath, "DarkSoulsII", "DarkSoulsII_save");
                        break;

                    case ConsoleKey.D4:
                        saveManager = new SaveManager("Dark Souls III", WorkingPaths.DarkSoulsIIIPath, "DarkSoulsIII", "DarkSoulsIII_save");
                        break;

                    case ConsoleKey.D5:
                        saveManager = new SaveManager("Sekiro: Shadows Die Twice", WorkingPaths.SekiroPath, "Sekiro", "SekiroShadowsDieTwice_save");
                        break;

                    case ConsoleKey.D6:
                        saveManager = new SaveManager("Elden Ring", WorkingPaths.EldenRingPath, "EldenRing", "EldenRing_save");
                        break;
                    default: continue;

                }

                Console.Title = saveManager.GameName;

                saveManager.Invoke();
            }
        }

        private static void Initialize() 
        {
            Colorful.Console.ForegroundColor = Color.FromArgb(255, 151, 124, 163);
            Console.Title = "From Software Games Save Manager ";
        }
    }
}
