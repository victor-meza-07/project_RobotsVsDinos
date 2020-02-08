﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVsDinosaurs
{

    /// <summary> 
    /// TODO: 
    ///  
    /// ASSIGN ROBOT IDS PROGRAMATICALLY MAYBE SOME ADVATAGES WILL COME FROM THIS
    /// ASSIGING OF WEAPONS IS NOT HAPPENING ACORDING TO THE ROBO WIELDING IT, WEAPON EFFICACY VALUES ARE SET ACCRODING TO THE LAST ROBOT TO BE SCANNED FOR
    /// FIX THAT
    /// </summary>

    //WE WANT THE "FLEET" OF ROBOTS THAT THE USER SELECTED TO BE SAVED IN FLEET
    class GameEngine
    {
        //Member Variables
        Robot robot; 
        WeaponType WeaponType;
        List<WeaponType> weaponTypeS;
        List<Dinosaur> dinoList;
        List<Robot> robotList;
        public bool runGame;
        Fleet fleet;


        //Constructor
        public GameEngine()
        {
            robot = new Robot();
            WeaponType = new WeaponType();
            weaponTypeS = new List<WeaponType>();
            dinoList = new List<Dinosaur>();
            robotList = new List<Robot>();
            runGame = true;
            fleet = new Fleet();

        }


        //Methods
        public void Start()
        {
            Console.WriteLine("Adding Robots");
            addRobots();
            Console.WriteLine("Adding WeaponTypes");
            addWeaponType();
            Console.WriteLine("Adding Dinos");
            addDinos();

            //Pick a robot and weaponize it.
            for (int i = 0; i < 3; i++) 
            {
                pickARobotNweaponize();
            }

            displayAllFleet();
            displayAllDinos();
            



        }


        //** PROMPT USER INPUT **//
        //** PICK A ROBOT AND HIS WEAPON**//

        //pick a robot //pick a weapon
        public void pickARobotNweaponize()
        {
            Console.Clear();
            Console.WriteLine("Pick a robot from the list");
            displayAllRobots();
            string robotpicked = Console.ReadLine(); // Expecting it as the ID



            robot = findRobotPickedObject(robotpicked); // getting the robot object corresponding to that ID
            Console.WriteLine($"Pick a weapon for {robot.name}");
            displayAllWeapons(robot.name);
            string weaponPicked = Console.ReadLine();
            


            //Check if the robot has access to wheelchair;
            if ((robot.name != "Mr Jenkins") && (weaponPicked == "7"))
            {
                Console.WriteLine("Your Character doesn't have access to that weapon!");
            }
            //This is where we assign a weapon to our robot. 
            else 
            {
                

                this.WeaponType = findWeaponPicked(weaponPicked); // we are getting the weapon object here.
                



                //TODO : SEND TO A METHOD THAT CALCULATES EFFICACY DEPENDING ON WHO IS HOLDING X WEAPON.
                
                this.WeaponType = this.WeaponType.getWeaponEfficacy(robot,this.WeaponType);
                

                //Adding them to the fleetList with finished attributes
                fleet.addToFleetList(robot,this.WeaponType);
            }


        }

        
        




        //** DISPLAY **//

        //display all Robots
        private void displayAllRobots() 
        {
            
            foreach (Robot robot in robotList) 
            {
                Console.WriteLine($"{robot.robotId}.{robot.name}");
                
            }
        }
        //display all weapons
        private void displayAllWeapons(string robotName) 
        {
           
           foreach (WeaponType weapon in weaponTypeS)
           {
                if (robotName == "Mr Jenkins")
                {
                    Console.WriteLine($"{weapon.weaponId}.{weapon.weaponType}");
                }
                else 
                {
                    if (weapon.weaponType != "Wheel Chair") 
                    {
                        Console.WriteLine($"{weapon.weaponId}.{weapon.weaponType}");
                    }
                }
           }
            
        }
        //display all fleetRobots
        private void displayAllFleet() 
        {
            Console.WriteLine(string.Format("{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10} |", "Robot Name", "Health", "Energy", "AttackPower", "Weapon", "Efficacy"));
            foreach (Robot robot in fleet.fleetOfRobots) 
            {
                //"Robot Name", "Health", "Energy", "AttackPower", "Weapon", "Efficacy"
                Console.WriteLine(string.Format("{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10} |", robot.name, robot.health, robot.energy, robot.attackPower, robot.Weapontype.weaponType, robot.Weapontype.strikeefficacy.ToString()));
            }
        }
        private void displayAllDinos() 
        {
            foreach (Dinosaur dino in dinoList) 
            {
                Console.WriteLine(dino.dinosaurName);
            }
        }



        //** ADD LIST OF STUFF WITH STARTER PROPERTIES **//
       
        //add weapons
        public void addWeaponType()
        {
            weaponTypeS.Add(new WeaponType { weaponType = "Axe", weaponId = 0, attackDamage = 5 });
            weaponTypeS.Add(new WeaponType { weaponType = "Shovel", weaponId = 1, attackDamage = 3 });
            weaponTypeS.Add(new WeaponType { weaponType = "Sword", weaponId = 2, attackDamage = 7 });
            weaponTypeS.Add(new WeaponType { weaponType = "Gun", weaponId = 3, attackDamage = 9 });
            weaponTypeS.Add(new WeaponType { weaponType = "Frying Pan", weaponId = 4, attackDamage = 8.5 });
            weaponTypeS.Add(new WeaponType { weaponType = "Rubber Ducky", weaponId = 5, attackDamage = 2 });
            weaponTypeS.Add(new WeaponType { weaponType = "Bucket o' Bolts", weaponId = 6, attackDamage = 1 });
            weaponTypeS.Add(new WeaponType { weaponType = "Wheel Chair", weaponId = 7, attackDamage = 50 }); // Specific to MR Jenkins
        }
        //add dinosaurs
        public void addDinos()
        {
            dinoList.Add(new Dinosaur { dinosaurName = "T Rex", dinoAttackPower = 1, dinoEnergy = 1, dinoShieldPower = 1, dinoHealth = 1});
            dinoList.Add(new Dinosaur { dinosaurName = "Iguanadon", dinoAttackPower = 1, dinoEnergy = 1, dinoShieldPower = 1, dinoHealth = 1 });
            dinoList.Add(new Dinosaur { dinosaurName = "Velociraptor", dinoAttackPower = 1, dinoEnergy = 1, dinoShieldPower = 1, dinoHealth = 1 });
            dinoList.Add(new Dinosaur { dinosaurName = "Triceratops", dinoAttackPower = 1, dinoEnergy = 1, dinoShieldPower = 1, dinoHealth = 1 });
            dinoList.Add(new Dinosaur { dinosaurName = "Stegasaurus", dinoAttackPower = 1, dinoEnergy = 1, dinoShieldPower = 1, dinoHealth = 1 });
            dinoList.Add(new Dinosaur { dinosaurName = "Spinosaurus", dinoAttackPower = 1, dinoEnergy = 1, dinoShieldPower = 1, dinoHealth = 1 });
            dinoList.Add(new Dinosaur { dinosaurName = "Brachiosaurus", dinoAttackPower = 1, dinoEnergy = 1, dinoShieldPower = 1, dinoHealth = 1 });
            dinoList.Add(new Dinosaur { dinosaurName = "Pterodactyl", dinoAttackPower = 1, dinoEnergy = 1, dinoShieldPower = 1, dinoHealth = 1 });
            dinoList.Add(new Dinosaur { dinosaurName = "Plesiasoraus", dinoAttackPower = 1, dinoEnergy = 1, dinoShieldPower = 1, dinoHealth = 1 });
        }
        //add robots
        public void addRobots() 
        {
            robotList.Add(new Robot { name = "FINN", attackPower = 1.5, energy = .5, health = 100, robotId = 0 }); //BASED ON MICRO PROCESSOR 
            robotList.Add(new Robot { name = "PATRICIA", attackPower = 1.5, energy = .5, health = 100, robotId = 1 }); //BASED UNIVERSITY OF MANCHISTER ATLAS 
            robotList.Add(new Robot { name = "Mr Jenkins", attackPower = 1.5, energy = .5, health = 100, robotId = 2}); // BASED ON THE ARCHITECTURE FOR MANCHESTER BABY
            robotList.Add(new Robot { name = "HALLEY", attackPower = 1.5, energy = .5, health = 100, robotId = 3 }); //BASED ON QUANTUM COMPUTERS
        }



        //find robotpicked
        public string findRobotPicked(string robotID) 
        {
            string robotname = "";

            foreach (Robot robot in robotList) 
            {
                if (robot.robotId.ToString() == robotID) 
                {
                    robotname = robot.name;
                }
            }

            return robotname;
        }
        //find weapon picked
        public WeaponType findWeaponPicked(string weaponID) 
        {
            WeaponType weaponPicked = new WeaponType();

            foreach (WeaponType weapon in weaponTypeS) 
            {
                if (weaponID == weapon.weaponId.ToString()) 
                {
                    
                    weaponPicked = weapon;
                    weaponPicked.weaponType = weapon.weaponType;
                }
            }

            return weaponPicked;
        }
        public Robot findRobotPickedObject(string robotID) 
        {
            Robot pickedRobot = new Robot();
            foreach (Robot robot in robotList) 
            {
                if (robotID == robot.robotId.ToString()) 
                {
                    pickedRobot = robot;
                }
            }
            return pickedRobot;
        }



        //** GAME MODES **//

    }
}
