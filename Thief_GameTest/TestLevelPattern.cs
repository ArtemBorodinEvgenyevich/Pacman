using NUnit.Framework;
using System.Collections.Generic;
using Thief_Game;

namespace Thief_GameTest
{
    [TestFixture]
    public class TestLevelPattern
    {
        [TestCase]
        public void TestCreating()
        {
            var pattern = new LevelPattern();

            Assert.AreNotEqual(null, pattern.MonsterSpawns);
            Assert.AreNotEqual(null, pattern.Walls);
        }
    }
}