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
            Assert.AreEqual(0, pattern.Player.X);
            Assert.AreEqual(0, pattern.Player.Y);
            Assert.AreNotEqual(null, pattern.Walls);
        }
    }
}