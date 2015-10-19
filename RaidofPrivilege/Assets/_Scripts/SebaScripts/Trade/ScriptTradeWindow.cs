using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// @Author: Andrew Seba
/// @Description: Populates the remaning list for now.
/// </summary>
public class ScriptTradeWindow : MonoBehaviour {

    public Transform contentPanel;

    public GameObject prefabButtonRemaining;
    public List<ScriptItem> gameResources;
    public List<ScriptItem> remainingResourseList;

    PlayerData playerData;

    public void InitList()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").
            GetComponent<ScriptEngine>().
            players[0].
            GetComponent<PlayerData>();

        ScriptItem wood = new ScriptItem("Wood", playerData.wood);
        gameResources.Add(wood);

        ScriptItem wool = new ScriptItem("Wool", playerData.wool);
        gameResources.Add(wool);

        ScriptItem brick = new ScriptItem("Brick", playerData.brick);
        gameResources.Add(brick);

        ScriptItem grain = new ScriptItem("Grain", playerData.grain);
        gameResources.Add(grain);

        PopulateRemainingList();
    }


    /// <summary>
    /// Populates the remaning resource list with resources that you have with
    /// a value above 0 so that you know that you have it or not to trade.
    /// </summary>
    void PopulateRemainingList()
    {
        foreach(ScriptItem resource in gameResources)
        {
            if (resource.resourceAmount > 0 && !remainingResourseList.Contains(resource))
            {
                GameObject newButton = (GameObject)Instantiate(prefabButtonRemaining);
                SampleButtonRemaining tempButton = newButton.GetComponent<SampleButtonRemaining>();

                tempButton.resourceName.text = resource.resourceName;
                tempButton.resourceAmount.text = resource.resourceAmount.ToString();

                tempButton.button.onClick.AddListener(delegate { SomethingToDo(); });

                newButton.transform.SetParent(contentPanel);
                remainingResourseList.Add(resource);
            }
        }
    }

    public void SomethingToDo()
    {
        PopulateRemainingList();
    }
}
