namespace Maui.CommandPattern.BlazorHybrid.Constants
{
    public static class SqLiteConstants
    {
        public const string DatabaseFilename = "CommandPattern.db3";

        public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

        public static string WindowsDatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public static string AndriodDatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public static string IosDatabasePath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", DatabaseFilename);

        public static string GetDatabasePath()
        {
            var databasePath = "";

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                databasePath = AndriodDatabasePath;
            }
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                SQLitePCL.Batteries_V2.Init();
                databasePath = IosDatabasePath;
            }
            else
            {
                databasePath = WindowsDatabasePath;
            }

            return databasePath;

        }
    }
}
