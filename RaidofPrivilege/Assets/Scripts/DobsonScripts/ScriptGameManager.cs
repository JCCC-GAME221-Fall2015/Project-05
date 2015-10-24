using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// @author Mike Dobson
/// This is going to control the state of the game that is outside of the players control
/// </summary>

public class ScriptGameManager : MonoBehaviour
{
	// Craig
	[HideInInspector]
	public InformationSave saveInfo;
	public bool restartedGame = false;

    public List<ScriptPlayer> players = new List<ScriptPlayer>();
    public List<ScriptTrade> trades = new List<ScriptTrade>();

    public GameObject startGameMenu;
    public ScriptPlayer localPlayer;//Andrew Seba

    [Tooltip("Place the next phase button here.")]
    public GameObject nextPhaseButton;//Andrew Seba
    [Tooltip("Place the end turn toggle button here.")]
    public GameObject endTurnToggle;

    bool playersInitialized = false;

    int winningPlayerNumber = -1;

    // Use this for initialization
    void Start()
    {
        //StartCoroutine

	}

    public void InitializeGame()
    {
        GameObject[] tempArray = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject obj in tempArray)
        {
            players.Add(obj.GetComponent<ScriptPlayer>());
        }
        foreach(ScriptPlayer player in players)
        {
            player.Phase0();
        }
        playersInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playersInitialized)
        {
            bool endTurn = true;

            foreach (ScriptPlayer player in players)
            {
                if (endTurn == true && player.endTurn == false)
                {
                    endTurn = false;
                }

            }

            if (endTurn)
            {
                endTurnToggle.GetComponent<Toggle>().isOn = false;
                CheckForWinner();
                for (int i = 0; i < players.Count; i++)
                {
                    players[i].endTurn = false;
                    players[i].MoveNextAndTransition("goto phase 5");
                }

            }
        }
    }

    public void ToggleLocalEndTurn()
    {
        if(localPlayer.endTurn == false)
        {
            localPlayer.endTurn = true;
        }
        else
        {
            localPlayer.endTurn = false;
        }
    }

    void CheckForWinner()
    {
        Debug.Log("Checking for winner");

        Debug.Log("Start Processing");
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].numSettlements > 1.25 * players.Count)
            {
                winningPlayerNumber = i;
            }
        }

        if (winningPlayerNumber != -1)
        {
            Debug.Log("End Processing");
            Debug.Log("Winner found");
            foreach(ScriptPlayer player in players)
            {
                player.MoveNextAndTransition("goto phase 6");
            }
        }
        else
        {
            Debug.Log("End Processing");
            Debug.Log("No winner");
            foreach(ScriptPlayer player in players)
            {
                //player.MoveNextAndTransition("goto phase 5");
            }
        }
    }
	
	public void _PlayerNextPhase()
	{
        localPlayer._NextPhaseButton();
	}
	
	// Craig
	public void LoadSavedGame()
	{
		saveInfo.LoadGame();
		restartedGame = true;
	}
}
