using UnityEngine;
using System.Collections;

public class Stun : MonoBehaviour {

	public static Stun stun;
	private TileMap map;


	private int duration = 1;
//	public TileMap map;
	
	
	// Use this for initialization
	void Start () {

		map = TileMap.map;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ApplyStun() {
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject enemyAi in Enemies) {
			BaseEnemy enemy = enemyAi.GetComponent<BaseEnemy> ();
			if (enemy.Recentlyhit) {
				enemy.Stunned = true;
				enemy.StunDuration = duration;
			}
		}
	}

	public void RunStun(){
		GameObject EnemyAi = GameObject.Find(map.selectedEnemy);
		BaseEnemy enemy = EnemyAi.GetComponent<BaseEnemy>();
//		HealthBar enemyHpBar = EnemyAi.GetComponent<HealthBar> ();					
//		enemyHpBar.CurHealth -= (enemy.BurnDamage / enemy.HpPointsMax) * 100;	
		enemy.StunDuration--;	
		if (enemy.StunDuration == 0 ) {
			enemy.Stunned = false;
		}
		
	}
}
