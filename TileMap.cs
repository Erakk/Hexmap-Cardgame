using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class TileMap : MonoBehaviour {

	public static TileMap map;

	public Material hoverMaterial;
	public GameObject playerPrefab;
	public GameObject enemyPrefab;
//	public StartingUnits startingunits;

	// 1: startdeck
	// 2: custom deck
	public int selectedDeck;

//	MapSettings settings;

	private Color startMaterial;

//	public string selectedCharacter = "UnitTwo";
	public string selecterPlayer;
	public string selectedEnemy;

	private ButtonScripts buttonScripts;
	public TileType[] tileTypes;
	public MapSettingAreas[] mapSettingAreas;
//	public ChangeTilesArea changeTilesArea;

	int[,] tiles;

	public Node[,] graph;
	List<Node> currentPath;
	List<Node> visibleTiles;
	public int currentPathCount;
	public int mapSizeX = 10;
	public int mapSizeY = 10;
	public float pathCost;

  	public float xOffset = 0.862f;
	public float zOffset = 0.744f;

/*	void Awake () {
		if (map == null) {
			DontDestroyOnLoad (gameObject);
			map = this;
		}
		else if (map != this) {
			Destroy(gameObject);
		}

	}
*/
	void Start() {
		GameObject GameControl = GameObject.Find ("GameController");
		buttonScripts = GameControl.GetComponent<ButtonScripts> ();
		buttonScripts.map = this;
//		buttonScripts = ButtonScripts.buttonScript;
		GameObject Scripts = GameObject.Find ("_Scripts");
		SummonStartEnemies summonStartEnemies = Scripts.GetComponent<SummonStartEnemies> ();
		SummonStartPlayers summonStartPlayers = Scripts.GetComponent<SummonStartPlayers> ();
		GameObject[] PlayersAlive =  GameObject.FindGameObjectsWithTag("Player");
//		GameObject.Find ("Players").SetActive(true);
		GenerateMapData();
//		settings.TileObjects ();
		GeneratePathfindingGraph();
		GenerateMapVisual();
//		CreateEnemies();
		
		foreach (GameObject Player in PlayersAlive) {
			PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
//			player.map = GameObject.Find ("Map").GetComponent<TileMap>();
//			player.map = map;
			selecterPlayer = player.name;
			CheckVisibleTiles();
		}
		selecterPlayer = "Player1";

		buttonScripts.ShowVisibleTiles();

		summonStartPlayers.CreatePlayers();
		SelectedDeck ();
//		GameController.control.BuildInitialPlayerDeck();
//		gameController.AddEnemyToMap();
		summonStartEnemies.StartEnemies();
		summonStartEnemies.CreateEnemies();
//		CheckVisibleTiles();


		
		GameObject[] EnemysAlive =  GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject enemy in EnemysAlive) {
		enemy.GetComponent<BaseEnemy> ().StartWalkable();
		}
		GameObject[] Players =  GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject player in Players) {
		player.GetComponent<PlayableCharacter> ().StartWalkable();
		}
