namespace save_manager
{
    internal class StaticPath
    {
        public static string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/backup";
        public static string DarkSoulsPreparePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/NGBI/DarkSouls";
        public static string DarkSoulsRemasteredPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/NBGI/DARK SOULS REMASTERED";
        public static string DarkSoulsIIPath = AppDataPath + "/DarkSoulsII";
        public static string DarkSoulsIIIPath = AppDataPath + "/DarkSoulsIII";
        public static string SekiroPath = AppDataPath + "/Sekiro";
        public static string EldenRingPath = AppDataPath + "/EldenRing";
    }
}
