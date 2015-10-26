using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
//Mike
public enum GameState
{
    PHASE0,//GameStart
    PHASE1,//Roll
    PHASE2,//Trade
    PHASE3,//Build
    PHASE4,//Process
    PHASE5,//EndGame
    PHASE6//Win
}
//Mike
public enum StateCommands
{
    GOTO_PHASE0,
    GOTO_PHASE1,
    GOTO_PHASE2,
    GOTO_PHASE3,
    GOTO_PHASE4,
    GOTO_PHASE5,
    GOTO_PHASE6,
    QUIT_APPLICATION
}

/// <summary>
/// @Author: Andrew Seba
/// @Description: Holds all resource data and player actions.
/// </summary>
public class ScriptPlayer : NetworkBehaviour {

    Dictionary<ScriptPhaseTransition, GameState> allTransitions; //a dictionary of phase transitions
    Dictionary<string, StateCommands> enumParse;

    [SerializeField]
    public GameState CurrentState { get; private set; } //the current state of the game
    public GameState PreviousState { get; private set; } //the previous state of the game

    public ScriptGameManager gameManager;

    #region Player Variables
    public int wood { get; set; }
    public int wool { get; set; }
    public int brick { get; set; }
    public int grain { get; set; }

    [SyncVar]
    int serverWood;
    [SyncVar]
    int serverWool;
    [SyncVar]
    int serverBrick;
    [SyncVar]
    int serverGrain;

    Text PhaseText;
    Text grainAmount;
    Text brickAmount;
    Text woodAmount;
    Text woolAmount;

    public List<GameObject> settlements;
    public List<GameObject> roads;
    public int numSettlements { get; set; }
    #endregion

    #region Phase 2 Variables
    GameObject tradeWindowButton;
    #endregion

    #region Phase 3 Variables
    [Header("Phase 3")]
    GameObject BuildPhaseMenu;
    GameObject BuildSettlementButton; //build settlement button
    GameObject BuildRoadButton; //build road button
    #endregion

    #region Network Variables
    public string playerName;
    [SyncVar]
    public bool endTurn = false;
    Time time;

    #endregion


    [HideInInspector]
    public Queue<string> playerActions;

