using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVsDinosaurs
{
    class WeaponType
    {
        //Weapon Types
        public string weaponType;
        public double attackDamage;
        public double strikeefficacy; // THIS IS GOING TO BE A NEGATIVE MULTIPLIER (0.5 or SO) DEPENDING ON WHO WIELDS IT
        public int weaponId;

        public WeaponType()
        {
            weaponType = "";
            attackDamage = 0;
            strikeefficacy = 0;
            weaponId = 0;

        }

       
        


        //Deciphering where to send them
        public double checkForWeapon(WeaponType weapon, Robot robot) 
        {
            double efficacy = 0;

            if (weapon.weaponType == "Axe")
            {
              efficacy =  wAxeLoogicstrikeEfficacy(robot);
            }
            else if (weapon.weaponType == "Shovel")
            { Console.WriteLine("You Picked a Shovel"); }
            else if (weapon.weaponType == "Sword")
            { Console.WriteLine("You Picked a Sword"); }
            else if (weapon.weaponType == "Gun")
            { Console.WriteLine("You Picked a Gun"); }
            else if (weapon.weaponType == "Frying Pan")
            { Console.WriteLine("You Picked a Frying Pan"); }
            else if (weapon.weaponType == "Wheel Chair")
            { Console.WriteLine("You Picked Weel Chair"); }

            

            return efficacy;
        }


        //Adding Some Weapon Logic
        public void wAxeLogicAttack() 
        {
            
        }
        public double wAxeLoogicstrikeEfficacy(Robot robotWielding) 
        {

            //THIS VALUE SHOULD REFLECT COMPUTER SPEED BASED ON THE CHARACTER BACKSTORY, BUILD DATE, QUALITY OF COMPENETS
            double efficacy = 0;

            //This should take information about the robot picked
            if (robotWielding.robotId == 0 ) // FIN 
            {
                efficacy = .9;
            }
            else if (robotWielding.robotId == 1) // PATRICIA
            {
                efficacy = .7;
            }
            else if (robotWielding.robotId == 2) // Jenkins 
            {
                efficacy = .6;
            }
            else if (robotWielding.robotId == 3) // HALLEY
            {
                efficacy = .98;
            }

            return efficacy;
        }


        //setting weapon efficacy
        public double getWeaponEfficacy(Robot robot, WeaponType weapon) 
        {
            double efficacy = 0;
            efficacy = checkForWeapon(weapon, robot);
            return efficacy;
        }
       
    }
}
