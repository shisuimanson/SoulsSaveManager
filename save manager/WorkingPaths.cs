namespace SoulsSaveManager
{
    internal static class WorkingPaths
    {
        internal static string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        internal static string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/backup";
        internal static string DarkSoulsPreparePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/NGBI/DarkSouls";
        internal static string DarkSoulsRemasteredPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/NBGI/DARK SOULS REMASTERED";
        internal static string DarkSoulsIIPath = AppDataPath + "/DarkSoulsII";
        internal static string DarkSoulsIIIPath = AppDataPath + "/DarkSoulsIII";
        internal static string SekiroPath = AppDataPath + "/Sekiro";
        internal static string EldenRingPath = AppDataPath + "/EldenRing";
        internal static string BloodbornePath;
    }
}