    //Mike Dobson & Andrew Seba Engine collaberation from here down unless otherwise noted
    void Start()
    {

        if (isLocalPlayer)
        {
            gameManager = GameObject.Find("GameManager").GetComponent<ScriptGameManager>();

            if (isLocalPlayer)
            {
                gameManager.localPlayer = this.GetComponent<ScriptPlayer>();
            }

            // Craig
            if (gameManager.restartedGame)
		    {
			    // load player data from the saved game data using the player's name (public string playerName)
		    }
            else
            {
                wood = 0;
                wool = 0;
                brick = 0;
                grain = 0;
                numSettlements = 0;

                settlements = new List<GameObject>();
                roads = new List<GameObject>();
                playerActions = new Queue<string>();

            }



            try
            {
                BuildPhaseMenu = GameObject.Find("Panel_BuildMenu");


                if (BuildPhaseMenu != null) {
                    BuildSettlementButton = GameObject.Find("Button_BuildSettlement");
                    BuildRoadButton = GameObject.Find("Button_BuildRoad");
                    
                    BuildPhaseMenu.SetActive(false);
                }
                else
                {
                    Debug.Log("Panel_BuildMenu can't be found. Please re-enable in scene before running.");
                }

                tradeWindowButton = GameObject.Find("Button_OpenTradeWindow");

                if(tradeWindowButton != null)
                {
                    tradeWindowButton.SetActive(false);
                }
                else
                {
                    Debug.LogError("Button_OpenTradeWindow can't be found. Please re-enable in hierarchy before running.");
                }


                PhaseText = GameObject.Find("Text_CurPhase").GetComponent<Text>();
                grainAmount = GameObject.Find("Text_GrainAmount").GetComponent<Text>();
                brickAmount = GameObject.Find("Text_BrickAmount").GetComponent<Text>();
                woodAmount = GameObject.Find("Text_WoodAmount").GetComponent<Text>();
                woolAmount = GameObject.Find("Text_WoolAmount").GetComponent<Text>();
            }
            catch
            {
                Debug.Log("no gui object found in scene.");
            }

        }

        CurrentState = GameState.PHASE0;

        //setup the previous state
        PreviousState = GameState.PHASE0;

        //create the dictionary
        allTransitions = new Dictionary<ScriptPhaseTransition, GameState>
        {
            //Defines the state transitions where
            //{new ScriptPhaseTransition(actual state of the machine, transition state/command), final state of the machine)}
            {new ScriptPhaseTransition(GameState.PHASE0, StateCommands.GOTO_PHASE5), GameState.PHASE5 },
            {new ScriptPhaseTransition(GameState.PHASE1, StateCommands.GOTO_PHASE2), GameState.PHASE2 },
            {new ScriptPhaseTransition(GameState.PHASE2, StateCommands.GOTO_PHASE3), GameState.PHASE3 },
            {new ScriptPhaseTransition(GameState.PHASE3, StateCommands.GOTO_PHASE4), GameState.PHASE4 },
            {new ScriptPhaseTransition(GameState.PHASE4, StateCommands.GOTO_PHASE2), GameState.PHASE2 },
            {new ScriptPhaseTransition(GameState.PHASE4, StateCommands.GOTO_PHASE3), GameState.PHASE3 },
            {new ScriptPhaseTransition(GameState.PHASE4, StateCommands.GOTO_PHASE5), GameState.PHASE5 },
            {new ScriptPhaseTransition(GameState.PHASE5, StateCommands.GOTO_PHASE1), GameState.PHASE1 },
            {new ScriptPhaseTransition(GameState.PHASE5, StateCommands.GOTO_PHASE6), GameState.PHASE6 }
        };

        //Create the dictionary where
        //{string that is passed by the button, command the string represents
        enumParse = new Dictionary<string, StateCommands>
        {
            {"goto phase 0", StateCommands.GOTO_PHASE0},
            {"goto phase 1", StateCommands.GOTO_PHASE1},
            {"goto phase 2", StateCommands.GOTO_PHASE2},
            {"goto phase 3", StateCommands.GOTO_PHASE3},
            {"goto phase 4", StateCommands.GOTO_PHASE4},
            {"goto phase 5", StateCommands.GOTO_PHASE5},
            {"goto phase 6", StateCommands.GOTO_PHASE6},
            {"quit application", StateCommands.QUIT_APPLICATION}
        };

        Debug.Log("Current state: " + CurrentState);
        //Phase0();
    }

    //void Update()
    //{ 
    //    //Cheat codes
    //#if UNITY_EDITOR
    //    if (Input.GetKeyDown("1"))
    //    {
    //        grain++;
    //    }
    //    if (Input.GetKeyDown("2"))
    //    {
    //        brick++;
    //    }
    //    if (Input.GetKeyDown("3"))
    //    {
    //        wood++;
    //    }
    //    if (Input.GetKeyDown("4"))
    //    {
    //        wool++;
    //    }
    //#endif
    //}

    #region Player Methods
    public void GainResources(int diceRoll)
    {
        foreach (GameObject settlement in settlements)
        {
            settlement.GetComponent<ScriptBoardCorner>().GainResources(diceRoll);
        }
    }

    public void AddAction(string pAction)
    {
        Debug.Log(pAction);
        //playerActions.Add(pAction);
    }

    public void ChangeGrain(int pAmount)
    {
        grain += pAmount;
        UpdateResourceText();
    }

    public void ChangeBrick(int pAmount)
    {
        brick += pAmount;
        UpdateResourceText();
    }

    public void ChangeWood(int pAmount)
    {
        wood += pAmount;
        UpdateResourceText();
    }

    public void ChangeWool(int pAmount)
    {
        wool += pAmount;
        UpdateResourceText();
    }

    void UpdateResourceText()
    {
        try
        {
            grainAmount.text = grain.ToString();
            brickAmount.text = brick.ToString();
            woodAmount.text = wood.ToString();
            woolAmount.text = wool.ToString();
        }
        catch
        {
            Debug.LogError("No Text to update resources.");
        }

    }
    #endregion

    #region Common Class Methods

    /// <summary>
    /// @Author: Andrew Seba
    /// @Description: Takes the current phase and calls the transition engine.
    /// Button should only be available if done with phase.
    /// </summary>
    public void _NextPhaseButton()
    {
        switch (CurrentState)
        {
            case GameState.PHASE0:
                MoveNextAndTransition("goto phase 5");
                break;
            case GameState.PHASE1:
                MoveNextAndTransition("goto phase 2");
                break;
            case GameState.PHASE2:
                MoveNextAndTransition("goto phase 3");
                break;
            case GameState.PHASE3:
                MoveNextAndTransition("goto phase 4");
                break;
            case GameState.PHASE4:
                break;
            case GameState.PHASE5:
                break;
        }
    }

