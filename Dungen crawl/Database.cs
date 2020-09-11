using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Dungen_crawl
{
    class Database
    {
        private string connectionString = "Data Source=CV-BB-5988;Initial Catalog=Dungen_crawl;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private DataSet Execute(string query)
        {
            DataSet resultSet = new DataSet();
            using (SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(query, new SqlConnection(connectionString))))
            {
                adapter.Fill(resultSet);
            }
            return resultSet;
        }
        public List<Highscore> GetHighscores()
        {
            List<Highscore> allHighscores = new List<Highscore>(0);
            string allHighscoresQuery = "SELECT * FROM Highscore";
            DataSet resultSet = Execute(allHighscoresQuery);
            DataTable HighscoresTable = resultSet.Tables[0];
            foreach(DataRow highscoreRow in HighscoresTable.Rows)
            {
                string playerName = (string)highscoreRow["PlayerName"];
                int goblinsKilled = (int)highscoreRow["GoblinsKilled"];
                int orcsKilled = (int)highscoreRow["OrcsKilled"];
                int dragonsKilled = (int)highscoreRow["DragonsKilled"];
                int score = (int)highscoreRow["Score"];
                Highscore highscore = new Highscore(playerName, goblinsKilled, orcsKilled, dragonsKilled, score);
                allHighscores.Add(highscore);
            }
            return allHighscores;
        }
        public void AddNew(Highscore highscore)
        {
            string addNewHighscoreQuery = $"INSERT INTO Highscore (PlayerName, GoblinsKilled, OrcsKilled, DragonsKilled, Score) VALUES('{highscore.PlayerName}','{highscore.GoblinsKilled}','{highscore.OrcsKilled}','{highscore.DragonsKilled}','{highscore.Score}')";
            Execute(addNewHighscoreQuery);
        }
    }
}
