using UnityEngine;
using System.Collections.Generic;

public class DrawLine : MonoBehaviour {

	private LineRenderer lineRenderer;	
	public TileMap map;	
	public Transform origin;
	public Transform destination;
	public Vector3 startPosition;
	public Vector3 endPosition;

	public int skillDistance;
	
	void Start () {
//		map = TileMap.map;
		lineRenderer = GetComponent<LineRenderer>();
	}
	
	public void Draw()
	{
		GameObject Player = GameObject.Find (map.selecterPlayer);
		PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
		float posY = player.PlayerClass.TileY * 0.764f;
		float posX = player.PlayerClass.TileX * 0.882f;		
		if (player.PlayerClass.TileY % 2 == 1) {
			posX += 0.882f / 2f;
		}	
		startPosition = new Vector3(posX,posY,-0.1f);
		lineRenderer.SetPosition(0, startPosition);
		lineRenderer.SetPosition(1, endPosition);
	}

	public void DeleteDraw()
	{
		startPosition = new Vector3(0,0,-0.1f);
		endPosition = new Vector3(0,0,-0.1f);
		lineRenderer.SetPosition(0, startPosition);
		lineRenderer.SetPosition(1, endPosition);

		
	}
	
	static Vector3 CubeLerp(Vector3 a, Vector3 b, float t)
	{
		Vector3 cube = new Vector3();
		cube.x = (a.x + (b.x - a.x) * t);
		cube.y = (a.y + (b.y - a.y) * t);
		cube.z = (a.z + (b.z - a.z) * t);
		return cube;
	}

	public bool CalculateLine(int startPointX, int startPointY ,int endPointX, int endPointY)
	{
		//TODO
		//Visio laskeminen pitää tehdä uudestaan
		Vector3 startLoc = new Vector3();
		Vector3 endLoc = new Vector3();
		bool walkable = true;
		startLoc.y = startPointY;
		startLoc.z = startPointX - (startPointY - (Mathf.Abs(startPointY) % 2)) / 2;
		startLoc.x = - startLoc.y - startLoc.z;
		endLoc.y = endPointY;
		endLoc.z = endPointX - (endPointY - (Mathf.Abs(endPointY) % 2)) / 2;
		endLoc.x = - endLoc.y - endLoc.z;
		int n = (int)(Mathf.Abs(startLoc.x - endLoc.x) + Mathf.Abs(startLoc.y - endLoc.y) + Mathf.Abs(startLoc.z - endLoc.z)) / 2;
//		if (n <= skillDistance) {
			Vector3 [] tiles = new Vector3[n];	
			for (int i = 0; i < n; i++) {
				float a = (1.0f/n) * (i+1);
				tiles[i] = CubeLerp(startLoc,endLoc, a);
				GameObject[] Tiles = GameObject.FindGameObjectsWithTag("Hex");
				foreach (GameObject tile in Tiles) {
					ClickableTile clickableTile = tile.GetComponent<ClickableTile> ();
					if (tiles[i].x >= clickableTile.worldPos.x - 0.5f && tiles[i].y <= clickableTile.worldPos.y + 0.50f ) {
						if (tiles[i].y >= clickableTile.worldPos.y - 0.5f && tiles[i].y <= clickableTile.worldPos.y + 0.50f) {
							if (tiles[i].z >= clickableTile.worldPos.z - 0.5f && tiles[i].z <= clickableTile.worldPos.z + 0.50f) {
								walkable = map.UnitCanEnterTile(clickableTile.tileX, clickableTile.tileY);
								if (walkable == false) {
									return walkable;
								}
							}
						}	
					}	
				}
			}
//		}
		return walkable;
	}


