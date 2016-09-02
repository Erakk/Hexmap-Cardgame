using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public float maxHealth = 100f;
	public GameObject healthBar;
	public string parentName;
	public float CurHealth { get; set;}
//	private TileMap map;

	void Start () {
//		map = TileMap.map;
		CurHealth = maxHealth;
		SetHealthBarStart();
	}

	public void SetHealthBarStart()
	{	
		float myHealth = CurHealth / maxHealth;
		if(myHealth <= 0){
			myHealth = 0;
		}
		if(myHealth >= 1){
			myHealth = 1;
		}
		healthBar.transform.localScale = new Vector3(myHealth,healthBar.transform.localScale.y,healthBar.transform.localScale.z);
//		Debug.Log("myHealth " + myHealth);	
		
	}

	public void SetHealthBarEnemy()
	{	
		float myHealth = CurHealth / maxHealth;
		if(myHealth <= 0){
			myHealth = 0;
		}
		if(myHealth >= 1){
			myHealth = 1;
		}
		healthBar.transform.localScale = new Vector3(myHealth,healthBar.transform.localScale.y,healthBar.transform.localScale.z);
//		Debug.Log("myHealth " + myHealth);	
		
	}
	public void SetHealthBarPlayer()
	{	
//		Debug.Log("Healthbar test");
		float myHealth = CurHealth / maxHealth;
//		Debug.Log(curHealth + " current Health");
//		Debug.Log(myHealth);
		if(myHealth <= 0){
			myHealth = 0;
		}
		if(myHealth >= 1){
			myHealth = 1;
		}
		healthBar.transform.localScale = new Vector3(myHealth,healthBar.transform.localScale.y,healthBar.transform.localScale.z);
//		Debug.Log("myHealth " + myHealth);	
		GameObject TileMap = GameObject.Find ("Map");
		TileMap map = TileMap.GetComponent<TileMap>();
		GameObject Enemy = GameObject.Find (map.selectedEnemy);
		BaseEnemy enemy = Enemy.GetComponent<BaseEnemy>();
		GameObject Player = GameObject.Find (enemy.selectedPlayer);
		PlayableCharacter player = Player.GetComponent<PlayableCharacter>();
		player.PlayerClass.HpPointsRemaining = (int)(myHealth * player.PlayerClass.HpPointsMax);
	}
	public void KillUnit()
	{
//		GameObject GameController = GameObject.Find ("GameController");
//		GameController gameController = GameController.GetComponent<GameController> ();
		if (CurHealth <= 0) {
			GameObject EnemyAI = GameObject.Find (parentName);
			BaseEnemy enemyAi = EnemyAI.GetComponent<BaseEnemy> ();
			GameObject ClickableTile = GameObject.Find ("Hex_" + enemyAi.TileX + "_" + enemyAi.TileY);
			ClickableTile clickableTile = ClickableTile.GetComponent<ClickableTile> ();
			clickableTile.isWalkable = true;
			this.tag = "DeadEnemy";
			this.transform.SetParent(null);
			Destroy(gameObject);		
		}
	}
	public void KillPlayer()
	{

		if (CurHealth <= 0) {			
			GameObject TileMap = GameObject.Find ("Map");
			TileMap map = TileMap.GetComponent<TileMap>();
			GameObject Enemy = GameObject.Find (map.selectedEnemy);
			BaseEnemy enemy = Enemy.GetComponent<BaseEnemy>();
			GameObject Player = GameObject.Find (enemy.selectedPlayer);
			PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
			GameObject ClickableTile = GameObject.Find ("Hex_" + player.PlayerClass.TileX + "_" + player.PlayerClass.TileY);
			ClickableTile clickableTile = ClickableTile.GetComponent<ClickableTile> ();
			clickableTile.isWalkable = true;
			Player.tag = "DeadPlayer";
			GameObject[] PlayersAlive =  GameObject.FindGameObjectsWithTag("Player");
			foreach (GameObject PlayerAlive in PlayersAlive) {
				map.selecterPlayer = PlayerAlive.name;
			}
			Player.SetActive(false);
		}
	}
}
