using UnityEngine;
using System.Collections.Generic;

public class ScriptTradePlayerSelect : MonoBehaviour {

    public Transform contentPanel;

    public GameObject prefabPlayerSelectButton;

    ScriptGameManager gameManager;

    public string receivingPlayerName;

    public void InitList()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<ScriptGameManager>();
        receivingPlayerName = "";
        

        foreach(ScriptPlayer player in gameManager.players)
        {
            GameObject newButton = (GameObject)Instantiate(prefabPlayerSelectButton);
            SampleButtonPlayer tempButton = newButton.GetComponent<SampleButtonPlayer>();

            tempButton.name = player.playerName + " Button";
            tempButton.playerName.text = player.playerName;

            tempButton.button.onClick.AddListener(delegate { SelectPlayer(tempButton.playerName.text); });

            newButton.transform.SetParent(contentPanel);
        }

    }

    public void SelectPlayer(string pPlayerName)
    {
        receivingPlayerName = pPlayerName;
    }
}
