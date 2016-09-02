using UnityEngine;
using System.Collections;

public class Blind : MonoBehaviour {

	private TileMap map;

	private int duration = 3;
	//	public TileMap map;


	// Use this for initialization
	void Start () {

		map = TileMap.map;
	}

	// Update is called once per frame
	void Update () {

	}

	public void Applyblind() {
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject enemyAi in Enemies) {
			BaseEnemy enemy = enemyAi.GetComponent<BaseEnemy> ();
			if (enemy.Recentlyhit ) {
				enemy.Blinded = true;
				enemy.BlindDuration = duration;

			}
		}
	}

	public void RunBlind(){
		GameObject EnemyAi = GameObject.Find(map.selectedEnemy);
		BaseEnemy enemy = EnemyAi.GetComponent<BaseEnemy>();
		//		HealthBar enemyHpBar = EnemyAi.GetComponent<HealthBar> ();					
		//		enemyHpBar.CurHealth -= (enemy.BurnDamage / enemy.HpPointsMax) * 100;	
		enemy.BlindDuration--;	
		if (enemy.BlindDuration == 0 ) {
			enemy.Blinded = false;

		}

	}
}
