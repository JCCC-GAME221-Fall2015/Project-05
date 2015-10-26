using UnityEngine;
using System.Collections; // Craig
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

/// <summary>
/// @author Mike Dobson
/// This is going to control the state of the game that is outside of the players control
/// </summary>

public class ScriptGameManager : NetworkBehaviour
{
	public bool restartedGame = false; // Craig

    public List<ScriptPlayer> players; //= new List<ScriptPlayer>();
    //[SyncVar]
    public List<ScriptTrade> trades; //= new List<ScriptTrade>();

    public GameObject startGameMenu;
    public ScriptPlayer localPlayer;//Andrew Seba

    [Tooltip("Place the next phase button here.")]
    public GameObject nextPhaseButton;//Andrew Seba
    [Tooltip("Place the end turn toggle button here.")]
    public GameObject endTurnToggle;

    bool playersInitialized = false;

    int winningPlayerNumber = -1;

    int infiniteLoopBreak = 0;

    // Use this for initialization
    void Start()
    {
		restartedGame = false; // Craig
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
        StartCoroutine(CheckForEndGame());
    }

    IEnumerator CheckForEndGame()
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
                ToggleLocalEndTurn();
                CheckForWinner();
                yield return StartCoroutine(TransmitTrades());

                
                localPlayer.MoveNextAndTransition("goto phase 5");

                //for (int i = 0; i < players.Count; i++)
                //{
                //    players[i].endTurn = false;
                //    players[i].MoveNextAndTransition("goto phase 5");
                //}
            }
        }

        //if(infiniteLoopBreak > 1000)
        //{
        //    Debug.LogWarning("Loop Reached Max");
        //}
        //else 
        //{
        //    Debug.Log("Working Fine");
        //}
        //infiniteLoopBreak++;
        yield return new WaitForEndOfFrame();
    }

    /// <summary>
    /// @Author: Andrew Seba
    /// @Description: Toggles the endturn on local player and sends it across
    /// the network.
    /// </summary>
    public void ToggleLocalEndTurn()
    {
        if(localPlayer.endTurn == false)
        {
            localPlayer.endTurn = true;
            localPlayer.CmdSendEndTurn(true);
        }
        else
        {
            localPlayer.endTurn = false;
            localPlayer.CmdSendEndTurn(false);
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
	
    IEnumerator TransmitTrades()
    {
        foreach(ScriptTrade trade in trades)
        {
            ScriptPlayer tempPlayer = trade.tradie;
            tempPlayer.inboundTrade.Enqueue(trade);
        }
        yield return null;
    }

	public void _PlayerNextPhase()
	{
        localPlayer._NextPhaseButton();
	}
	
	// @author: Craig Broskow
	public void LoadSavedGame(string pLevelName)
	{
		InformationSave saveInfo = Camera.main.GetComponent<InformationSave>();
		if (saveInfo.LoadGame(pLevelName))
			restartedGame = true;
		else
			restartedGame = false;
	} // end method LoadSavedGame
}
