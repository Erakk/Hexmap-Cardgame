using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasicStatsGui : MonoBehaviour {

	public TileMap map;
	// Use this for initialization
	void Start () {
//		map = TileMap.map;
		StatsUpdate ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void StatsUpdate ()
	{
		GameObject Player = GameObject.Find (map.selecterPlayer);
		PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();

//		GameObject GameController = GameObject.Find ("GameController");
//		GameController gameControllerscripts = GameController.GetComponent<GameController> ();

		Text guiPlayerHealth = GameObject.Find ("PlayerHealth").GetComponent<Text> ();
		guiPlayerHealth.text = "Player Health: " + player.PlayerClass.HpPointsRemaining + " / " + player.PlayerClass.HpPointsMax ;

		Text guiPlayerMS = GameObject.Find ("PlayerMS").GetComponent<Text> ();
		guiPlayerMS.text = "Player MS: " + player.PlayerClass.RemainingMovement + " / " + player.PlayerClass.MoveSpeed ;

		Text guiPlayerManaLeft = GameObject.Find ("PlayerManaLeft").GetComponent<Text> ();
		guiPlayerManaLeft.text = "Mana " + GameController.control.manaRemaining + " / " + GameController.control.manaMax ;

	}
}
