using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController control;

	public GameObject playerOne;
	public GameObject playerTwo;
	public GameObject playerThree;

	public Material playerSelectedMaterial;
	public Material playerUnSelectedMaterial;

	public static GameController instance;
	public string playerName;
//	public int playerLevel = 1;
	public PlayableCharacter selecterModifyPlayer;	
	public int manaMax = 5;
	public int manaRemaining;
	public int cardCost;

	public Dictionary<string, DamageCard> allDamageCards;
	public Dictionary<string, HealCard> allHealCards;
	public Dictionary<string, UtilityCard> allUtilityCards;
	public Dictionary<string, BaseEnemy> allEnemies;



	public int playersAlive = 0;
	public int enemiesAlive = 0;

//	public BaseClass playerClass = new BaseClassMage ();


	// Use this for initialization
	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		}
		else if (control != this) {
			Destroy(gameObject);
		}

	}

	void Start()
	{
		StartClassSetup();
		manaRemaining = manaMax;		
	}

	void StartClassSetup(){
		SelectedPlayerTwo();
		SelectClassMage();
		SelectedPlayerThree();
		SelectClassMage();
		SelectedPlayerOne();
		SelectClassMage();

	}
	
	void OnEnable () {
		instance = this;
		if (allDamageCards == null) {
			allDamageCards = new Dictionary<string, DamageCard>();
		}
		
		allHealCards = new Dictionary<string, HealCard>();
		allUtilityCards = new Dictionary<string, UtilityCard>();
		allEnemies = new Dictionary<string, BaseEnemy>();

	}
	public void SelectClassMage()
	{
		selecterModifyPlayer.PlayerClass = gameObject.AddComponent<BaseClassMage>();
	}
	public void SelectClassPriest()
	{
		selecterModifyPlayer.PlayerClass = gameObject.AddComponent<BaseClassPriest>();
	}
	public void SelectClassWarrior()
	{
		selecterModifyPlayer.PlayerClass = gameObject.AddComponent<BaseClassWarrior>();
	}
	public void SelectClassRogue()
	{
		selecterModifyPlayer.PlayerClass = gameObject.AddComponent<BaseClassRogue>();
	}
	public void SelectedPlayerOne()
	{
		GameObject Player = GameObject.Find ("Player1");
		PlayableCharacter player = Player.GetComponent<PlayableCharacter>();
		selecterModifyPlayer = player;
	}
	public void SelectedPlayerTwo()
	{
		GameObject Player = GameObject.Find ("Player2");
		PlayableCharacter player = Player.GetComponent<PlayableCharacter>();
		selecterModifyPlayer = player;
	}
	public void SelectedPlayerThree()
	{
		GameObject Player = GameObject.Find ("Player3");
		PlayableCharacter player = Player.GetComponent<PlayableCharacter>();
		selecterModifyPlayer = player;
	}
