using System;
using System.Collections.Generic;
using System.Text;

namespace PathFinder
{
    //Lev
    public static class IdGenerator
    {
        public static int LastId = 0;

        /// <summary>
        /// Generate new identificator
        /// </summary>
        /// <returns>identificator</returns>
        public static int Generate()
        {
            LastId++;

            return LastId;
        }
    }
}
