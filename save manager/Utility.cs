namespace save_manager
{
    internal class Utility
    {
        public static void InvokeText(string gameName)
        {
            int visualLineLenght = gameName.Length;
            for (int i = 0; visualLineLenght < 100; i++)
            {
                visualLineLenght++;
            }
            visualLineLenght = visualLineLenght - gameName.Length;

            Console.WriteLine($" ┌─────$> {gameName} <${new string('─', visualLineLenght)}┐\n" +
                                   " │!> To change the game prees 'F1'                                                                               │\n" +
                                   " └───────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n" +
                                   " ┌─────────────────────────────────────────────────────────────────────────────────────────────────────┐\n" +
                                   " │$> [1]> Backup save to default folder                                                                │\n" +
                                   " │$> [2]> Load save from default folder                                                                │\n" +
                                   " │$> [3]> Backup save to another directory                                                             │\n" +
                                   " │$> [4]> Load save from another directory                                                             │\n" +
                                   " └─────────────────────────────────────────────────────────────────────────────────────────────────────┘\n"
                                  );
        }
        internal static void GetFolderList(string gameCustomBackupFolder)
        {
            var directories = new DirectoryInfo(gameCustomBackupFolder).GetDirectories();

            int visualLineLenght = directories.Max(x => x.FullName.Length) + 5;
            Console.WriteLine($" ┌{new string('─', visualLineLenght)}┐");

            for (int i = 0; i < directories.Length; i++)
            {
                Console.WriteLine(" │" + $"[{i + 1}]> " + directories[i].Name +
                    $"{new string(' ', visualLineLenght - (directories[i].Name.Length + 5))}│");
            }

            Console.WriteLine($" └{new string('─', visualLineLenght)}┘");
        }

        public static void CopyDirectory(string? sourceDir, string? destinationDir, bool recursive)
        {
            try
            {
                var dir = new DirectoryInfo(sourceDir);
                if (!dir.Exists)
                    throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");
                DirectoryInfo[] dirs = dir.GetDirectories();

                Directory.CreateDirectory(destinationDir);

                foreach (FileInfo file in dir.GetFiles())
                {
                    string targetFilePath = Path.Combine(destinationDir, file.Name);
                    file.CopyTo(targetFilePath);
                }

                if (recursive)
                {
                    foreach (DirectoryInfo subDir in dirs)
                    {
                        string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                        CopyDirectory(subDir.FullName, newDestinationDir, true);
                    }
                }
            }
            catch (Exception ex) { }
        }
    }
}
