using System;using DefaultNamespace;namespace DefaultNamespace
{
    public struct Temperament
    {

        public Temperament(string name, float happinessMod, float hungerMod, float energyMod)
        {


            Name = name;
            HappinessMod = happinessMod;
            HungerMod = hungerMod;
            EnergyMod = energyMod;
        }

        public Temperament(Temperament temperment)
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





