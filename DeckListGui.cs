using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeckListGui : MonoBehaviour {

	private int totalCards;

	GameObject Deck;
	DeckOne deck;
	// Use this for initialization
	void Start () {
		Deck = GameObject.Find ("Decks");
		deck = Deck.GetComponent<DeckOne> ();
	}

	public void UpdateCardList ()
	{
//		totalCards = deck.allCardsInDeck.Count;

		for (int i = 0; i < deck.allCardsInDeck.Count; i++) {
			Text cardOne = GameObject.Find ("Card" + (i+1)).GetComponent<Text> ();		
			cardOne.text = (i+1) + ". " + deck.allCardsInDeck[i];
		}
		

	}

}
