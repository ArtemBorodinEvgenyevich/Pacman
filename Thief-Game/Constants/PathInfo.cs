using System;
using System.IO;

namespace Thief_Game
{
    // Artem
    // Save and process path info
    /// <summary>
    /// Класс с путями дирректорий проекта
    /// </summary>
    class PathInfo
    {
        public static string WorkingDir = Environment.CurrentDirectory;
        public static string ProjectDir = Directory.GetParent(WorkingDir).Parent.Parent.FullName;
        public static string SourceDir = Path.Combine(ProjectDir, @"Source");
        public static string LevelSpritesDir = Path.Combine(SourceDir, "Level");
        public static string MonstersSpritesDir = Path.Combine(SourceDir, "Monsters");
        public static string PlayerSpritesDir = Path.Combine(SourceDir, "Player");
        public static string CoinsSpritesDir = Path.Combine(SourceDir, "Coins");
        public static string GUISpritesDir = Path.Combine(SourceDir, "GUI");
        public static string Fonts = Path.Combine(SourceDir, "Fonts");
    }
}
