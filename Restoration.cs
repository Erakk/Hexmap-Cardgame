using UnityEngine;
using System.Collections;

public class Restoration : MonoBehaviour {

	public static Restoration restoration;
	private TileMap map;
	
	private int duration = 3;
//	public string playerName;
	public float heal;
//	private float lostDamage;
//	public TileMap map;
	// Use this for initialization
	void Start () {

		map = TileMap.map;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ApplyRestoration() {
		GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject Player in Players) {
			PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
			if (player.recentlyHit) {
				player.PlayerClass.Restoration = true;
				player.PlayerClass.RestorationDuration = duration;
				player.PlayerClass.RestorationValue = heal;

			}
		}

	}
	public void RunRestoration(){
		GameObject Player = GameObject.Find(map.selecterPlayer);
		PlayableCharacter player = Player.GetComponent<PlayableCharacter>();
		HealthBar playerHpBar = Player.GetComponent<HealthBar> ();					
		playerHpBar.CurHealth += (player.PlayerClass.RestorationValue / player.PlayerClass.HpPointsMax) * 100;	
		if (playerHpBar.CurHealth > playerHpBar.maxHealth) {
			playerHpBar.CurHealth = playerHpBar.maxHealth;
		}
		player.PlayerClass.RestorationDuration--;	
		if (player.PlayerClass.RestorationDuration == 0) {
			player.PlayerClass.Restoration = false;
		}
		playerHpBar.SetHealthBarPlayer();
		playerHpBar.parentName = map.selecterPlayer;
		
	}
}
