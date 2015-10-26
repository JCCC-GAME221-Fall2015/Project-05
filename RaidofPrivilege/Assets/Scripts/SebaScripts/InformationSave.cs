using UnityEngine;
using System; // Craig
using System.Collections; // Craig
using System.IO;
using System.Collections.Generic;

/// <summary>
/// @Author: Andrew Seba
/// @Description: takes the player and level name and writes it to a file under
/// Assets/save_data/"levelName"/gameinformation.txt
/// 
/// </summary>
public class InformationSave : MonoBehaviour {

	string userName = null;
	string levelName = null;
	string txtInfoLocation;
	string outputFile = "/gameinformation.txt";

	// Craig
	private FileInfo sourceFile = null;
	private StreamReader reader = null;
	
	public string UserName
	{
		set
		{
			userName = value;
		}
		get
		{
			return UserName;
		}
	}

	public string LevelName
	{
		set
		{
			levelName = value;
		}
		get
		{
			return levelName;
		}
	}

	void Start()
	{
		DontDestroyOnLoad(gameObject);
//		LoadGame("CraigsGame"); // Craig
	}

	/// <summary>
	/// Takes the level name and makes a new folder.
	/// Creates a gameinformation.txt file and writes the user name and level name.
	/// </summary>
	public void _InitFile()
	{
		txtInfoLocation = Application.dataPath + "/save_data/" + levelName;
		StreamWriter writer = null;


		//Check to see if both things have been entered as a safety.
		if (userName != null && levelName != null)
		{
			if (!Directory.Exists(txtInfoLocation))
			{
				Directory.CreateDirectory(
					Application.dataPath + "/save_data/" + levelName);

			}


			//gameinformation.txt
			//UserName
			//LevelName
			using (writer = new StreamWriter(txtInfoLocation + outputFile))
			{
				writer.WriteLine(userName);
				writer.WriteLine(levelName);
				
			}
			writer.Close();
		}
		else
		{
			Debug.Log("Either name or level name haven't been entered." +
				"\nThis is required.");
		}

	}

	/*SaveFile Looks like
    UserName
    LevelName
    CurrentPhase
    WoodAmount
    WoolAmount
    BrickAmount
    GrainAmount
    Buildings And roads arrays
    
    */
	public void SaveGame()
	{
		ScriptPlayer playerData = GameObject.Find("SceneManager").GetComponent<ScriptPlayer>();
		
		StreamWriter writer = null;
		using (writer = new StreamWriter(txtInfoLocation + outputFile))
		{
			writer.WriteLine(userName);
			writer.WriteLine(levelName);
			
			writer.WriteLine(playerData.CurrentState);
			
			writer.WriteLine(playerData.wood);
			writer.WriteLine(playerData.wool);
			writer.WriteLine(playerData.brick);
			writer.WriteLine(playerData.grain);
			
			
			//Write building info.TODO
			
			//write actions
			foreach(string action in playerData.playerActions)
			{
				writer.WriteLine(action);
			}
		}
		writer.Close();
    }

	/* New SaveFile Looks like
	Starts with a Player line:
		PN=Craig#LN=CraigsGame#CP=GAMESTART#WD=0#WL=0#BR=0#GR=0#
	That's followed by one line for every Hex in the map:
		HN=Hex (4)#HP=(0.0, -1.0, 0.0)#DN=0#RT=3#
	Those are followed by Road lines in the map (probably owned by the Player):
		RN=Road#RP=(0.4, -1.2, 0.0)#RO=None#
	Those are followed by Settlement lines in the map (probably owned by the Player):
		SN=Settlement#SP=(-0.5, -0.3, 0.0)#SR=(0.7, 0.0, 0.0, 0.7)#SO=None#
    */
	