    public void LoadTransition(GameState state, string command)
    {
        CurrentState = state;
        switch (state)
        {
            case GameState.PHASE1:
                PreviousState = GameState.PHASE5;
                //phase1menu.SetActive(true);
                break;
            case GameState.PHASE2:
                PreviousState = GameState.PHASE1;
                MoveNextAndTransition(command);
                break;
            case GameState.PHASE3:
                PreviousState = GameState.PHASE2;
                MoveNextAndTransition(command);
                break;
            case GameState.PHASE4:
                PreviousState = GameState.PHASE3;
                MoveNextAndTransition(command);
                break;
        }
    }


    void PhaseTextTransition()
    {
        if (PhaseText != null)
        {
            switch (CurrentState)
            {
                case GameState.PHASE0:
                    PhaseText.text = "Setup Phase";
                    break;
                case GameState.PHASE1:
                    PhaseText.text = "Rolling Dice";
                    break;
                case GameState.PHASE2:
                    PhaseText.text = "Trade";
                    break;
                case GameState.PHASE3:
                    PhaseText.text = "Build";
                    break;
                case GameState.PHASE4:
                    PhaseText.text = "End Turn";
                    break;
                case GameState.PHASE5:
                    PhaseText.text = "Processing";
                    break;
                case GameState.PHASE6:
                    PhaseText.text = "Winner is:";
                    break;
                default:
                    PhaseText.text = "Current Phase Text";
                    break;
            }
        }
        else
        {
            //throw new UnityException("No Phase text in Engine");
            Debug.Log("No Phase text in Engine.");
        }
    }

    GameState GetNext(StateCommands command)
    {
        //construct transition based on machine current state and the command
        ScriptPhaseTransition newTransition = new ScriptPhaseTransition(CurrentState, command);

        //store the location to got to here
        GameState newState;

        if (!allTransitions.TryGetValue(newTransition, out newState))
            throw new UnityException("Invalid Game State transition " + CurrentState + " -> " + command);

        //return the new state
        return newState;
    }

    public void MoveNextAndTransition(string command)
    {
        //record the previous state of the machine
        PreviousState = CurrentState;

        //location for the new command
        StateCommands newCommand;

        //try to get the value of the command
        if (!enumParse.TryGetValue(command, out newCommand))
            throw new UnityException("Invalid command  -> " + command);

        //setup the new state
        CurrentState = GetNext(newCommand);

        Debug.Log("Transitioning from " + PreviousState + " -> " + CurrentState);
        //transition the game to the next state

        Transition();

    }



    public void Transition()
    {
        switch (PreviousState)
        {
            case GameState.PHASE0:
                Phase5();
                break;
            case GameState.PHASE1:
                tradeWindowButton.SetActive(true);
                Phase2();
                break;
            case GameState.PHASE2:
                tradeWindowButton.SetActive(false);
                Phase3();
                break;
            case GameState.PHASE3:
                BuildPhaseMenu.SetActive(true);
                Phase4();
                break;
            case GameState.PHASE4:
                //phase4menu.SetActive(false);
                Phase5();
                break;
            case GameState.PHASE5:
                if (CurrentState == GameState.PHASE1)
                {
                    //phase1menu.SetActive(true);
                    Phase1();
                }
                else
                {
                    //Phase6(winningPlayerNumber);//TODO
                }
                break;
        }
    }
    #endregion

    #region Phase 0
    public void Phase0()
    {
        time = new Time();
        PhaseTextTransition();
        Debug.Log("Entering Phase 0");
        StartCoroutine("StartGame");
    }


    IEnumerator StartGame()
    {
        yield return StartCoroutine("GetSettlement");
        yield return StartCoroutine("GetRoad");
        gameManager.nextPhaseButton.SetActive(true);
        MoveNextAndTransition("goto phase 5");
        //phase0button.SetActive(true);
    }

