using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// @Author: Andrew Seba
/// @Description: Populates the remaning list for now.
/// </summary>
public class ScriptTradeWindow : MonoBehaviour {

    public Transform contentPanel;

    public GameObject prefabButtonRemaining;
    public List<ScriptItemRemaining> remainingResourceItems;

    PlayerData playerData;

    public void InitList()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();

        ScriptItemRemaining wood = new ScriptItemRemaining("Wood", playerData.wood);
        remainingResourceItems.Add(wood);

        ScriptItemRemaining wool = new ScriptItemRemaining("Wool", playerData.wool);
        remainingResourceItems.Add(wool);

        ScriptItemRemaining brick = new ScriptItemRemaining("Brick", playerData.wood);
        remainingResourceItems.Add(brick);

        ScriptItemRemaining grain = new ScriptItemRemaining("Grain", playerData.grain);
        remainingResourceItems.Add(grain);
    }


    /// <summary>
    /// Populates the remaning resource list with resources that you have with
    /// a value above 0 so that you know that you have it or not to trade.
    /// </summary>
    void PopulateRemainingList()
    {
        foreach(ScriptItemRemaining resource in remainingResourceItems)
        {
            if(resource.resourceAmount > 0)
            {
                GameObject newButton = (GameObject)Instantiate(prefabButtonRemaining);
                SampleButtonRemaining tempButton = newButton.GetComponent<SampleButtonRemaining>();

                tempButton.resourceName.text = resource.resourceName;
                tempButton.resourceAmount.text = resource.resourceAmount.ToString();

                //tempButton.button.onClick.AddListener(delegate { SomethingToDo(); });

                newButton.transform.SetParent(contentPanel);
            }
        }
    }

    //public void SomethingToDo()
    //{

    //}
}
