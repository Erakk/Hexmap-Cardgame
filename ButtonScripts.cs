using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour {

	public static ButtonScripts buttonScript;

	public GameObject priceScreen;

	public bool moveSelected = false;
	public bool changeAreaTiles = false;
	public bool enemyMoving = false;
	public bool attackSelected = false;
	public bool drawSelected = false;
	public bool coneSelected = false;
	public bool changeAreaTilesNoMid = false;
	public bool trapSelected = false;
	public bool allySelected = false;
	private string lastPlayer;
	private bool lastPlayerAlive = true;
	public Deck deck;
	public TileMap map;
	
	void Awake () {
//		DontDestroyOnLoad (gameObject);
/*		if (buttonScript == null) {
			DontDestroyOnLoad (gameObject);
			buttonScript = this;
		}
		else if (buttonScript != this) {
			Destroy(gameObject);
		}
*/
	}

	void Start()
	{
		
		TurnEverythingFalse ();
	}

	public void TurnEverythingFalse()
	{
		moveSelected = false;
		changeAreaTiles = false;
		enemyMoving = false;
		attackSelected = false;
		drawSelected = false;
		coneSelected = false;
		changeAreaTilesNoMid = false;
		trapSelected = false;
		allySelected = false;
	}	

	public void MovementClicked()
	{	
		TurnEverythingFalse();
		CheckDropZone();
		GameObject Player = GameObject.Find(map.selecterPlayer);
		PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
		GameObject HighlightTiles = GameObject.Find ("_Scripts");
		HighlightTiles highlightTiles = HighlightTiles.GetComponent<HighlightTiles> ();

		highlightTiles.HideAllAllowedTiles();
		moveSelected = true;
		highlightTiles.ShowAllowedTilesMovement();
		player.PlayerClass.AttackableTiles = 0;
	}

	public void LookAround()
	{	
		GameObject HighlightTiles = GameObject.Find ("_Scripts");
		HighlightTiles highlightTiles = HighlightTiles.GetComponent<HighlightTiles> ();
		highlightTiles.HideAllAllowedTiles();
		TurnEverythingFalse();
		map.CheckVisibleTiles();
		ShowVisibleTiles();
		GameObject Player = GameObject.Find(map.selecterPlayer);
		PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
		player.PlayerClass.RemainingMovement--;		
		if (player.PlayerClass.RemainingMovement < 0) {
			player.PlayerClass.RemainingMovement = 0;
		}
		GameObject Stats = GameObject.Find("ScreenPlayerStats");
		BasicStatsGui stats = Stats.GetComponent<BasicStatsGui>();
		stats.StatsUpdate();
	}

	public void PlayerOneSelected ()
	{
//		GameObject TileMap = GameObject.Find("Map");
//		TileMap tileMap = TileMap.GetComponent<TileMap> ();
		CheckDropZone();
		map.selecterPlayer = "Player1";
		ShowVisibleTiles();
		GameObject Stats = GameObject.Find("ScreenPlayerStats");
		BasicStatsGui stats = Stats.GetComponent<BasicStatsGui>();
		stats.StatsUpdate();
		HidePlayerSelectButton();
		GameObject Player = GameObject.Find("Player One");
		Player.GetComponent<Button> ().interactable = false;
		UnSelectPlayerColours();
		
//		GameObject GameController = GameObject.Find("GameController");
//		GameController gameController = GameController.GetComponent<GameController>();

		GameObject PlayerOneCube = GameObject.Find("PlayerOneCube");
		Material[] matOne = PlayerOneCube.GetComponent<Renderer>().materials;
		matOne[0] = GameController.control.playerSelectedMaterial;
		PlayerOneCube.GetComponent<Renderer>().materials = matOne;	
		UpdateHandTooltip ();
		return;
	}

	public void PlayerTwoSelected ()
	{		
//		GameObject TileMap = GameObject.Find("Map");
//		TileMap tileMap = TileMap.GetComponent<TileMap> ();
		CheckDropZone();
		map.selecterPlayer = "Player2";
		ShowVisibleTiles();
		GameObject Stats = GameObject.Find("ScreenPlayerStats");
		BasicStatsGui stats = Stats.GetComponent<BasicStatsGui>();
		stats.StatsUpdate();
		HidePlayerSelectButton();
		GameObject Player = GameObject.Find("Player Two");
		Player.GetComponent<Button> ().interactable = false;
		UnSelectPlayerColours();
		
//		GameObject GameController = GameObject.Find("GameController");
//		GameController gameController = GameController.GetComponent<GameController>();

		GameObject PlayerTwoCube = GameObject.Find("PlayerTwoCube");
		Material[] matTwo = PlayerTwoCube.GetComponent<Renderer>().materials;
		matTwo[0] = GameController.control.playerSelectedMaterial;
		PlayerTwoCube.GetComponent<Renderer>().materials = matTwo;

		UpdateHandTooltip ();
		return;
	}

	public void PlayerThreeSelected ()
	{
//		GameObject TileMap = GameObject.Find("Map");
//		TileMap tileMap = TileMap.GetComponent<TileMap> ();
		CheckDropZone();
		map.selecterPlayer = "Player3";
		ShowVisibleTiles();
		GameObject Stats = GameObject.Find("ScreenPlayerStats");
		BasicStatsGui stats = Stats.GetComponent<BasicStatsGui>();
		stats.StatsUpdate();
		HidePlayerSelectButton();
		GameObject Player = GameObject.Find("Player Three");
		Player.GetComponent<Button> ().interactable = false;
		UnSelectPlayerColours();

//		GameObject GameController = GameObject.Find("GameController");
//		GameController gameController = GameController.GetComponent<GameController>();

		GameObject PlayerThreeCube = GameObject.Find("PlayerThreeCube");
		Material[] matThree = PlayerThreeCube.GetComponent<Renderer>().materials;
		matThree[0] = GameController.control.playerSelectedMaterial;
		PlayerThreeCube.GetComponent<Renderer>().materials = matThree;

		UpdateHandTooltip ();
		return;
	}

	public void MoveConfirmed ()
	{
//		int i = 0;
//		GameObject GameController = GameObject.Find("GameController");
//		GameController gameController = GameController.GetComponent<GameController>();
		GameController.control.manaRemaining = GameController.control.manaMax;
		lastPlayer = map.selecterPlayer;
		GameObject HighlightTiles = GameObject.Find ("_Scripts");
		HighlightTiles highlightTiles = HighlightTiles.GetComponent<HighlightTiles> ();
		highlightTiles.HideAllAllowedTiles();
		CheckDropZone();

		GameObject[] EnemysAlive =  GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject Enemy in EnemysAlive) {

//			Debug.Log(Enemy.name);
			map.selectedEnemy = Enemy.name;
			BaseEnemy enemy = Enemy.GetComponent<BaseEnemy> ();
			if (!enemy.Stunned && !enemy.Frozen) {
				enemy.MoveNextTile();	
			}
			enemy.RunEffects();			
		}

		GameController.control.CalculateEnemies();
		GameObject PlayerAliveCheck = GameObject.Find(lastPlayer);
		PlayableCharacter playerAliveCheck = PlayerAliveCheck.GetComponent<PlayableCharacter>();
		lastPlayerAlive = playerAliveCheck.PlayerClass.Alive;

		GameObject[] PlayersAlive =  GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject Player in PlayersAlive) {
			PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
			player.PlayerClass.RemainingMovement = player.PlayerClass.MoveSpeed;
			player.PlayerClass.AttackableTiles = 0;
			player.RunEffects();
			map.selecterPlayer = player.name;
			map.CheckVisibleTiles();
			if (!lastPlayerAlive) {
				lastPlayer = Player.name;
				lastPlayerAlive = true;
			}
			
		}
		map.selecterPlayer = lastPlayer;
		ShowVisibleTiles();
		deck.DrawCardToHand();
		TurnEverythingFalse();
		GameObject Stats = GameObject.Find("ScreenPlayerStats");
		BasicStatsGui stats = Stats.GetComponent<BasicStatsGui>();
		stats.StatsUpdate();
		GameController.control.TurnTruePlayerButtons();
		UpdateHandTooltip ();
		
	}
		
	public void DrawLine()
	{
		TurnEverythingFalse();
		drawSelected = true;
	}	

	public void VisibleHex()
	{
		TurnEverythingFalse();
		drawSelected = true;
	}

	public void HiddenHex()
	{
		TurnEverythingFalse();
		drawSelected = true;
	}
	public void CheckDropZone()
	{	

		GameObject CardDropArea = GameObject.Find ("CardDropArea");
		GameObject hand = GameObject.Find ("Hand");
		DropZone dropZone = CardDropArea.GetComponent<DropZone>();
		Draggable[] cardsToMove = CardDropArea.GetComponentsInChildren<Draggable>();
		GameObject HighlightTiles = GameObject.Find ("_Scripts");
		HighlightTiles highlightTiles = HighlightTiles.GetComponent<HighlightTiles> ();
		highlightTiles.HideAllAllowedTiles();

		if (cardsToMove.Length >= 1) {
			TurnEverythingFalse();
			dropZone.damage = 0;
			dropZone.movementCost = 0;
			dropZone.effect = Effects.Empty;
			foreach (Draggable card in cardsToMove) {
				if (transform.name != "CardDropArea") {
					card.transform.SetParent(hand.transform); 
				}
				
			}
		}
	}
	public void Exit() {
		Application.Quit();
	}

	public void Restart() {
		SceneManager.LoadScene ("CharacterCreation");
	}

	public void LoadStarttingArea()
	{
//		GameObject GameController = GameObject.Find("GameController");
//		GameController gameController = GameController.GetComponent<GameController>();
		GameController.control.LoadTutorialBattle();
//		map = TileMap.map;
//		LoadTown();
	}

	public void LoadTown()
	{
		SceneManager.LoadScene ("Town");
	}

	public void ChangeCharacterName()
	{
		
		// Toimii jotenkin. Mieti myöhemmin miten haluat tämän toimivan
		GameObject inputFieldGo = GameObject.Find("CharacterNameInput");
		InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
//		Debug.Log (inputFieldCo.text);

//		GameObject GameController = GameObject.Find ("GameController");
//		GameController gameControllerscripts = GameController.GetComponent<GameController> ();
		GameController.control.playerName = inputFieldCo.text;

	}           

	public void ShowVisibleTiles()
	{
		GameObject[] Tiles =  GameObject.FindGameObjectsWithTag("Hex");
		foreach (GameObject TileDeny in Tiles) {
			ClickableTile tileDeny = TileDeny.GetComponent<ClickableTile> ();
			tileDeny.hexVisible = false;
		}
//		GameObject TileMap = GameObject.Find("Map");
//		TileMap tileMap = TileMap.GetComponent<TileMap> ();
		GameObject Player = GameObject.Find (map.selecterPlayer);
		PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
		foreach (Node node in player.VisibleNodes) {
			GameObject Tile = GameObject.Find ("Hex_" + node.x + "_" + node.y);
			ClickableTile tile = Tile.GetComponent<ClickableTile> ();
			tile.hexVisible = true;
		}
	} 
	void HidePlayerSelectButton()
	{
		GameObject[] SelectButtons =  GameObject.FindGameObjectsWithTag("PlayerSelectButton");
		foreach (GameObject SelectButton in SelectButtons) {
			SelectButton.GetComponent<Button> ().interactable = true;
		}
	}       
	void UnSelectPlayerColours()
	{
//		GameObject GameController = GameObject.Find("GameController");
//		GameController gameController = GameController.GetComponent<GameController>();
		GameObject PlayerOneCube = GameObject.Find("PlayerOneCube");
		GameObject PlayerTwoCube = GameObject.Find("PlayerTwoCube");
		GameObject PlayerThreeCube = GameObject.Find("PlayerThreeCube");
		if (PlayerOneCube != null) {
			Material[] matOne = PlayerOneCube.GetComponent<Renderer>().materials;
			matOne[0] = GameController.control.playerUnSelectedMaterial;
			PlayerOneCube.GetComponent<Renderer>().materials = matOne;	
		}
		if (PlayerTwoCube != null) {
			Material[] matTwo = PlayerTwoCube.GetComponent<Renderer>().materials;
			matTwo[0] = GameController.control.playerUnSelectedMaterial;
			PlayerTwoCube.GetComponent<Renderer>().materials = matTwo;
		}
		if (PlayerThreeCube != null) {
			Material[] matThree = PlayerThreeCube.GetComponent<Renderer>().materials;
			matThree[0] = GameController.control.playerUnSelectedMaterial;
			PlayerThreeCube.GetComponent<Renderer>().materials = matThree;
		}	
	}       

	void UpdateHandTooltip()
	{
		GameObject UpdateHandTooltip = GameObject.Find("_Scripts");
		UpdateHandTooltip updateHandTooltip = UpdateHandTooltip.GetComponent<UpdateHandTooltip>();
		updateHandTooltip.UpdateHand ();
	}
}
