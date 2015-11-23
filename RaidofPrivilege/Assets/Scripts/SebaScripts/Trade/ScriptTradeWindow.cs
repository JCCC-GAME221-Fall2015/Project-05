using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// @Author: Andrew Seba
/// </summary>
public class ScriptTradeWindow : MonoBehaviour {

    //public Transform myResourceContentPanel;
    //public Transform givingResourceContentPanel;

    //public GameObject prefabButtonRemaining;
    ////public List<ScriptItem> gameResources;
    //public List<ScriptItem> remainingResourse;
    //public List<ScriptItem> givingResources;

    ScriptPlayer playerData;
    ScriptGameManager manager;

    [Header("MyResourceButtons")]
    public Button addGrainButton;
    public Text grainAmount;
    public Button addBrickButton;
    public Text brickAmount;
    public Button addWoodButton;
    public Text woodAmount;
    public Button addWoolButton;
    public Text woolAmount;


    [Header("Wanting To Give Resources Buttons")]
    public Button removeGrain;
    public Button removeBrick;
    public Button removeWood;
    public Button removeWool;

    List<Button> buttons;
    /// <summary>
    /// Adds the game resources to a list of resources that we might display
    /// on the trade window.
    /// </summary>
    public void InitList()
    {
        foreach(ScriptPlayer player in manager.players)
        {
            if (player.GetComponent<ScriptPlayer>())
            {
                playerData = player.GetComponent<ScriptPlayer>();
            }
        }
        buttons = new List<Button>();
        //PopulateListWithDefaultResources();
        //PopulateButtonLists();
    }

    void PopulateText()
    {
        foreach(Button button in buttons)
        {
            if (button.GetComponent<Text>().name == "Button_AddGrain")
            {
                
            }
        }
    }


    ///Dynamic Button Trade un-successful attempt
    //void PopulateListWithDefaultResources()
    //{
    //    gameResources = new List<ScriptItem>();

    //    ScriptItem wood = new ScriptItem("Wood", playerData.wood);
    //    gameResources.Add(wood);

    //    ScriptItem wool = new ScriptItem("Wool", playerData.wool);
    //    gameResources.Add(wool);

    //    ScriptItem brick = new ScriptItem("Brick", playerData.brick);
    //    gameResources.Add(brick);

    //    ScriptItem grain = new ScriptItem("Grain", playerData.grain);
    //    gameResources.Add(grain);
    //}


    /// <summary>
    /// Populates the remaning resource list with resources that you have with
    /// a value above 0 so that you know that you have it or not to trade.
    /// </summary>
    //void PopulateButtonLists()
    //{
    //    foreach(ScriptItem resource in gameResources)
    //    {
    //        if (resource.resourceAmount > 0 && !remainingResourse.Contains(resource))
    //        {
    //            GameObject newButton = (GameObject)Instantiate(prefabButtonRemaining);
    //            SampleButtonRemaining tempButton = newButton.GetComponent<SampleButtonRemaining>();

    //            tempButton.name = resource.resourceName + "Button";
    //            tempButton.resourceName.text = resource.resourceName;
    //            tempButton.resourceAmount.text = resource.resourceAmount.ToString();

    //            tempButton.button.onClick.AddListener(delegate { AddToGiveList(tempButton.resourceName.text); });

    //            newButton.transform.SetParent(myResourceContentPanel);
    //            remainingResourse.Add(resource);
    //        }
    //    }

    //    foreach(ScriptItem resource in givingResources)
    //    {
    //        if (resource.resourceAmount > 0 && !givingResources.Contains(givingResources.Find(item => item == resource)))
    //        {
    //            GameObject newButton = (GameObject)Instantiate(prefabButtonRemaining);
    //            SampleButtonRemaining tempButton = newButton.GetComponent<SampleButtonRemaining>();

    //            tempButton.resourceName.text = resource.resourceName;
    //            tempButton.resourceAmount.text = resource.resourceAmount.ToString();

    //            //tempButton.button.onClick.AddListener(delegate { })

    //            newButton.transform.SetParent(givingResourceContentPanel);

    //        }

    //    }
    //}

    ///// <summary>
    ///// For some reason I can only get strings to pass through this button.
    ///// </summary>
    //public void AddToGiveList(string pName)
    //{

    //    ScriptItem givingItem;

    //    switch (pName)
    //    {
    //        case "Wood":
    //            givingItem = gameResources.Find(item => item.resourceName == "Wood");
    //            break;
    //        case "Wool":
    //            givingItem = gameResources.Find(item => item.resourceName == "Wool");
    //            break;
    //        case "Brick":
    //            givingItem = gameResources.Find(item => item.resourceName == "Brick");
    //            break;
    //        case "Grain":
    //            givingItem = gameResources.Find(item => item.resourceName == "Grain");
    //            break;
    //        default:
    //            givingItem = null;
    //            break;
    //    }

    //    if(remainingResourse.Find(item => item == givingItem).resourceAmount > 0)
    //    {
    //        remainingResourse.Find(item => item == givingItem).resourceAmount -= 1;
    //    }
    //    else
    //    {
    //        remainingResourse.Remove(remainingResourse.Find(item => item == givingItem));
    //    }
        


    //    if (!givingResources.Contains(givingItem) && givingItem != null)
    //    {
    //        Debug.Log("Adding new Button");

            
    //        givingResources.Add(givingItem);
    //        givingItem.resourceAmount = 1;

    //    }
    //    else
    //    {
    //        Debug.Log("Adding to old button");
    //        givingItem = givingResources.Find(item => item == givingItem);
    //        givingItem.resourceAmount += 1;
    //    }

    //    PopulateButtonLists();
    //}
}
