using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVsDinosaurs
{
    class Dinosaur
    {
        //Member variables
        public string dinosaurName;
        public double dinoAttackPower; //THIS WILL BE A BASE NUMBER OF POWER
        public double dinoShieldPower; //THIS WILL BE A SHIELD BASE NUMBER
        public double dinoEnergy; // THIS WILL BE A PERCENTAGE
        public double dinoHealth; // THIS WILL BE A PERCENTAGE
        public double dinoAttackEfficacy; // Will BE SET BY DINO LOGIC DEPENDING ON RECEIVING PARTY // will be a multiplyer
        public int dinoID;

        public Dinosaur()
        {
            dinosaurName = "";
            dinoAttackPower = 0;
            dinoShieldPower = 0;
            dinoEnergy = 0;
            dinoHealth = 0;
            dinoAttackEfficacy = 0;
            dinoID = 0;
        }

        //Methods


        //DINO LOGIC

    }
}
