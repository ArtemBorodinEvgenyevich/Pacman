using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Thief_Game
{
    // Save and process path info
    class PathInfo
    {
        public static string WorkingDir = Environment.CurrentDirectory;
        public static string ProjectDir = Directory.GetParent(WorkingDir).Parent.Parent.FullName;
        public static string SourceDir = Path.Combine(ProjectDir, @"Source");
    }
}
