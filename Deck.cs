using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Deck : MonoBehaviour {

	// The transform's children are going to be GameObjects that have <Card> components.

	GameObject playerHand;

	public Text cardCounter;

	public string counterPrefix = "Deck ";

	void Start() {
		playerHand = GameObject.Find("Hand");
	}

	void Update() {
//		cardCounter.text = counterPrefix + "(" + this.transform.childCount.ToString() + ")";
	}

/*	public void AddCard(Draggable c) {
		c.transform.SetParent(this.transform);
		// Move the card to be centered on us?
		//c.transform.localPosition = Vector3.zero;
		// Disable the card so it doesn't do anything while it's in a deck.
		//c.gameObject.SetActive(false);

		c.StartMoveAnimation(this.transform.position, 
			(c2) => { 
				c2.StopMoveAnimation();
				c2.gameObject.SetActive(false);
			}
		);
	}
*/
	public void Shuffle() {
		List<Transform> cardTransforms = new List<Transform>();

		while(transform.childCount > 0) {
			Transform t = transform.GetChild( Random.Range(0, transform.childCount) );
			t.SetParent(null);
			cardTransforms.Add(t);
		}

		foreach(Transform t in cardTransforms) {
			t.SetParent(this.transform);
		}
	}

	public void DrawCardToHand() {
		Shuffle();
/*		if(transform.childCount <= 0) {
			// Really, the only deck for which this should ever be called
			// on is the, well, draw deck.  Therefore, this is a good time
			// to reshuffle the discards into ourselves.

			GameObject discardDeck = Utilities.PlayerDiscard();

			if(discardDeck.transform.childCount == 0) {
				Debug.Log("Draw deck is empty...as is the discard pile!");
				return null;
			}

			// Move everything into this deck.
			while(discardDeck.transform.childCount > 0) {
				discardDeck.transform.GetChild( Random.Range(0, discardDeck.transform.childCount) ).SetParent( this.transform );
			}

		}
*/		
		if(transform.childCount <= 0) {
			Debug.Log("your deck is empty!");
			return;
		}
		GameObject hand = GameObject.Find("Hand");
//		Debug.Log(hand.transform.childCount);
		if(hand.transform.childCount >= 5) {
			Debug.Log("Your Hand is Full");
			return;
		}
		Draggable card = transform.GetChild(0).GetComponent<Draggable>();
//		c.StopMoveAnimation();
		card.gameObject.SetActive(true);
		card.transform.SetParent(playerHand.transform);  // This is no child of ours!
		card.transform.SetSiblingIndex(0);
		card.transform.localScale = Vector3.one;
//		if(c.onDrawn != null) {
//			c.onDrawn(c);
//		}

//		return c;
	}

}