//		buttonScripts.AttackButtonDisable();
	}

	void SelectedDeck()
	{
		if (selectedDeck == 1) {
			GameController.control.BuildInitialPlayerDeck();
		}
		else if (selectedDeck == 2) {
			GameController.control.BuildCustomDeck();
		}
	}

	void GenerateMapData() {

		tiles = new int[mapSizeX,mapSizeY];
		int x,y;



		// Initialize our map tiles to be grass
		for(x=0; x < mapSizeX; x++) {
			for(y=0; y < mapSizeY; y++) {
				tiles[x,y] = 0;
			}
		}
//		Debug.Log (mapSettingAreas.Length);
		// Make a big swamp area
//		mapSettingAreas.Length;
		//For lauseke määrittääkseen jokaisen editorissa määritellyn aleen kohdat. 
		//Tämä ajteaan uuden mapin alkaessa, jotta saadaan oikeat materiaalit oikeisiin kohtiin.
		for (int i = 0; i < mapSettingAreas.Length; i++) {
			

			int startX = mapSettingAreas [i].startX;
			int endX = mapSettingAreas [i].endX;
			int startY = mapSettingAreas [i].startY;
			int endY = mapSettingAreas [i].endY;
			int tileType = mapSettingAreas [i].tileType; 

			for(x=startX; x <= endX; x++) {
				for(y=startY; y < endY; y++) {
					tiles[x,y] = tileType;
				}
			}

		}

			
	}

	public float CostToEnterTile(int sourceX, int sourceY, int targetX, int targetY) {

		TileType tt = tileTypes[ tiles[targetX,targetY] ];
		string currentTile = "Hex_" + targetX + "_" + targetY;
		bool clicableTileWalkable = GameObject.Find (currentTile).GetComponent<ClickableTile> ().isWalkable;

		if(UnitCanEnterTile(targetX, targetY) == false || !clicableTileWalkable )
			return Mathf.Infinity;

		float cost = tt.movementCost;
/*
		if( sourceX!=targetX && sourceY!=targetY) {
			// We are moving diagonally!  Fudge the cost for tie-breaking
			// Purely a cosmetic thing!
			cost += 0.001f;
		}
*/
		return cost;

	}

	void GeneratePathfindingGraph() {
		// Initialize the array
		graph = new Node[mapSizeX,mapSizeY];

		// Initialize a Node for each spot in the array
		for(int x=0; x < mapSizeX; x++) {
			for(int y=0; y < mapSizeY; y++) {
				graph[x,y] = new Node();
				graph[x,y].x = x;
				graph[x,y].y = y;
			}
		}



		// Now that all the nodes exist, calculate their neighbours
		for(int x=0; x < mapSizeX; x++) {
			for(int y=0; y < mapSizeY; y++) {
				NeighboursCalculate(x, y);


			}
		}
	}
				
	void GenerateMapVisual() 
	{
//		Debug.Log("GenerateMapVisual");
		for (int x = 0; x < mapSizeX; x++) 
		{
			for (int y = 0; y < mapSizeY; y++) 
			{

				float xPos = x * xOffset;

				if (y % 2 == 1) {
					xPos += xOffset / 2f;
				}
				TileType tt = tileTypes[ tiles[x,y] ];
				GameObject go = (GameObject)Instantiate( tt.tileVisualPrefab, new Vector3(xPos, y * zOffset, 0), new Quaternion (0, 180, 0, 0));

				ClickableTile ct = go.GetComponent<ClickableTile>();
				ct.tileX = x;
				ct.tileY = y;
				ct.map = this;
				go.name = "Hex_" + x + "_" + y;

				go.transform.SetParent(this.transform);
				go.tag = "Hex";

//				go.isStatic = true;

			}
		}
	}




	public Vector3 TileCoordToWorldCoord(float x, float y) {
		float xPos = x * xOffset;
		float yPos = y * zOffset;

		if (y % 2 == 1) {
			xPos = xPos + xOffset / 2f;
		}
	
		return new Vector3(xPos, yPos, 0);
	}

	public bool UnitCanEnterTile(int x, int y) {

		// We could test the unit's walk/hover/fly type against various
		// terrain flags here to see if they are allowed to enter the tile.

		return tileTypes[ tiles[x,y] ].isWalkable;
	}

	public void GeneratePathToPlayer(int x, int y) {
		pathCost = 0;
//		GameObject SelectedUnit = GameObject.Find(selectedCharacter);
		GameObject SelectedUnit = GameObject.Find(selecterPlayer);
		// Clear out our unit's old path.

		SelectedUnit.GetComponent<PlayableCharacter>().currentPath = null;
		


		if( UnitCanEnterTile(x,y) == false) {
			// We probably clicked on a mountain or something, so just quit out.
			return;
		}

		Dictionary<Node, float> dist = new Dictionary<Node, float>();
		Dictionary<Node, Node> prev = new Dictionary<Node, Node>();

		// Setup the "Q" -- the list of nodes we haven't checked yet.
		List<Node> unvisited = new List<Node>();
		
		Node source = graph[
		     				SelectedUnit.GetComponent<PlayableCharacter>().PlayerClass.TileX, 
		                    SelectedUnit.GetComponent<PlayableCharacter>().PlayerClass.TileY
		                    ];
		
		Node target = graph[
		                    x, 
		                    y
		                    ];
		
		dist[source] = 0;
		prev[source] = null;

		// Initialize everything to have INFINITY distance, since
		// we don't know any better right now. Also, it's possible
		// that some nodes CAN'T be reached from the source,
		// which would make INFINITY a reasonable value
		foreach(Node v in graph) {
			if(v != source) {
				dist[v] = Mathf.Infinity;
				prev[v] = null;
			}

			unvisited.Add(v);
		}

		while(unvisited.Count > 0) {
			// "u" is going to be the unvisited node with the smallest distance.
			Node u = null;

			foreach(Node possibleU in unvisited) {
				if(u == null || dist[possibleU] < dist[u]) {
					u = possibleU;
				}
			}

			if(u == target) {
				break;	// Exit the while loop!
			}

			unvisited.Remove(u);

			foreach(Node v in u.neighbours) {
				//float alt = dist[u] + u.DistanceTo(v);
				float alt = dist[u] + CostToEnterTile(u.x, u.y, v.x, v.y);
				if( alt < dist[v] ) {
					dist[v] = alt;
					prev[v] = u;
				}
			}
		}

		// If we get there, the either we found the shortest route
		// to our target, or there is no route at ALL to our target.

		if(prev[target] == null) {
			// No route between our target and the source
			return;
		}

//		List<Node> currentPath = new List<Node>();
		currentPath = new List<Node>();

		Node curr = target;

		// Step through the "prev" chain and add it to our path
		while(curr != null) {
			currentPath.Add(curr);
			curr = prev[curr];
		}

		// Right now, currentPath describes a route from out target to our source
		// So we need to invert it!

		currentPath.Reverse();
		
		SelectedUnit.GetComponent<PlayableCharacter>().currentPath = currentPath;

		currentPathCount = currentPath.Count;
		if (currentPathCount > 0 ) {
			for (int i = 0; i < currentPathCount - 1; i++) {
				float moveCost = CostToEnterTile(currentPath[i].x, currentPath[i].y, currentPath[i+1].x, currentPath[i+1].y);
				pathCost += moveCost;
//				Debug.Log("Movecost " + pathCost);
				
			}
		}
		

	}
	public void GeneratePathToEnemy(int x, int y) {
//		GameObject SelectedUnit = GameObject.Find(selectedCharacter);
		GameObject SelectedUnit = GameObject.Find(selectedEnemy);

		// Clear out our unit's old path.

		SelectedUnit.GetComponent<BaseEnemy>().currentPath = null;
		
		

		if( UnitCanEnterTile(x,y) == false ) {
			// We probably clicked on a mountain or something, so just quit out.
			return;
		}

		Dictionary<Node, float> dist = new Dictionary<Node, float>();
		Dictionary<Node, Node> prev = new Dictionary<Node, Node>();

		// Setup the "Q" -- the list of nodes we haven't checked yet.
		List<Node> unvisited = new List<Node>();
		
		Node source = graph[
		     				SelectedUnit.GetComponent<BaseEnemy>().TileX, 
		                    SelectedUnit.GetComponent<BaseEnemy>().TileY
		                    ];
		
		Node target = graph[
		                    x, 
		                    y
		                    ];
		
		dist[source] = 0;
		prev[source] = null;

		// Initialize everything to have INFINITY distance, since
		// we don't know any better right now. Also, it's possible
		// that some nodes CAN'T be reached from the source,
		// which would make INFINITY a reasonable value
		foreach(Node v in graph) {
			if(v != source) {
				dist[v] = Mathf.Infinity;
				prev[v] = null;
			}

			unvisited.Add(v);
		}

		while(unvisited.Count > 0) {
			// "u" is going to be the unvisited node with the smallest distance.
			Node u = null;

			foreach(Node possibleU in unvisited) {
				if(u == null || dist[possibleU] < dist[u]) {
					u = possibleU;
				}
			}

			if(u == target) {
				break;	// Exit the while loop!
			}

			unvisited.Remove(u);

			foreach(Node v in u.neighbours) {
				//float alt = dist[u] + u.DistanceTo(v);
				float alt = dist[u] + CostToEnterTile(u.x, u.y, v.x, v.y);
				if( alt < dist[v] ) {
					dist[v] = alt;
					prev[v] = u;
				}
			}
		}

		// If we get there, the either we found the shortest route
		// to our target, or there is no route at ALL to our target.

		if(prev[target] == null) {
			// No route between our target and the source
			return;
		}

//		List<Node> currentPath = new List<Node>();
		currentPath = new List<Node>();

		Node curr = target;

		// Step through the "prev" chain and add it to our path
		while(curr != null) {
			currentPath.Add(curr);
			curr = prev[curr];
		}

		// Right now, currentPath describes a route from out target to our source
		// So we need to invert it!

		currentPath.Reverse();

		SelectedUnit.GetComponent<BaseEnemy>().currentPath = currentPath;
	}
	public void NeighboursCalculate(int x, int y){
		if (x > 0)
		 {
			graph [x, y].neighbours.Add (graph [x - 1, y]);  // Vasen -- Tomii
					
			if (y % 2 == 0) {
				if (y > 0)
					graph [x, y].neighbours.Add (graph [x - 1, y - 1]); // Vasen alas 
				if (y < mapSizeY - 1)
				graph [x, y].neighbours.Add (graph [x - 1, y + 1]); // Vasen ylös 
			}
		}
		if(y % 2 != 0)
		{
			if(y > 0)
				graph[x,y].neighbours.Add( graph[x, y-1] ); // Vasen alas 
			if(y < mapSizeY-1)
				graph[x,y].neighbours.Add( graph[x, y+1] ); // Vasen ylös 
		}
				

		if (x < mapSizeX - 1) 
		{
			graph [x, y].neighbours.Add (graph [x + 1, y]); // oikea -- Toimii
			if (y % 2 != 0) { 
				if (y > 0)
					graph [x, y].neighbours.Add (graph [x + 1, y - 1]); // oikea alas 
				if (y < mapSizeY - 1)
					graph [x, y].neighbours.Add (graph [x + 1, y + 1]); // oikea ylös
					}
		}
		if(y % 2 == 0) 
		{ 
			if(y > 0)
				graph[x,y].neighbours.Add( graph[x, y-1] ); // oikea alas
			if(y < mapSizeY-1)
				graph[x,y].neighbours.Add( graph[x, y+1] );  // oikea ylös 
		}
	}
	public void CheckVisibleTiles()
	{
		GameObject DrawLine = GameObject.Find ("LineRenderer");
		DrawLine drawLine = DrawLine.GetComponent<DrawLine> ();
		visibleTiles = new List<Node>();
		drawLine.skillDistance = 20;
		GameObject Player = GameObject.Find (selecterPlayer);
		PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
//		player.VisibleNodes = null;
		GameObject[] Tiles = GameObject.FindGameObjectsWithTag("Hex");
		foreach (GameObject tile in Tiles) {
			ClickableTile clickableTile = tile.GetComponent<ClickableTile> ();
			bool allowed = drawLine.CalculateLine(player.PlayerClass.TileX, player.PlayerClass.TileY, clickableTile.tileX, clickableTile.tileY);
			if (allowed) {
//				clickableTile.hexVisible = true;
				visibleTiles.Add(graph[clickableTile.tileX, clickableTile.tileY]);

			} else {
//				clickableTile.hexVisible = false;

			}
		}
		player.VisibleNodes = visibleTiles;
	}
}
