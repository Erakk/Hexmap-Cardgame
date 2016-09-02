using UnityEngine;
using System.Collections;

public class WarriorStartDeck : MonoBehaviour {

	public void StartDeck()
	{	
//		GameObject GameController = GameObject.Find ("GameController");
//		GameController gameController = GameController.GetComponent<GameController> ();

		GameController.control.AddDamageCardToDeck("Leap Slam");
		GameController.control.AddDamageCardToDeck("Leap Slam");
		GameController.control.AddDamageCardToDeck("Leap Slam");
		GameController.control.AddHealCardToDeck("Bandage");
		GameController.control.AddHealCardToDeck("Bandage");
		GameController.control.AddHealCardToDeck("Bandage");
	}
}