    IEnumerator GetSettlement()
    {
        while (true)
        {
            foreach (GameObject settlement in GameObject.FindGameObjectsWithTag("Settlement"))
            {
                if(settlement.GetComponent<ScriptBoardCorner>().owner == null)
                {
                    settlement.GetComponent<Renderer>().material.color = Color.clear;
                }

            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Settlement")
                {
                    if(hit.transform.GetComponent<ScriptBoardCorner>().owner == null)
                    {
                        hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;

                        if (Input.GetMouseButtonDown(0))
                        {
                            GameObject settlement = hit.transform.gameObject;
                            settlement.GetComponent<ScriptBoardCorner>().owner = this;
                            settlements.Add(settlement);//Andrew Seba
                            AddAction(playerName + "," + time + ",settlement,"
                                + settlement.transform.position.x +
                                "," + settlement.transform.position.y +
                                "," + settlement.transform.position.z);
                            break;
                        }
                    }

                }
            }
            yield return null;
        }
    }

    IEnumerator GetRoad()
    {
        while (true)
        {
            foreach (GameObject road in GameObject.FindGameObjectsWithTag("Road"))
            {
                if(road.GetComponent<ScriptBoardEdge>().owner == null)
                {
                    road.GetComponent<Renderer>().material.color = Color.clear;
                }
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Road")
                {
                    hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (hit.transform.GetComponent<ScriptBoardEdge>().CheckStartRoad(this.gameObject))
                        {
                            hit.transform.GetComponent<ScriptBoardEdge>().owner = this;
                            roads.Add(hit.transform.gameObject);//Andrew Seba

                            break;
                        }
                    }
                }
            }
            yield return null;
        }
    }
    #endregion

    #region Phase 1
    void Phase1()
    {
        Debug.Log("Entered Phase 1");
        PhaseTextTransition();

        int diceRoll = Random.Range(1, 6);
        Debug.Log("Dice Roll " + diceRoll);
        Debug.Log("Checking Settlements");
        this.GainResources(diceRoll);
        
    }
    #endregion

    #region Phase 2
    void Phase2()
    {
        Debug.Log("Entered Phase 2");
        PhaseTextTransition();
    }
    #endregion

    #region Phase 3
    void Phase3()//Stopped in here.
    {
        Debug.Log("Entered Phase 3");
        PhaseTextTransition();
        
        BuildPhaseMenu.SetActive(true);
        DisplayRoadButton();
        DisplaySettlementButton();
    }

    void DisplaySettlementButton()
    {
        if (brick >= 1 && wood >= 1 && grain >= 1 && wool >= 1)
        {
            BuildSettlementButton.GetComponent<Button>().interactable = true;
        }
        else//andrew Seba
        {
            BuildSettlementButton.GetComponent<Button>().interactable = false;
        }
    }

    IEnumerator BuySettlement()
    {
        while (true)
        {

            //Andrew Seba
            foreach (GameObject settlement in GameObject.FindGameObjectsWithTag("Settlement"))
            {
                if(settlement.GetComponent<ScriptBoardCorner>().owner == null)
                {
                    settlement.GetComponent<Renderer>().material.color = Color.clear;
                }
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Settlement")
                {
                    if (hit.transform.GetComponent<ScriptBoardCorner>().owner == null)
                    { 

                        hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;

                        if (Input.GetMouseButtonDown(0))
                        {
                            if (hit.transform.GetComponent<ScriptBoardCorner>().CheckValidBuild(this.gameObject))
                            {
                                Debug.Log("Valid Settlement Placement");
                                ChangeBrick(-1);
                                ChangeWood(-1);
                                ChangeGrain(-1);
                                ChangeWool(-1);

                                DisplayRoadButton();
                                DisplaySettlementButton();

                                //Add to player and remove from empty list //andrew seba
                                hit.transform.GetComponent<ScriptBoardCorner>().owner = this;
                                settlements.Add(hit.transform.gameObject);//Andrew Seba
                                AddAction(playerName + "," + time + ",settlement,"
                                    + hit.transform.position.x +
                                    "," + hit.transform.position.y +
                                    "," + hit.transform.position.z);
                                break;
                            }
                            else
                            {
                                Debug.Log("Invalid Settlement Placement");
                                //break;
                            }
                        }
                    }
                }
            }
            yield return null;
        }


    }

    void DisplayRoadButton()
    {
        if (brick >= 1 && wood >= 1)
        {
            BuildRoadButton.GetComponent<Button>().interactable = true;
        }
        else//Andrew Seba
        {
            BuildRoadButton.GetComponent<Button>().interactable = false;
        }
    }

    IEnumerator BuyRoad()
    {
        while (true)
        {

            foreach (GameObject road in GameObject.FindGameObjectsWithTag("Road"))
            {
                if(road.GetComponent<ScriptBoardEdge>().owner == null)
                {
                    road.GetComponent<Renderer>().material.color = Color.clear;
                }
                
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Road")
                {
                    GameObject selectedRoad = hit.collider.gameObject;
                    selectedRoad.GetComponent<Renderer>().material.color = Color.yellow;

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (selectedRoad.GetComponent<ScriptBoardEdge>().CheckValidBuild(this.gameObject))
                        {
                            Debug.Log("Valid Road Placement");
                            ChangeBrick(-1);
                            ChangeWood(-1);
                            DisplayRoadButton();
                            DisplaySettlementButton();

                            //Andrew Seba
                            selectedRoad.GetComponent<ScriptBoardEdge>().owner = this;
                            roads.Add(hit.transform.gameObject);
                            //end Andrew Seba
                            break;
                        }
                        else
                        {
                            Debug.Log("Invalid Road Placement");
                            //break;
                        }
                    }
                }
            }
            yield return null;
        }


    }
    #endregion

    #region Phase 4
    void Phase4()
    {
        Debug.Log("Entering Phase 4");

        BuildPhaseMenu.SetActive(false);
        gameManager.endTurnToggle.SetActive(true);
        PhaseTextTransition();
        //ResourcesText();
        //StartCoroutine("CheckForEndTurn");


    }

    public void ReturnToTrade()
    {
        StopCoroutine("CheckForEndTurn");
        endTurn = false;
        MoveNextAndTransition("goto phase 2");
    }

    public void ReturnToBuild()
    {
        StopCoroutine("CheckForEndTurn");
        endTurn = false;
        MoveNextAndTransition("goto phase 3");
    }

    public void EndTurn()
    {
        endTurn = true;
    }
    #endregion

    #region Phase 5
    public void Phase5()
    {
        Debug.Log("Entered Phase 5");

        //Disable toggle
        gameManager.endTurnToggle.SetActive(false);//andrew seba

        PhaseTextTransition();
        while(playerActions.Count > 0)
        {
            CmdSendActions(playerActions.Dequeue());
        }
        MoveNextAndTransition("goto phase 1");
    }

    [Command]
    void CmdSendActions(string action)
    {
        char seperator = ',';
        string[] parse = action.Split(seperator);
        switch(parse[0])
        {
            case "p1":
                GainResources(System.Convert.ToInt32(parse[1]));
                break;
            case "p2":
                break;
            case "p3":
                GameObject[] tempArray;
                switch(parse[2])
                {
                    case "settlement":
                        tempArray = GameObject.FindGameObjectsWithTag("Settlement");
                        foreach(GameObject settlement in tempArray)
                        {
                            if(settlement.transform.position.x == System.Convert.ToInt32(parse[3]) &&
                                settlement.transform.position.y == System.Convert.ToInt32(parse[4]) &&
                                settlement.transform.position.z == System.Convert.ToInt32(parse[5]))
                            {
                                float tempTime = System.Convert.ToSingle(parse[1]);
                                if(settlement.GetComponent<ScriptBoardCorner>().time < tempTime)
                                {
                                    settlement.GetComponent<ScriptBoardCorner>().owner = this;
                                }
                            }
                        }
                        break;
                    case "road":
                        tempArray = GameObject.FindGameObjectsWithTag("Road");
                        foreach(GameObject road in tempArray)
                        {
                            if (road.transform.position.x == System.Convert.ToInt32(parse[3]) &&
                                road.transform.position.y == System.Convert.ToInt32(parse[4]) &&
                                road.transform.position.z == System.Convert.ToInt32(parse[5]))
                            {
                                float tempTime = System.Convert.ToSingle(parse[1]);
                                if(road.GetComponent<ScriptBoardEdge>().time < tempTime)
                                {
                                    road.GetComponent<ScriptBoardEdge>().owner = this;
                                }
                            }
                        }
                        break;
                }
                break;
        }
    }
    #endregion

    #region Phase 6
    void Phase6(int player)
    {
        Debug.Log("Entering Phase 6 (End Game)");
        //WinnerText.text = ("Winner: " + players[player].playerName);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
    #endregion

	// @author: Craig Broskow
	public void SetCurrentState(GameState newGameState) // Craig
	{
		PreviousState = CurrentState;
		CurrentState = newGameState;
	} // end method SetCurrentState
}
