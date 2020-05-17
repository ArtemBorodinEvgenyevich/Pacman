using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Thief_Game
{
    class WorldStatPickle
    {
        private string pathToFile;
        
        // Создает файл в папке ~/Thief-Game/bin/docs/netcoreapp3.1
        // тк в дебаг версии эта папка является рабочей
        public WorldStatPickle()
        {
            pathToFile = Path.Combine(PathInfo.WorkingDir, "WorldStat.json");
            if (!File.Exists(pathToFile))
                File.Create(pathToFile);
        }

        // TODO: pass WorldStat class as a parameter
        public void DataSerialize(int score) 
        {
            string jsonString = JsonSerializer.Serialize(score);
            File.WriteAllText(pathToFile, jsonString);
        }

        public int DataDeserialize() 
        {
            string jsonString = File.ReadAllText(pathToFile);

            return JsonSerializer.Deserialize<int>(jsonString);
        }
    }
}
