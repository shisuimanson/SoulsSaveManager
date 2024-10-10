namespace save_manager
{
    internal class Utility
    {
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
