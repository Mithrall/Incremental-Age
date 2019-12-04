using Incremental_Age.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Incremental_Age.Models
{
    public class GameModel
    {
        public Player[] Players { get; set; }
        public Tree[] Trees { get; set; }
    }
}
