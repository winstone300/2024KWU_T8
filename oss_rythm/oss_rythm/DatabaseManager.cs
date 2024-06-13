using System;
using System.Data;

namespace oss_rythm
{
    public static class DatabaseManager
    {
        private static DataSet dataSet = new DataSet("MusicDataSet");

        static DatabaseManager()
        {
            DataTable dataTable = new DataTable("MusicList");
            dataTable.Columns.Add("Username", typeof(string));
            dataTable.Columns.Add("FileName", typeof(string));
            dataTable.Columns.Add("BPM", typeof(string));
            dataTable.Columns.Add("Score", typeof(string));
            dataTable.Columns.Add("Combo", typeof(string));
            dataTable.Columns.Add("Difficulty", typeof(string));

            dataSet.Tables.Add(dataTable);
        }

        public static DataTable GetMusicList(string username)
        {
            // Create a DataView to filter the DataTable by UserId
            DataView view = new DataView(dataSet.Tables["MusicList"]);
            view.RowFilter = $"Username = '{username}'";

            // Check if the DataView contains any rows
            if (view.Count > 0)
            {
                // Convert DataView back to DataTable
                return view.ToTable();
            }
            else
            {
                // Return an empty DataTable with the same schema if no rows are found
                return dataSet.Tables["MusicList"].Clone();
            }
        }

        public static void AddOrUpdateMusicList(string username, string fileName, string bpm, string score, string combo, string difficulty)
        {
            DataTable table = dataSet.Tables["MusicList"];
            DataRow[] rows = table.Select($"Username = '{username}' AND FileName = '{fileName}'");

            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                row["BPM"] = bpm;
                row["Score"] = score;
                row["Combo"] = combo;
                row["Difficulty"] = difficulty;
            }
            else
            {
                table.Rows.Add(username, fileName, bpm, score, combo, difficulty);
            }
        }
    }
}
