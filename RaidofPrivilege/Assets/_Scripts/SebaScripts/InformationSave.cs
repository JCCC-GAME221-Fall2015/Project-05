using UnityEngine;
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
		PlayerData playerData = GameObject.Find("SceneManager").GetComponent<PlayerData>();

		StreamWriter writer = null;
		using (writer = new StreamWriter(txtInfoLocation + outputFile))
		{
			writer.WriteLine(userName);
			writer.WriteLine(levelName);

			writer.WriteLine(playerData.curPhase);

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
+	Starts with a Player line:
+		PN=Craig#LN=CraigsGame#CP=GAMESTART#WD=0#WL=0#BR=0#GR=0#
+	That's followed by one line for every Hex in the map:
+		HN=Hex (4)#HP=(0.0, -1.0, 0.0)#DN=0#RT=3#
+	Those are followed by Road lines in the map (probably owned by the Player):
+		RN=Road#RP=(0.4, -1.2, 0.0)#RO=None#
+	Those are followed by Settlement lines in the map (probably owned by the Player):
+		SN=Settlement#SP=(-0.5, -0.3, 0.0)#SR=(0.7, 0.0, 0.0, 0.7)#SO=None#
+    */
	public void SaveGame2() // Craig
	{
		string outputString;
		PlayerData playerData = GameObject.Find("SceneManager").GetComponent<PlayerData>();
		GameObject[] hexes;
		GameObject[] roads;
		GameObject[] settlements;

		StreamWriter writer = null;
		using (writer = new StreamWriter(txtInfoLocation + outputFile))
		{
			outputString = "PN=" + userName.ToString() +
				"#LN=" + levelName.ToString() +
				"#CP=" + playerData.curPhase.ToString() +
				"#WD=" + playerData.wood.ToString() +
				"#WL=" + playerData.wool.ToString() +
				"#BR=" + playerData.brick.ToString() +
				"#GR=" + playerData.grain.ToString() + "#";
			writer.WriteLine(outputString);

			hexes = GameObject.FindGameObjectsWithTag("Hex");
			for (int i = 0; i<hexes.Length; i++)
			{
				outputString = "HN=" + hexes[i].name.ToString() +
					"#HP=" + hexes[i].transform.position.ToString() +
						"#DN=" + hexes[i].GetComponent<ScriptBoardHex>().hexDieValue.ToString() +
						"#RT=" + ((int)(hexes[i].GetComponent<ScriptBoardHex>().resource)).ToString() +
						"#";
				writer.WriteLine(outputString);
			}
			
			roads = GameObject.FindGameObjectsWithTag("Road");
			for (int i = 0; i<roads.Length; i++)
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
							"#RO=" + roads[i].GetComponent<ScriptBoardEdge>().owner.PlayerName.ToString() +
							"#";
				}
				writer.WriteLine(outputString);
			}
			
			settlements = GameObject.FindGameObjectsWithTag("Settlement");
			for (int i = 0; i<settlements.Length; i++)
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
							"#SO=" + settlements[i].GetComponent<ScriptBoardCorner>().owner.PlayerName.ToString() +
							"#";
				}
				writer.WriteLine(outputString);
			}

			//write actions
//			foreach(string action in playerData.playerActions)
//			{
//				writer.WriteLine(action);
//			}
		}
		writer.Close();
	} // end method SaveGame2
}
