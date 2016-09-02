using UnityEngine;
using System.Collections;

public class Frozen : MonoBehaviour {

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

	public void ApplyFrozen() {
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject enemyAi in Enemies) {
			BaseEnemy enemy = enemyAi.GetComponent<BaseEnemy> ();
			if (enemy.Recentlyhit && enemy.Frozen == false) {
				enemy.Frozen = true;
				enemy.FrozenDuration = duration;
				enemy.PhysDmgReduction = enemy.PhysDmgReduction + 0.5f; 
			}
		}

	}

	public void RunFrozen(){
		GameObject EnemyAi = GameObject.Find(map.selectedEnemy);
		BaseEnemy enemy = EnemyAi.GetComponent<BaseEnemy>();

		enemy.FrozenDuration--;	
		if (enemy.FrozenDuration == 0) {
			enemy.Frozen = false;
			enemy.PhysDmgReduction = enemy.PhysDmgReduction - 0.5f; 
		}


	}
}
