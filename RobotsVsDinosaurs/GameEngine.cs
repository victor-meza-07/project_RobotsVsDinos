using System;
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
        int counter; 


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
            counter = 0;
            

        }


        //Methods
        public void Start()
        {
            counter = 0;
            Console.WriteLine("Adding Robots");
            addRobots();
            Console.WriteLine("Adding WeaponTypes");
            addWeaponType();
            Console.WriteLine("Adding Dinos");
            addDinos();


            //I want them to pick, 3 robots
            //counter = 0, everytime we get a valid pick counter++, inside a while counter < 3 execute The Following: 
                //I want to check if the pick was valid
                    // does that robot have access to that weapon?
                        //if not --> do not add counter --> Let Them Know that robot does not have access to that weapon
                        //else it must mean that the robot does have access
                            // add to the fleet list
                            // counter ++
           

            //Pick a robot and weaponize it.
            while (counter < 3) 
            {
                pickARobotNweaponize();
            }

            displayAllFleet();
            displayAllDinos();
            



        }


        //** PROMPT USER INPUT **//
        //** PICK A ROBOT AND HIS WEAPON**//
        // THERE IS A BUG INSIDE THIS METHOD RELATED TO EFFICACY VALUE ASSIGNMENT

        //pick a robot //pick a weapon
        public void pickARobotNweaponize()
        {
            Console.Clear();
            Console.WriteLine("Pick a robot from the list");
            displayAllRobots();
            string robotpicked = Console.ReadLine(); // Expecting it as the ID


            Robot robotAsObj = new Robot();
            robotAsObj = findRobotPickedObject(robotpicked); // getting the robot object corresponding to that ID
            Console.WriteLine($"Pick a weapon for {robotAsObj.name}");
            displayAllWeapons(robotAsObj.name);
            string weaponPicked = Console.ReadLine();
            


            //Check if the robot has access to wheelchair;
            if ((robotAsObj.name != "Mr Jenkins") && (weaponPicked == "7"))
            {
                WeaponType weaponAsObject = new WeaponType();
                weaponAsObject = findWeaponPicked(weaponPicked);
                Console.WriteLine($"{robotAsObj.name} does not have access to {weaponAsObject.weaponType}");
                Console.WriteLine("Please choose a different weapon");

                //this is where we would invalidate the pick by not adding to the counter. 
            }
            //This is where we assign a weapon to our robot. 
            else 
            {
                WeaponType weaponObject = new WeaponType();
                weaponObject = findWeaponPicked(weaponPicked); // we are getting the weapon object here.

                //SEND TO A METHOD THAT CALCULATES EFFICACY DEPENDING ON WHO IS HOLDING X WEAPON.
                weaponObject = this.WeaponType.getWeaponEfficacy(robotAsObj, weaponObject);
                
                //Adding them to the fleetList with finished attributes
                fleet.addToFleetList(robotAsObj,weaponObject);

                //adding to the counter to finally validate the pick
                counter++;
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
                    break;   
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
