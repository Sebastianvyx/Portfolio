using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Unit
{
    public int Owner;
    public int Formation;

    public Coordinates Position;
    public int Speed;

    public int Morale;
    public int MoraleValue;
    public int Experience;
    public int ExperienceValue;

    public int MaxHealth;
    public int CurrentHealth;
    public int Armour;

    public int BaseMeleeSpeed;
    public int MeleeSpeed;
    public int BaseMeleeAttack;
    public int MeleeAttack;
    public int BaseMeleeDefence;
    public int MeleeDefence;
    public int BaseMeleeMaxDamage;
    public int MeleeMaxDamage;
    public int MeleeMinDamage;

    public int Ammunition;
    public int BaseRangeMaxDamage;
    public int RangeMaxDamage;
    public int RangeMinDamage;
    public int BaseRangeAccuracy;
    public int RangeAccuracy;
    public int RangeReach;

    public int ChargeAttackBonus;
    public int ChargeDamageBonus;
    public int StandingAttackPenalty;
    public int StandingDefencePenalty;

    public int MaxMana;
    public int CurrentMana;
    public int BasePower;
    public int Power;

    public void UpdateStats ()
    {
        MeleeSpeed = BaseMeleeSpeed + (Experience + Morale);
        MeleeAttack = BaseMeleeAttack + (Experience + Morale);
        MeleeDefence = BaseMeleeDefence + (Experience + Morale);
        MeleeMaxDamage = BaseMeleeMaxDamage + (Experience + Morale);

        if (this is Archer)
        {
            RangeAccuracy = BaseRangeAccuracy + (Experience + Morale);
            RangeMaxDamage = BaseRangeMaxDamage + (Experience + Morale);
        }

        if (this is Mage)
        {
            Power = BasePower + (Experience + Morale);
        }
    }

    public void Move(int X, int Y)
    {
        Battlefield.Tiles[Position.X, Position.Y] = null;
        Battlefield.Tiles[X, Y] = this;
        Position.X = X;
        Position.Y = Y;
    }

	public void Strike(Unit Target, int IndexNumber)
    {
        int RandomNumber;
        int RandomNumber2;
        int Damage;

        Combat.BattleCourses.Add (new List<int>());

        while (Target.CurrentHealth > 0 && CurrentHealth > 0)
        {
            RandomNumber2 = Random.GetRandomNumber(1, MeleeSpeed + Target.MeleeSpeed);

            if (RandomNumber2 <= MeleeSpeed)
            {
                RandomNumber = Random.GetRandomNumber(0, 100);
                if (RandomNumber <= MeleeAttack - Target.MeleeDefence)
                {
                    RandomNumber = Random.GetRandomNumber(MeleeMinDamage, MeleeMaxDamage);
                    if (RandomNumber >= Target.Armour)
                    {
                        Damage = RandomNumber - Target.Armour;
                    }
                    else
                    {
                        Damage = 0;
                    }
                    Target.CurrentHealth -= Damage;
                    if (Target.CurrentHealth > 0)
                    {
                        Combat.BattleCourses[IndexNumber].Add(1);
                        Debug.Log("Attacker Health : " + CurrentHealth);
                        Debug.Log("Defender Health : " + Target.CurrentHealth);
                    }
                    else
                    {
                        Combat.BattleCourses[IndexNumber].Add(3);
                        Debug.Log("Attacker Health : " + CurrentHealth);
                        Debug.Log("Defender Health : " + Target.CurrentHealth);                  
                    }
                }
                else
                {
                    Combat.BattleCourses[IndexNumber].Add(2);
                    Debug.Log("Attacker Health : " + CurrentHealth);
                    Debug.Log("Defender Health : " + Target.CurrentHealth);         
                }
                if (Target.CurrentHealth > 0)
                {
                    RandomNumber = Random.GetRandomNumber(0, 100);
                    if (RandomNumber <= Target.MeleeAttack - MeleeDefence)
                    {
                        RandomNumber = Random.GetRandomNumber(Target.MeleeMinDamage, Target.MeleeMaxDamage);
                        if (RandomNumber >= Armour)
                        {
                            Damage = RandomNumber - Armour;
                        }
                        else
                        {
                            Damage = 0;
                        }
                        CurrentHealth -= Damage;
                        if (CurrentHealth > 0)
                        {
                            Combat.BattleCourses[IndexNumber].Add(4);
                            Debug.Log("Attacker Health : " + CurrentHealth);
                            Debug.Log("Defender Health : " + Target.CurrentHealth);
                        }
                        else
                        {
                            Combat.BattleCourses[IndexNumber].Add(6);
                            Debug.Log("Attacker Health : " + CurrentHealth);
                            Debug.Log("Defender Health : " + Target.CurrentHealth);
                        }
                    }
                    else
                    {
                        Combat.BattleCourses[IndexNumber].Add(5);
                        Debug.Log("Attacker Health : " + CurrentHealth);
                        Debug.Log("Defender Health : " + Target.CurrentHealth);
                    }
                }
            }
            if (RandomNumber2 > MeleeSpeed)
            {
                RandomNumber = Random.GetRandomNumber(0, 100);
                if (RandomNumber <= Target.MeleeAttack - MeleeDefence)
                {
                    RandomNumber = Random.GetRandomNumber(Target.MeleeMinDamage, Target.MeleeMaxDamage);
                    if (RandomNumber >= Armour)
                    {
                        Damage = RandomNumber - Armour;
                    }
                    else
                    {
                        Damage = 0;
                    }
                    CurrentHealth -= Damage;
                    if (CurrentHealth > 0)
                    {
                        Combat.BattleCourses[IndexNumber].Add(4);
                        Debug.Log("Attacker Health : " + CurrentHealth);
                        Debug.Log("Defender Health : " + Target.CurrentHealth);                  
                    }
                    else
                    {
                        Combat.BattleCourses[IndexNumber].Add(6);
                        Debug.Log("Attacker Health : " + CurrentHealth);
                        Debug.Log("Defender Health : " + Target.CurrentHealth);                  
                    }
                }
                else
                {
                    Combat.BattleCourses[IndexNumber].Add(5);
                    Debug.Log("Attacker Health : " + CurrentHealth);
                    Debug.Log("Defender Health : " + Target.CurrentHealth);               
                }
                if (CurrentHealth > 0)
                {
                    RandomNumber = Random.GetRandomNumber(0, 100);
                    if (RandomNumber <= MeleeAttack - Target.MeleeDefence)
                    {
                        RandomNumber = Random.GetRandomNumber(MeleeMinDamage, MeleeMaxDamage);
                        if (RandomNumber >= Target.Armour)
                        {
                            Damage = RandomNumber - Target.Armour;
                        }
                        else
                        {
                            Damage = 0;
                        }
                        Target.CurrentHealth -= Damage;

                        if (Target.CurrentHealth > 0)
                        {
                            Combat.BattleCourses[IndexNumber].Add(1);
                            Debug.Log("Attacker Health : " + CurrentHealth);
                            Debug.Log("Defender Health : " + Target.CurrentHealth);                     
                        }
                        else
                        {
                            Combat.BattleCourses[IndexNumber].Add(3);
                            Debug.Log("Attacker Health : " + CurrentHealth);
                            Debug.Log("Defender Health : " + Target.CurrentHealth);                     
                        }
                    }
                    else
                    {
                        Combat.BattleCourses[IndexNumber].Add(2);
                        Debug.Log("Attacker Health : " + CurrentHealth);
                        Debug.Log("Defender Health : " + Target.CurrentHealth);

                    }
                    if (CurrentHealth <= 0)
                    {
                        Combat.BattleCourses[IndexNumber].Add(3);
                        Debug.Log("Attacker Health : " + CurrentHealth);
                        Debug.Log("Defender Health : " + Target.CurrentHealth);                  
                    }
                }
            }
        }
        if (Target.CurrentHealth <= 0)
        {
            Experience += Target.ExperienceValue;
            Morale += Target.MoraleValue;
            UpdateStats();
        }
        else
        {
            Target.Experience += Experience + MoraleValue;
            Target.Morale += MoraleValue;
            Target.UpdateStats();
        }
    }
    virtual public void Shoot(Unit Target, int IndexNumber)
    { }
    virtual public void Charge(Unit Target, int IndexNumber)
    { }
    virtual public void Heal(Unit Target)
    { }
}

