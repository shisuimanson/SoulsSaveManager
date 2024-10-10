namespace save_manager
{
    internal class ConsoleUtility
    {
        public static void InvokeText(string gameName)
        {
            int visualLineLenght = gameName.Length;
            for (int i = 0; visualLineLenght < 100 ; i++)
            {
                visualLineLenght++;
            }
            visualLineLenght = visualLineLenght - gameName.Length;

            Console.WriteLine(    $" ┌─────$> {gameName} <${new string('─', visualLineLenght)}┐\n" +
                                   " │!> To change the game prees 'F1'                                                                               │\n" +
                                   " └───────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n" +
                                   " ┌─────────────────────────────────────────────────────────────────────────────────────────────────────┐\n" +
                                   " │$> [1]> Backup save                                                                                  │\n" +
                                   " │$> [2]> Load backuped save                                                                           │\n" +
                                   " │$> [3]> Backup save to another directory                                                             │\n" +
                                   " │$> [4]> Load save from another directory                                                             │\n" +
                                   " └─────────────────────────────────────────────────────────────────────────────────────────────────────┘\n"
                                  );
        }

        public static void RemoveMoreString(int count)
        {
            for(int i = 0; i < count; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.BufferWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
        }

        public static void RemoveString()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}
