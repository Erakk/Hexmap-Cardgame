using UnityEngine;
using System.Collections;

public class SetCardDraggable : MonoBehaviour {


	// Update is called once per frame
	void FixedUpdate () {
		GameObject Hand = GameObject.Find("Hand");
		Card[] cardsInHand = Hand.GetComponentsInChildren<Card>();
//		GameObject TileMap = GameObject.Find("Map");
//		TileMap map = TileMap.GetComponent<TileMap>();

//		GameObject GameController = GameObject.Find("GameController");
//		GameController gameController = GameController.GetComponent<GameController> ();
		foreach (Card Card in cardsInHand) {
			Card card =  Card.GetComponent<Card>();
			if (GameController.control.manaRemaining < card.CardCost) {
//				card.transform.gameObject.SetActive(false);
				card.transform.GetComponent<Draggable>().enabled = false;
			} 
			else {
				card.transform.GetComponent<Draggable>().enabled = true;
			}

		}

	}
}
