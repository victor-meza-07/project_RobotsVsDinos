using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVsDinosaurs
{
    class Battlefield
    {
        //Member Variables
        //Ideally, this is where i'll put items that will tilt the field on the side of the robots or the

        double newDifficultyMargin;
        public Battlefield()
        {
            newDifficultyMargin = 0;
        }

        //METHODS
        //Id like to add some logic for the game to figure out the battlefield we find ourselves in depending on the dinosaurs randmoly picked from the list
        //  Make a method that picks dinosaurs and saves them to a list of dinosaurs in herd that doesnt pick the same dinosaur twice
        //add land air or sea attributes to our dinosaurs to see what kind of battle field we should fight in
        //add battlefields  that make sense depening on the attributes that we find ourselves in that will give the dinos certain strengths.


        // ATTTACK LOGIC
        //If a robot attacks a dino, I want to check i



        //START A BATTLE
        /*
         * We should be able to choose what abttlefield to be in, depending on the battlefield we are in, we will edit the efficacy levels of our dinos
         * We should be able to know what difficulty we areplaying on in order to subtract from the efficacy levels of our dinos
         * 
         */
        public void startABattle(int difficulty, List<Robot> fleet, List<Dinosaur> herd, int battlefieldEnvironmentPicked)
        {
            setDifficultyMargin(difficulty);
            setDinosBuffer(herd, difficulty, battlefieldEnvironmentPicked); // SENDING OUT SOME PARAMATERS TO GAIN BUFFERS AND UPDATE HERD LISTS
        }


        
        /***  GAMEPLAY   ***/

        

        public void setDinosBuffer(List<Dinosaur> herd, int difficulty, int battlefieldEnvironmentPicked) // SENDS A DINO OBJECT TO BE EDITED
        {
            Dinosaur dinoWithBuffer = new Dinosaur();


            //THIS WILL SCAN WHAT DINOS, and then we will send what dino goes to what logic method for buffers
           

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
            return newDino;
        } //PULLS FROM GENERAL DIFFICULTY MARGIN VALUES
        public Dinosaur plesiasorauslBufferLogic(Dinosaur dino, int enviroment) // HAS DEFFENSE ADVNATAGE IN MOUNTAIN
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
            return newDino;
        } //PULLS FROM GENERAL DIFFICULTY MARGIN VALUES




    }
}
