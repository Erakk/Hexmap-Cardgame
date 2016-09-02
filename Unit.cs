using UnityEngine;
using System.Collections.Generic;

public class Unit : MonoBehaviour  {
/*
	public int tileX ;
	public int tileY ;
	public TileMap map;
	private int strength;
	private float cardCostReduction;
	private float cardRangeIncrease;
	private int dexterity;
	private int wisdom;
	private int intelligence;
	public float hpPointsMax;
//	public float hpPointsCurr;
//	public int attackRange = 2;
	public int attackableTiles = 0;
	public int physicalAttackDMG = 1;
	public int magicAttackDMG = 1;
	public int rangedAttackDMG = 1;
	public int healValue;
	public int attackDMG;
//	public ButtonScripts buttonScripts;
	
	
//	float xOffset = 0.882f;
//	float zOffset = 0.764f;
	public int distance;
	public List<Node> currentPath = null;

	public int moveSpeed;
	public float remainingMovement;
	void Start (){
		
//		strength = game;
		GameObject GameController = GameObject.Find ("GameController");
		GameController gameControllerscripts = GameController.GetComponent<GameController> ();
		strength = gameControllerscripts.playerClass.Strength;
		dexterity = gameControllerscripts.playerClass.Dexterity;
		wisdom = gameControllerscripts.playerClass.Wisdom;
		intelligence = gameControllerscripts.playerClass.Intelligence;
		// 1 int reduce cost by 2%
		moveSpeed = dexterity / 2;
		hpPointsMax = strength * 3;
		cardCostReduction = intelligence / 50;
		cardRangeIncrease = wisdom / 50;
		physicalAttackDMG = strength / 2;
		rangedAttackDMG = dexterity / 2;
		magicAttackDMG = intelligence / 2;
		healValue = wisdom / 2;
		
//		hpPointsCurr = hpPointsMax;
//		Debug.Log(strength);
		remainingMovement = moveSpeed;
//		attackRange = 2;
//		map.CalculateAttackableTiles();
//		attackDMG = wisdom / 2;
//		buttonScripts.AttackButtonDisable();
	}
	void Update() {


		GameObject ButtonScripts = GameObject.Find ("ButtonsCanvas");
		ButtonScripts buttonScripts = ButtonScripts.GetComponent<ButtonScripts> ();
		if(buttonScripts.changeAreaTiles){
			currentPath = null;
		}

		if(currentPath != null) {

			int currNode = 0;


			while( currNode < currentPath.Count-1 ) {

				Vector3 start = map.TileCoordToWorldCoord( currentPath[currNode].x, currentPath[currNode].y ) + 
					new Vector3(0, 0, -0.2f) ;
				Vector3 end   = map.TileCoordToWorldCoord( currentPath[currNode+1].x , currentPath[currNode+1].y )  + 
					new Vector3(0, 0, -0.2f) ;

				Debug.DrawLine(start, end, Color.red);

				currNode++;
			}

		}


	}
	
	public void MoveNextTile() {
//		remainingMovement = moveSpeed;

		GameObject ButtonScripts = GameObject.Find ("ButtonsCanvas");
		ButtonScripts buttonScripts = ButtonScripts.GetComponent<ButtonScripts> ();
		
		if (buttonScripts.moveSelected){
			
//			map.ShowAllowedTiles();
//			Debug.Log("Test1");
			while(remainingMovement > 0 ) {
				
				
				

				if(currentPath==null )
					return;
	
				// Get cost from current tile to next tile
				remainingMovement -= map.CostToEnterTile(currentPath[0].x, currentPath[0].y, currentPath[1].x, currentPath[1].y );
	
				// Move us to the next tile in the sequence
				tileX = currentPath[1].x;
				tileY = currentPath[1].y;

				TransformPosition();
//				transform.position = map.TileCoordToWorldCoord( tileX, tileY );	// Update our unity world position

				// Remove the old "current" tile
				currentPath.RemoveAt(0);

				if(currentPath.Count == 1) {
					// We only have one tile left in the path, and that tile MUST be our ultimate
					// destination -- and we are standing on it!
					// So let's just clear our pathfinding info.
					currentPath = null;
				}

				buttonScripts.moveSelected = false;
				
		}
		map.CalculateAttackableTiles();
	}	
		return;
	}
	
	public void TransformPosition(){
		transform.position = map.TileCoordToWorldCoord( tileX, tileY );
	}
	public void Attack()
	{

//		Debug.Log("Hit player Unit Attack");
//		GameObject EnemyAI = GameObject.Find ("UnitTwo");
		GameObject EnemyAI = GameObject.Find (map.selectedEnemy);
		EnemyAI enemyAi = EnemyAI.GetComponent<EnemyAI> ();
		HealthBar healthBar = EnemyAI.GetComponent<HealthBar> ();
		
		healthBar.curHealth -= 	(attackDMG / enemyAi.hpPointsMax) * 100;
//		healthBar.curHealth --; 	
//		Debug.Log(healthBar.curHealth);
		healthBar.SetHealthBar();
		
		enemyAi.hpPointsCurr--;

		remainingMovement --;


	}
*/
	
}
