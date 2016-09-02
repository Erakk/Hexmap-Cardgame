using UnityEngine;
using System.Collections;

public class Chill : MonoBehaviour {

	private TileMap map;

	private int duration = 2;
	//	public TileMap map;


	// Use this for initialization
	void Start () {

		map = TileMap.map;
	}

	// Update is called once per frame
	void Update () {

	}

	public void ApplyChill() {
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject enemyAi in Enemies) {
			BaseEnemy enemy = enemyAi.GetComponent<BaseEnemy> ();
			if (enemy.Recentlyhit  && enemy.MovementSpeed > 0) {
				enemy.Chilled = true;
				enemy.ChillDuration = duration;
				enemy.MovementSpeed--;
				enemy.ChillCount++;
				if (enemy.ChillCount >= 2) {
					enemy.Chilled = false;
					enemy.ChillDuration = 0;
					enemy.ChillCount = 0;
					GameObject effects = GameObject.Find ("Effects");
					Frozen frozen = effects.GetComponent<Frozen> ();
					frozen.ApplyFrozen();	

				}
			}
		}
	}

	public void RunChill(){
		GameObject EnemyAi = GameObject.Find(map.selectedEnemy);
		BaseEnemy enemy = EnemyAi.GetComponent<BaseEnemy>();
		//		HealthBar enemyHpBar = EnemyAi.GetComponent<HealthBar> ();					
		//		enemyHpBar.CurHealth -= (enemy.BurnDamage / enemy.HpPointsMax) * 100;	
		enemy.ChillDuration--;	
		if (enemy.ChillDuration == 0 ) {
			enemy.Chilled = false;
			enemy.MovementSpeed++;
			enemy.ChillCount = 0;

		}

	}
}
