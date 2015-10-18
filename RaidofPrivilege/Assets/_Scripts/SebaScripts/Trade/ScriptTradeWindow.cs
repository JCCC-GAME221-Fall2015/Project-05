using UnityEngine;
using System.Collections.Generic;

public class ScriptTradeWindow : MonoBehaviour {

    PlayerData playerData;

    public GameObject prefabButtonRemaining;
    public List<ScriptItemRemaining> remainingResourceItems;

    public void InitList()
    {
        //playerData = localPlayerData
        ScriptItemRemaining Wood = new ScriptItemRemaining();
        Wood.resourceName = "Wood";
        Wood.resourceAmount = playerData.wood;
        remainingResourceItems.Add(Wood);
        ScriptItemRemaining Wool = new ScriptItemRemaining();
    }

    void PopulateList()
    {

    }
}
