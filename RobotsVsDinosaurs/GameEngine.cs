using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVsDinosaurs
{

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

        //pick a robot
        public void pickARobotNweaponize()
        {
            Console.Clear();
            Console.WriteLine("Pick a robot from the list");
            displayAllRobots();
            string robotpicked = Console.ReadLine(); // Expecting it as the ID
            


            string name = findRobotPicked(robotpicked);
            Console.WriteLine($"Pick a weapon for {name}");
            displayAllWeapons(name);
            string weaponPicked = Console.ReadLine();
            


            //Check if the robot has access to wheelchair;
            if ((name != "Mr Jenkins") && (weaponPicked == "7"))
            {
                Console.WriteLine("Your Character doesn't have access to that weapon!");
            }
            //This is where we assign a weapon to our robot. 
            else 
            {
                WeaponType weapongPickeD = new WeaponType();
                weapongPickeD = findWeaponPicked(weaponPicked);
                Robot robotPickeD = findRobotPickedObject(name);



                //TODO : SEND TO A METHOD THAT CALCULATES EFFICACY DEPENDING ON WHO IS HOLDING X WEAPON.
                

                //Adding them to the fleetList with finished attributes
                fleet.addToFleetList(robotPickeD,weapongPickeD);
            }


        }

        //pick a weapon
        




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
                Console.WriteLine(string.Format("{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10} |", robot.name, robot.health, robot.energy, robot.attackPower, robot.Weapontype.weaponType, "This Requires a Method"));
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
            robotList.Add(new Robot { name = "FINN", attackPower = 1.5, energy = .5, health = 100, robotId = 0 });
            robotList.Add(new Robot { name = "PATRICIA", attackPower = 1.5, energy = .5, health = 100, robotId = 1 });
            robotList.Add(new Robot { name = "Mr Jenkins", attackPower = 1.5, energy = .5, health = 100, robotId = 2});
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
                }
            }

            return weaponPicked;
        }
        public Robot findRobotPickedObject(string robotName) 
        {
            Robot theRobot = new Robot();
            foreach (Robot robot in robotList) 
            {
                if (robotName == robot.name) 
                {
                    theRobot = robot;
                }
            }
            return theRobot;
        }



        //** GAME MODES **//

    }
}
