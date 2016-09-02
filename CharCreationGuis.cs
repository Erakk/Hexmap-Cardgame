using UnityEngine;
using System.Collections;

public class CharCreationGuis : MonoBehaviour {

	void FixedUpdate ()
	{
//		GameObject GameController = GameObject.Find ("GameController");
//		GameController gameControllerscripts = GameController.GetComponent<GameController> ();

		GUIText guiChooseClassGuiText = GameObject.Find ("ChooseClassGuiText").GetComponent<GUIText> ();
		guiChooseClassGuiText.text = "Class: " + GameController.control.selecterModifyPlayer.PlayerClass.CharacterClassName ;

		GUIText guiClassStrengthGui = GameObject.Find ("ClassStrengthGui").GetComponent<GUIText> ();
		guiClassStrengthGui.text = "Strength: " + GameController.control.selecterModifyPlayer.PlayerClass.Strength ;

		GUIText guiClassIntelligenceGui = GameObject.Find ("ClassIntelligenceGui").GetComponent<GUIText> ();
		guiClassIntelligenceGui.text = "Intelligence: " + GameController.control.selecterModifyPlayer.PlayerClass.Intelligence ;

		GUIText guiClassWisdomGui = GameObject.Find ("ClassWisdomGui").GetComponent<GUIText> ();
		guiClassWisdomGui.text = "Wisdom: " + GameController.control.selecterModifyPlayer.PlayerClass.Wisdom ;

		GUIText guiClassDexterityGui = GameObject.Find ("ClassDexterityGui").GetComponent<GUIText> ();
		guiClassDexterityGui.text = "Dexterity: " + GameController.control.selecterModifyPlayer.PlayerClass.Dexterity ;

//		GUIText guiPointsLeftGui = GameObject.Find ("PointsLeftGui").GetComponent<GUIText> ();
//		guiPointsLeftGui.text = "Points Left " + gameControllerscripts.pointsLeft ;

//		GUIText characterName = GameObject.Find ("CharacterName").GetComponent<GUIText> ();
//		characterName.text = gameControllerscripts.playerName ;
	}
}
