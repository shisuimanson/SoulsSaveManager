using System.Diagnostics;

namespace save_manager
{
    internal class Manager
    {

        internal static void SelectGame(string gameName, string savePath, string saveFolderName,string customFolderName)
        {
            Utility.InvokeText(gameName);
            while (true)
            {
                Console.Title = gameName;
                SelectBackupFunctions(savePath, saveFolderName, customFolderName);
            }
        }

        public static void GameSelection()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            Console.Clear();

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    SelectGame(GameList.SoulsGameList[0], StaticPath.DarkSoulsPreparePath, "NGBI/DarkSouls", "DarkSoulsPrepareToDieEdition_save");
                    break;

                case ConsoleKey.D2:
                    SelectGame(GameList.SoulsGameList[1], StaticPath.DarkSoulsRemasteredPath, "NGBI/DARK SOULS REMASTERED", "DarkSoulsRemastered_save");
                    break;

                case ConsoleKey.D3:
                    SelectGame(GameList.SoulsGameList[2], StaticPath.DarkSoulsIIPath, "DarkSoulsII", "DarkSoulsII_save");
                    break;

                case ConsoleKey.D4:
                    SelectGame(GameList.SoulsGameList[3], StaticPath.DarkSoulsIIIPath, "DarkSoulsIII", "DarkSoulsIII_save");
                    break;

                case ConsoleKey.D5:
                    SelectGame(GameList.SoulsGameList[4], StaticPath.SekiroPath, "Sekiro", "SekiroShadowDieTwice_save");
                break;

                case ConsoleKey.D6:
                    SelectGame(GameList.SoulsGameList[5], StaticPath.EldenRingPath, "EldenRing", "EldenRing_save");
                break;
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
                    Process.Start(AppDomain.CurrentDomain.FriendlyName);
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

                case ConsoleKey.D5:
                    AutoSave.ActivateAutoSave(gameSavePath, gameSaveFolderName, customFolderName);
                break;
            }
        }
    }
}
