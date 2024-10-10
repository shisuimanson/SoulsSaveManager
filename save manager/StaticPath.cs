namespace save_manager
{
    internal class StaticPath
    {
        public static string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/backup";
        public static string DarkSoulsRemasteredPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/NBGI/DARK SOULS REMASTERED";
        public static string DarkSoulsIIPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/DarkSoulsII";
        public static string DarkSoulsIIIPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/DarkSoulsIII";
        public static string SekiroPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Sekiro";
        public static string EldenRingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/EldenRing";
    }
}
