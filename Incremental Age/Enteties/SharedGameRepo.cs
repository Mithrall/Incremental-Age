using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Incremental_Age.Enteties
{
    public static class SharedGameRepo
    {
        public static List<Player> Players { get; set; } = new List<Player>();
        public static List<Tree> Trees { get; set; } = new List<Tree>();
    }
}
