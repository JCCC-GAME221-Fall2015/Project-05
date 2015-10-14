using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public enum Phases
{
	GAMESTART,//One time go.
	ROLL,
	TRADE,//Extra Credit.
	BUILD,
	PROCESS,//For furture use.
	ENDGAME
}


/// <summary>
/// @Author: Andrew Seba
/// @Description: Controls phases of the game.
/// </summary>
public class CatanPhases : MonoBehaviour {

	Text textCurPhase;
	Text textNextPhase;

	Phases phase;
	int turnNumber = 0;
	int curPhaseIndex = 0;

	//This will restart the curPhaseIndex to 0 when you reach this num.
	const int ROTATE = 6;


	//Stops the UpdateText from throwing errors if theres no text gui in the scene.
	[HideInInspector]
	public bool textEnabled = true;

	void Start()
	{
		try
		{
			textCurPhase = GameObject.Find("Text_CurPhase").GetComponent<Text>();
			textNextPhase = GameObject.Find("Text_NextPhase").GetComponent<Text>();
		}
		catch
		{
			textEnabled = false;
		}

		curPhaseIndex = (int)Convert.ChangeType(phase, phase.GetTypeCode());

		UpdateText();
	}

	/// <summary>
	/// @Author: Andrew Seba
	/// Increments the phase to next ENUM;
	/// </summary>
	public void NextPhase()
	{

		curPhaseIndex = (curPhaseIndex + 1) % ROTATE;
		phase = (Phases)curPhaseIndex;

		switch (phase)
		{
			case (Phases.GAMESTART):
				if(turnNumber > 0)
				{
					//skip phase
					SetPhase("ROLL");
					break;
				}


				break;
			case (Phases.ROLL):
				break;
			case (Phases.TRADE):
				break;
			case (Phases.BUILD):
				break;
			case (Phases.PROCESS):
				break;
			case (Phases.ENDGAME):
				turnNumber++;
				break;
		}

		UpdateText();
	}

    /// <summary>
    /// Uses the string parameter to Set phase directly.
    /// </summary>
    /// <param name="pPhase"></param>
	public void SetPhase(string pPhase)
	{
		pPhase = pPhase.ToUpper();
		switch (pPhase)
		{
			case ("GAMESTART"):
				phase = Phases.GAMESTART;
				break;
			case ("ROLL"):
				phase = Phases.ROLL;
				break;
			case ("TRADE"):
				phase = Phases.TRADE;
				break;
			case ("BUILD"):
				phase = Phases.BUILD;
				break;
			case ("PROCESS"):
				phase = Phases.PROCESS;
				break;
			case ("ENDGAME"):
				phase = Phases.ENDGAME;
				break;
		}
		curPhaseIndex = (int)phase.GetTypeCode();
	}


	//Updates text strings.
	public void UpdateText()
	{
		if (textEnabled)
		{
			try
			{
				textCurPhase = GameObject.Find("Text_CurPhase").GetComponent<Text>();
				textNextPhase = GameObject.Find("Text_NextPhase").GetComponent<Text>();
			}
			catch
			{
				textEnabled = false;
				Debug.Log("No text objects found. Probably not in the game scene.");
			}
			textCurPhase.text = "Current Phase: " + phase.ToString();
			textNextPhase.text = "Next Phase: " + ((Phases)((curPhaseIndex + 1) % ROTATE)).ToString();

		}
	}

}
