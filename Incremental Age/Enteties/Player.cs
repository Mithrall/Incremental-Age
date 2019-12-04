namespace Incremental_Age.Enteties
{
    public class Player
    {
        public string Name { get; set; } = "None";
        public string Color { get; set; }
        public double moveSpeed { get; set; } = 2;
        public int X { get; set; } = 200;
        public int Y { get; set; } = 200;
        public string Job { get; set; } = "Idle";

        //public enum Action { Idle, onRoute, choppingTree }
        public string Action { get; set; } = "Idle";

        public int DestinationX { get; set; }
        public int DestinationY { get; set; }
    }
}