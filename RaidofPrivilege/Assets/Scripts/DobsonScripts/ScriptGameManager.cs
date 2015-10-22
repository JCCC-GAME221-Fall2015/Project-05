using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// @author Mike Dobson
/// This is going to control the state of the game that is outside of the players control
/// </summary>

public class ScriptGameManager : MonoBehaviour
{

    public List<ScriptPlayer> players = new List<ScriptPlayer>();

    public GameObject startGameMenu;

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
    }

    // Update is called once per frame
    void Update()
    {
        bool endTurn;
        endTurn = true;
        foreach (ScriptPlayer player in players)
        {
            if (endTurn == true && player.endTurn == false)
            {
                endTurn = false;
            }
        }


        if (endTurn)
        {
            Debug.Log(players.Count);
            CheckForWinner();
            for (int i = 0; i < players.Count; i++)
            {
                players[i].endTurn = false;
                players[i].MoveNextAndTransition("goto phase 5");
            }

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
                player.MoveNextAndTransition("goto phase 1");
            }
        }
    }
}
