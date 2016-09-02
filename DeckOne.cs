using UnityEngine;
using System.Collections.Generic;

public class DeckOne : MonoBehaviour {

	public List<string> damageCardsInDeck;
	public List<string> healCardsInDeck;
	public List<string> utilityCardsInDeck;
	public List<string> allCardsInDeck;

	// Use this for initialization
	void Start () {
		damageCardsInDeck = new List<string>();
		healCardsInDeck = new List<string>();
		utilityCardsInDeck = new List<string>();
		allCardsInDeck = new List<string>();
	}
	

	public void resetDeck()
	{
		damageCardsInDeck = null;
		healCardsInDeck = null;
		utilityCardsInDeck = null;
		allCardsInDeck = null;
		damageCardsInDeck = new List<string>();
		healCardsInDeck = new List<string>();
		utilityCardsInDeck = new List<string>();
		allCardsInDeck = new List<string>();
	}

	public void Deck()
	{	
//		GameObject GameController = GameObject.Find ("GameController");
//		GameController gameController = GameController.GetComponent<GameController> ();
		if (damageCardsInDeck.Count > 0) {
			for (int i = 0; i < damageCardsInDeck.Count; i++) {
				GameController.control.AddDamageCardToDeck(damageCardsInDeck[i]);
			}
		}
		
		if (healCardsInDeck.Count > 0) {
			for (int i = 0; i < healCardsInDeck.Count; i++) {
				GameController.control.AddHealCardToDeck(healCardsInDeck[i]);
			}
		}

		if (utilityCardsInDeck.Count > 0) {
			for (int i = 0; i < utilityCardsInDeck.Count; i++) {
				GameController.control.AddUtilityCardToDeck(utilityCardsInDeck[i]);
			}
		}
	}

	public void AddDamageCard(string cardName)
	{
		damageCardsInDeck.Add(cardName);
		AddCard(cardName);
	}

	public void AddHealCard(string cardName)
	{
		healCardsInDeck.Add(cardName);
		AddCard(cardName);
	}

	public void AddUtilityCard(string cardName)
	{
		utilityCardsInDeck.Add(cardName);
		AddCard(cardName);
	}

	void AddCard(string cardName)
	{
		allCardsInDeck.Add(cardName);
	}
}
