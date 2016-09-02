using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ChangeTilesArea : MonoBehaviour {

	public int area = 2;
	public int tileX;
	public int tileY;
	public TileMap map;
	public int skillDistance = 6;
/*
	public void ChangeArea()
	{
		map.CalculateArea();
	}
*/	
	void Start ()
	{
//		map = TileMap.map;
	}

	public void CalculateArea(int targetX, int targetY)
	{
		Vector3 ret = new Vector3();
		Vector3 unitRet = new Vector3();
		GameObject Player = GameObject.Find (map.selecterPlayer);
		PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
		int distanceFromMiddle;
		int distanceFromPlayer;
		ret.y = targetY;
		ret.z = targetX - (targetY - (Mathf.Abs(targetY) % 2)) / 2;
		ret.x = - ret.y - ret.z;

		unitRet.y = player.PlayerClass.TileY;
		unitRet.z = player.PlayerClass.TileX - (player.PlayerClass.TileY - (Mathf.Abs(player.PlayerClass.TileY) % 2)) / 2;
		unitRet.x = - unitRet.y - unitRet.z;
		distanceFromPlayer = (int)((Mathf.Abs(unitRet.x - ret.x) + Mathf.Abs(unitRet.y - ret.y) + Mathf.Abs(unitRet.z - ret.z)) / 2);		
		
		GameObject[] ClickableTiles = GameObject.FindGameObjectsWithTag("Hex");
		foreach (GameObject tile in ClickableTiles) {
		
			ClickableTile clickableTile = tile.GetComponent<ClickableTile> ();
			Vector3 hexLoc = new Vector3();
			hexLoc.y = clickableTile.tileY;
			hexLoc.z = clickableTile.tileX - (clickableTile.tileY - (Mathf.Abs(clickableTile.tileY) % 2)) / 2;
			hexLoc.x = - hexLoc.y - hexLoc.z;
			distanceFromMiddle = (int)((Mathf.Abs(ret.x - hexLoc.x) + Mathf.Abs(ret.y - hexLoc.y) + Mathf.Abs(ret.z - hexLoc.z)) / 2);		
			if (distanceFromMiddle <= area ) {
				if(distanceFromPlayer <= skillDistance){
					GameObject HighlightTiles = GameObject.Find ("_Scripts");
					HighlightTiles highlightTiles = HighlightTiles.GetComponent<HighlightTiles> ();
					highlightTiles.tileX = clickableTile.tileX;
					highlightTiles.tileY = clickableTile.tileY;
					highlightTiles.ShowTilesThatWillBeHitSkill();
				}		
			}
			
		}
	}
	public void CalculateAreaNoMid(int targetX, int targetY)
	{
		Vector3 ret = new Vector3();
		Vector3 unitRet = new Vector3();
		GameObject Player = GameObject.Find (map.selecterPlayer);
		PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
		int distanceFromMiddle;
		int distanceFromPlayer;
		ret.y = targetY;
		ret.z = targetX - (targetY - (Mathf.Abs(targetY) % 2)) / 2;
		ret.x = - ret.y - ret.z;

		unitRet.y = player.PlayerClass.TileY;
		unitRet.z = player.PlayerClass.TileX - (player.PlayerClass.TileY - (Mathf.Abs(player.PlayerClass.TileY) % 2)) / 2;
		unitRet.x = - unitRet.y - unitRet.z;
		distanceFromPlayer = (int)((Mathf.Abs(unitRet.x - ret.x) + Mathf.Abs(unitRet.y - ret.y) + Mathf.Abs(unitRet.z - ret.z)) / 2);		
		
		GameObject[] ClickableTiles = GameObject.FindGameObjectsWithTag("Hex");
		foreach (GameObject tile in ClickableTiles) {
		
			ClickableTile clickableTile = tile.GetComponent<ClickableTile> ();
			Vector3 hexLoc = new Vector3();
			hexLoc.y = clickableTile.tileY;
			hexLoc.z = clickableTile.tileX - (clickableTile.tileY - (Mathf.Abs(clickableTile.tileY) % 2)) / 2;
			hexLoc.x = - hexLoc.y - hexLoc.z;
			distanceFromMiddle = (int)((Mathf.Abs(ret.x - hexLoc.x) + Mathf.Abs(ret.y - hexLoc.y) + Mathf.Abs(ret.z - hexLoc.z)) / 2);		
			if (distanceFromMiddle <= area && distanceFromMiddle != 0 ) {
				if(distanceFromPlayer <= skillDistance){
					GameObject HighlightTiles = GameObject.Find ("_Scripts");
					HighlightTiles highlightTiles = HighlightTiles.GetComponent<HighlightTiles> ();
					highlightTiles.tileX = clickableTile.tileX;
					highlightTiles.tileY = clickableTile.tileY;
					highlightTiles.ShowTilesThatWillBeHitSkill();
				}		
			}
			if (distanceFromMiddle == 0 ) {
					if(distanceFromPlayer <= skillDistance){
						GameObject HighlightTiles = GameObject.Find ("_Scripts");
						HighlightTiles highlightTiles = HighlightTiles.GetComponent<HighlightTiles> ();
						highlightTiles.tileX = clickableTile.tileX;
						highlightTiles.tileY = clickableTile.tileY;
						highlightTiles.ShowHoveringTileSkill();
				}
				}
		}
	}
}
