﻿using System;
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
    }
}