/*
	public void DecreaseStrength()
	{
		if(decreaseStr > 0){
			pointsLeft++;
			playerClass.Strength = playerClass.Strength - 1;
			decreaseStr--;
		}
	}
	public void IncreaseStrength()
	{
		if(pointsLeft > 0){
			playerClass.Strength = playerClass.Strength + 1;
			pointsLeft--;
			decreaseStr++;
		}
	}
	public void DecreaseIntelligence()
	{
		if (decreaseInt > 0) {
			pointsLeft++;
			playerClass.Intelligence = playerClass.Intelligence - 1;
			decreaseInt--;
		}

	}
	public void IncreaseIntelligence()
	{
		if (pointsLeft > 0) {
			playerClass.Intelligence = playerClass.Intelligence + 1;
			pointsLeft--;
			decreaseInt++;
		}
	}
	public void DecreaseWisdom()
	{
		if (decreaseWis > 0) {
			pointsLeft++;
			playerClass.Wisdom = playerClass.Wisdom - 1;
			decreaseWis--;
		}
	}
	public void IncreaseWisdom()
	{
		if (pointsLeft > 0) {
			playerClass.Wisdom = playerClass.Wisdom + 1;
			pointsLeft--;
			decreaseWis++;
		} 
	}
	public void DecreaseDexterity()
	{
		if (decreaseDex > 0) {
			pointsLeft++;
			playerClass.Dexterity = playerClass.Dexterity - 1;
			decreaseDex--;
		}
	}
	public void IncreaseDexterity()
	{
		if (pointsLeft > 0) {
			playerClass.Dexterity = playerClass.Dexterity + 1;
			pointsLeft--;
			decreaseDex++;
		}
	}
*/
	public void CalculatePlayers()
	{
		GameObject[] PlayersAlive =  GameObject.FindGameObjectsWithTag("Player");
		playersAlive = PlayersAlive.Length;
		
	}

	public void AddDamageCardToDatabase(DamageCard c) {
		c.gameObject.name = c.CardName;
		allDamageCards.Add(c.CardName, c);

		c.transform.SetParent(transform);
	}
	public void AddDamageCardToDeck(string title) {
		if(allDamageCards.ContainsKey(title) == false) {
			Debug.LogError("No player card with title: " + title);
			return;
		}
//		Debug.Log(title);
		DamageCard c = allDamageCards[title];
		AddDamageCardToDeck(c);
	}
	public void AddDamageCardToDeck(DamageCard c) {
		//Debug.Log("AddCardToDeck: " + c.title);

		GameObject go = Instantiate( c.gameObject );
		go.GetComponent<DamageCard>().CopyActionsFrom( c );
		GameObject hand = GameObject.Find("Deck");
		go.transform.SetParent(hand.transform );
		go.SetActive(false);
	}
	public void AddHealCardToDatabase(HealCard c) {
		c.gameObject.name = c.CardName;
		allHealCards.Add(c.CardName, c);

		c.transform.SetParent(transform);
	}
	public void AddHealCardToDeck(string title) {
		if(allHealCards.ContainsKey(title) == false) {
			Debug.LogError("No player card with title: " + title);
			return;
		}

		HealCard c = allHealCards[title];
		AddHealCardToDeck(c);
	}
	public void AddHealCardToDeck(HealCard c) {
		//Debug.Log("AddCardToDeck: " + c.title);

		GameObject go = Instantiate( c.gameObject );
		go.GetComponent<HealCard>().CopyActionsFrom( c );
		GameObject hand = GameObject.Find("Deck");
		go.transform.SetParent(hand.transform );
		go.SetActive(false);
	}
	public void AddUtilityCardToDatabase(UtilityCard c) {
		c.gameObject.name = c.CardName;
		allUtilityCards.Add(c.CardName, c);

		c.transform.SetParent(transform);
	}
	public void AddUtilityCardToDeck(string title) {
		if(allUtilityCards.ContainsKey(title) == false) {
			Debug.LogError("No player card with title: " + title);
			return;
		}

		UtilityCard c = allUtilityCards[title];
		AddUtilityCardToDeck(c);
	}
	public void AddUtilityCardToDeck(UtilityCard c) {
		//Debug.Log("AddCardToDeck: " + c.title);

		GameObject go = Instantiate( c.gameObject );
		go.GetComponent<UtilityCard>().CopyActionsFrom( c );
		GameObject hand = GameObject.Find("Deck");
		go.transform.SetParent(hand.transform );
		go.SetActive(false);
	}

	public void BuildInitialPlayerDeck() {

		GameObject[] PlayersAlive =  GameObject.FindGameObjectsWithTag("Player");
//		Debug.Log (PlayersAlive.Length);

		//Tekee alkupakat ensimmäiseen taisteluun. 
		//Nämä pakat ovat ennalta määritetyt
		GameObject Scripts = GameObject.Find ("_ScriptsTutorialBattle");
		foreach (GameObject Player in PlayersAlive) {
			PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
//			Debug.Log (player.name);
			if (player.PlayerClass.CharacterClassName == "Warrior") {
				WarriorStartDeck warriorStartDeck = Scripts.GetComponent<WarriorStartDeck> ();
				warriorStartDeck.StartDeck();
			}
			else if (player.PlayerClass.CharacterClassName == "Mage") {
				MageStartDeck mageStartDeck = Scripts.GetComponent<MageStartDeck> ();
				mageStartDeck.StartDeck();
			}
			else if (player.PlayerClass.CharacterClassName == "Priest") {
				PriestStartDeck priestStartDeck = Scripts.GetComponent<PriestStartDeck> ();
				priestStartDeck.StartDeck();
			}
			else if (player.PlayerClass.CharacterClassName == "Rogue") {
				RogueStartDeck rogueStartDeck = Scripts.GetComponent<RogueStartDeck> ();
				rogueStartDeck.StartDeck();
			}
		}


	}
	public void BuildCustomDeck() {

		GameObject[] PlayersAlive =  GameObject.FindGameObjectsWithTag("Player");
		//		Debug.Log (PlayersAlive.Length);

		//Rakentaa itsetehdyn pakan. Pakkaa pystyy muokkaamaan kylän "library":ssä


		GameObject DeckOne = GameObject.Find ("Decks");
		DeckOne deckOne = DeckOne.GetComponent<DeckOne> ();
		deckOne.Deck();


	}
	public void AddEnemyToDatabase(BaseEnemy enemy) {
		enemy.gameObject.name = enemy.EnemyName;
		allEnemies.Add(enemy.EnemyName, enemy);

		enemy.transform.SetParent(transform);
	}

	public void AddEnemyToMap(string title)
	{
		if(allEnemies.ContainsKey(title) == false) {
			Debug.LogError("No enemy with title: " + title);
			return;
		}
		BaseEnemy enemy = allEnemies[title];
		AddEnemyToMap(enemy);
	}
	public void AddEnemyToMap(BaseEnemy enemy)
	{
		GameObject go = Instantiate( enemy.gameObject );
		go.GetComponent<BaseEnemy>().CopyActionsFrom( enemy );
		GameObject enemies = GameObject.Find("Enemies");
		go.transform.SetParent(enemies.transform );
		go.tag = "Enemy";
		go.SetActive(true);
	}

	public void CalculateRemainingMana()
	{
		manaRemaining -= cardCost;
		cardCost = 0;
	}
	
	public void LoadTown()
	{
		
		SceneManager.LoadScene ("Town");

		// hakee aikaisemmassa taistelussa käytössä olleen pakan ja kirjoittaa sen valmiiksi kirjastoon
		GameObject TownDeckMakingScripts = GameObject.Find ("LibraryOptions");
		TownDeckMakingScripts townDeckMakingScripts = TownDeckMakingScripts.GetComponent<TownDeckMakingScripts> ();
		townDeckMakingScripts.WritePreviousDeck();
	}

	public void CalculateEnemies()
	{

		GameObject[] EnemysAlive =  GameObject.FindGameObjectsWithTag("Enemy");
		int enemiesAlive = EnemysAlive.Length;
		if (enemiesAlive == 0) {
			Debug.Log ("enemies down");
			//Mikäli vastustajia ei ole jäljellä, tuo esiin palkinto mahdollisuudet.
			PriceScreen ();
//			LoadTown();
		}
	}

	public void LoadTutorialBattle()
	{
		playerOne.SetActive(true);	
		playerOne.tag = "Player";
		playerTwo.SetActive(true);
		playerTwo.tag = "Player";
		playerThree.SetActive(true);
		playerThree.tag = "Player";			
		
		GameObject[] PlayersAlive =  GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject Player in PlayersAlive) {
			PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();	
			player.CalculateMainStats();
			HealthBar playerHpBar = Player.GetComponent<HealthBar> ();
			playerHpBar.CurHealth = playerHpBar.maxHealth;
			playerHpBar.SetHealthBarStart();
			
		}

	
		SceneManager.LoadScene ("BattleArea1");
