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

        /*************  BUG FOUND ****************/
        //Values are being reset because the Robot class is only refrencing one instance of the WeaponType Class,
        //To Fix this, we should instanciate a new Weapon Type Class Everytime we instanciate a New Robot Class in the same loop
        /* 
         * addrobotandweapon(robotObjectPicked, weaponPickedWithAllInfo)
            {
                List<Robot>fleet? = new List<Robot>();
                fleet.add(Robot({WeaponType = new weaponPickedWithAllInfo()});

            }
        */
        public void addToFleetList(Robot robotPickeD, WeaponType weaponPicked)
        {
            //FIND A WAY TO EDIT MEMBER VARIABle OF AN INSTANTIATED OBJECT


            Robot newRobot = new Robot();
            WeaponType savedWeapon = new WeaponType();

            savedWeapon.attackDamage = weaponPicked.attackDamage;
            savedWeapon.strikeefficacy = weaponPicked.strikeefficacy;
            savedWeapon.weaponId = weaponPicked.weaponId;
            savedWeapon.weaponType = weaponPicked.weaponType;

            newRobot.robotId = robotPickeD.robotId;
            newRobot.attackPower = robotPickeD.attackPower;
            newRobot.energy = robotPickeD.energy;
            newRobot.health = robotPickeD.health;
            newRobot.name = robotPickeD.name;
            newRobot.Weapontype = savedWeapon;


            // THE BUG IS, WHATEVERTHIS LIST's ROBOT is Refrencing as his Weapon, is NOT being saved For that Robot Perosnally
            fleetOfRobots.Add(newRobot);
        }



        //MAYBE ADD SOME LOGIC OF HOW WELL OUR ROBOTS WILL INTERACTWITH EACHOTHER?
    }
}
