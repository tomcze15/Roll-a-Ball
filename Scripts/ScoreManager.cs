using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The main class that manages currentResult in the game
/// </summary>
class ScoreManager : MonoBehaviour
{
    private static int current_result;
    private static readonly int[] MaxPointsInLvl = { 4, 6, 1 };
    private static int current_lvl;

    void Start()
    {
        //current_result = 0;
        //current_lvl = 0;
    }

    public int currentResult
    {
        set
        {
            if (current_result < MaxPointsInLvl[current_lvl])
                current_result = value;
        }
        get { return current_result; }
    }
    public int currentLevel
    {
        set
        {
            if (MaxPointsInLvl.Length >= value)
            {
                current_lvl = value;
                current_result = 0;
            }
            else
                Debug.Log("Nie ma takiego Level'u. Prawdopodobnie za duża wartość.");
        }
        get { return current_lvl; }
    }

    public int maxPointInLevel
    {
        get
        {
            if (current_lvl < 0)
                return -1;  
            return MaxPointsInLvl[current_lvl];
        }
    }

    public int lastLevel{ get { return MaxPointsInLvl.Length-1; } }
}

