using System;using DefaultNamespace;namespace DefaultNamespace
{
    public struct Temperment
    {

        public Temperment(string name, float happinessMod, float hungerMod, float energyMod)
        {


            Name = name;
            HappinessMod = happinessMod;
            HungerMod = hungerMod;
            EnergyMod = energyMod;
        }

        public Temperment(Temperment temperment)
        {
            Name = temperment.Name;
            HappinessMod = temperment.HappinessMod;
            HungerMod = temperment.HungerMod;
            EnergyMod = temperment.EnergyMod;
        }
        
        public string Name { get; }
        public float HappinessMod { get; }
        public float HungerMod { get; }
        public float EnergyMod { get; }
        
    }
}





