using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
   This difficulty class is meant to define a difficulty in each level of QuickChange 
   by providing set maximum values for key elements that which math operations should 
   be taken on.
*/

public class DifficultyClass : MonoBehaviour
{
    public string levelDifficulty; // String meant to be set to easy, normal, or hard

    // Maximum Values for customer tender and balance of payment of each problem 
    public double balanceMax;
    public double tenderMax;

    // Start is called before the first frame update
    void Start()
    {
        initializeDifficulty();
    }

    // Update is called once per frame
    void Update()
    {

        // switch/case defines maximum values at each difficulty level
        string updateDifficulty = levelDifficulty;
        switch (updateDifficulty)
        {
            case "easy":
               balanceMax = 99.0;
               tenderMax = 100.0;
               break;
            case "normal":
               balanceMax = 499.0;
               tenderMax = 500.0;
               break;
            case "hard":
               balanceMax = 999.0;
               tenderMax = 1000.0;
               break;
            default:
               Debug.LogError("Invalid Difficulty");
               break;
        }
    }

    void initializeDifficulty()
    {
        levelDifficulty = "easy";
    }

    void setDifficulty( string levelSetting )
    {
        levelDifficulty = levelSetting.ToLower();
    }

    string getDifficulty()
    {
        return levelDifficulty;
    }

    bool validateDifficulty( double balance, double tender )
    {
        // Checks if problem parameters are within correct range
        return balance <= balanceMax && tender <= tenderMax;
    }

    public void increaseDifficulty()
    {
        switch (levelDifficulty)
        {
            case "easy":
               levelDifficulty = "normal";
               break;
            case "normal":
               levelDifficulty = "hard";
               break;
            case "hard":
               Debug.Log("Already at Maximum difficulty");
               break;
            default:
               Debug.LogError("Invalid Difficulty");
               break;
        }
    }

    public void decreaseDifficulty()
    {
        switch (levelDifficulty)
        {
            case "hard":
               levelDifficulty = "normal";
               break;
            case "normal":
               levelDifficulty = "easy";
               break;
            case "easy":
               Debug.Log("Already at Minimum difficulty");
               break;
            default:
               Debug.LogError("Invalid Difficulty");
               break;
        }
    }

    // Automated Tests
    bool testSetDifficulty()
    {
        string result = "easy";
        DifficultyClass testDifficulty = new DifficultyClass();

        testDifficulty.setDifficulty("easy");

        if( result == testDifficulty.getDifficulty() )
        {
            testDifficulty = null;
            return true;
        }
        else
        {
            Debug.LogError("Issue with DifficultyClass : setDifficulty()");
        }

        testDifficulty = null;

        return false;
    }

    bool testGetDifficulty()
    {
        string result = levelDifficulty;
        string currentDifficulty = getDifficulty();

        if( result == currentDifficulty )
        {
            return true;
        }
        else
        {
            Debug.LogError("Issue with DifficultyClass : getDifficulty()");
        }
        return false;
    }

    bool testIncreaseDifficulty()
    {
        string result = "hard";
        DifficultyClass testDifficulty = new DifficultyClass();

        testDifficulty.initializeDifficulty();
        testDifficulty.increaseDifficulty();
        testDifficulty.increaseDifficulty();

        if( result == testDifficulty.getDifficulty() )
        {
            testDifficulty = null;
            return true;
        }
        else
        {
            Debug.LogError( "Issue with DifficultyClass : increaseDifficulty()" );
        }

        testDifficulty = null;
        return false;
    }
    bool testDecreaseDifficulty()
    {
        string result = "easy";
        DifficultyClass testDifficulty = new DifficultyClass();

        testDifficulty.initializeDifficulty();
        testDifficulty.setDifficulty("hard");

        testDifficulty.decreaseDifficulty();
        testDifficulty.decreaseDifficulty();

        if( result == testDifficulty.getDifficulty() )
        {
            testDifficulty = null;
            return true;
        }
        else
        {
            Debug.LogError( "Issue with DifficultyClass : decreaseDifficulty()" );
        }
        
        testDifficulty = null;
        return false;
    }
}


