using SoulsSaveManager.Tools;
using System.Drawing;

namespace SoulsSaveManager
{
    internal class SaveManager
    {
        #region game list
        internal static string[] SoulsGameList =
        [
            "Dark Souls: Prepare To Die Edition",
            "Dark Souls: Remastered",
            "Dark Souls II",
            "Dark Souls III",
            "Sekiro: Shadow Die Twice",
            "Elden Ring"
        ];
        #endregion

        internal SaveManager(string gameName, string savePath, string saveFolderName, string customFolderName)
        {
            GameName = gameName;
            _savePath = savePath;
            _saveFolderName = saveFolderName;
            _customFolderName = customFolderName;
        }

        internal string GameName { get; private set; }
        private string _savePath, _saveFolderName, _customFolderName;

        private bool isExit = false;

        internal void Invoke()
        {
            Console.WriteLine($" ┌─────$> {GameName} <${new string('─', 100 - GameName.Length)}┐\n" +
                   " │!> To change the game prees 'F1'                                                                               │\n" +
                   " └───────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n" +
                   " ┌─────────────────────────────────────────────────────────────────────────────────────────────────────┐\n" +
                   " │$> [1]> Backup save to default folder                                                                │\n" +
                   " │$> [2]> Load save from default folder                                                                │\n" +
                   " │$> [3]> Backup save to another directory                                                             │\n" +
                   " │$> [4]> Load save from another directory                                                             │\n" +
                   " └─────────────────────────────────────────────────────────────────────────────────────────────────────┘\n"
                   );

            while (!isExit)
            {
                SelectBackupFunctions();
            }

            Console.Clear();
        }

        private void SelectBackupFunctions()
        {
            _ = Directory.CreateDirectory(WorkingPaths.DesktopPath);

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.F1:
                    isExit = true;
                    break;

                case ConsoleKey.D1:
                    MakeBackupToDefaultFolder();
                    break;

                case ConsoleKey.D2:
                    LoadBackupFromDefaulFolder();
                    break;

                case ConsoleKey.D3:
                    MakeBackupToCustomFolder();
                    break;

                case ConsoleKey.D4:
                    LoadBackupFromCustomFolder();
                    break;
            }
        }

        private void MakeBackupToDefaultFolder()
        {
            if (!Directory.Exists(_savePath))
            {
                ConsoleUtility.RemoveLine();
                Colorful.Console.WriteLine(" [!]> Save directory doesn't exist", Color.Red);
                return;
            }

            if (Directory.Exists(WorkingPaths.DesktopPath + $"/{_customFolderName}" + $"/{_saveFolderName}"))
                Directory.Delete(WorkingPaths.DesktopPath + $"/{_customFolderName}" + $"/{_saveFolderName}", true);

            Utility.CopyDirectory(_savePath, WorkingPaths.DesktopPath + $"/{_customFolderName}" + $"/{_saveFolderName}", true);

            ConsoleUtility.RemoveLine();
            Colorful.Console.WriteLine($" [!]> Default save succefull backuped at {DateTime.Now:hh:mm:ss}",
                Color.FromArgb(255, 198, 107, 255));
        }
        private void MakeBackupToCustomFolder()
        {
            if (!Directory.Exists(_savePath))
            {
                ConsoleUtility.RemoveLine();
                Colorful.Console.WriteLine(" [!]> Save directory doesn't exist", Color.Red);

                return;
            }
            ConsoleUtility.RemoveLine();
            Colorful.Console.Write(" [?]> New folder name >>> ", Color.FromArgb(255, 198, 107, 255));
            string? newSave_customFolderName = Console.ReadLine();

            Utility.CopyDirectory(_savePath, WorkingPaths.DesktopPath + $"/{_customFolderName}" + $"/{newSave_customFolderName}" + $"/{_saveFolderName}", true);

            ConsoleUtility.RemoveLine();
            Colorful.Console.WriteLine($" [!]> Save succefull backuped to \"{newSave_customFolderName}\" folder at " + $"{DateTime.Now.ToString("hh:mm:ss")}",
                Color.FromArgb(255, 198, 107, 255));
        }
        private void LoadBackupFromDefaulFolder()
        {
            if (!Directory.Exists(WorkingPaths.DesktopPath + $"/{_customFolderName}" + $"/{_saveFolderName}"))
            {
                ConsoleUtility.RemoveLine();
                Colorful.Console.WriteLine(" [!]> Backup save directory is an empty", Color.Red);
                return;
            }

            if (Directory.Exists(_savePath))
                Directory.Delete(_savePath, true);

            Utility.CopyDirectory(WorkingPaths.DesktopPath + $"/{_customFolderName}" + $"/{_saveFolderName}", _savePath, true);

            ConsoleUtility.RemoveLine();
            Colorful.Console.WriteLine($" [!]> Default save succefull loaded at " + $"{DateTime.Now:hh:mm:ss}",
                Color.FromArgb(255, 255, 110, 144));
        }
        private void LoadBackupFromCustomFolder()
        {
            ConsoleUtility.RemoveLine();

            if (Directory.Exists(WorkingPaths.DesktopPath + $"/{_customFolderName}"))
                Utility.GetSaveFolderList(WorkingPaths.DesktopPath + $"/{_customFolderName}");
            else
            {
                Colorful.Console.WriteLine($" [!]> {_customFolderName} doesn't exist", Color.Red);
                return;
            }

            Colorful.Console.Write(" [?]> Folder name >>> ", Color.FromArgb(255, 255, 110, 144));
            string? newSave_customFolderName = Console.ReadLine();

            if (!Directory.Exists(WorkingPaths.DesktopPath + $"/{_customFolderName}" + $"/{newSave_customFolderName}") || newSave_customFolderName == "")
            {
                ConsoleUtility.RemoveLines(new DirectoryInfo(WorkingPaths.DesktopPath + $"/{_customFolderName}").GetDirectories().Count() + 3);
                Colorful.Console.WriteLine($" [!]> \"{newSave_customFolderName}\" folder doesn't exist, try again :(", Color.Red);

                return;
            }
            if (Directory.Exists(_savePath))
                Directory.Delete(_savePath, true);

            Utility.CopyDirectory(WorkingPaths.DesktopPath + $"/{_customFolderName}" + $"/{newSave_customFolderName}" + $"/{_saveFolderName}", _savePath, true);

            ConsoleUtility.RemoveLines(new DirectoryInfo(WorkingPaths.DesktopPath + $"/{_customFolderName}").GetDirectories().Count() + 3);
            Colorful.Console.WriteLine($" [!]> \"{newSave_customFolderName}\" save succefull loaded at " + $"{DateTime.Now.ToString("hh:mm:ss")}",
                Color.FromArgb(255, 255, 110, 144));
        }
    }
}
