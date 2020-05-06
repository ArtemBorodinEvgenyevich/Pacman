//Lev

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Thief_Game
{
    static class MonsterViewLoader
    {
        

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
            var path = Path.Combine(PathInfo.SourceDir, fileName);
            return Image.FromFile(path);
        }
    }
}
