using UnityEngine;
using System.Collections;

public class Slow : MonoBehaviour{

	public static Slow slow;
	private TileMap map;

	private int duration = 2;
	private bool slowApplied = false;
//	public TileMap map;
	
	
	// Use this for initialization
	void Start () {

		map = TileMap.map;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ApplySlow() {
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject enemyAi in Enemies) {
			BaseEnemy enemy = enemyAi.GetComponent<BaseEnemy> ();
			if (enemy.Recentlyhit && !slowApplied && enemy.MovementSpeed > 0) {
				enemy.Slowed = true;
				enemy.SlowDuration = duration;
				enemy.MovementSpeed--;
				slowApplied = true;	
			}
		}
	}

	public void RunSlow(){
		GameObject EnemyAi = GameObject.Find(map.selectedEnemy);
		BaseEnemy enemy = EnemyAi.GetComponent<BaseEnemy>();
//		HealthBar enemyHpBar = EnemyAi.GetComponent<HealthBar> ();					
//		enemyHpBar.CurHealth -= (enemy.BurnDamage / enemy.HpPointsMax) * 100;	
		enemy.SlowDuration--;	
		if (enemy.SlowDuration == 0 ) {
			enemy.Slowed = false;
			enemy.MovementSpeed++;
			slowApplied = false;
		}
		
	}
}
