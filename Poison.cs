using UnityEngine;
using System.Collections;

public class Poison : MonoBehaviour {

	public static Poison poison;
	private TileMap map;

	private int duration = 3;
	public float damage = 0;
	private float lostDamage;
//	public TileMap map;
	
	
	// Use this for initialization
	void Start () {

		map = TileMap.map;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ApplyPoison() {
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject enemyAi in Enemies) {
			BaseEnemy enemy = enemyAi.GetComponent<BaseEnemy> ();
			if (enemy.Recentlyhit) {
				lostDamage = enemy.AttackDamage;
				enemy.Poisoned = true;
				enemy.PoisonDuration = duration;
				enemy.PoisonDamage = damage;
				enemy.AttackDamage /= 2;
				lostDamage -= enemy.AttackDamage;
			}
		}

	}

	public void RunPoison(){
		GameObject EnemyAi = GameObject.Find(map.selectedEnemy);
		BaseEnemy enemy = EnemyAi.GetComponent<BaseEnemy>();
		HealthBar enemyHpBar = EnemyAi.GetComponent<HealthBar> ();					
		enemyHpBar.CurHealth -= (enemy.BurnDamage / enemy.HpPointsMax) * 100;	
		enemy.BurnDuration--;	
		if (enemy.PoisonDuration == 0) {
			enemy.Poisoned = false;
			enemy.AttackDamage += lostDamage; 
		}
		enemyHpBar.SetHealthBarEnemy();
		enemyHpBar.parentName = map.selectedEnemy;
		enemyHpBar.KillUnit();
		
	}
}
