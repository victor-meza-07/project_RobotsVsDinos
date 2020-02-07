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
        public double strikeefficacy;
        public int weaponId;

        public WeaponType()
        {
            weaponType = "";
            attackDamage = 0;
            strikeefficacy = 0;
            weaponId = 0;

        }

       
        


        //Deciphering where to send them
        public void checkForWeapon(string weaponType, WeaponType weapon, Robot robot) 
        {
            if (weapon.weaponType == "Axe")
            { Console.WriteLine("You Picked an Axe"); }
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
        }


        //Adding Some Weapon Logic
        public void wAxeLogicAttack() 
        {
            
        }
        public void wAxeLoogicstrikeEfficacy(Robot robotWielding) 
        {
            //This should take information about the robot picked
        }


        //setting weapon efficacy
        public double getWeaponEfficacy(Robot robot, WeaponType weapon) 
        {
            double efficacy = 0;
            //Axe
            checkForWeapon(weapon.weaponType, weapon, robot);
            

            //Shovel
            //Sword
            //Gun
            //Frying Pan
            //





            return efficacy;
        }
       
    }
}
