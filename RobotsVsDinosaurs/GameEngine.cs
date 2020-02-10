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
        List<BattleEnviroment> listofEnviroments;
        public bool runGame;
        Fleet fleet;
        int counter;
        int difficulty;
        int gamemode;
        Herd herdClass;
        Battlefield battlefieldClass;



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
            difficulty = 0; // this will be set by the player before anything else, this is how we will determine how many dinos or robots they fight against. 
            herdClass = new Herd();
            battlefieldClass = new Battlefield();
            listofEnviroments = new List<BattleEnviroment>();
            gamemode = 0;
        }


        //Methods
        public void Start()
        {
            //FLUSH THE LISTS
            weaponTypeS.Clear();
            robotList.Clear();
            listofEnviroments.Clear();
            dinoList.Clear();
            herdClass.herdOFDinos.Clear();
            fleet.fleetOfRobots.Clear();

            //flushing the variables
            gamemode = 0;
            difficulty = 0;


            counter = 0;
            Console.WriteLine("Adding Robots");
            addRobots();
            Console.WriteLine("Adding WeaponTypes");
            addWeaponType();
            Console.WriteLine("Adding Dinos");
            addDinos();
            Console.WriteLine("Adding Enviroments");
            addEnviroments();


            //I want them to pick, 3 robots
            //counter = 0, everytime we get a valid pick counter++, inside a while counter < 3 execute The Following: 
            //I want to check if the pick was valid
            // does that robot have access to that weapon?
            //if not --> do not add counter --> Let Them Know that robot does not have access to that weapon
            //else it must mean that the robot does have access
            // add to the fleet list
            // counter ++

            //Picking a gamemode
            gamemode = Convert.ToInt32(gameModePrompt());

            //picking a difficulty
            difficulty = Convert.ToInt32(difficultyPrompt());


            gamemodeSetter(); // Will kick things off in the propper gamemode & DIFFICULTY








            Console.Clear();
            displayAllFleet();
            Console.WriteLine("vs");
            displayAllHerd();
            Console.ReadLine();
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
        public void makeAherd() 
        {
            herdClass.addHerdofDinos(difficulty ,dinoList);  
        }
        public void autoPickRobotNWeaponize() 
        {
            int counter = 0;
            while (counter < 3) 
            {
                int roboID = 0;
                int weaponID = 0;
                Robot newRobot = new Robot();
                WeaponType newWepon = new WeaponType();

                roboID = herdClass.rng.Next(0, (robotList.Count));
                weaponID = herdClass.rng.Next(0, (weaponTypeS.Count));

                foreach (Robot robot in robotList) 
                {
                    if (roboID == robot.robotId) 
                    {
                        newRobot = robot;
                        break;
                    }
                }
                foreach (WeaponType weapon in weaponTypeS) 
                {
                    if (weaponID == weapon.weaponId) 
                    {
                        newWepon = weapon;
                        break;
                    }
                }

                if ((newRobot.robotId != 2) && (newWepon.weaponId == 7)) // MAKES SURE NO AUTO PICKED ROBOT HAS WHEEL CHAIR
                {
                    // DO NOT ADD TO COUNTER
                    continue;
                }
                else 
                {
                    newWepon = this.WeaponType.getWeaponEfficacy(newRobot, newWepon);
                    fleet.addToFleetList(newRobot, newWepon);
                    counter++;
                }
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
        private void displayAllHerd() 
        {
            Console.WriteLine("DINO HERD");
            foreach (Dinosaur dino in herdClass.herdOFDinos) 
            {  
                Console.WriteLine(dino.dinosaurName);
            }
        }

        //display all gamemodes
        private string gameModePrompt() 
        {
            string userchoice = "";
            Console.WriteLine("Please Select A Game Mode");
            Console.WriteLine("1. Original - We Have you Pick An Environment, Three Robots and 3 Dinos Spawn you see the battle happen"); // MVP
            Console.WriteLine("2. Involved - We Have you Pick Three Robots and up to 12 Dinos Spawn depending on difficulty chosen, you control the robot attacks");
            Console.WriteLine("3. Multiplayer - Each Player Picks 3, One player controls Robot Fleet, Second Player Controls Dino Herd YOU DUKE IT OUT ON A CHESSBOARD, Players vote on Environment if a tie occurs one is chosen at random from the 2"); // THIS WILL PLOT THEM ON A CHESSBOARD AND SHOULD DISPLAY POSITIONS ON CONSOLE
            userchoice = Console.ReadLine();

            return userchoice;
        }
        //display all difficulties
        private string difficultyPrompt() 
        {
            string userchoice = "";
            Console.WriteLine("What Difficulty would you like to set?");
            Console.WriteLine("0. BABY");
            Console.WriteLine("1. EASY");
            Console.WriteLine("2. MEDIUM");
            Console.WriteLine("3. HARD");
            Console.WriteLine("4. IMPOSSIBLE");
            userchoice = Console.ReadLine();
            return userchoice;
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
            dinoList.Add(new Dinosaur { dinosaurName = "T Rex", dinoAttackPower = 1, dinoEnergy = 1, dinoShieldPower = 1, dinoHealth = 1, dinoID = 0 });
            dinoList.Add(new Dinosaur { dinosaurName = "Iguanadon", dinoAttackPower = 1, dinoEnergy = 1, dinoShieldPower = 1, dinoHealth = 1, dinoID = 1 });
            dinoList.Add(new Dinosaur { dinosaurName = "Velociraptor", dinoAttackPower = 1, dinoEnergy = 1, dinoShieldPower = 1, dinoHealth = 1, dinoID = 2 });
            dinoList.Add(new Dinosaur { dinosaurName = "Triceratops", dinoAttackPower = 1, dinoEnergy = 1, dinoShieldPower = 1, dinoHealth = 1, dinoID = 3 });
            dinoList.Add(new Dinosaur { dinosaurName = "Stegasaurus", dinoAttackPower = 1, dinoEnergy = 1, dinoShieldPower = 1, dinoHealth = 1, dinoID = 4 });
            dinoList.Add(new Dinosaur { dinosaurName = "Spinosaurus", dinoAttackPower = 1, dinoEnergy = 1, dinoShieldPower = 1, dinoHealth = 1, dinoID = 5 });
            dinoList.Add(new Dinosaur { dinosaurName = "Brachiosaurus", dinoAttackPower = 1, dinoEnergy = 1, dinoShieldPower = 1, dinoHealth = 1, dinoID = 6 });
            dinoList.Add(new Dinosaur { dinosaurName = "Pterodactyl", dinoAttackPower = 1, dinoEnergy = 1, dinoShieldPower = 1, dinoHealth = 1, dinoID = 7 });
            dinoList.Add(new Dinosaur { dinosaurName = "Plesiasoraus", dinoAttackPower = 1, dinoEnergy = 1, dinoShieldPower = 1, dinoHealth = 1, dinoID = 8 });
        }
        //add robots
        public void addRobots() 
        {
            robotList.Add(new Robot { name = "FINN", attackPower = 1.5, energy = .5, health = 100, robotId = 0 }); //BASED ON MICRO PROCESSOR 
            robotList.Add(new Robot { name = "PATRICIA", attackPower = 1.5, energy = .5, health = 100, robotId = 1 }); //BASED UNIVERSITY OF MANCHISTER ATLAS 
            robotList.Add(new Robot { name = "Mr Jenkins", attackPower = 1.5, energy = .5, health = 100, robotId = 2}); // BASED ON THE ARCHITECTURE FOR MANCHESTER BABY
            robotList.Add(new Robot { name = "HALLEY", attackPower = 1.5, energy = .5, health = 100, robotId = 3 }); //BASED ON QUANTUM COMPUTERS
        }
        //add Enviroments or "BattleFields" that will be chosen from at random when starting a battle, these will give advantages to the dinosaurs
        public void addEnviroments() 
        {
            listofEnviroments.Add(new BattleEnviroment {enviromentType = "Plain", enviromentID = 0 });
            listofEnviroments.Add(new BattleEnviroment { enviromentType = "Mountain", enviromentID = 1 });
            listofEnviroments.Add(new BattleEnviroment { enviromentType = "Jungle", enviromentID = 2 });
            listofEnviroments.Add(new BattleEnviroment { enviromentType = "Beach", enviromentID = 3 });
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
      
        public void gamemodeSetter() 
        {
            if (gamemode == 1) 
            {
                autoPickRobotNWeaponize();
                makeAherd();
            }//MVP
            else if (gamemode == 2) 
            {
                int counter = 0;
                while (counter < 3) // Lets you pick 3 robots and weaponize them // SHOULD USE DIFFICULTY LEVEL IN FUTURE
                {
                    pickARobotNweaponize();
                    counter++;
                }
                makeAherd(); // MAKES A HEARD, IN FUTURE SHOULD USE DIFFICULTY LEVEL
            } // USER SELECTION SINGLE PLAYER
            else if (gamemode == 3) { } // MULTIPLAYER
        }


        

        //START A BATTLE
        //we need to pass the FLEET LIST & HERD LIST
        public void startABattle() 
        {
            
        }
    }
}
