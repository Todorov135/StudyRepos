namespace NavalVessels
{
    using Core;
    using Core.Contracts;
    using NavalVessels.Models;
    using NavalVessels.Models.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            // IEngine engine = new Engine();
            // engine.Run();

            IVessel battleship = new Battleship("BattleshipTest", 10, 20);
            IVessel submarine = new Submarine("SubmarineTest", 20, 40);
        }
    }
}