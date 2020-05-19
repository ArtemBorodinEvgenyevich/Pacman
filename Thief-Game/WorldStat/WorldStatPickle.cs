using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace Thief_Game
{
    class WorldStatPickle
    {
        private string pathToFile;
        
        // Создает файл в папке ~/Thief-Game/bin/docs/netcoreapp3.1
        // тк в дебаг версии эта папка является рабочей
        public WorldStatPickle()
        {
            pathToFile = Path.Combine(PathInfo.WorkingDir, "ScoreRecord.json");
            
            if (!File.Exists(pathToFile))
            {
                File.Create(pathToFile).Close();
                string jsonString = @"{""ScoreTotal"":0,""ScoreRecord"":[1500, 1400]}";
                File.WriteAllText(pathToFile, jsonString);
            }
            
                
        }

        public void DataSerialize(int score) 
        {
            WorldStat worldStat = JsonSerializer.Deserialize<WorldStat>(File.ReadAllText(pathToFile));
            worldStat.ScoreTotal = score;

            if (worldStat.ScoreRecord.Count == 7)
            {
                worldStat.ScoreRecord.RemoveAt(6);
            }

            worldStat.ScoreRecord.Add(score);
            worldStat.ScoreRecord.Sort(); 
            worldStat.ScoreRecord.Reverse();

            string jsonString = JsonSerializer.Serialize(worldStat);
            File.WriteAllText(pathToFile, jsonString);
        }

        public WorldStat DataDeserialize() 
        {
            string jsonString = File.ReadAllText(pathToFile);

            return JsonSerializer.Deserialize<WorldStat>(jsonString);
        }
    }
}