public class Infantryman : Unit
{
}

public class Archer : Unit
{

    public override void Shoot(Unit Target, int IndexNumber)
    {
        int RandomNumber;
        int Damage;

		Shooting.BattleCourses.Add(0);

        RandomNumber = Random.GetRandomNumber(0, 100);

        if (RandomNumber <= RangeAccuracy)
        {
            RandomNumber = Random.GetRandomNumber(RangeMinDamage, RangeMaxDamage);
            if (RandomNumber >= Target.Armour)
            {
                Damage = RandomNumber - Target.Armour;
            }
            else Damage = 0;
            Target.CurrentHealth -= Damage;

            if (Target.CurrentHealth > 0)
            {
                Shooting.BattleCourses[IndexNumber] = 1;
            }

            if (Target.CurrentHealth <= 0)
            {
                Shooting.BattleCourses[IndexNumber] = 2;
            }
        }
        if (RandomNumber > RangeAccuracy)
        {
            Shooting.BattleCourses[IndexNumber] = 3;
        }

        if (Target.CurrentHealth <= 0)
        {
            Experience += Target.ExperienceValue;
            Morale += Target.MoraleValue;
            UpdateStats();
        }
        Ammunition-- ;
    }
}

public class Horseman : Unit
{
    override public void Charge(Unit Target, int IndexNumber)
    {
        int RandomNumber;
        int Damage;
        bool FirstHit = true;

        MeleeAttack += Experience + Morale;
        MeleeMinDamage += Experience + Morale;
        MeleeMaxDamage += Experience + Morale;

		for (int Counter = 1; Target.CurrentHealth > 0 && CurrentHealth > 0; Counter++)
        {
            if (FirstHit)
            {
                MeleeAttack += ChargeAttackBonus;
                MeleeMaxDamage += ChargeDamageBonus;
                MeleeMinDamage += ChargeDamageBonus;
                FirstHit = false;
            }
            RandomNumber = Random.GetRandomNumber(0, 100);
            if (RandomNumber <= MeleeAttack - Target.MeleeDefence)
            {
                RandomNumber = Random.GetRandomNumber(MeleeMinDamage, MeleeMaxDamage);
                if (RandomNumber >= Target.Armour)
                {
                    Damage = RandomNumber - Target.Armour;
                }
                else
                {
                    Damage = 0;
                }
                Target.CurrentHealth -= Damage;
                if (Target.CurrentHealth > 0)
                {
					Combat.BattleCourses[IndexNumber].Add(1);
                    Debug.Log("Attacker Health : " + CurrentHealth);
                    Debug.Log("Defender Health : " + Target.CurrentHealth);
                    
                }
                else
                {
					Combat.BattleCourses[IndexNumber].Add(3);
                    Debug.Log("Attacker Health : " + CurrentHealth);
                    Debug.Log("Defender Health : " + Target.CurrentHealth);
                    
                }
            }
            else
            {
				Combat.BattleCourses[IndexNumber].Add(2);
                Debug.Log("Attacker Health : " + CurrentHealth);
                Debug.Log("Defender Health : " + Target.CurrentHealth);
                
            }

            MeleeAttack -= ChargeAttackBonus;
            MeleeMaxDamage -= ChargeDamageBonus;
            MeleeMinDamage -= ChargeDamageBonus;

            if (Target.CurrentHealth > 0)
            {
                RandomNumber = Random.GetRandomNumber(0, 100);
                if (RandomNumber <= Target.MeleeAttack - MeleeDefence)
                {
                    RandomNumber = Random.GetRandomNumber(Target.MeleeMinDamage, Target.MeleeMaxDamage);
                    if (RandomNumber >= Armour)
                    {
                        Damage = RandomNumber - Armour;
                    }
                    else
                    {
                        Damage = 0;
                    }
                    CurrentHealth -= Damage;
                    if (CurrentHealth > 0)
                    {
						Combat.BattleCourses[IndexNumber].Add(4);
                        Debug.Log("Attacker Health : " + CurrentHealth);
                        Debug.Log("Defender Health : " + Target.CurrentHealth);
                        
                    }
                    else
                    {
						Combat.BattleCourses[IndexNumber].Add(6);
                        Debug.Log("Attacker Health : " + CurrentHealth);
                        Debug.Log("Defender Health : " + Target.CurrentHealth);
                        

                    }
                }
                else
                {
					Combat.BattleCourses[IndexNumber].Add(5);
                    Debug.Log("Attacker Health : " + CurrentHealth);
                    Debug.Log("Defender Health : " + Target.CurrentHealth);
                }
            }

			if (Target.CurrentHealth <= 0)
            {
                Experience += Target.ExperienceValue;
                Morale += Target.MoraleValue;
                UpdateStats();
            }
            else
            {
                Target.Experience += Experience + MoraleValue;
                Target.Morale += MoraleValue;
                Target.UpdateStats();
            }
        }
    }
}

public class Mage : Unit
{   
    public override void Heal(Unit Target)
    {

        if (Target.CurrentHealth + Power <= Target.MaxHealth)
        {
            Target.CurrentHealth += Power;
            CurrentMana -= Power;
        }
        else
        {
            CurrentMana = CurrentMana - (Target.MaxHealth - Target.CurrentHealth);
            Target.CurrentHealth = Target.MaxHealth;
        }

        Experience ++;
        UpdateStats();
    }
}