	public void CheckLineTiles(int startPointX, int startPointY ,int endPointX, int endPointY)
	{
//		GameObject Tile = GameObject.Find ("Hex_" + endTileX + "_" + endTileX);
//		ClickableTile tile = Tile.GetComponent<ClickableTile> ();
		Vector3 startLoc = new Vector3();
		Vector3 endLoc = new Vector3();
		startLoc.y = startPointY;
		startLoc.z = startPointX - (startPointY - (Mathf.Abs(startPointY) % 2)) / 2;
		startLoc.x = - startLoc.y - startLoc.z;
		endLoc.y = endPointY;
		endLoc.z = endPointX - (endPointY - (Mathf.Abs(endPointY) % 2)) / 2;
		endLoc.x = - endLoc.y - endLoc.z;
		int n = (int)(Mathf.Abs(startLoc.x - endLoc.x) + Mathf.Abs(startLoc.y - endLoc.y) + Mathf.Abs(startLoc.z - endLoc.z)) / 2;
		
		Vector3 [] tiles = new Vector3[n];	
				
			for (int i = 0; i < n; i++) {
				float a = (1.0f/n) * (i+1);
				tiles[i] = CubeLerp(startLoc,endLoc, a);
				GameObject[] Tiles = GameObject.FindGameObjectsWithTag("Hex");
					foreach (GameObject tile in Tiles) {
						ClickableTile clickableTile = tile.GetComponent<ClickableTile> ();
//						clickableTile.lineTargetted = false;	
						Vector3 hexLoc = new Vector3();
						hexLoc.y = clickableTile.tileY;
						hexLoc.z = clickableTile.tileX - (clickableTile.tileY - (Mathf.Abs(clickableTile.tileY) % 2)) / 2;
						hexLoc.x = - hexLoc.y - hexLoc.z;
						int m = (int)(Mathf.Abs(startLoc.x - hexLoc.x) + Mathf.Abs(startLoc.y - hexLoc.y) + Mathf.Abs(startLoc.z - hexLoc.z)) / 2;
						if (tiles[i].x >= clickableTile.worldPos.x - 0.5f && tiles[i].y <= clickableTile.worldPos.y + 0.50f ) {
							if (tiles[i].y >= clickableTile.worldPos.y - 0.5f && tiles[i].y <= clickableTile.worldPos.y + 0.50f) {
								if (tiles[i].z >= clickableTile.worldPos.z - 0.5f && tiles[i].z <= clickableTile.worldPos.z + 0.50f) {
									if (m <= skillDistance) {
										GameObject HighlightTiles = GameObject.Find ("_Scripts");
										HighlightTiles highlightTiles = HighlightTiles.GetComponent<HighlightTiles> ();
										highlightTiles.tileX = clickableTile.tileX;
										highlightTiles.tileY = clickableTile.tileY;
										clickableTile.lineTargetted = true;								
										highlightTiles.ShowTilesThatWillNotBeHitSkill();

								}
						}	
					}	
				}
			}
		}

	}
	public void CheckEnemiesInLine()
	{
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject Player = GameObject.Find(map.selecterPlayer);
		PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
		Vector3 playerRet = new Vector3();
		Vector3 enemyRet = new Vector3();
		playerRet.y = player.PlayerClass.TileY;
		playerRet.z = player.PlayerClass.TileX - (player.PlayerClass.TileY - (Mathf.Abs(player.PlayerClass.TileY) % 2)) / 2;
		playerRet.x = - playerRet.y - playerRet.z;
		int minDistance = 30;
//		foreach (Node Tile in pathTiles) {
			
//		}
		foreach (GameObject Enemy in Enemies) {
			BaseEnemy enemy = Enemy.GetComponent<BaseEnemy> ();
			GameObject Tile = GameObject.Find ("Hex_" + enemy.TileX + "_" + enemy.TileY);
			ClickableTile tile = Tile.GetComponent<ClickableTile> ();
			enemy.distanceToPlayer = 30;
//			Debug.Log (tile.lineTargetted);
			if (tile.lineTargetted) {
//				Debug.Log (enemy.name);
				enemyRet.y = enemy.TileY;
				enemyRet.z = enemy.TileX - (enemy.TileY - (Mathf.Abs(enemy.TileY) % 2)) / 2;
				enemyRet.x = - enemyRet.y - enemyRet.z;
				int d = (int)(Mathf.Abs(playerRet.x - enemyRet.x) + Mathf.Abs(playerRet.y - enemyRet.y) + Mathf.Abs(playerRet.z - enemyRet.z)) / 2;
				enemy.distanceToPlayer = d;
				if (d <= minDistance) {
					minDistance = d;
				}
			}
			
		}
		foreach (GameObject Enemy in Enemies) {
			BaseEnemy enemy = Enemy.GetComponent<BaseEnemy> ();
			GameObject Tile = GameObject.Find ("Hex_" + enemy.TileX + "_" + enemy.TileY);
			ClickableTile tile = Tile.GetComponent<ClickableTile> ();
			if (enemy.distanceToPlayer == minDistance && tile.lineTargetted && enemy.distanceToPlayer != 30) {
				GameObject CardDropArea = GameObject.Find ("CardDropArea");
				DropZone dropZone = CardDropArea.GetComponent<DropZone>();
				if (dropZone.areaRange >= 1) {
					GameObject Area = GameObject.Find ("_Scripts");
					ChangeTilesArea area = Area.GetComponent<ChangeTilesArea> ();
					area.area = dropZone.areaRange;
					area.skillDistance = 30;
					area.CalculateArea(tile.tileX, tile.tileY);

				} else {
					GameObject HighlightTiles = GameObject.Find ("_Scripts");
					HighlightTiles highlightTiles = HighlightTiles.GetComponent<HighlightTiles> ();	
					highlightTiles.ShowTilesThatWillBeHitSkill();

				}

			}
		}
	}
}
