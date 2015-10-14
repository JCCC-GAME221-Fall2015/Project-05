using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// @Author: Andrew Seba
/// @Description: Holds all resource data and player actions.
/// </summary>
public class PlayerData : MonoBehaviour {

    [HideInInspector]
    public Phases curPhase;
    public int wood { get; set; }
    public int wool { get; set; }
    public int brick { get; set; }
    public int grain {get; set; }

    public Text grainAmount;
    public Text brickAmount;
    public Text woodAmount;
    public Text woolAmount;
    

    [HideInInspector]
    public List<string> playerActions;



    /// <summary>
    /// Adds a string to the player Actions list for saving later
    /// </summary>
    /// <param name="pAction"></param>
    public void AddAction(string pAction)
    {
        /*saving Heuristic (prototype)

        "build","road or settlement","ArrayLocation"   email me when you figure it out*/
        playerActions.Add(pAction);
    }

    void Update()
    { 
    

    #if UNITY_EDITOR
        if (Input.GetKeyDown("1"))
        {
            grain++;
        }
        if (Input.GetKeyDown("2"))
        {
            brick++;
        }
        if (Input.GetKeyDown("3"))
        {
            wood++;
        }
        if (Input.GetKeyDown("4"))
        {
            wool++;
        }
    #endif
        UpdateResourceText();

    }

    void UpdateResourceText()
    {
        grainAmount.text = grain.ToString();
        brickAmount.text = brick.ToString();
        woodAmount.text = wood.ToString();
        woolAmount.text = wool.ToString();
    }
}
