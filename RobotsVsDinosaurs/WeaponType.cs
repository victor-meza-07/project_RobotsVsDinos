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

       
        


        //Deciphering where to send them depending on the weapon they chose
        public double checkForWeapon(WeaponType weapon, Robot robot) 
        {
            double efficacy = 0;

            if (weapon.weaponId == 0) 
            {
                efficacy = wAxeLoogicstrikeEfficacy(robot);
            }//AXE
            if (weapon.weaponId == 1) 
            {
                efficacy = wShovelLoogicstrikeEfficacy(robot);
            }//SHOVEL
            if (weapon.weaponId == 2) 
            {
                efficacy = wSwordLoogicstrikeEfficacy(robot);
            }//SWORD
            if (weapon.weaponId == 3) 
            {
                efficacy = wGunLoogicstrikeEfficacy(robot);
            }//GUN
            if (weapon.weaponId == 4) 
            {
                efficacy = wFryingPanLoogicstrikeEfficacy(robot);
            }//FRYING PAN
            if (weapon.weaponId == 5) 
            {
                efficacy = wRubberDLoogicstrikeEfficacy(robot);
            }//RUBBER DUCKY
            if (weapon.weaponId == 6) 
            {
                efficacy = wBucketBLoogicstrikeEfficacy(robot);
            }//BUCKET OF BOLTS
            if (weapon.weaponId == 7) 
            {
                efficacy = wWheelChairLoogicstrikeEfficacy(robot);
            }//WHEEL CHAIR

            return efficacy;
        }



        // THe Following Method Set Could and SHOULD be moved to a "weapons Type" of its own Ex Class: Axe, Shove, Sword etc...
        // And the values of the following should be properties in that class that can be "gotten" by {get;}
        //Adding Some Weapon Logic
        public void wAxeLogicAttack() 
        {
            
        }
        //Calculating Weapon Efficacy
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
        public double wSwordLoogicstrikeEfficacy(Robot robotWielding)
        {

            //THIS VALUE SHOULD REFLECT COMPUTER SPEED BASED ON THE CHARACTER BACKSTORY, BUILD DATE, QUALITY OF COMPENETS
            double efficacy = 0;

            //This should take information about the robot picked
            if (robotWielding.robotId == 0) // FIN 
            {
                efficacy = .9;
            }
            else if (robotWielding.robotId == 1) // PATRICIA
            {
                efficacy = .75;
            }
            else if (robotWielding.robotId == 2) // Jenkins 
            {
                efficacy = .5;
            }
            else if (robotWielding.robotId == 3) // HALLEY
            {
                efficacy = .99;
            }

            return efficacy;
        }
        public double wGunLoogicstrikeEfficacy(Robot robotWielding)
        {

            //THIS VALUE SHOULD REFLECT COMPUTER SPEED BASED ON THE CHARACTER BACKSTORY, BUILD DATE, QUALITY OF COMPENETS
            double efficacy = 0;

            //This should take information about the robot picked
            if (robotWielding.robotId == 0) // FIN 
            {
                efficacy = .85;
            }
            else if (robotWielding.robotId == 1) // PATRICIA
            {
                efficacy = .75;
            }
            else if (robotWielding.robotId == 2) // Jenkins 
            {
                efficacy = .2;
            }
            else if (robotWielding.robotId == 3) // HALLEY
            {
                efficacy = .999;
            }

            return efficacy;
        }
        public double wShovelLoogicstrikeEfficacy(Robot robotWielding)
        {

            //THIS VALUE SHOULD REFLECT COMPUTER SPEED BASED ON THE CHARACTER BACKSTORY, BUILD DATE, QUALITY OF COMPENETS
            double efficacy = 0;

            //This should take information about the robot picked
            if (robotWielding.robotId == 0) // FIN 
            {
                efficacy = .8;
            }
            else if (robotWielding.robotId == 1) // PATRICIA
            {
                efficacy = .6;
            }
            else if (robotWielding.robotId == 2) // Jenkins 
            {
                efficacy = .7;
            }
            else if (robotWielding.robotId == 3) // HALLEY
            {
                efficacy = .85;
            }

            return efficacy;
        }
        public double wFryingPanLoogicstrikeEfficacy(Robot robotWielding)
        {

            //THIS VALUE SHOULD REFLECT COMPUTER SPEED BASED ON THE CHARACTER BACKSTORY, BUILD DATE, QUALITY OF COMPENETS
            double efficacy = 0;

            //This should take information about the robot picked
            if (robotWielding.robotId == 0) // FIN 
            {
                efficacy = .85;
            }
            else if (robotWielding.robotId == 1) // PATRICIA
            {
                efficacy = .9;
            }
            else if (robotWielding.robotId == 2) // Jenkins 
            {
                efficacy = .7;
            }
            else if (robotWielding.robotId == 3) // HALLEY
            {
                efficacy = .999;
            }

            return efficacy;
        }
        public double wWheelChairLoogicstrikeEfficacy(Robot robotWielding)
        {

            //THIS VALUE SHOULD REFLECT COMPUTER SPEED BASED ON THE CHARACTER BACKSTORY, BUILD DATE, QUALITY OF COMPENETS
            double efficacy = 0;

            //This should take information about the robot picked
            if (robotWielding.robotId == 2) // Jenkins 
            {
                efficacy = 1;
            }
            else // ALL OTHER ROBOTS
            {
                efficacy = .05;
            }

            return efficacy;
        }
        public double wBucketBLoogicstrikeEfficacy(Robot robotWielding)
        {

            //THIS VALUE SHOULD REFLECT COMPUTER SPEED BASED ON THE CHARACTER BACKSTORY, BUILD DATE, QUALITY OF COMPENETS
            double efficacy = 0;

            //This should take information about the robot picked
            if (robotWielding.robotId == 0) // FIN 
            {
                efficacy = .99;
            }
            else if (robotWielding.robotId == 1) // PATRICIA
            {
                efficacy = .9;
            }
            else if (robotWielding.robotId == 2) // Jenkins 
            {
                efficacy = .7;
            }
            else if (robotWielding.robotId == 3) // HALLEY
            {
                efficacy = .999;
            }

            return efficacy;
        }
        public double wRubberDLoogicstrikeEfficacy(Robot robotWielding)
        {

            //THIS VALUE SHOULD REFLECT COMPUTER SPEED BASED ON THE CHARACTER BACKSTORY, BUILD DATE, QUALITY OF COMPENETS
            double efficacy = 0;

            //This should take information about the robot picked
            if (robotWielding.robotId == 0) // FIN 
            {
                efficacy = .4;
            }
            else if (robotWielding.robotId == 1) // PATRICIA
            {
                efficacy = .9;
            }
            else if (robotWielding.robotId == 2) // Jenkins 
            {
                efficacy = .7;
            }
            else if (robotWielding.robotId == 3) // HALLEY
            {
                efficacy = .999;
            }

            return efficacy;
        }





        //setting weapon efficacy
        public WeaponType getWeaponEfficacy(Robot robot, WeaponType weapon) 
        {
            WeaponType newWeappon = new WeaponType();
            robot.Weapontype = newWeappon;
            double efficacy = 0;
            efficacy = checkForWeapon(weapon, robot);
            newWeappon = weapon;
            newWeappon.strikeefficacy = efficacy;
            return newWeappon;
        }
       
    }
}
