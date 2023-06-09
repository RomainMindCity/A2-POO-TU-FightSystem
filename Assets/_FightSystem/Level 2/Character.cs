﻿using System;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Définition d'un personnage
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Stat de base, HP
        /// </summary>
        int _baseHealth;
        int _maxHealth;
        /// <summary>
        /// Stat de base, ATK
        /// </summary>
        int _baseAttack;
        /// <summary>
        /// Stat de base, DEF
        /// </summary>
        int _baseDefense;
        /// <summary>
        /// Stat de base, SPE
        /// </summary>
        int _baseSpeed;
        /// <summary>
        /// Type de base
        /// </summary>
        TYPE _baseType;

        public Character(int baseHealth, int baseAttack, int baseDefense, int baseSpeed, TYPE baseType)
        {
            _baseHealth = baseHealth;
            _maxHealth = baseHealth;
            _baseAttack = baseAttack;
            _baseDefense = baseDefense;
            _baseSpeed = baseSpeed;
            _baseType = baseType;
        }
        /// <summary>
        /// HP actuel du personnage
        /// </summary>
        public int CurrentHealth 
        { 
            get => _baseHealth; 
            private set {CurrentHealth = value;}
        }
        public TYPE BaseType { get => _baseType;}
        /// <summary>
        /// HPMax, prendre en compte base et equipement potentiel
        /// </summary>
        public int MaxHealth
        {
            get
            {
                return _maxHealth;
            }

            set { 
                _maxHealth = value;
            }
        }
        /// <summary>
        /// ATK, prendre en compte base et equipement potentiel
        /// </summary>
        public int Attack
        {
            get
            {
                return _baseAttack;
            }

            private set {
                _baseAttack = value;
            }
        }
        /// <summary>
        /// DEF, prendre en compte base et equipement potentiel
        /// </summary>
        public int Defense
        {
            get
            {
                return _baseDefense;
            }

            private set {
                _baseDefense = value;
            }
        }
        /// <summary>
        /// SPE, prendre en compte base et equipement potentiel
        /// </summary>
        public int Speed
        {
            get
            {
                return _baseSpeed;
            }

            private set {
                _baseSpeed = value;
            }
        }
        /// <summary>
        /// Equipement unique du personnage
        /// set stats for equipment
        /// </summary>
        public Equipment CurrentEquipment { get; private set;}
        /// <summary>
        /// null si pas de status
        /// </summary>
        public StatusEffect CurrentStatus { get; private set;}

        public bool IsAlive => CurrentHealth > 0;

        /// <summary>
        /// Application d'un skill contre le personnage
        /// On pourrait potentiellement avoir besoin de connaitre le personnage attaquant,
        /// Vous pouvez adapter au besoin
        /// </summary>
        /// <param name="s">skill attaquant</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ReceiveAttack(Skill s)
        {
            _baseHealth -= s.Power - Defense;
            if (_baseHealth < 0)
            {
                _baseHealth = 0;
            }
            //throw new NotImplementedException();
        }
        /// <summary>
        /// Equipe un objet au personnage
        /// </summary>
        /// <param name="newEquipment">equipement a appliquer</param>
        /// <exception cref="ArgumentNullException">Si equipement est null</exception>
        public void Equip(Equipment newEquipment)
        {
            if (newEquipment == null)
            {
                throw new ArgumentNullException(nameof(newEquipment));
            }
            MaxHealth += newEquipment.BonusHealth;
            Attack += newEquipment.BonusAttack;
            Defense += newEquipment.BonusDefense;
            Speed += newEquipment.BonusSpeed;
            CurrentEquipment = newEquipment;
        }
        /// <summary>
        /// Desequipe l'objet en cours au personnage
        /// </summary>
        public void Unequip()
        {
            MaxHealth -= CurrentEquipment.BonusHealth;
            Attack -= CurrentEquipment.BonusAttack;
            Defense -= CurrentEquipment.BonusDefense;
            Speed -= CurrentEquipment.BonusSpeed;
            CurrentEquipment = null;
        }

        public void TakeMaxDamage(int amount)
        {
            MaxHealth -= amount;
            if(CurrentHealth > MaxHealth)
            {
                _baseHealth = MaxHealth;
            }
        }

        public void Heal(int amount)
        {
            if(CurrentHealth + amount > MaxHealth)
            {
                _baseHealth = MaxHealth;
            }
            else
            {
                _baseHealth += amount;
            }
        }

    }
}
