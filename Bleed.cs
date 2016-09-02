using UnityEngine;
using System.Collections;

public class Bleed : MonoBehaviour  {

	public static Bleed bleed;
	private TileMap map;
	public float damage = 0;
//	public TileMap map;
	
	
	// Use this for initialization
	void Start () {

		map = TileMap.map;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ApplyBleed() {
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject enemyAi in Enemies) {
			BaseEnemy enemy = enemyAi.GetComponent<BaseEnemy> ();
			if (enemy.Recentlyhit) {
				enemy.Bleeding = true;;
				enemy.BleedStacks ++;
			}
		}

	}

	public void RunBleed(){
		GameObject EnemyAi = GameObject.Find(map.selectedEnemy);
		BaseEnemy enemy = EnemyAi.GetComponent<BaseEnemy>();
		HealthBar enemyHpBar = EnemyAi.GetComponent<HealthBar> ();	
		damage = (enemyHpBar.maxHealth / 2) * enemy.BleedStacks;				
		enemyHpBar.CurHealth -= damage;	
		enemyHpBar.SetHealthBarEnemy();
		enemyHpBar.parentName = map.selectedEnemy;
		enemyHpBar.KillUnit();
		
	}
}
