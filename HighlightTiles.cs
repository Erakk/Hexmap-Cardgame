using UnityEngine;
using System.Collections;

public class HighlightTiles : MonoBehaviour {

	public TileMap map;
	public Material hoverMaterialAllowed; // tile skilleissä näyttää tilet joihin voi targettaa
	public Material showMaterialInRange; // normaali rangesta riippuvainen tile
	public Material hoverMaterialMouseInRangeNotAllowed; // esim singletargetissa jos vie hiiren "range" maalattun tileen, johon ei voi iskee
	public Material hoverMaterialMouseTileAffected; // tileen tulee vaikutus ja tyyppi liikkuu tähän
	public Material materialWillBeHit; // Esim leap salm AOE tai iskussa hiiri on alowed tilen päällä
	public int tileX;
	public int tileY;
	private int skillRange;
	// Use this for initialization
	void Start () {
//		map = TileMap.map;
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void HideAllowedTiles()
	{
		GameObject[] ClickableTiles = GameObject.FindGameObjectsWithTag("Hex");
		foreach (GameObject v in ClickableTiles) 
		{
			ClickableTile clickableTile = v.GetComponent<ClickableTile> ();
			if (clickableTile.rangeTargetted) 
			{
				Material[] mat = clickableTile.GetComponent<Renderer>().materials;
				mat[1] = hoverMaterialAllowed;
				clickableTile.GetComponent<Renderer>().materials = mat;	
				clickableTile.willTakeHit = false;	
			} 
			else 
			{
				Material[] mat = clickableTile.GetComponent<Renderer>().materials;
				mat[1] = clickableTile.primaryMaterial;
				clickableTile.GetComponent<Renderer>().materials = mat;	
				clickableTile.willTakeHit = false;		
			}
		}
	}	
	public void HideAllAllowedTiles()
	{
		GameObject[] ClickableTiles = GameObject.FindGameObjectsWithTag("Hex");
		foreach (GameObject v in ClickableTiles) 
		{
			ClickableTile clickableTile = v.GetComponent<ClickableTile> ();

			Material[] mat = clickableTile.GetComponent<Renderer>().materials;
			mat[1] = clickableTile.primaryMaterial;
			clickableTile.GetComponent<Renderer>().materials = mat;	
			clickableTile.willTakeHit = false;			
			
		}
	}	
	public void HighlightTilesInRange()
	{
		GameObject CardDropArea = GameObject.Find ("CardDropArea");
		DropZone dropZone = CardDropArea.GetComponent<DropZone>();
		GameObject Player = GameObject.Find (map.selecterPlayer);
		PlayableCharacter player = Player.GetComponent<PlayableCharacter>();
		skillRange = dropZone.range;
		Vector3 retPlayer = new Vector3();
		Vector3 retTarget = new Vector3();

		retPlayer.y = player.PlayerClass.TileY;
		retPlayer.z = player.PlayerClass.TileX - (player.PlayerClass.TileY - (Mathf.Abs(player.PlayerClass.TileY) % 2)) / 2;
		retPlayer.x = - retPlayer.y - retPlayer.z;
		
		GameObject[] Tiles = GameObject.FindGameObjectsWithTag("Hex");
		foreach (GameObject Tile in Tiles) {
			ClickableTile tile = Tile.GetComponent<ClickableTile> ();
			retTarget.y = tile.tileY;
			retTarget.z = tile.tileX - (tile.tileY - (Mathf.Abs(tile.tileY) % 2)) / 2;
			retTarget.x = - retTarget.y - retTarget.z;
			int d = (int)((Mathf.Abs(retPlayer.x - retTarget.x) + Mathf.Abs(retPlayer.y - retTarget.y) + Mathf.Abs(retPlayer.z - retTarget.z)) / 2);
			if (d<= skillRange && tile.hexVisible && map.UnitCanEnterTile(tile.tileX, tile.tileY) == true ) {
//				Material[] mat = tile.GetComponent<Renderer>().materials;
//				mat[1] = hoverMaterialAllowed;
//				tile.GetComponent<Renderer>().materials = mat;
				tile.rangeTargetted = true;
			} else {
				tile.rangeTargetted = false;
			}
		}

	}
	public void ColorTargettedTiles()
	{

		GameObject[] Tiles = GameObject.FindGameObjectsWithTag("Hex");
		foreach (GameObject Tile in Tiles) {
			ClickableTile tile = Tile.GetComponent<ClickableTile> ();
			if (tile.rangeTargetted) {
				Material[] mat = tile.GetComponent<Renderer>().materials;
				mat[1] = hoverMaterialAllowed;
				tile.GetComponent<Renderer>().materials = mat;
				tile.willTakeHit = false;		
			}
		}

	}
	public void ShowAllowedTilesMovement()
	{
//		Debug.Log("test");
//		GameObject Unit = GameObject.Find (selectedCharacter);
		GameObject Player = GameObject.Find (map.selecterPlayer);

		PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();

		Vector3 ret = new Vector3();
		Vector3 retTarget = new Vector3();

		ret.y = player.PlayerClass.TileY;
		ret.z = player.PlayerClass.TileX - (player.PlayerClass.TileY - (Mathf.Abs(player.PlayerClass.TileY) % 2)) / 2;
		ret.x = - ret.y - ret.z;
		
		GameObject[] ClickableTiles = GameObject.FindGameObjectsWithTag("Hex");

//		foreach (Node v in graph) {
		foreach (GameObject v in ClickableTiles) {

			ClickableTile clickableTile = v.GetComponent<ClickableTile> ();

		
//			int targetX = (int)clickableTile.worldPos.x; 
//			int targetY = (int)clickableTile.worldPos.y; 
//			int targetZ = (int)clickableTile.worldPos.z; 
			retTarget.y = clickableTile.tileY;
			retTarget.z = clickableTile.tileX - (clickableTile.tileY - (Mathf.Abs(clickableTile.tileY) % 2)) / 2;
			retTarget.x = - retTarget.y - retTarget.z;
			if (clickableTile.hexVisible) {
				
			}
			
			player.PlayerClass.Distance = (int)((Mathf.Abs(ret.x - retTarget.x) + Mathf.Abs(ret.y - retTarget.y) + Mathf.Abs(ret.z - retTarget.z)) / 2);
//			Debug.Log(unit.distance);
//			string currentTile = "Hex_" + v.x + "_" + v.y;
//			bool clicableTile = GameObject.Find (currentTile).GetComponent<ClickableTile> ().isNotWalkable;
			bool clicableTileWalkable = clickableTile.isWalkable;
//			Debug.Log("test");
//			if(unit.distance <= unit.moveSpeed && UnitCanEnterTile(v.x, v.y) == true && !clicableTile){	
//			if(currentPathCount <= unit.remainingMovement + 1 && UnitCanEnterTile(clickableTile.tileX, clickableTile.tileY) == true && !clicableTile && currentPath != null && clickableTile.hexVisible){	
//			if(unit.distance <= unit.moveSpeed && UnitCanEnterTile(clickableTile.tileX, clickableTile.tileY) == true && !clicableTile && currentPath != null && clickableTile.hexVisible){	
			if( player.PlayerClass.Distance <= player.PlayerClass.RemainingMovement && map.UnitCanEnterTile(clickableTile.tileX, clickableTile.tileY) == true && clicableTileWalkable && clickableTile.hexVisible){	
				map.GeneratePathToPlayer(clickableTile.tileX, clickableTile.tileY);
//				if (map.currentPathCount <= player.PlayerClass.RemainingMovement + 1 && map.pathCost <= player.PlayerClass.RemainingMovement) {
				if (map.pathCost <= player.PlayerClass.RemainingMovement) {
					Material[] mat = clickableTile.GetComponent<Renderer>().materials;
					mat[1] = hoverMaterialAllowed;
					clickableTile.GetComponent<Renderer>().materials = mat;
					clickableTile.rangeTargetted = true;
					clickableTile.willTakeHit = false;
				}
				else {
				clickableTile.rangeTargetted = false;
				}
			} else {
				clickableTile.rangeTargetted = false;
			}

		}
		player.currentPath = null;
	}
	public void ShowHoveringTileMovement()
	{
		GameObject Tile = GameObject.Find ("Hex_" + tileX + "_" + tileY);
		ClickableTile tile = Tile.GetComponent<ClickableTile>();
		if (tile.rangeTargetted) {
			Material[] mat = tile.GetComponent<Renderer>().materials;
			mat[1] = hoverMaterialMouseTileAffected;
			tile.GetComponent<Renderer>().materials = mat;
			tile.willTakeHit = false;
		}
		
	}

	public void ShowHoveringTileSkill()
	{
		GameObject Tile = GameObject.Find ("Hex_" + tileX + "_" + tileY);
		ClickableTile tile = Tile.GetComponent<ClickableTile>();
		if (tile.rangeTargetted) {
			Material[] mat = tile.GetComponent<Renderer>().materials;
			mat[1] = hoverMaterialMouseTileAffected;
			tile.GetComponent<Renderer>().materials = mat;
			tile.willTakeHit = false;
		}
	}
	public void ShowTilesThatWillBeHitSkill()
	{
		GameObject Tile = GameObject.Find ("Hex_" + tileX + "_" + tileY);
		ClickableTile tile = Tile.GetComponent<ClickableTile>();

		Material[] mat = tile.GetComponent<Renderer>().materials;
		mat[1] = materialWillBeHit;
		tile.GetComponent<Renderer>().materials = mat;		
		tile.willTakeHit = true;

	}
	public void ShowTilesThatWillBeHitAreaSkill()
	{
		GameObject Tile = GameObject.Find ("Hex_" + tileX + "_" + tileY);
		ClickableTile tile = Tile.GetComponent<ClickableTile>();
//		if (tile.rangeTargetted) {
		Material[] mat = tile.GetComponent<Renderer>().materials;
		mat[1] = materialWillBeHit;
		tile.GetComponent<Renderer>().materials = mat;
		tile.willTakeHit = true;
		
//		}

	}
	public void ShowTilesThatWillNotBeHitSkill()
	{
		GameObject Tile = GameObject.Find ("Hex_" + tileX + "_" + tileY);
		ClickableTile tile = Tile.GetComponent<ClickableTile>();

		if (tile.rangeTargetted) {		
		Material[] mat = tile.GetComponent<Renderer>().materials;
		mat[1] = hoverMaterialMouseInRangeNotAllowed;
		tile.GetComponent<Renderer>().materials = mat;
		tile.willTakeHit = false;	
//		tile.lineTargetted = true;
		}
	}
	public void ShowTilesThatCanBeHit()
	{
		GameObject Tile = GameObject.Find ("Hex_" + tileX + "_" + tileY);
		ClickableTile tile = Tile.GetComponent<ClickableTile>();

		Material[] mat = tile.GetComponent<Renderer>().materials;
		mat[1] = hoverMaterialAllowed;
		tile.GetComponent<Renderer>().materials = mat;
		tile.willTakeHit = false;

	}

	public void ShowTilesThatInRangeGeneral(int startX, int startY)
	{
		Vector3 ret = new Vector3();
		Vector3 retTarget = new Vector3();

		ret.y = startY;
		ret.z = startX - (startY - (Mathf.Abs(startY) % 2)) / 2;
		ret.x = - ret.y - ret.z;
		
		GameObject[] ClickableTiles = GameObject.FindGameObjectsWithTag("Hex");
		foreach (GameObject v in ClickableTiles) {
			ClickableTile clickableTile = v.GetComponent<ClickableTile> ();
			retTarget.y = clickableTile.tileY;
			retTarget.z = clickableTile.tileX - (clickableTile.tileY - (Mathf.Abs(clickableTile.tileY) % 2)) / 2;
			retTarget.x = - retTarget.y - retTarget.z;
			int d = (int)((Mathf.Abs(ret.x - retTarget.x) + Mathf.Abs(ret.y - retTarget.y) + Mathf.Abs(ret.z - retTarget.z)) / 2);
			if (d <= skillRange && clickableTile.hexVisible) {
				Material[] mat = clickableTile.GetComponent<Renderer>().materials;
				mat[1] = showMaterialInRange;
				clickableTile.GetComponent<Renderer>().materials = mat;
//				clickableTile.isInrange = true;
				clickableTile.rangeTargetted = true;
				tileX = clickableTile.tileX;
				tileY = clickableTile.tileY;
				if (clickableTile.enemyTarget) {
					CheckEnemiesInSkillRange();
				} else {
					CheckPlayersInSkillRange();
				}

			} else {
//				clickableTile.isInrange = false;
				clickableTile.rangeTargetted = false;
			}
		}
	}	

	public void CheckEnemiesInSkillRange()
	{
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject Enemy in Enemies) {
			BaseEnemy enemy = Enemy.GetComponent<BaseEnemy> ();
			if (enemy.TileX == tileX && enemy.TileY == tileY) {
				GameObject Tile = GameObject.Find ("Hex_" + tileX + "_" + tileY);
				ClickableTile tile = Tile.GetComponent<ClickableTile>();
				Material[] mat = tile.GetComponent<Renderer>().materials;
				mat[1] = hoverMaterialAllowed;
				tile.GetComponent<Renderer>().materials = mat;
				tile.canAttack = true;
				tile.willTakeHit = false;
			}
		}
	}
	public void CheckPlayersInSkillRange()
	{
		GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject Player in Players) {
			PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
			if (player.PlayerClass.TileX == tileX && player.PlayerClass.TileY == tileY) {
				GameObject Tile = GameObject.Find ("Hex_" + tileX + "_" + tileY);
				ClickableTile tile = Tile.GetComponent<ClickableTile>();
				Material[] mat = tile.GetComponent<Renderer>().materials;
				mat[1] = hoverMaterialAllowed;
				tile.GetComponent<Renderer>().materials = mat;
				tile.canAttack = true;
				tile.willTakeHit = false;
//				player.isSelected = true;
			}
		}
	}

	public void ShowTilesThatInTrapRange(int startX, int startY)
	{
		Vector3 ret = new Vector3();
		Vector3 retTarget = new Vector3();

		ret.y = startY;
		ret.z = startX - (startY - (Mathf.Abs(startY) % 2)) / 2;
		ret.x = - ret.y - ret.z;
		
		GameObject[] ClickableTiles = GameObject.FindGameObjectsWithTag("Hex");
		foreach (GameObject v in ClickableTiles) {
			ClickableTile clickableTile = v.GetComponent<ClickableTile> ();
			retTarget.y = clickableTile.tileY;
			retTarget.z = clickableTile.tileX - (clickableTile.tileY - (Mathf.Abs(clickableTile.tileY) % 2)) / 2;
			retTarget.x = - retTarget.y - retTarget.z;
			int d = (int)((Mathf.Abs(ret.x - retTarget.x) + Mathf.Abs(ret.y - retTarget.y) + Mathf.Abs(ret.z - retTarget.z)) / 2);
			if (d<= skillRange && clickableTile.hexVisible && map.UnitCanEnterTile(clickableTile.tileX, clickableTile.tileY) == true && d != 0) {
				Material[] mat = clickableTile.GetComponent<Renderer>().materials;
				mat[1] = hoverMaterialAllowed;
				clickableTile.GetComponent<Renderer>().materials = mat;
				clickableTile.rangeTargetted = true;
				clickableTile.canAttack = true;
				clickableTile.willTakeHit = false;
//				tileX = clickableTile.tileX;
//				tileY = clickableTile.tileY;

			} else {

				clickableTile.rangeTargetted = false;
			}
		}
	}	
}
