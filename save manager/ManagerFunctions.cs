using System.Drawing;

namespace save_manager
{
    internal class ManagerFunctions
    {
        internal static void MakeBackupToDefaultFolder(string gameSavePath, string gameSaveFolderName, string customFolderName)
        {
            if (!Directory.Exists(gameSavePath))
            {
                ConsoleUtility.RemoveString();
                Colorful.Console.WriteLine(" [!]> Save directory doesn't exist", Color.Red);
                return;
            }

            if (Directory.Exists(StaticPath.DesktopPath + $"/{customFolderName}" + $"/{gameSaveFolderName}")) 
                Directory.Delete(StaticPath.DesktopPath + $"/{customFolderName}" + $"/{gameSaveFolderName}", true);

            Utility.CopyDirectory(gameSavePath, StaticPath.DesktopPath + $"/{customFolderName}" + $"/{gameSaveFolderName}", true);

            ConsoleUtility.RemoveString();
            Colorful.Console.WriteLine($" [!]> Default save succefull backuped at {DateTime.Now.ToString("hh:mm:ss")}",
                Color.FromArgb(255, 198, 107, 255));
        }

        internal static void LoadBackupFromDefaulFolder(string gameSavePath, string gameSaveFolderName, string customFolderName)
        {
            if (!Directory.Exists(StaticPath.DesktopPath + $"/{customFolderName}" + $"/{gameSaveFolderName}"))
            {
                ConsoleUtility.RemoveString();
                Colorful.Console.WriteLine(" [!]> Backup save directory is an empty", Color.Red);
                return;
            }

            if (Directory.Exists(gameSavePath))
                Directory.Delete(gameSavePath, true);

            Utility.CopyDirectory(StaticPath.DesktopPath + $"/{customFolderName}" + $"/{gameSaveFolderName}", gameSavePath, true);

            ConsoleUtility.RemoveString();
            Colorful.Console.WriteLine($" [!]> Default save succefull loaded at " + $"{DateTime.Now.ToString("hh:mm:ss")}",
                Color.FromArgb(255, 255, 110, 144));
        }

        internal static void MakeBackupToCustomFolder(string gameSavePath, string gameSaveFolderName, string customFolderName)
        {
            if (!Directory.Exists(gameSavePath))
            {
                ConsoleUtility.RemoveString();
                Colorful.Console.WriteLine(" [!]> Save directory doesn't exist", Color.Red);

                return;
            }
            ConsoleUtility.RemoveString();
            Colorful.Console.Write(" [?]> New folder name >>> ", Color.FromArgb(255, 198, 107, 255));
            string? newSaveCustomFolderName = Console.ReadLine();

            Utility.CopyDirectory(gameSavePath, StaticPath.DesktopPath + $"/{customFolderName}" + $"/{newSaveCustomFolderName}" + $"/{gameSaveFolderName}", true);

            ConsoleUtility.RemoveString();
            Colorful.Console.WriteLine($" [!]> Save succefull backuped to \"{newSaveCustomFolderName}\" folder at " + $"{DateTime.Now.ToString("hh:mm:ss")}", 
                Color.FromArgb(255, 198, 107, 255));
        }

        internal static void LoadBackupFromCustomFolder(string gameSavePath, string gameSaveFolderName, string customFolderName)
        {
            ConsoleUtility.RemoveString();

            if(Directory.Exists(StaticPath.DesktopPath + $"/{customFolderName}"))
                Utility.GetFolderList(StaticPath.DesktopPath + $"/{customFolderName}");
            else
            {
                Colorful.Console.WriteLine($" [!]> {customFolderName} doesn't exist", Color.Red);
                return;
            }


            Colorful.Console.Write(" [?]> Folder name >>> ", Color.FromArgb(255, 255, 110, 144));
            string? newSaveCustomFolderName = Console.ReadLine();

            if (!Directory.Exists(StaticPath.DesktopPath + $"/{customFolderName}" + $"/{newSaveCustomFolderName}") || newSaveCustomFolderName == "")
            {
                ConsoleUtility.RemoveMoreString(new DirectoryInfo(StaticPath.DesktopPath + $"/{customFolderName}").GetDirectories().Count() + 3);
                Colorful.Console.WriteLine($" [!]> \"{newSaveCustomFolderName}\" folder doesn't exist, try again :(", Color.Red);

                return;
            }
            if (Directory.Exists(gameSavePath))
               Directory.Delete(gameSavePath, true);

            Utility.CopyDirectory(StaticPath.DesktopPath + $"/{customFolderName}" + $"/{newSaveCustomFolderName}" + $"/{gameSaveFolderName}", gameSavePath, true);

            ConsoleUtility.RemoveMoreString(new DirectoryInfo(StaticPath.DesktopPath + $"/{customFolderName}").GetDirectories().Count() + 3);
            Colorful.Console.WriteLine($" [!]> \"{newSaveCustomFolderName}\" save succefull loaded at " + $"{DateTime.Now.ToString("hh:mm:ss")}", 
                Color.FromArgb(255, 255, 110, 144));
        }
    }
}
