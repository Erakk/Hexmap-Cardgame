using UnityEngine;
using System.Collections;

public class SummonStartPlayers : MonoBehaviour {

//	GameObject GameController;
//	GameController gameController;
	public TileMap map;


	public void Start()
	{
//		map = TileMap.map;
//		GameController = GameObject.Find ("GameController");
//		gameController = GameController.GetComponent<GameController> ();
	}
	
	public void CreatePlayers()
	{
		GameObject[] Players =  GameObject.FindGameObjectsWithTag("Player");
		int slotY = 7;
		float yPos = map.zOffset * (slotY) ;
		int slotX = 0;
		float xPos = slotX * map.xOffset + map.xOffset/2;
//		int slotY = 7;
		for (int i = 1; i < 4; i++) {
			GameObject Player = GameObject.Find ("Player" + i);	
			PlayableCharacter player = Player.GetComponent<PlayableCharacter>();
			player.transform.position = new Vector3(xPos, yPos, 0); 
			yPos = yPos - (map.zOffset * 2);	
			player.PlayerClass.TileX = 0; 
			player.PlayerClass.TileY = slotY;
			slotY = slotY - 2;
//			Debug.Log(player.name);
		}
		GameController.control.CalculatePlayers();
	}
}
