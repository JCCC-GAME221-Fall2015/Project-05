using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;

/// <summary>
/// @Author: Andrew Seba
/// @Description: Holds all resource data and player actions.
/// </summary>
public class PlayerData : NetworkBehaviour{

    [HideInInspector]
    public GameState curPhase;
    public int wood { get; set; }
    public int wool { get; set; }
    public int brick { get; set; }
    public int grain {get; set; }

    public Text grainAmount;
    public Text brickAmount;
    public Text woodAmount;
    public Text woolAmount;

    public string PlayerName;

    public List<GameObject> settlements;
    public List<GameObject> roads;

    public bool EndTurn = false;


    public int numSettlements { get; set; }

    [HideInInspector]
    public List<string> playerActions;


    void Start()
    {
        wood = 0;
        wool = 0;
        brick = 0;
        grain = 0;
        numSettlements = 0;

        settlements = new List<GameObject>();
        roads = new List<GameObject>();

        transform.parent = GameObject.Find("Player").transform;

        if (isLocalPlayer)
        {
            grainAmount = GameObject.Find("Text_GrainAmount").GetComponent<Text>();
            brickAmount = GameObject.Find("Text_BrickAmount").GetComponent<Text>();
            woodAmount = GameObject.Find("Text_WoodAmount").GetComponent<Text>();
            woolAmount = GameObject.Find("Text_WoolAmount").GetComponent<Text>();
        }

    }

    public void GainResources(int diceRoll)
    {
        foreach (GameObject settlement in settlements)
        {
            settlement.GetComponent<ScriptBoardCorner>().GainResources(diceRoll);
        }
    }

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

    public void ChangeGrain(int pAmount)
    {
        grain += pAmount;
    }

    public void ChangeBrick(int pAmount)
    {
        brick += pAmount;
    }

    public void ChangeWood(int pAmount)
    {
        wood += pAmount;
    }

    public void ChangeWool(int pAmount)
    {
        wool += pAmount;
    }

    void UpdateResourceText()
    {
        
        grainAmount.text = grain.ToString();
        brickAmount.text = brick.ToString();
        woodAmount.text = wood.ToString();
        woolAmount.text = wool.ToString();
    }
}
