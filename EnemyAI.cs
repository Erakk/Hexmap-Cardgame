using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class EnemyAI : MonoBehaviour {
/*
	public int tileX ;
	public int tileY ;
	public TileMap map;
	public List<Node> currentPath = null;
	public int moveSpeed = 1;
	float distance;
	float remainingMovement;
	public int wantedDistance = 1;
	string currentTile;
	private int attackDamage = 3;
	public float hpPointsMax = 20;
	public float hpPointsCurr = 20;
	public int distanceToPlayer;
	public bool recentlyhit;
	public bool burned = false;
	public int burnDuration = 0;
	public int burnDamage = 0;

	int[,] tiles;

	void Start()
	{
		hpPointsCurr = hpPointsMax;
	}	
	
	public void StartWalkable(){
		currentTile = "Hex_" + tileX + "_" + tileY;
		GameObject.Find (currentTile).GetComponent<ClickableTile> ().IsNotWalkable();
	}

	public void MoveNextTile() {
		
		remainingMovement = moveSpeed;
	

//			GameObject Unit = GameObject.Find ("UnitOne");
			GameObject Unit = GameObject.Find (map.selecterPlayer);

			Unit unit = Unit.GetComponent<Unit> ();

			map.GeneratePathToEnemy (unit.tileX, unit.tileY);

			while(remainingMovement > 0 ) {
				currentTile = ("Hex_" + tileX + "_" + tileY);

				GameObject.Find (currentTile).GetComponent<ClickableTile> ().IsNotWalkable();

//				tile.IsNotWalkable();
				int tileXHolder = tileX;
				int tileYHolder = tileY;
				CalculateDistance();

				if(currentPath==null || distance <= wantedDistance  ){
//				Debug.Log(remainingMovement);
					if(remainingMovement >= 1){
						Attack();
					}
					return;
				}
				// Get cost from current tile to next tile
				remainingMovement -= map.CostToEnterTile(currentPath[0].x, currentPath[0].y, currentPath[1].x, currentPath[1].y );
	
				// Move us to the next tile in the sequence
				tileX = currentPath[1].x;
				tileY = currentPath[1].y;
	
				transform.position = map.TileCoordToWorldCoord( tileX, tileY );	// Update our unity world position

				// Remove the old "current" tile
				currentPath.RemoveAt(0);

				if(currentPath.Count == 1) {
					// We only have one tile left in the path, and that tile MUST be our ultimate
					// destination -- and we are standing on it!
					// So let's just clear our pathfinding info.
					currentPath = null;
				}
				currentTile = ("Hex_" + tileXHolder + "_" + tileYHolder);
				GameObject.Find (currentTile).GetComponent<ClickableTile> ().IsWalkable();
				currentTile = ("Hex_" + tileX + "_" + tileY);
				GameObject.Find (currentTile).GetComponent<ClickableTile> ().IsNotWalkable();

		}

	}
	
	void CalculateDistance()
	{
//		GameObject Unit = GameObject.Find ("UnitOne");
		GameObject Unit = GameObject.Find (map.selecterPlayer);	
		Unit unit = Unit.GetComponent<Unit> ();

		Vector3 ret = new Vector3();
		Vector3 unitRet = new Vector3();

		ret.y = tileY;
		ret.z = tileX - (tileY - (Mathf.Abs(tileY) % 2)) / 2;
		ret.x = - ret.y - ret.z;

		unitRet.y = unit.tileY;
		unitRet.z = unit.tileX - (unit.tileY - (Mathf.Abs(unit.tileY) % 2)) / 2;
		unitRet.x = - unitRet.y - unitRet.z;
//		Debug.Log(unitRet.x + " x");
//		Debug.Log(unitRet.z + " z");
//		Debug.Log(unitRet.y + " y");
		distance = (Mathf.Abs(ret.x - unitRet.x) + Mathf.Abs(ret.y - unitRet.y) + Mathf.Abs(ret.z - unitRet.z)) / 2;
	}

	void Attack()
    {
		if(distance == 1){
//		Debug.Log("Hit player");
//		GameObject Unit = GameObject.Find ("UnitOne");
		GameObject Unit = GameObject.Find (map.selecterPlayer);
		Unit unit = Unit.GetComponent<Unit> ();
		HealthBar healthBar = Unit.GetComponent<HealthBar> ();
		
		healthBar.curHealth -= 	(attackDamage / unit.hpPointsMax) * 100;
//		healthBar.curHealth --; 	
//		Debug.Log(healthBar.curHealth);
		healthBar.SetHealthBar();
		
		unit.hpPointsCurr--;

		remainingMovement --;
//		Debug.Log(remainingMovement);
		}
		else{
			Debug.Log("Dance!");
		}
	}
	void OnMouseUp ()
	{
//		Debug.Log("enemy mouse up");
		GameObject ClickableTile = GameObject.Find ("Hex_" + tileX + "_" + tileY);
		ClickableTile clickableTile = ClickableTile.GetComponent<ClickableTile> ();
		clickableTile.Attack();
	}

	public void RunEffects(){
		if (burned) {
			map.selectedEnemy = this.name;
			GameObject Burn = GameObject.Find ("_Scripts");
			Burn burn = Burn.GetComponent<Burn> ();
			burn.RunBurn();
		}
	}

*/
}

