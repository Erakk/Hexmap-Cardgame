using UnityEngine;
using System.Collections.Generic;

public class Burn : MonoBehaviour {


	public string targetType = "Enemy";
//	public static Burn burn;
//	private TileMap map;
//	public int duration { get; set;}
//	public float damage { get; set;}
//	private int duration = 2;
//	public float damage = 3;
//	public TileMap map;
	public int Duration(int duration)
	{
		return duration;
	}
	public float Damage(float damage, float reduction)
	{
		return (damage / reduction);
	}

	public void ApplyBurn(int duration, float damage) {
		GameObject Map = GameObject.Find ("Map");
		TileMap map = Map.GetComponent<TileMap> ();
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag("targetType");
		foreach (GameObject enemyAi in Enemies) {
			BaseEnemy enemy = enemyAi.GetComponent<BaseEnemy> ();
			if (enemy.Recentlyhit) {
				enemy.Burned = true;
				enemy.BurnDuration = Duration(duration);
				enemy.BurnDamage = damage;
			}
		}

	}

	public void RunBurn(){
		GameObject Map = GameObject.Find ("Map");
		TileMap map = Map.GetComponent<TileMap> ();
		GameObject EnemyAi = GameObject.Find(map.selectedEnemy);
		BaseEnemy enemy = EnemyAi.GetComponent<BaseEnemy>();
		HealthBar enemyHpBar = EnemyAi.GetComponent<HealthBar> ();					
		enemyHpBar.CurHealth -= (enemy.BurnDamage / enemy.HpPointsMax) * 100;	
		enemy.BurnDuration--;	
		if (enemy.BurnDuration == 0) {
			enemy.Burned = false;
		}
		enemyHpBar.SetHealthBarEnemy();
		enemyHpBar.parentName = map.selectedEnemy;
		enemyHpBar.KillUnit();
		
	}
	public void RunBurnPlayer(){
		GameObject Map = GameObject.Find ("Map");
		TileMap map = Map.GetComponent<TileMap> ();
		GameObject Player = GameObject.Find(map.selecterPlayer);
		PlayableCharacter player = Player.GetComponent<PlayableCharacter>();
		HealthBar playerHpBar = Player.GetComponent<HealthBar> ();					
		playerHpBar.CurHealth -= (player.BurnDamage / player.PlayerClass.HpPointsMax) * 100;	
		player.BurnDuration--;	
		if (player.BurnDuration == 0) {
			player.Burned = false;
		}
		playerHpBar.SetHealthBarPlayer();
		playerHpBar.parentName = map.selecterPlayer;
		playerHpBar.KillPlayer();

	}
}
