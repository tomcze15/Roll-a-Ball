using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The main class that manages score in the game
/// </summary>
class ScoreManager
{
    private static ScoreManager manager = new ScoreManager();
    private int                 current_result;
    private readonly int[]      MaxPointsInLvl  = {0, 4, 6, 1 }; //Ponieważ pierwszy level to Menu xD
    private int                 current_lvl     = 1;
    
    private ScoreManager() { }
   
    public static ScoreManager Instance { get { return manager; } }
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
            current_lvl = value;
            current_result = 0;
        }
        get { return current_lvl; }
    }
    public int maxPointInLevel { get { return MaxPointsInLvl[current_lvl]; } }
}

