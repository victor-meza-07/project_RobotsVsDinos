using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVsDinosaurs
{
    class Fleet
    {
        //Member Variables
        public List<Robot> fleetOfRobots;


        //Constructor
        public Fleet()
        {
            fleetOfRobots = new List<Robot>();
        }

        //Methods

        //add to the fleet list
        public void addToFleetList(Robot robotPickeD, WeaponType weaponPicked) 
        {
            //FIND A WAY TO EDIT MEMBER VARIABle OF AN INSTANTIATED OBJECT
            robotPickeD.Weapontype = weaponPicked;
            fleetOfRobots.Add(robotPickeD);
        }



        //MAYBE ADD SOME LOGIC OF HOW WELL OUR ROBOTS WILL INTERACTWITH EACHOTHER?
    }
}
