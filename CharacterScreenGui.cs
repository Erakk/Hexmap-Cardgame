using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CharacterScreenGui : MonoBehaviour {
	
//	GameController gameControllerscripts;


	void FixedUpdate()
	{
//		GameObject GameController = GameObject.Find ("GameController");
//		GameController gameControllerscripts = GameController.GetComponent<GameController> ();

		GUIText guiCharacterName = GameObject.Find ("CharacterName").GetComponent<GUIText> ();
		guiCharacterName.text = "Character Name: " + GameController.control.playerName ;

//		GUIText guiCharacterLevel = GameObject.Find ("CharacterLevel").GetComponent<GUIText> ();
//		guiCharacterLevel.text = "Character Level: " + GameController.control.playerLevel ;

		GUIText guiCharacterClass = GameObject.Find ("CharacterClass").GetComponent<GUIText> ();
		guiCharacterClass.text = "Character Class: " + GameController.control.selecterModifyPlayer.PlayerClass.CharacterClassName ;


	}
}
