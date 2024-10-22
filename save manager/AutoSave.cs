//using System.Drawing;

//namespace save_manager
//{
//    internal class AutoSave
//    {
//        public static bool AutoSaveStatus = false;
//        internal static void ActivateAutoSave(string gameSavePath, string gameSaveFolderName, string customFolderName)
//        {
//            AutoSaveStatus = !AutoSaveStatus;

//            if (AutoSaveStatus)
//            {
//                if (!Directory.Exists(gameSavePath))
//                {
//                    ConsoleUtility.RemoveString();
//                    Colorful.Console.WriteLine(" [!]> Save directory doesn't exist", Color.Red);
//                    return;
//                }

//                if (Directory.Exists(StaticPath.DesktopPath + $"/{customFolderName}" + $"/{gameSaveFolderName}"))
//                    Directory.Delete(StaticPath.DesktopPath + $"/{customFolderName}" + $"/{gameSaveFolderName}", true);

//                Utility.CopyDirectory(StaticPath.DesktopPath + $"/{customFolderName}" + $"/{gameSaveFolderName}_autosave_{DateTime.Now.ToString("dd:mm:yy_hh:mm:ss")}", gameSavePath, true);

//            }
//        }
//    }
//}
