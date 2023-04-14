
using System;
using UnityEngine.TextCore.Text;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    public class Fight
    {
        public Fight(Character character1, Character character2)
        {
            Character1 = character1;
            Character2 = character2;

            if (character1 == null || character2 == null)
            {
                throw new ArgumentNullException();
            }

        }


        public Character Character1 { get; private set; }
        public Character Character2 { get; private set; }
        /// <summary>
        /// Est-ce la condition de victoire/défaite a été rencontré ?
        /// </summary>
        public bool IsFightFinished => Character1.CurrentHealth <= 0 || Character2.CurrentHealth <= 0;

        /// <summary>
        /// Jouer l'enchainement des attaques. Attention à bien gérer l'ordre des attaques par apport à la speed des personnages
        /// </summary>
        /// <param name="skillFromCharacter1">L'attaque selectionné par le joueur 1</param>
        /// <param name="skillFromCharacter2">L'attaque selectionné par le joueur 2</param>
        /// <exception cref="ArgumentNullException">si une des deux attaques est null</exception>
        public void ExecuteTurn(Skill skillFromCharacter1, Skill skillFromCharacter2)
        {
           if (skillFromCharacter1 == null || skillFromCharacter2 == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
               if (Character1.Speed < Character2.Speed)
                {
                    Character2.ReceiveAttack(skillFromCharacter1);
                    Character1.ReceiveAttack(skillFromCharacter2);
                }
                else if (Character1.Speed == Character2.Speed)
                {
                    Character1.ReceiveAttack(skillFromCharacter2);
                    Character2.ReceiveAttack(skillFromCharacter1);
                }
                else if (Character1.Speed > Character2.Speed)
                {
                    Character1.ReceiveAttack(skillFromCharacter2);
                    Character2.ReceiveAttack(skillFromCharacter1);
                }
            } 

            //throw new NotImplementedException();


                /*if (Character1.BaseType == TYPE.WATER)
                {
                    Skill Water = new WaterBlouBlou();
                    skillFromCharacter1 = Water ;
                } else if(Character2.BaseType == TYPE.FIRE) {

                    Skill Fire = new FireBall();
                    skillFromCharacter1= Fire ;

                } else if (Character1.BaseType == TYPE.NORMAL) {
                    Skill Norm  = new Punch();
                    skillFromCharacter1 = Norm;
                } else if (Character2.BaseType == TYPE.GRASS){
                    Skill Plant = new MagicalGrass();
                    skillFromCharacter1 = Plant ;
                }

                if (Character2.BaseType == TYPE.WATER)
                {
                    Skill Water = new WaterBlouBlou();
                    skillFromCharacter2 = Water;
                }
                else if (Character2.BaseType == TYPE.FIRE)
                {
                    Skill Fire = new FireBall();
                    skillFromCharacter2 = Fire;
                }
                else if (Character2.BaseType == TYPE.NORMAL)
                {
                    Skill Norm = new Punch();
                    skillFromCharacter2 = Norm;
                }
                else if (Character2.BaseType == TYPE.GRASS)
                {
                    Skill Plant = new MagicalGrass();
                    skillFromCharacter2 = Plant;
                }

                if (Character1.Speed < Character2.Speed)
                {
                    Character2.ReceiveAttack(skillFromCharacter1);
                    Character1.ReceiveAttack(skillFromCharacter2);
                }
                else if (Character1.Speed == Character2.Speed)
                {
                    Character1.ReceiveAttack(skillFromCharacter2);
                    Character2.ReceiveAttack(skillFromCharacter1);
                }*/
            }

          

        }
    }