	// @author: Craig Broskow
	public void SaveGame3()
	{
		string outputString;
		ScriptGameManager gameManagerScript = GameObject.Find("GameManager").GetComponent<ScriptGameManager>();
		GameObject[] hexes;
		GameObject[] roads;
		GameObject[] settlements;

		StreamWriter writer = null;
		using (writer = new StreamWriter(txtInfoLocation + outputFile))
		{
			foreach(ScriptPlayer player in gameManagerScript.players)
	        {
				outputString = "PN=" + player.playerName.ToString() +
					"#LN=" + player.playerName.ToString() +
					"#CP=" + player.CurrentState.ToString() +
					"#WD=" + player.wood.ToString() +
					"#WL=" + player.wool.ToString() +
					"#BR=" + player.brick.ToString() +
					"#GR=" + player.grain.ToString() + "#";
				writer.WriteLine(outputString);
        	}

			hexes = GameObject.FindGameObjectsWithTag("Hex");
			
			for (int i = 0; i < hexes.Length; i++)
			{
				outputString = "HN=" + hexes[i].name.ToString() +
					"#HP=" + hexes[i].transform.position.ToString() +
						"#DN=" + hexes[i].GetComponent<ScriptBoardHex>().hexDieValue.ToString() +
						"#RT=" + ((int)(hexes[i].GetComponent<ScriptBoardHex>().resource)).ToString() +
						"#";
				writer.WriteLine(outputString);
			}
			
			roads = GameObject.FindGameObjectsWithTag("Road");
			
			for (int i = 0; i < roads.Length; i++)
			{
				if (roads[i].GetComponent<ScriptBoardEdge>().owner == null)
				{
					outputString = "RN=" + roads[i].name.ToString() +
						"#RP=" + roads[i].transform.position.ToString() +
							"#RO=None#";
				}
				else
				{
					outputString = "RN=" + roads[i].name.ToString() +
						"#RP=" + roads[i].transform.position.ToString() +
							"#RO=" + roads[i].GetComponent<ScriptBoardEdge>().owner.playerName.ToString() +
							"#";
				}
				writer.WriteLine(outputString);
			}
			
			settlements = GameObject.FindGameObjectsWithTag("Settlement");
			
			for (int i = 0; i < settlements.Length; i++)
			{
				if (settlements[i].GetComponent<ScriptBoardCorner>().owner == null)
				{
					outputString = "SN=" + settlements[i].name.ToString() +
						"#SP=" + settlements[i].transform.position.ToString() +
							"#SR=" + settlements[i].transform.rotation.ToString() +
							"#SO=None#";
				}
				else
				{
					outputString = "SN=" + settlements[i].name.ToString() +
						"#SP=" + settlements[i].transform.position.ToString() +
							"#SR=" + settlements[i].transform.rotation.ToString() +
							"#SO=" + settlements[i].GetComponent<ScriptBoardCorner>().owner.playerName.ToString() +
							"#";
				}
				writer.WriteLine(outputString);
			}
		}
		writer.Close();
	} // end method SaveGame3

