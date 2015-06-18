namespace FarmersCreed
{
    using System;
    using FarmersCreed.Simulator;
    using FarmersCreed.Units;

    class FarmersCreedMain
    {
        static void Main()
        {
            ExtendedFarmSimulator simulator = new ExtendedFarmSimulator();
            simulator.Run();
        }
    }
}
