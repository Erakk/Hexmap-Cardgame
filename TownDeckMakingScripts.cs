using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TownDeckMakingScripts : MonoBehaviour {


	GameObject Deck;
	DeckOne deck;
	GameObject canvas;
	DeckListGui cardList;
	public GameObject cardText;

	private int cardNumber;
	// Use this for initialization
	void Start () {
		Deck = GameObject.Find ("Decks");
		deck = Deck.GetComponent<DeckOne> ();
		canvas = GameObject.Find ("Canvas");
		cardList = canvas.GetComponent<DeckListGui> ();
		cardNumber = 0;
	}

	public void ResetDeck()
	{
		GameObject[] CardTexts = GameObject.FindGameObjectsWithTag("CardListText");
//				bool skillHit = false;
		foreach (GameObject cardText in CardTexts) {
			Destroy(cardText);
		}
		cardNumber = 0;		
		deck.resetDeck();
	}

	public void WritePreviousDeck()
	{
//		Debug.Log("test");
		for (int i = 0; i < deck.allCardsInDeck.Count; i++) {
			cardNumber++;
			GameObject go = GameObject.Instantiate(cardText);
			go.transform.position = new Vector3(Screen.width * (1 - 0.08386f), Screen.height + (0 - (15 * (cardNumber-1))) ,0);
//			go.GetComponent<RectTransform>().localPosition.x = 0;
//			go.GetComponent<RectTransform>().localPosition.y = 0 - (15 * (cardNumber-1));
			go.name = "Card" + (i+1);
			GameObject list = GameObject.Find ("CardList");
			go.transform.SetParent(list.transform);
		}

		cardList.UpdateCardList ();
	}

	public void AddBackStab()
	{
		cardNumber++;
		GameObject go = GameObject.Instantiate(cardText);
		go.transform.position = new Vector3(Screen.width * (1 - 0.08386f), Screen.height + (0 - (15 * (cardNumber-1))) ,0);
		go.name = "Card" + cardNumber;
		GameObject list = GameObject.Find ("CardList");
		go.transform.SetParent(list.transform);
		deck.AddDamageCard("Backstab");
//		GameObject.Instantiate();
		cardList.UpdateCardList();	
	}

	public void AddPunch()
	{
		cardNumber++;
		GameObject go = GameObject.Instantiate(cardText);
		go.transform.position = new Vector3(Screen.width * (1 - 0.08386f), Screen.height + (0 - (15 * (cardNumber-1))) ,0);
		go.name = "Card" + cardNumber;
		GameObject list = GameObject.Find ("CardList");
		go.transform.SetParent(list.transform);
		deck.AddDamageCard("Punch");
//		GameObject.Instantiate();
		cardList.UpdateCardList();	
	}

	public void AddPatheticSwing()
	{
		cardNumber++;
		GameObject go = GameObject.Instantiate(cardText);
		go.transform.position = new Vector3(Screen.width * (1 - 0.08386f), Screen.height + (0 - (15 * (cardNumber-1))) ,0);
		go.name = "Card" + cardNumber;
		GameObject list = GameObject.Find ("CardList");
		go.transform.SetParent(list.transform);
		deck.AddDamageCard("Pathetic Swing");
//		GameObject.Instantiate();
		cardList.UpdateCardList();	
	}

	public void AddLeapSlam()
	{
		cardNumber++;
		GameObject go = GameObject.Instantiate(cardText);
		go.transform.position = new Vector3(Screen.width * (1 - 0.08386f), Screen.height + (0 - (15 * (cardNumber-1))) ,0);
		go.name = "Card" + cardNumber;
		GameObject list = GameObject.Find ("CardList");
		go.transform.SetParent(list.transform);
		deck.AddDamageCard("Leap Slam");
//		GameObject.Instantiate();
		cardList.UpdateCardList();
	}
//__________________________________________________________
	public void AddIgnite()
	{
		cardNumber++;
		GameObject go = GameObject.Instantiate(cardText);
		go.transform.position = new Vector3(Screen.width * (1 - 0.08386f), Screen.height + (0 - (15 * (cardNumber-1))) ,0);
		go.name = "Card" + cardNumber;
		GameObject list = GameObject.Find ("CardList");
		go.transform.SetParent(list.transform);
		deck.AddDamageCard("Ignite");
//		GameObject.Instantiate();
		cardList.UpdateCardList();	
	}

	public void AddShieldBash()
	{
		cardNumber++;
		GameObject go = GameObject.Instantiate(cardText);
		go.transform.position = new Vector3(Screen.width * (1 - 0.08386f), Screen.height + (0 - (15 * (cardNumber-1))) ,0);
		go.name = "Card" + cardNumber;
		GameObject list = GameObject.Find ("CardList");
		go.transform.SetParent(list.transform);
		deck.AddDamageCard("Shield Bash");
//		GameObject.Instantiate();
		cardList.UpdateCardList();	
	}

	public void AddStunArrow()
	{
		cardNumber++;
		GameObject go = GameObject.Instantiate(cardText);
		go.transform.position = new Vector3(Screen.width * (1 - 0.08386f), Screen.height + (0 - (15 * (cardNumber-1))) ,0);
		go.name = "Card" + cardNumber;
		GameObject list = GameObject.Find ("CardList");
		go.transform.SetParent(list.transform);
		deck.AddDamageCard("Stun Arrow");
//		GameObject.Instantiate();
		cardList.UpdateCardList();	
	}

	public void AddFireFist()
	{
		cardNumber++;
		GameObject go = GameObject.Instantiate(cardText);
		go.transform.position = new Vector3(Screen.width * (1 - 0.08386f), Screen.height + (0 - (15 * (cardNumber-1))) ,0);
		go.name = "Card" + cardNumber;
		GameObject list = GameObject.Find ("CardList");
		go.transform.SetParent(list.transform);
		deck.AddDamageCard("Fire Fist");
//		GameObject.Instantiate();
		cardList.UpdateCardList();
	}
	
	public void AddBlizzard()
	{
		cardNumber++;
		GameObject go = GameObject.Instantiate(cardText);
		go.transform.position = new Vector3(Screen.width * (1 - 0.08386f), Screen.height + (0 - (15 * (cardNumber-1))) ,0);
		go.name = "Card" + cardNumber;
		GameObject list = GameObject.Find ("CardList");
		go.transform.SetParent(list.transform);
		deck.AddDamageCard("Blizzard");
//		GameObject.Instantiate();
		cardList.UpdateCardList();	
	}

	public void AddPoisonArrow()
	{
		cardNumber++;
		GameObject go = GameObject.Instantiate(cardText);
		go.transform.position = new Vector3(Screen.width * (1 - 0.08386f), Screen.height + (0 - (15 * (cardNumber-1))) ,0);
		go.name = "Card" + cardNumber;
		GameObject list = GameObject.Find ("CardList");
		go.transform.SetParent(list.transform);
		deck.AddDamageCard("Poison Arrow");
//		GameObject.Instantiate();
		cardList.UpdateCardList();	
	}

	public void AddBearTrap()
	{
		cardNumber++;
		GameObject go = GameObject.Instantiate(cardText);
		go.transform.position = new Vector3(Screen.width * (1 - 0.08386f), Screen.height + (0 - (15 * (cardNumber-1))) ,0);
		go.name = "Card" + cardNumber;
		GameObject list = GameObject.Find ("CardList");
		go.transform.SetParent(list.transform);
		deck.AddDamageCard("Bear Trap");
//		GameObject.Instantiate();
		cardList.UpdateCardList();	
	}

	public void AddPoisonCloudArrow()
	{
		cardNumber++;
		GameObject go = GameObject.Instantiate(cardText);
		go.transform.position = new Vector3(Screen.width * (1 - 0.08386f), Screen.height + (0 - (15 * (cardNumber-1))) ,0);
		go.name = "Card" + cardNumber;
		GameObject list = GameObject.Find ("CardList");
		go.transform.SetParent(list.transform);
		deck.AddDamageCard("Poison Cloud Arrow");
//		GameObject.Instantiate();
		cardList.UpdateCardList();
	}

	public void AddFireball()
	{
		cardNumber++;
		GameObject go = GameObject.Instantiate(cardText);
		go.transform.position = new Vector3(Screen.width * (1 - 0.08386f), Screen.height + (0 - (15 * (cardNumber-1))) ,0);
		go.name = "Card" + cardNumber;
		GameObject list = GameObject.Find ("CardList");
		go.transform.SetParent(list.transform);
		deck.AddDamageCard("Fireball");
//		GameObject.Instantiate();
		cardList.UpdateCardList();	
	}

	public void AddShadowStrike()
	{
		cardNumber++;
		GameObject go = GameObject.Instantiate(cardText);
		go.transform.position = new Vector3(Screen.width * (1 - 0.08386f), Screen.height + (0 - (15 * (cardNumber-1))) ,0);
		go.name = "Card" + cardNumber;
		GameObject list = GameObject.Find ("CardList");
		go.transform.SetParent(list.transform);
		deck.AddDamageCard("Shadow Strike");
//		GameObject.Instantiate();
		cardList.UpdateCardList();	
	}

	public void AddFlameBreath()
	{
		cardNumber++;
		GameObject go = GameObject.Instantiate(cardText);
		go.transform.position = new Vector3(Screen.width * (1 - 0.08386f), Screen.height + (0 - (15 * (cardNumber-1))) ,0);
		go.name = "Card" + cardNumber;
		GameObject list = GameObject.Find ("CardList");
		go.transform.SetParent(list.transform);
		deck.AddDamageCard("Flame Breath");
//		GameObject.Instantiate();
		cardList.UpdateCardList();	
	}


}