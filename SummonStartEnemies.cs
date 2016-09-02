using UnityEngine;
using System.Collections;


public class SummonStartEnemies : MonoBehaviour {

//	public StartingUnits startingunits;
//	public GameObject enemyPrefab;
//	public string name;
	public SummonStartEnemiesSerial[] summonStartEnemiesSerial;
//	public TileMap map;
//	GameObject GameController;
//	GameController gameController;
	public TileMap map;


	public void CreateEnemies()
	{
		int enemyNumber = 0;
		int slotY = 9;
		float yPos = map.zOffset * (slotY);
		int slotX = 14;
		float xPos = slotX * map.xOffset + map.xOffset/2;
		
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
//		int[] enemies = GameObject.F
		foreach (GameObject enemy in enemies) {
			BaseEnemy enemyAi = enemy.GetComponent<BaseEnemy> ();
			enemy.transform.position = new Vector3(xPos, yPos, 0); 
			yPos = yPos - (0.764f * 2);
			enemyNumber++;			
			enemyAi.TileX = 14; 
			enemyAi.TileY = slotY;
//			enemyAi.map = map;
			enemy.name = enemyAi.EnemyName + " " + enemyNumber;
			slotY = slotY - 2;
			enemyAi.map = map;
		}

		GameController.control.CalculateEnemies();
	}

	public void StartEnemies()
	{
		for (int i = 0; i < summonStartEnemiesSerial.Length; i++) {
			GameController.control.AddEnemyToMap(summonStartEnemiesSerial[i].name);
		}
	}
}
