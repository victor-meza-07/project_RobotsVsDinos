﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVsDinosaurs
{
    class Robot
    {
        //Member Variables
        
        public WeaponType Weapontype;
        public int robotId;
        public string name;
        public double health;
        public double energy;
        public double attackPower; // This will be a multiplyer of the weapons attack strength.
        public bool amIalive;
        public string wasKilledBy;
        

        //Constructor
        public Robot()
        {
            Weapontype = new WeaponType();
            name = null;
            health = 100;
            energy = 100;
            attackPower = 0;
            robotId = 0;
            amIalive = true;
            wasKilledBy = null;            
        }

        //Methods

        //assign a weapon to a robot boii
       

        //ROBOT LOGIC


    }
}
