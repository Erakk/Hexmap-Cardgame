using UnityEngine;
using System.Collections;

public class MageStartDeck : MonoBehaviour {

	public void StartDeck()
	{	
//		GameObject GameController = GameObject.Find ("GameController");
//		GameController gameController = GameController.GetComponent<GameController> ();

		GameController.control.AddDamageCardToDeck("Fireball");
		GameController.control.AddDamageCardToDeck("Fireball");
		GameController.control.AddDamageCardToDeck("Fireball");
		GameController.control.AddDamageCardToDeck("Ignite");
		GameController.control.AddDamageCardToDeck("Ignite");
		GameController.control.AddDamageCardToDeck("Ignite");
	}
}