	// @author: Craig Broskow
	public bool LoadGame(string pLevelName)
	{
		string outputString;
		char[] delimiterChars = { '#', '=' };
		char[] charsToTrim = { '(', ')' };
		List<string> inputLines;
		ScriptGameManager gameManagerScript = GameObject.Find("GameManager").GetComponent<ScriptGameManager>();
		GameObject[] hexes;
		GameObject[] roads;
		GameObject[] settlements;

		if ((pLevelName == null) || (pLevelName == ""))
		{
			pLevelName = levelName;
		}
		txtInfoLocation = Application.dataPath + "/save_data/" + pLevelName;
		
		if (!SavedGameExists())
		{
			Debug.Log("The saved game file cannot be found!");
			return false;
		}
		
		try
		{
			if (!sourceFile.Exists)
			{
				return false;
			}
			if (sourceFile != null && sourceFile.Exists)
				reader = sourceFile.OpenText();
			if (reader == null)
			{
				Debug.Log ("Saved game stream reader is null!");
				return false;
			}
			else
			{
				hexes = GameObject.FindGameObjectsWithTag("Hex");
				roads = GameObject.FindGameObjectsWithTag("Road");
				settlements = GameObject.FindGameObjectsWithTag("Settlement");
				
				inputLines = new List<string>();
				string inputLine;
				while((inputLine = reader.ReadLine()) != null)
				{
					inputLines.Add(inputLine);
				}
				reader.Close();
				
				foreach (string currentLine in inputLines)
				{
					string[] paramArray = currentLine.Split(delimiterChars);
					if (paramArray[0] == "PN")
					{
						string playerName = paramArray[1].ToString();
						foreach(ScriptPlayer player in gameManagerScript.players)
						{
							if (player.playerName.ToString() == playerName)
							{
								for (int i = 2; i < paramArray.Length - 1; i = i + 2)
								{
									switch (paramArray[i])
									{
										case "CP":
											switch (paramArray[i + 1].ToString())
											{
												case "PHASE0":
													player.SetCurrentState(GameState.PHASE0);
													break;
												case "PHASE1":
													player.SetCurrentState(GameState.PHASE1);
													break;
												case "PHASE2":
													player.SetCurrentState(GameState.PHASE2);
													break;
												case "PHASE3":
													player.SetCurrentState(GameState.PHASE3);
													break;
												case "PHASE4":
													player.SetCurrentState(GameState.PHASE4);
													break;
												case "PHASE5":
													player.SetCurrentState(GameState.PHASE5);
													break;
												case "PHASE6":
													player.SetCurrentState(GameState.PHASE6);
													break;
												default:
													player.SetCurrentState(GameState.PHASE0);
													break;
											}
											break;
										case "WD":
											player.wood = Convert.ToInt32(paramArray[i + 1]);
											break;
										case "WL":
											player.wool = Convert.ToInt32(paramArray[i + 1]);
											break;
										case "BR":
											player.brick = Convert.ToInt32(paramArray[i + 1]);
											break;
										case "GR":
											player.grain = Convert.ToInt32(paramArray[i + 1]);
											break;
										default:
											Debug.Log ("The saved game file contains an unknown Player parameter: " + paramArray[i]);
											break;
									} // end switch (paramArray[i])...
								} // end for (int i = 2; i < paramArray.Length - 1; i = i + 2)...
							} // end if (player.playerName.ToString() == playerName)...
						} // end foreach(ScriptPlayer player in gameManagerScript.players)...
					} // end if (paramArray[0] == "PN")...

					if (paramArray[0] == "HN")
					{
						string hexName = paramArray[1].ToString();
						for (int j = 0; j < hexes.Length; j++)
						{
							if (hexes[j].name.ToString() == hexName)
							{
								for (int i = 2; i < paramArray.Length - 1; i = i + 2)
								{
									switch (paramArray[i])
									{
										case "DN":
											hexes[j].GetComponent<ScriptBoardHex>().hexDieValue = Convert.ToInt32(paramArray[i + 1]);
											break;
										case "RT":
											switch (Convert.ToInt32(paramArray[i + 1]))
											{
												case 0:
													hexes[j].GetComponent<ScriptBoardHex>().resource = HexType.WOOD;
													break;
												case 1:
													hexes[j].GetComponent<ScriptBoardHex>().resource = HexType.GRAIN;
													break;
												case 2:
													hexes[j].GetComponent<ScriptBoardHex>().resource = HexType.BRICK;
													break;
												default:
													hexes[j].GetComponent<ScriptBoardHex>().resource = HexType.WOOL;
													break;
											}
//											Debug.Log("Resource Type: " + hexes[j].GetComponent<ScriptBoardHex>().resource.ToString());
											break;
										default:
											Debug.Log ("The saved game file contains an unknown Hex parameter: " + paramArray[i]);
											break;
									} // end switch (paramArray[i])...
								} // end for (int i = 2; i < paramArray.Length - 1; i = i + 2)...
							} // end if (hexes[j].name.ToString() == hexName)...
						} // end for (int j = 0; j < hexes.Length; j++)...
					} // end if (paramArray[0] == "HN")...
					
					if (paramArray[0] == "RN")
					{
						string posString = paramArray[3].Trim(charsToTrim);
						string[] posArray = posString.Split(',');
						Vector3 roadPosition = new Vector3(Convert.ToSingle(posArray[0]),
							Convert.ToSingle(posArray[1]), Convert.ToSingle(posArray[2]));
						for (int i = 0; i < roads.Length; i++)
						{
							if (roads[i].transform.position == roadPosition)
							{
								Debug.Log("Found Road named: " + roads[i].name.ToString());
							}
						}
					} // end if (paramArray[0] == "RN")...
					
					if (paramArray[0] == "SN")
					{
						string posString = paramArray[3].Trim(charsToTrim);
						string[] posArray = posString.Split(',');
						Vector3 settPosition = new Vector3(Convert.ToSingle(posArray[0]),
							Convert.ToSingle(posArray[1]), Convert.ToSingle(posArray[2]));
						for (int i = 0; i < settlements.Length; i++)
						{
							if (settlements[i].transform.position == settPosition)
							{
								Debug.Log("Found Settlement named: " + settlements[i].name.ToString());
							}
						}
					} // end if (paramArray[0] == "SN")...
				} // end foreach (string currentLine in inputLines)...
			} // end if (reader == null)...else...
			return true;
		}
		catch (Exception e)
		{
			Debug.Log("InformationSave.LoadGame() threw an exception!");
			Debug.Log("Exception Message: " + e.Message);
			return false;
		}
	} // end method LoadGame
	
	// @author: Craig Broskow
	private void ListPlayers()
	{
		string outputString;
		ScriptGameManager gameManagerScript = GameObject.Find("GameManager").GetComponent<ScriptGameManager>();

		if (userName != null)
			Debug.Log("User Name: " + userName.ToString());
		Debug.Log("List of instantiated players: ");
		foreach(ScriptPlayer player in gameManagerScript.players)
		{
			outputString = "PN=" + player.playerName.ToString() +
				" CP=" + player.CurrentState.ToString() +
				" WD=" + player.wood.ToString() +
				" WL=" + player.wool.ToString() +
				" BR=" + player.brick.ToString() +
				" GR=" + player.grain.ToString();
			Debug.Log(outputString);
		}
	} // end method ListPlayers
	
	// @author: Craig Broskow
	private bool SavedGameExists()
	{
		string filePath = txtInfoLocation + outputFile;
		
		try
		{
			sourceFile = new FileInfo(filePath);
			return (sourceFile.Exists);
		}
		catch (Exception e)
		{
			Debug.Log("InformationSave.SavedGameExists() threw an exception!");
			Debug.Log("Exception Message: " + e.Message);
			return false;
		}
	} // end method SavedGameExists
} // end class InformationSave
