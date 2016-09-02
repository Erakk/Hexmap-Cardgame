using UnityEngine;
using System.Collections;

public class RogueStartDeck : MonoBehaviour {

	public void StartDeck()
	{	
//		GameObject GameController = GameObject.Find ("GameController");
//		GameController gameController = GameController.GetComponent<GameController> ();

		GameController.control.AddDamageCardToDeck("Backstab");
		GameController.control.AddDamageCardToDeck("Backstab");
		GameController.control.AddDamageCardToDeck("Backstab");
		GameController.control.AddDamageCardToDeck("Stun Arrow");
		GameController.control.AddDamageCardToDeck("Stun Arrow");
		GameController.control.AddDamageCardToDeck("Stun Arrow");
	}
}