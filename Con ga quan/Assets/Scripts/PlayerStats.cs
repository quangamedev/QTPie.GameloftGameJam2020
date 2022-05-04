using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    private static float health = 100, maxHealth = 100;
    private static int money = 100;

    private static int enoughItemsMoneyReward = 40;
    private static int missingItemMoneyPenaltyMultiplier = 2;

    private static float fakeItemHealthPenalty = 10;


    public static float Health
    {
        get
        {
            return health;
        }
        set
        {
            if (health > maxHealth)
            {
                health = maxHealth;
            }

            health = value;
        }
    }

    public static float MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
        }
    }

    public static int Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
        }
    }

    public static int EnoughItemsMoneyReward
    {
        get
        {
            return enoughItemsMoneyReward;
        }
    }

    public static int MissingItemMoneyPenaltyMultiplier
    {
        get
        {
            return missingItemMoneyPenaltyMultiplier;
        }
    }

    public static float FakeItemHealthPenalty
    {
        get
        {
            return fakeItemHealthPenalty;
        }
    }

    ////default value of the players basic stats
    //public float health;
    //public float maxHealth = 100;
    //public int money = 100;

    ////modify the player's health
    ////pass in positive values to increase
    //            //negative values to decrease
    //public void ModifyHealth(float value)
    //{
    //    health += value;

    //    if (health > maxHealth)
    //    {
    //        health = maxHealth;
    //    }

    //    Debug.Log("Health: " + health);
    //}
}
