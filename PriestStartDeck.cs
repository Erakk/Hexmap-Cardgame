using UnityEngine;
using System.Collections;

public class PriestStartDeck : MonoBehaviour {

	public void StartDeck()
	{	
//		GameObject GameController = GameObject.Find ("GameController");
//		GameController gameController = GameController.GetComponent<GameController> ();

		GameController.control.AddDamageCardToDeck("Punch");
		GameController.control.AddDamageCardToDeck("Punch");
		GameController.control.AddDamageCardToDeck("Punch");
		GameController.control.AddHealCardToDeck("Basic Heal");
		GameController.control.AddHealCardToDeck("Basic Heal");
		GameController.control.AddHealCardToDeck("Basic Heal");
	}
}