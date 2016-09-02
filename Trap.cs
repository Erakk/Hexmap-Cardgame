using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {
	
	public TileMap map;
	// Use this for initialization
	void Start ()
	{
//		map = TileMap.map;
	}
	
	public void CalculateTrapArea(int playerX, int playerY)
	{
		Vector3 startLoc = new Vector3();
		startLoc.y = playerY;
		startLoc.z = playerX - (playerY - (Mathf.Abs(playerY) % 2)) / 2;
		startLoc.x = - startLoc.y - startLoc.z;
		GameObject[] Tiles = GameObject.FindGameObjectsWithTag("Hex");

		foreach (GameObject tile in Tiles) {
			bool enemyInTile = false;
			ClickableTile clickableTile = tile.GetComponent<ClickableTile> ();
			Vector3 hexLoc = new Vector3();
			hexLoc.y = clickableTile.tileY;
			hexLoc.z = clickableTile.tileX - (clickableTile.tileY - (Mathf.Abs(clickableTile.tileY) % 2)) / 2;
			hexLoc.x = - hexLoc.y - hexLoc.z;
			int n = (int)(Mathf.Abs(startLoc.x - hexLoc.x) + Mathf.Abs(startLoc.y - hexLoc.y) + Mathf.Abs(startLoc.z - hexLoc.z)) / 2;
			GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Hex");
			foreach (GameObject Enemy in Enemies) {
				BaseEnemy enemy = Enemy.GetComponent<BaseEnemy>();
//				&& (enemy.TileY != clickableTile.tileY && enemy.TileX != clickableTile.tileX)
//				enemy.TileX = clickableTile.tileX;
//				enemy.TileY = clickableTile.tileY;
				if (enemy.TileY == clickableTile.tileY && enemy.TileX == clickableTile.tileX) {
					enemyInTile = true;
				}
			}
			if (n == 1 && enemyInTile == false ) {
				GameObject HighlightTiles = GameObject.Find ("_Scripts");
				HighlightTiles highlightTiles = HighlightTiles.GetComponent<HighlightTiles> ();
				highlightTiles.tileX = clickableTile.tileX;
				highlightTiles.tileY = clickableTile.tileY;
				highlightTiles.ShowHoveringTileSkill ();
			}
		}
	}

	public void TrapActivate()
	{
		GameObject ButtonScripts = GameObject.Find ("ButtonsCanvas");
		ButtonScripts buttonScripts = ButtonScripts.GetComponent<ButtonScripts> ();
		GameObject CardDropArea = GameObject.Find ("CardDropArea");
		DropZone dropZone = CardDropArea.GetComponent<DropZone>();
		GameObject Enemy = GameObject.Find(map.selectedEnemy);
		BaseEnemy enemy = Enemy.GetComponent<BaseEnemy>();
		HealthBar enemyHpBar = enemy.GetComponent<HealthBar> ();
		GameObject Tile = GameObject.Find ("Hex_" + enemy.TileX + "_" + enemy.TileY);
		ClickableTile tile = Tile.GetComponent<ClickableTile>();
		buttonScripts.CheckDropZone();
		enemyHpBar.CurHealth -= (tile.trapDamage / enemy.HpPointsMax) * 100;
		enemyHpBar.SetHealthBarEnemy();
//		map.CheckVisibleTiles();
		enemyHpBar.parentName = map.selectedEnemy;
		enemyHpBar.KillUnit();
		dropZone.effect = tile.trapEffect;
		dropZone.RunEffect();
	}
}
