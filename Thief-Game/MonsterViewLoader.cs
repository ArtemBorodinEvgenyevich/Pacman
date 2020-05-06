using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Thief_Game
{
    static class MonsterViewLoader
    {
        private static string WorkingDir = Environment.CurrentDirectory;
        private static string ProjectDir = Directory.GetParent(WorkingDir).Parent.Parent.FullName;
        private static string SourceDir = Path.Combine(ProjectDir, @"Source");

        /// <summary>
        /// Загрузить картинку монстра
        /// </summary>
        /// <param name="fileName">Название картинки (в идеалек объект класса, 
        /// основании которого решаем какую картинку загрузить)</param>
        /// <returns></returns>
        public static Image LoadImage(string fileName)
        {
            //Определять какой файл грузить на основании
            //класса, который запросил картинку
            //Переделать, когда будет реализовано наследование монстров
            var path = Path.Combine(SourceDir, fileName);
            return Image.FromFile(path);
        }
    }
}
