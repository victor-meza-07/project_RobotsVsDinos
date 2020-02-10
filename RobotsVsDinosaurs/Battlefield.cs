using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVsDinosaurs
{
    class Battlefield
    {
        //Member Variables
        //Ideally, this is where i'll put items that will tilt the field on the side of the robots or the
        Random rng; // didn't feel like passing the one in fleet or herd.
        bool hasOneTeamDied;


        double newDifficultyMargin;
        public Battlefield()
        {
            newDifficultyMargin = 0;
            rng = new Random();
            hasOneTeamDied = false;
        }

        //METHODS


        //START A BATTLE
        /*
         * We should be able to choose what abttlefield to be in, depending on the battlefield we are in, we will edit the efficacy levels of our dinos
         * We should be able to know what difficulty we areplaying on in order to subtract from the efficacy levels of our dinos
         * 
         */
        public void startABattle(int difficulty, List<Robot> fleet, List<Dinosaur> herd, int battlefieldEnvironmentPicked, int gamemode)
        {
            setDifficultyMargin(difficulty);
            setDinosBuffer(herd, difficulty, battlefieldEnvironmentPicked); // SENDING OUT SOME PARAMATERS TO GAIN BUFFERS AND UPDATE HERD LISTS
            
           
            while (hasOneTeamDied == false) 
            {
                checkTeamsDeathStatus(fleet, herd);
                mainTurningLogic(gamemode, fleet, herd);
                
            } // KEEP RUNNING WHILE NO TEAMS HAVE PERSIHED
            statusofTeams(fleet, herd);

            
        }



        /***  GAMEPLAY   ***/
        /*
         * I want to; SET THA PACE OF THE GAME
         *  DECIDE WHO IS GOING FIRST, THEN ALTERNATE BETWEEN THE FLEET AND HERD IN ORDER
         *      WE WILL ROLL A DICE, WHOEVER HAS THEI HIGHEST VALUE GOES FIRST. 1: DINOS, 2: ROBOTS
         *  PASS WHOS TURN IT IS AND WHAT THEY ARE DOING (ATTACKING MOSTLY) --> AND TO WHOM
         *  GET THE TOTAL ATTACK DEALT AND PASS IT TO A METHOD THAT CALCULATES THE DAMAGE RECEIVED OF THE PARTY INTENDED
         *  GET TOTAL DAMAGE RECEIVED AND PARTY INTENDED AND SET THAT PARTIES VALUES ACCRODINGLY
         */

        public void mainTurningLogic(int gamemode, List<Robot> fleet, List<Dinosaur> herd) 
        {
            int winner = 0;
            while (winner == 0) { winner = getturnFirst(winner); } //IF DINOS: 1, IF ROBOTS 2.
            
            //CHeck what gamemode we are in so we know if there is user input or not.
            if (gamemode == 1)
            {

                int attacker = 0;
                int attacked = 0;
                int attackflow = 0; // IF 1 R>D, 2 D>R
                double damage = 0;
                



                if (winner == 1)  
                {
                    attackflow = 2;
                }// DINOS WON ROLL
                else if (winner == 2) 
                {
                    attackflow = 1;
                }//ROBOTS WON ROLL

                statusofTeams(fleet, herd);

                if (attackflow == 1) 
                {
                    attacker = pickAttackingParty(fleet.Count);
                    attacked = pickAttackedParty(herd.Count);
                    while (fleet[attacker].health <= 0) // maybe put this in a foreach loop that checks for amialive = false; 
                    {
                        attacker = pickAttackingParty(fleet.Count);
                    } // CHecks if Attacker is Alive IF NOT PICKS A NEW ATTACKER
                      // THIS HAS TO DO WITH WHO WON THE ROLL OF DICE. FIND A WAY TO HAVE THE attackflow change at who won the woll of dice
                    while (herd[attacked].dinoHealth <= 0) // is the thing getting attacked dead? if so get a new indice, if not continue
                    {
                        attacked = pickAttackedParty(herd.Count);
                    } // THIS ENSURES THE ATTACKED PARTY IS ALIVE.

                    Console.WriteLine($"{fleet[attacker].name} is attacking {herd[attacked].dinosaurName}");
                }// ROBOTS WON THE ROLL 
                else if (attackflow == 2) 
                {
                    attacker = pickAttackingParty(herd.Count);
                    attacked = pickAttackedParty(fleet.Count);
                    while (herd[attacker].dinoHealth <= 0) // maybe put this in a foreach loop that checks for amialive = false; 
                    {
                        attacker = pickAttackingParty(fleet.Count);
                    } // CHecks if Attacker is Alive IF NOT PICKS A NEW ATTACKER
                      // THIS HAS TO DO WITH WHO WON THE ROLL OF DICE. FIND A WAY TO HAVE THE attackflow change at who won the woll of dice
                    while (fleet[attacked].health <= 0) // is the thing getting attacked dead? if so get a new indice, if not continue
                    {
                        attacked = pickAttackedParty(fleet.Count);
                    } // THIS ENSURES THE ATTACKED PARTY IS ALIVE.
                    Console.WriteLine($"{herd[attacker].dinosaurName} is attacking {fleet[attacked].name}");
                }// DINOS WON THE ROLL
             
                damage = getDamageDealt(fleet, herd, attacker, attackflow); // GETS DAMAGE AND SETS ENERGY ACCRODINGLY
                setHealthAfterAttack(fleet, herd, attacked, attackflow, damage); //SENDS DAMAGE AND SETS HEALTH AND SHIELDS ACCORDINGLY.
                setDeathOfCharacter(fleet,herd);

                if (attackflow == 1) 
                {
                    Console.WriteLine($"{fleet[attacker].name} dealt {damage} damage points to {herd[attacked].dinosaurName}");
                }
                else if (attackflow == 2) 
                {
                    Console.WriteLine($"{herd[attacker].dinosaurName} dealt {damage} damage points to {fleet[attacked].name}");
                }

              //  Console.ReadLine();



            }//AUTO
            else if (gamemode == 2) 
            {

            }//SINGLE PLAYER
            else if (gamemode == 3) 
            {
            }//MULTIPLAYER
            

        }
        
        public int getturnFirst(int winner) 
        {
            int dinosRoll = 0;
            int robotsRoll = 0;
            winner = 0;

            Console.WriteLine("Rolling For Dinos");
            dinosRoll = getDiceRolll();
            Console.WriteLine("Rolling For Robots");
            robotsRoll = getDiceRolll();

            if (dinosRoll > robotsRoll)
            {
                Console.WriteLine($"Dinos Win with {dinosRoll}");
                winner = 1;
            }
            else if (robotsRoll > dinosRoll) 
            {
                Console.WriteLine($"Robots Win with {robotsRoll}");
                winner = 2;
            }
            else 
            {
                Console.WriteLine($"Its a Tie Dinos:{dinosRoll} Robots:{robotsRoll}");
                winner = 0;
            }

            return winner;
        }



        // ATTACK LOGIC
        //AUTOMATIC
        public int pickAttackedParty(int sizeOfList) 
        {
            int indexOFpartyAttacked = 0;
            indexOFpartyAttacked = rng.Next(0, (sizeOfList));
            return indexOFpartyAttacked;
        } // RANDOMLY PICKS AN ATTACKED PARTY WHEN FED LIST SIZE.
        public int pickAttackingParty(int sizeOfList) 
        {
            int attakingindex = 0;
            attakingindex = rng.Next(0, (sizeOfList));
            return attakingindex;
        } // RANDOMLY PICKS AN ATTACKING PARTY WHEN FED LIST SIZE.

        
        public double getDamageDealt(List<Robot> fleet,List<Dinosaur> herd , int indexOfAttacker, int whosAttacking) 
        {
            double damage = 0;

            if (whosAttacking == 1) 
            {
                if (fleet[indexOfAttacker].energy != 0)
                {
                    damage = (fleet[indexOfAttacker].attackPower + fleet[indexOfAttacker].Weapontype.attackDamage) * fleet[indexOfAttacker].Weapontype.strikeefficacy;
                    if (fleet[indexOfAttacker].energy >= (damage * .25))
                    {
                        fleet[indexOfAttacker].energy = fleet[indexOfAttacker].energy - (damage * .25);
                    }
                    else
                    {

                        damage = fleet[indexOfAttacker].energy;
                        fleet[indexOfAttacker].energy = fleet[indexOfAttacker].energy - damage;
                    }
                }
                else 
                {
                    Console.WriteLine($"{fleet[indexOfAttacker].name} has {fleet[indexOfAttacker].energy.ToString()} and therefore cannot launch an attack");
                }
                

            }
            else if (whosAttacking == 2) 
            {
                if (herd[indexOfAttacker].dinoEnergy != 0)
                {
                    damage = (herd[indexOfAttacker].dinoAttackPower * herd[indexOfAttacker].dinoAttackEfficacy);
                    if (herd[indexOfAttacker].dinoEnergy >= (damage * .25))
                    {
                        herd[indexOfAttacker].dinoEnergy = herd[indexOfAttacker].dinoEnergy - (damage * .25);
                    }
                    else
                    {
                        damage = herd[indexOfAttacker].dinoEnergy;
                        herd[indexOfAttacker].dinoEnergy = herd[indexOfAttacker].dinoEnergy - damage;
                    }
                }
                else 
                {
                    Console.WriteLine($"{herd[indexOfAttacker].dinosaurName} has {herd[indexOfAttacker].dinoEnergy.ToString()} and therefore cannot launch an attack");
                }
                
            }
            return damage;
        } // TAKES THE ATTACK FLOW 1 or 2, THEN IT TAKES HERD AND FLEET AND CALCULATES DAMAGE DEALT.
        public void setHealthAfterAttack(List<Robot> fleet, List<Dinosaur> herd, int indexOfAttacked, int attackflow, double damageDealt) 
        {
            if (attackflow == 1) 
            {
                //HERE IS WHERE WE CHECK SHIELD STATUS
                if (herd[indexOfAttacked].dinoShieldPower >= 30)
                {
                    if (herd[indexOfAttacked].dinoShieldPower > damageDealt)
                    {
                        herd[indexOfAttacked].dinoShieldPower = herd[indexOfAttacked].dinoShieldPower - damageDealt;
                    }
                    else
                    {
                        herd[indexOfAttacked].dinoHealth = herd[indexOfAttacked].dinoHealth - damageDealt;
                    }
                }
                else 
                {
                    herd[indexOfAttacked].dinoHealth = herd[indexOfAttacked].dinoHealth - damageDealt;
                }
            } // ROBOTS ATTACKED DINO
            else if (attackflow == 2) 
            {
                fleet[indexOfAttacked].health = fleet[indexOfAttacked].health - damageDealt;
            } // DINOS AATTACKED ROBOT
        }
        public void setDeathOfCharacter(List<Robot> fleet, List<Dinosaur> herd) 
        {
            for (int i = 0; i < fleet.Count; i++)
            {
                if (fleet[i].health <= 0) { fleet[i].amIalive = false;  }
            }
            for (int i = 0; i < herd.Count; i++)
            {
                if (herd[i].dinoHealth <= 0) { herd[i].amIalive = false; }
            }
        }//ASK FOR INDICE OF HEALTH CHECKED VALUE OF HEALTH CHECKED AND SET THAT OBJECTS AMIALIVE BOOL TO FALSE IF <= 0 


        //SINGLE PLAYER
        //MULTIPLAYER



        public void setDinosBuffer(List<Dinosaur> herd, int difficulty, int battlefieldEnvironmentPicked) // SENDS A DINO OBJECT TO BE EDITED
        {
            Dinosaur dinoWithBuffer = new Dinosaur();
            for (int i = 0; i < herd.Count; i++)
            {
                if (herd[i].dinoID == 0) 
                {
                    dinoWithBuffer = trexBufferLogic(herd[i], difficulty, battlefieldEnvironmentPicked); // sets a new object with the buffer set
                     // this grabs the index of wherever we found the if statement to be true
                    herd[i] = dinoWithBuffer; // this tells the program to replace the object at that indice with the new buff object.
                    //break; // once we did this exit the loop stop checking the rest.
                }//TREX
                if (herd[i].dinoID == 1) 
                {
                    dinoWithBuffer = iguanadonBufferLogic(herd[i], difficulty, battlefieldEnvironmentPicked);
                    herd[i] = dinoWithBuffer;
                }//IGUANADON
                if (herd[i].dinoID == 2) 
                {
                    dinoWithBuffer = velociraptorBufferLogic(herd[i], difficulty, battlefieldEnvironmentPicked);
                    herd[i] = dinoWithBuffer;
                }//VELOCIRAPTOR
                if (herd[i].dinoID == 3)
                {
                    dinoWithBuffer = triceratopsBufferLogic(herd[i], difficulty, battlefieldEnvironmentPicked);
                    herd[i] = dinoWithBuffer;
                }//TRICERATOPS
                if (herd[i].dinoID == 4)
                {
                    dinoWithBuffer = stegasaurusBufferLogic(herd[i], difficulty, battlefieldEnvironmentPicked);
                    herd[i] = dinoWithBuffer;
                }//STEGASAURUS
                if (herd[i].dinoID == 5)
                {
                    dinoWithBuffer = spinosaurusBufferLogic(herd[i], battlefieldEnvironmentPicked);
                    herd[i] = dinoWithBuffer;
                }//SPINOSAURUS
                if (herd[i].dinoID == 6)
                {
                    dinoWithBuffer = brachiosaurusBufferLogic(herd[i], battlefieldEnvironmentPicked);
                    herd[i] = dinoWithBuffer;
                }//BRACHIOSAURUS
                if (herd[i].dinoID == 7)
                {
                    dinoWithBuffer = pterodactylBufferLogic(herd[i], battlefieldEnvironmentPicked);
                    herd[i] = dinoWithBuffer;
                }//PTERODACTYL
                if (herd[i].dinoID == 8)
                {
                    dinoWithBuffer = plesiasorauslBufferLogic(herd[i], battlefieldEnvironmentPicked);
                    herd[i] = dinoWithBuffer;
                }//PLESYASAURUS
            }
        }
        public void setDifficultyMargin(int difficulty) // IN CASE I WANT SOME DINOSAURS TO HAVE THE SAME DIFFICULTY MARGIN AS OTHERS
        {
            newDifficultyMargin = 0;

            if (difficulty == 0)
            {
                newDifficultyMargin = .01;
            }// BABY --> Margin .01
            else if (difficulty == 1)
            {
                newDifficultyMargin = .02;
            }// EASY --> Margin .02
            else if (difficulty == 2)
            {
                newDifficultyMargin = .03;
            }// MED --> Margin .03
            else if (difficulty == 3)
            {
                newDifficultyMargin = .8;
            }//HARD --> Margin .8;
            else if (difficulty == 4)
            {
                newDifficultyMargin = .9;
            }//IMPOSSIBLE --> Margin .9
        } //THIS SETS GENERAL DIFFICULTY VALUE


       // THIS ONLY ASSUMES SINGLE PLAYER OR NO PLAYER AT ALL!
        public Dinosaur trexBufferLogic(Dinosaur dino, int difficulty, int enviroment) // HAS ADVNATAGE ATTACK IN PLAINS AND JUNGLE
        {
            double difficultyMargin = 0;
            Dinosaur newDino = new Dinosaur();
            newDino = dino;
            //SHOULD TAKE IN DINO OBJECT SENT FROM HERD --> USE ENVIRONMENT DATA + DIFFICULTY DATA ==> GIVE BUFFER --> RETURN NEW DINO OBJECT 

            //FIRST IF CHECKS ANY ENVIRONMENT WE ARE PLAYING IN AND GIVES BUFFER IF BUFFER IS ON MULTIPLE ENVIRONMENTS Make a Chain of ELSE IF TO DECIDE SPECIFIC TO ENVIRONMENT BUFFERS (WHEN WE ADD ATTACK TYPES)
            //ENV KEY: 0->Plain, 1->Mountain, 2->Jungle, 3->Beach
            if (difficulty == 0)
            {
                difficultyMargin = .01;
            }// BABY --> Margin .01
            else if (difficulty == 1) 
            {
                difficultyMargin = .02;
            }// EASY --> Margin .02
            else if (difficulty == 2) 
            {
                difficultyMargin = .03;
            }// MED --> Margin .03
            else if (difficulty == 3) 
            {
                difficultyMargin = .8;
            }//HARD --> Margin .8;
            else if (difficulty == 4) 
            {
                difficultyMargin = .9;
            }//IMPOSSIBLE --> Margin .9


            //WARNING THESE NUMBERS ARE AN AGGREGAATE OF THE MARGIN SEt ABOVE ENSURE NO RESULT REACHES 1 EXCEPT FOR IMPOSSIBLE;
            if (enviroment == 0)
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .15;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 4;
            } //PLAIN MAX TOTAL--> 1.05
            else if (enviroment == 2)
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .10;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 6;
            } // JUNGLE  MAX TOTAL --> 1.0
            else 
            { 
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .01;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 1;
                newDino.dinoEnergy = newDino.dinoEnergy + difficulty + 2;
                newDino.dinoShieldPower = newDino.dinoShieldPower + difficultyMargin + 10;
            } //SETTING BASE VALUES
            return newDino;
        }
        public Dinosaur velociraptorBufferLogic(Dinosaur dino, int difficulty, int enviroment) // HAS ATTACK ADVNATAGE IN JUNGLE AND BEACH
        {
            double difficultyMargin = 0;
            Dinosaur newDino = new Dinosaur();
            newDino = dino;
            //SHOULD TAKE IN DINO OBJECT SENT FROM HERD --> USE ENVIRONMENT DATA + DIFFICULTY DATA ==> GIVE BUFFER --> RETURN NEW DINO OBJECT 

            //FIRST IF CHECKS ANY ENVIRONMENT WE ARE PLAYING IN AND GIVES BUFFER IF BUFFER IS ON MULTIPLE ENVIRONMENTS Make a Chain of ELSE IF TO DECIDE SPECIFIC TO ENVIRONMENT BUFFERS (WHEN WE ADD ATTACK TYPES)
            //ENV KEY: 0->Plain, 1->Mountain, 2->Jungle, 3->Beach
            if (difficulty == 0)
            {
                difficultyMargin = .01;
            }// BABY --> Margin .01
            else if (difficulty == 1)
            {
                difficultyMargin = .02;
            }// EASY --> Margin .02
            else if (difficulty == 2)
            {
                difficultyMargin = .03;
            }// MED --> Margin .03
            else if (difficulty == 3)
            {
                difficultyMargin = .8;
            }//HARD --> Margin .8;
            else if (difficulty == 4)
            {
                difficultyMargin = .9;
            }//IMPOSSIBLE --> Margin .9


            //WARNING THESE NUMBERS ARE AN AGGREGAATE OF THE MARGIN SEt ABOVE ENSURE NO RESULT REACHES 1 EXCEPT FOR IMPOSSIBLE;
            if (enviroment == 3)
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .10;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 3;
            } //PLAIN MAX TOTAL--> 1.05
            else if (enviroment == 2)
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .12;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 4;
            } // JUNGLE  MAX TOTAL --> 1.0
            else
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .01;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 1;
                newDino.dinoEnergy = newDino.dinoEnergy + difficulty + 2;
                newDino.dinoShieldPower = newDino.dinoShieldPower + difficultyMargin + 10;
            } //SETTING BASE VALUES
            return newDino;
        }
        public Dinosaur iguanadonBufferLogic(Dinosaur dino, int difficulty, int enviroment) // HAS ATTACK ADVNATAGE IN PLAIN AND MOUNTAIN
        {
            double difficultyMargin = 0;
            Dinosaur newDino = new Dinosaur();
            newDino = dino;
            //SHOULD TAKE IN DINO OBJECT SENT FROM HERD --> USE ENVIRONMENT DATA + DIFFICULTY DATA ==> GIVE BUFFER --> RETURN NEW DINO OBJECT 

            //FIRST IF CHECKS ANY ENVIRONMENT WE ARE PLAYING IN AND GIVES BUFFER IF BUFFER IS ON MULTIPLE ENVIRONMENTS Make a Chain of ELSE IF TO DECIDE SPECIFIC TO ENVIRONMENT BUFFERS (WHEN WE ADD ATTACK TYPES)
            //ENV KEY: 0->Plain, 1->Mountain, 2->Jungle, 3->Beach
            if (difficulty == 0)
            {
                difficultyMargin = .01;
            }// BABY --> Margin .01
            else if (difficulty == 1)
            {
                difficultyMargin = .02;
            }// EASY --> Margin .02
            else if (difficulty == 2)
            {
                difficultyMargin = .03;
            }// MED --> Margin .03
            else if (difficulty == 3)
            {
                difficultyMargin = .8;
            }//HARD --> Margin .8;
            else if (difficulty == 4)
            {
                difficultyMargin = .9;
            }//IMPOSSIBLE --> Margin .9


            //WARNING THESE NUMBERS ARE AN AGGREGAATE OF THE MARGIN SEt ABOVE ENSURE NO RESULT REACHES 1 EXCEPT FOR IMPOSSIBLE;
            if (enviroment == 1)
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .10;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 1;
            } //PLAIN MAX TOTAL--> 1.05
            else if (enviroment == 0)
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .12;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + .5;
            } // JUNGLE  MAX TOTAL --> 1.0
            else
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .01;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 1;
                newDino.dinoEnergy = newDino.dinoEnergy + difficulty + 2;
                newDino.dinoShieldPower = newDino.dinoShieldPower + difficultyMargin + 10;
            } //SETTING BASE VALUES
            return newDino;
        }
        public Dinosaur triceratopsBufferLogic(Dinosaur dino, int difficulty, int enviroment) // HAS DEFFENSE ADVNATAGE IN JUNGLE
        {
            double difficultyMargin = 0;
            Dinosaur newDino = new Dinosaur();
            newDino = dino;
            //SHOULD TAKE IN DINO OBJECT SENT FROM HERD --> USE ENVIRONMENT DATA + DIFFICULTY DATA ==> GIVE BUFFER --> RETURN NEW DINO OBJECT 

            //FIRST IF CHECKS ANY ENVIRONMENT WE ARE PLAYING IN AND GIVES BUFFER IF BUFFER IS ON MULTIPLE ENVIRONMENTS Make a Chain of ELSE IF TO DECIDE SPECIFIC TO ENVIRONMENT BUFFERS (WHEN WE ADD ATTACK TYPES)
            //ENV KEY: 0->Plain, 1->Mountain, 2->Jungle, 3->Beach
            if (difficulty == 0)
            {
                difficultyMargin = .01;
            }// BABY --> Margin .01
            else if (difficulty == 1)
            {
                difficultyMargin = .02;
            }// EASY --> Margin .02
            else if (difficulty == 2)
            {
                difficultyMargin = .03;
            }// MED --> Margin .03
            else if (difficulty == 3)
            {
                difficultyMargin = .8;
            }//HARD --> Margin .8;
            else if (difficulty == 4)
            {
                difficultyMargin = .9;
            }//IMPOSSIBLE --> Margin .9


            //WARNING THESE NUMBERS ARE AN AGGREGAATE OF THE MARGIN SEt ABOVE ENSURE NO RESULT REACHES 1 EXCEPT FOR IMPOSSIBLE;
            if (enviroment == 2)
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .12;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 2;
                newDino.dinoEnergy = newDino.dinoEnergy + difficultyMargin + 3;
                newDino.dinoHealth = newDino.dinoHealth + difficultyMargin + 5;
                newDino.dinoShieldPower = newDino.dinoShieldPower + difficultyMargin + 10;
            } // JUNGLE  MAX TOTAL --> 1.0
            else
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .01;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 1;
                newDino.dinoEnergy = newDino.dinoEnergy + difficulty + 2;
                newDino.dinoShieldPower = newDino.dinoShieldPower + difficultyMargin + 10;
            } //SETTING BASE VALUES
            return newDino;
        }
        public Dinosaur stegasaurusBufferLogic(Dinosaur dino, int difficulty, int enviroment) // HAS DEFFENSE ADVNATAGE IN PLAIN
        {
            double difficultyMargin = 0;
            Dinosaur newDino = new Dinosaur();
            newDino = dino;
            //SHOULD TAKE IN DINO OBJECT SENT FROM HERD --> USE ENVIRONMENT DATA + DIFFICULTY DATA ==> GIVE BUFFER --> RETURN NEW DINO OBJECT 

            //FIRST IF CHECKS ANY ENVIRONMENT WE ARE PLAYING IN AND GIVES BUFFER IF BUFFER IS ON MULTIPLE ENVIRONMENTS Make a Chain of ELSE IF TO DECIDE SPECIFIC TO ENVIRONMENT BUFFERS (WHEN WE ADD ATTACK TYPES)
            //ENV KEY: 0->Plain, 1->Mountain, 2->Jungle, 3->Beach
            if (difficulty == 0)
            {
                difficultyMargin = .01;
            }// BABY --> Margin .01
            else if (difficulty == 1)
            {
                difficultyMargin = .02;
            }// EASY --> Margin .02
            else if (difficulty == 2)
            {
                difficultyMargin = .03;
            }// MED --> Margin .03
            else if (difficulty == 3)
            {
                difficultyMargin = .6;
            }//HARD --> Margin .6;
            else if (difficulty == 4)
            {
                difficultyMargin = .7;
            }//IMPOSSIBLE --> Margin .7


            //WARNING THESE NUMBERS ARE AN AGGREGAATE OF THE MARGIN SEt ABOVE ENSURE NO RESULT REACHES 1 EXCEPT FOR IMPOSSIBLE;
            if (enviroment == 0)
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .12;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 1;
                newDino.dinoEnergy = newDino.dinoEnergy + difficultyMargin + 2;
                newDino.dinoHealth = newDino.dinoHealth + difficultyMargin + 3;
                newDino.dinoShieldPower = newDino.dinoShieldPower + difficultyMargin + 4;
            } // PLAINS  MAX ATTACKPOWER:3.7 ENEREGY:4.7 HEALTH:6.7 SHIELDPOWER:11.7 EFFICACY:1.89 TOTAL --> ATTACK: 6.993 DEFFEND: 18.4+(WHATEVER ENERGY WILL END UP DOING)
            else
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .01;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 1;
                newDino.dinoEnergy = newDino.dinoEnergy + difficulty + 2;
                newDino.dinoShieldPower = newDino.dinoShieldPower + difficultyMargin + 10;
            } //SETTING BASE VALUES
            return newDino;
        }
        public Dinosaur spinosaurusBufferLogic(Dinosaur dino, int enviroment) // HAS DEFFENSE ADVNATAGE IN PLAIN
        {
            double difficultyMargin = 0;
            Dinosaur newDino = new Dinosaur();
            newDino = dino;
            difficultyMargin = newDifficultyMargin;
            //SHOULD TAKE IN DINO OBJECT SENT FROM HERD --> USE ENVIRONMENT DATA + DIFFICULTY DATA ==> GIVE BUFFER --> RETURN NEW DINO OBJECT 

            //FIRST IF CHECKS ANY ENVIRONMENT WE ARE PLAYING IN AND GIVES BUFFER IF BUFFER IS ON MULTIPLE ENVIRONMENTS Make a Chain of ELSE IF TO DECIDE SPECIFIC TO ENVIRONMENT BUFFERS (WHEN WE ADD ATTACK TYPES)
            //ENV KEY: 0->Plain, 1->Mountain, 2->Jungle, 3->Beach
            

            //WARNING THESE NUMBERS ARE AN AGGREGAATE OF THE MARGIN SEt ABOVE ENSURE NO RESULT REACHES 1 EXCEPT FOR IMPOSSIBLE;
            if (enviroment == 0)
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .2;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 2;
                newDino.dinoEnergy = newDino.dinoEnergy + difficultyMargin + 2;
                newDino.dinoHealth = newDino.dinoHealth + difficultyMargin + 3;
                newDino.dinoShieldPower = newDino.dinoShieldPower + difficultyMargin + 8;
            } // PLAINS  MAX ATTACKPOWER:3.7 ENEREGY:2.7 HEALTH:4.7 SHIELDPOWER:8.7 EFFICACY:.8 TOTAL --> ATTACK:2.96 DEFFEND: 12.7(WHATEVER ENERGY WILL END UP DOING)
            else
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .01;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 1;
                newDino.dinoEnergy = newDino.dinoEnergy + difficultyMargin + 2;
                newDino.dinoShieldPower = newDino.dinoShieldPower + difficultyMargin + 10;
            } //SETTING BASE VALUES
            return newDino;
        } //PULLS FROM GENERAL DIFFICULTY MARGIN VALUES
        public Dinosaur brachiosaurusBufferLogic(Dinosaur dino, int enviroment) // HAS DEFFENSE ADVNATAGE IN PLAIN
        {
            double difficultyMargin = 0;
            Dinosaur newDino = new Dinosaur();
            newDino = dino;
            difficultyMargin = newDifficultyMargin;
            //SHOULD TAKE IN DINO OBJECT SENT FROM HERD --> USE ENVIRONMENT DATA + DIFFICULTY DATA ==> GIVE BUFFER --> RETURN NEW DINO OBJECT 

            //FIRST IF CHECKS ANY ENVIRONMENT WE ARE PLAYING IN AND GIVES BUFFER IF BUFFER IS ON MULTIPLE ENVIRONMENTS Make a Chain of ELSE IF TO DECIDE SPECIFIC TO ENVIRONMENT BUFFERS (WHEN WE ADD ATTACK TYPES)
            //ENV KEY: 0->Plain, 1->Mountain, 2->Jungle, 3->Beach


            //WARNING THESE NUMBERS ARE AN AGGREGAATE OF THE MARGIN SEt ABOVE ENSURE NO RESULT REACHES 1 EXCEPT FOR IMPOSSIBLE;
            if (enviroment == 0)
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .2;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 5;
                newDino.dinoEnergy = newDino.dinoEnergy + difficultyMargin + 1;
                newDino.dinoHealth = newDino.dinoHealth + difficultyMargin + 2;
                newDino.dinoShieldPower = newDino.dinoShieldPower + difficultyMargin + 10;
            } // PLAINS  MAX ATTACKPOWER:3.7 ENEREGY:2.7 HEALTH:4.7 SHIELDPOWER:8.7 EFFICACY:.8 TOTAL --> ATTACK:2.96 DEFFEND: 12.7(WHATEVER ENERGY WILL END UP DOING)
            else
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .01;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 1;
                newDino.dinoEnergy = newDino.dinoEnergy + difficultyMargin + 2;
                newDino.dinoShieldPower = newDino.dinoShieldPower + difficultyMargin + 10;
            } //SETTING BASE VALUES
            return newDino;
        } //PULLS FROM GENERAL DIFFICULTY MARGIN VALUES
        public Dinosaur pterodactylBufferLogic(Dinosaur dino, int enviroment) // HAS DEFFENSE ADVNATAGE IN MOUNTAIN
        {
            double difficultyMargin = 0;
            Dinosaur newDino = new Dinosaur();
            newDino = dino;
            difficultyMargin = newDifficultyMargin;
            //SHOULD TAKE IN DINO OBJECT SENT FROM HERD --> USE ENVIRONMENT DATA + DIFFICULTY DATA ==> GIVE BUFFER --> RETURN NEW DINO OBJECT 

            //FIRST IF CHECKS ANY ENVIRONMENT WE ARE PLAYING IN AND GIVES BUFFER IF BUFFER IS ON MULTIPLE ENVIRONMENTS Make a Chain of ELSE IF TO DECIDE SPECIFIC TO ENVIRONMENT BUFFERS (WHEN WE ADD ATTACK TYPES)
            //ENV KEY: 0->Plain, 1->Mountain, 2->Jungle, 3->Beach


            //WARNING THESE NUMBERS ARE AN AGGREGAATE OF THE MARGIN SEt ABOVE ENSURE NO RESULT REACHES 1 EXCEPT FOR IMPOSSIBLE;
            if (enviroment == 1)
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .8;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 5;
                newDino.dinoEnergy = newDino.dinoEnergy + difficultyMargin + 8;
                newDino.dinoHealth = newDino.dinoHealth + difficultyMargin + 3;
                newDino.dinoShieldPower = newDino.dinoShieldPower + difficultyMargin + 1;
            } // PLAINS  MAX ATTACKPOWER:3.7 ENEREGY:2.7 HEALTH:4.7 SHIELDPOWER:8.7 EFFICACY:.8 TOTAL --> ATTACK:2.96 DEFFEND: 12.7(WHATEVER ENERGY WILL END UP DOING)
            else
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .01;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 1;
                newDino.dinoEnergy = newDino.dinoEnergy + difficultyMargin + 2;
                newDino.dinoShieldPower = newDino.dinoShieldPower + difficultyMargin + 10;
            } //SETTING BASE VALUES
            return newDino;
        } //PULLS FROM GENERAL DIFFICULTY MARGIN VALUES
        public Dinosaur plesiasorauslBufferLogic(Dinosaur dino, int enviroment) // HAS DEFFENSE ADVNATAGE IN BEACH
        {
            double difficultyMargin = 0;
            Dinosaur newDino = new Dinosaur();
            newDino = dino;
            difficultyMargin = newDifficultyMargin;
            //SHOULD TAKE IN DINO OBJECT SENT FROM HERD --> USE ENVIRONMENT DATA + DIFFICULTY DATA ==> GIVE BUFFER --> RETURN NEW DINO OBJECT 

            //FIRST IF CHECKS ANY ENVIRONMENT WE ARE PLAYING IN AND GIVES BUFFER IF BUFFER IS ON MULTIPLE ENVIRONMENTS Make a Chain of ELSE IF TO DECIDE SPECIFIC TO ENVIRONMENT BUFFERS (WHEN WE ADD ATTACK TYPES)
            //ENV KEY: 0->Plain, 1->Mountain, 2->Jungle, 3->Beach


            //WARNING THESE NUMBERS ARE AN AGGREGAATE OF THE MARGIN SEt ABOVE ENSURE NO RESULT REACHES 1 EXCEPT FOR IMPOSSIBLE;
            if (enviroment == 3)
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .8;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 8;
                newDino.dinoEnergy = newDino.dinoEnergy + difficultyMargin + 8;
                newDino.dinoHealth = newDino.dinoHealth + difficultyMargin + 5;
                newDino.dinoShieldPower = newDino.dinoShieldPower + difficultyMargin + 3;
            } // PLAINS  MAX ATTACKPOWER:3.7 ENEREGY:2.7 HEALTH:4.7 SHIELDPOWER:8.7 EFFICACY:.8 TOTAL --> ATTACK:2.96 DEFFEND: 12.7(WHATEVER ENERGY WILL END UP DOING)
            else
            {
                newDino.dinoAttackEfficacy = newDino.dinoAttackEfficacy + difficultyMargin + .01;
                newDino.dinoAttackPower = newDino.dinoAttackPower + difficultyMargin + 1;
                newDino.dinoEnergy = newDino.dinoEnergy + difficultyMargin + 2;
                newDino.dinoShieldPower = newDino.dinoShieldPower + difficultyMargin + 10;
            } //SETTING BASE VALUES
            return newDino;
        } //PULLS FROM GENERAL DIFFICULTY MARGIN VALUES



        //SUPPORT METHODS
        public int getDiceRolll() 
        {
            int dice = 0;
            dice = rng.Next(1, 7);
            return dice;
        }
        public void statusofTeams(List<Robot> fleet, List<Dinosaur> herd) 
        {
            //NAME HEALTH SHIELD ENERGY
            Console.WriteLine(string.Format("{0,-10} {1,-20} {2, -20} {3, -20}", "NAME", "HEALTH", "SHIELD", "ENERGY"));
            foreach (Dinosaur dino in herd) 
            {
                Console.WriteLine(string.Format("{0,-10} {1,-20} {2, -20} {3, -20}", dino.dinosaurName, dino.dinoHealth.ToString(), dino.dinoShieldPower.ToString(), dino.dinoEnergy.ToString()));
            }
            foreach (Robot robo in fleet) 
            {
                Console.WriteLine(string.Format("{0,-10} {1,-20} {2, -20} {3, -20}", robo.name, robo.health.ToString(), "0", robo.energy.ToString()));
            }
        }
        public bool checkTeamsDeathStatus(List<Robot> fleet, List<Dinosaur> herd) 
        {
            bool answer = false;

            foreach (Dinosaur dino in herd) 
            {
                if (dino.amIalive == true) { answer = false; }
                else { answer = true; }
            } // checks for at least one instance of an alive character if none are found the team has perished. 
            foreach (Robot robo in fleet)
            {
                if (robo.amIalive == true) { answer = false; }
                else { answer = true; }
            }

            return answer;
        }
    }
}