//		BuildInitialPlayerDeck ();
	}
	public void LoadFireBattleOne()
	{
		playerOne.SetActive(true);	
		playerOne.tag = "Player";
		playerTwo.SetActive(true);
		playerTwo.tag = "Player";
		playerThree.SetActive(true);
		playerThree.tag = "Player";			

		GameObject[] PlayersAlive =  GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject Player in PlayersAlive) {
			PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();	
			player.CalculateMainStats();
			HealthBar playerHpBar = Player.GetComponent<HealthBar> ();
			playerHpBar.CurHealth = playerHpBar.maxHealth;
			playerHpBar.SetHealthBarStart();

		}


		SceneManager.LoadScene ("FireBattle1");
//		BuildCustomDeck ();
	}
	public void TurnFalsePlayerButtons()
	{
		GameObject[] SelectButtons =  GameObject.FindGameObjectsWithTag("PlayerButton");
		foreach (GameObject SelectButton in SelectButtons) {
			SelectButton.GetComponent<Button> ().interactable = false;
		}
		GameObject[] SelectButtonsCanvas =  GameObject.FindGameObjectsWithTag("PlayerButtonCanvas");
		foreach (GameObject SelectButtonCanvas in SelectButtonsCanvas) {
			SelectButtonCanvas.GetComponent<GraphicRaycaster> ().enabled = false;
			
		}
	}
	public void TurnTruePlayerButtons()
	{
		GameObject[] SelectButtons =  GameObject.FindGameObjectsWithTag("PlayerButton");
		foreach (GameObject SelectButton in SelectButtons) {
			SelectButton.GetComponent<Button> ().interactable = true;
		}
		GameObject[] SelectButtonsCanvas =  GameObject.FindGameObjectsWithTag("PlayerButtonCanvas");
		foreach (GameObject SelectButtonCanvas in SelectButtonsCanvas) {
			SelectButtonCanvas.GetComponent<GraphicRaycaster> ().enabled = true;
			
		}
	}

	void PriceScreen()
	{
		// laittaa price screenin näkyviin
		GameObject ButtonScripts = GameObject.Find ("ButtonsCanvas");
		ButtonScripts buttonScripts = ButtonScripts.GetComponent<ButtonScripts> ();
		buttonScripts.priceScreen.SetActive (true);
		Debug.Log ("price screen up?");

		//Price screenin napit ohjaa kylään
	}

}
