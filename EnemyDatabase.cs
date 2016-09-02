using UnityEngine;
using System.Collections;

public class EnemyDatabase : BaseEnemy {

	public GameObject enemyPrefabMelee;
	public GameObject enemyPrefabRanged;
	public GameObject enemyPrefabCaster;
	// Use this for initialization
	void Start () {

		GameObject enemyGO;
		BaseEnemy enemy;


		enemyGO = (GameObject)Instantiate(enemyPrefabRanged);
		enemyGO.SetActive(false);
		enemy = enemyGO.GetComponent<BaseEnemy>();
		enemy.EnemyName = "Weak Ranged Enemy";
		enemy.EnemyDescription = "Weak Ranged Enemy";
		enemy.MovementSpeed = 1;
		enemy.AttackDamage = 2;
		enemy.AttackRange = 6;
		enemy.HpPointsMax = 20; 
		enemy.DamageType = DamageTypes.Physical;
		enemy.PriorityTarget = PriorityTargets.Closest;
		enemy.AlweysTargetEnemyInRange = true;
		GameController.control.AddEnemyToDatabase(enemy);

		enemyGO = (GameObject)Instantiate(enemyPrefabMelee);
		enemyGO.SetActive(false);
		enemy = enemyGO.GetComponent<BaseEnemy>();
		enemy.EnemyName = "Fast Assassin";
		enemy.EnemyDescription = "Fast Assassin";
		enemy.MovementSpeed = 6;
		enemy.AttackDamage = 2;
		enemy.AttackRange = 1;
		enemy.HpPointsMax = 25; 
		enemy.DamageType = DamageTypes.Physical;
		enemy.PriorityTarget = PriorityTargets.LowHp;
		enemy.AlweysTargetEnemyInRange = true;
		GameController.control.AddEnemyToDatabase(enemy);
			
		enemyGO = (GameObject)Instantiate(enemyPrefabMelee);
		enemyGO.SetActive(false);
		enemy = enemyGO.GetComponent<BaseEnemy>();
		enemy.EnemyName = "Weak Melee Enemy";
		enemy.EnemyDescription = "Weak Melee Enemy";
		enemy.MovementSpeed = 2;
		enemy.AttackDamage = 2;
		enemy.AttackRange = 1;
		enemy.HpPointsMax = 30; 
		enemy.DamageType = DamageTypes.Physical;
		enemy.PriorityTarget = PriorityTargets.Closest;
		enemy.AlweysTargetEnemyInRange = true;
		GameController.control.AddEnemyToDatabase(enemy);
	}
}
