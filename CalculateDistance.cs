using UnityEngine;
using System.Collections;

public class CalculateDistance : MonoBehaviour {

	public int range;

	public void CalculateDistanceToTargets(int startPointX, int startPointY)
	{
		Vector3 startLoc = new Vector3();
		Vector3 endLoc = new Vector3();
		startLoc.y = startPointY;
		startLoc.z = startPointX - (startPointY - (Mathf.Abs(startPointY) % 2)) / 2;
		startLoc.x = - startLoc.y - startLoc.z;
		GameObject[] PlayersAlive =  GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject Player in PlayersAlive) {
			PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
			endLoc.y = player.PlayerClass.TileY;
			endLoc.z = player.PlayerClass.TileX - (player.PlayerClass.TileY - (Mathf.Abs(player.PlayerClass.TileY) % 2)) / 2;
			endLoc.x = - endLoc.y - endLoc.z;
			int distance = (int)(Mathf.Abs(startLoc.x - endLoc.x) + Mathf.Abs(startLoc.y - endLoc.y) + Mathf.Abs(startLoc.z - endLoc.z)) / 2;
			if (distance <= range) {
				GameObject Tile = GameObject.Find ("Hex_" + player.PlayerClass.TileX + "_" + player.PlayerClass.TileY);
				ClickableTile tile = Tile.GetComponent<ClickableTile> ();
				GameObject HighlightTiles = GameObject.Find ("_Scripts");
				HighlightTiles highlightTiles = HighlightTiles.GetComponent<HighlightTiles> ();
				highlightTiles.tileX = tile.tileX;
				highlightTiles.tileY = tile.tileY;
				highlightTiles.ShowHoveringTileSkill();
			}
		}
	}
}
