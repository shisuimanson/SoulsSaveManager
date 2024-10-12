using System.Diagnostics;

namespace save_manager
{
    internal class Manager
    {
        public static void SelectGame()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            Console.Clear();

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                ConsoleUtility.InvokeText("Dark Souls: Prepare To Die Edition");
                    while (true)
                    {
                        Console.Title = "Dark Souls: Prepare To Die Edition";
                        SelectBackupFunctions(StaticPath.DarkSoulsPreparePath, "NBGI/DarkSouls", "DarkSoulsPrepareToDieEdition_save");
                    }
                case ConsoleKey.D2:
                    ConsoleUtility.InvokeText("Dark Souls Remastered");
                    while (true)
                    {
                        Console.Title = "Dark Souls Remastered";
                        SelectBackupFunctions(StaticPath.DarkSoulsRemasteredPath, "NBGI/DARK SOULS REMASTERED", "DarkSoulsRemastered_save");
                    }
                   
                case ConsoleKey.D3:
                    ConsoleUtility.InvokeText("Dark Souls II");
                    while (true)
                    {
                        Console.Title = "Dark Souls II";
                        SelectBackupFunctions(StaticPath.DarkSoulsIIPath, "DarkSoulsII", "DarkSoulsII_save");
                    }
                case ConsoleKey.D4:
                    ConsoleUtility.InvokeText("Dark Souls III");
                    while (true)
                    {
                        Console.Title = "Dark Souls III";
                        SelectBackupFunctions(StaticPath.DarkSoulsIIIPath, "DarkSoulsIII", "DarkSoulsIII_save");
                    }
                case ConsoleKey.D5:
                    ConsoleUtility.InvokeText("Sekiro: Shadow Die Twice");
                    while (true)
                    {
                        Console.Title = "Sekiro";
                        SelectBackupFunctions(StaticPath.SekiroPath, "Sekiro", "SekiroShadowDieTwice_save");
                    }
                case ConsoleKey.D6:
                    ConsoleUtility.InvokeText("Elden Ring");
                    while (true)
                    {
                        Console.Title = "Elden Ring";
                        SelectBackupFunctions(StaticPath.EldenRingPath, "EldenRing", "EldenRing_save");
                    }
            }
        }

        public static void SelectBackupFunctions(string gameSavePath, string gameSaveFolderName, string customFolderName)
        {
            if (Directory.Exists(StaticPath.DesktopPath) == false)
            {
                Directory.CreateDirectory(StaticPath.DesktopPath);
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch(keyInfo.Key)
            {
                case ConsoleKey.F1:
                    Console.Clear();
                    Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                    Environment.Exit(0);
                break;

                case ConsoleKey.D1:
                    ManagerFunctions.MakeBackupToDefaultFolder(gameSavePath, gameSaveFolderName, customFolderName);
                break;

                case ConsoleKey.D2:
                    ManagerFunctions.LoadBackupFromDefaulFolder(gameSavePath, gameSaveFolderName, customFolderName);
                break;

                case ConsoleKey.D3:
                    ManagerFunctions.MakeBackupToCustomFolder(gameSavePath, gameSaveFolderName, customFolderName);
                break;

                case ConsoleKey.D4:
                    ManagerFunctions.LoadBackupFromCustomFolder(gameSavePath, gameSaveFolderName, customFolderName);
                break;
            }
        }
    }
}
