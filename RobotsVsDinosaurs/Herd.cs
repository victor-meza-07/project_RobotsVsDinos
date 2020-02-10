using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsVsDinosaurs
{
    class Herd
    {
        //Memeber Variables
        public List<Dinosaur> herdOFDinos;
        public Random rng;

        //Constructor
        public Herd()
        {
           herdOFDinos = new List<Dinosaur>();
           rng = new Random();
        }


        //METHODS
        //Difficulty KEY: 0: BABY, 1: EASY, 2:Medium, 3:Hard, 4: Impossible
        public Dinosaur pickDinosAToAdd(List<Dinosaur> totalDinos)
        {
            //randomly generate a dino id from dinolist, then check it agains "dino" object below.
            Dinosaur dinoToBeAdded = new Dinosaur();
            int dinoId = 0;
            dinoId = rng.Next(0, (totalDinos.Count));

            foreach (Dinosaur dino in totalDinos) 
            {
                if (dinoId == dino.dinoID) 
                {
                    dinoToBeAdded = dino;
                }
            }
            return dinoToBeAdded;
        }//PICKS A RANDOM DINO TO ADD TO THE HERD LIST
        public void addHerdofDinos(int difficulty,List<Dinosaur> totalDinos) 
        {
            int counter = 0;
            if (difficulty == 0) 
            {
                while (counter < 3)//DETERMINES THE DINOS TO SPAWN 
                {
                    Dinosaur newDinoToAdd = new Dinosaur();
                    newDinoToAdd = pickDinosAToAdd(totalDinos);
                    herdOFDinos.Add(newDinoToAdd);
                    counter++;
                }

            } //BABY
            else if (difficulty == 1)
            {
                while (counter < 4)//DETERMINES THE DINOS TO SPAWN 
                {
                    Dinosaur newDinoToAdd = new Dinosaur();
                    newDinoToAdd = pickDinosAToAdd(totalDinos);
                    herdOFDinos.Add(newDinoToAdd);
                    counter++;
                }

            } //EASY
            else if (difficulty == 2)
            {
                while (counter < 5)//DETERMINES THE DINOS TO SPAWN 
                {
                    Dinosaur newDinoToAdd = new Dinosaur();
                    newDinoToAdd = pickDinosAToAdd(totalDinos);
                    herdOFDinos.Add(newDinoToAdd);
                    counter++;
                }

            } //MED
            else if (difficulty == 3)
            {
                while (counter < 6)//DETERMINES THE DINOS TO SPAWN 
                {
                    Dinosaur newDinoToAdd = new Dinosaur();
                    newDinoToAdd = pickDinosAToAdd(totalDinos);
                    herdOFDinos.Add(newDinoToAdd);
                    counter++;
                }

            } //HARD
            else if (difficulty == 4)
            {
                while (counter < 12)//DETERMINES THE DINOS TO SPAWN 
                {
                    Dinosaur newDinoToAdd = new Dinosaur();
                    newDinoToAdd = pickDinosAToAdd(totalDinos);
                    herdOFDinos.Add(newDinoToAdd);
                    counter++;
                }

            } //IMPOSSIBLE
        }//CHECKS DIFFICULTY & SPAWNS PROPPER DINOS

    }
}
