using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum PriorityTargets{
	LowHp,
	Closest,
	HighestDamage
}

public class BaseEnemy : MonoBehaviour, EffectForUnits {


	public TileMap map;
//	private GameObject TileMap;
	private GameObject enemyPrefab;
	public List<Node> currentPath = null;

	private string currentTile;
	public string selectedPlayer;
	private float distance;
	private float remainingMovement;
	public int distanceToPlayer;
	public float MagicDmgReduction = 0;
	public float PhysDmgReduction = 0;

	public GameObject EnemyPrefab { get; set;}
	public string EnemyName { get; set;}
	public string EnemyDescription { get; set;}
	public int TileX { get; set;}
	public int TileY { get; set;}
	public int MovementSpeed { get; set;}
	public float AttackDamage { get; set;}
	public int AttackRange { get; set;}
	public float HpPointsMax { get; set;}
	public bool Recentlyhit { get; set;}
/*
	public bool Burned { get; set;}
	public int BurnDuration { get; set;}
	public float BurnDamage { get; set;}
	public bool Slowed { get; set;}
	public int SlowDuration { get; set;}
	public bool Chilled { get; set;}
	public int ChillDuration { get; set;}
	public int ChillCount { get; set;}
	public bool Poisoned { get; set;}
	public int PoisonDuration { get; set;}
	public bool Frozen { get; set;}
	public int FrozenDuration { get; set;}
	public float PoisonDamage { get; set;}
	public bool Bleeding { get; set;}
	public int BleedStacks { get; set;}
	public bool Stunned { get; set;}
	public int StunDuration { get; set;}
	public bool Blinded { get; set;}
	public int BlindDuration { get; set;}
*/
	
//	public int DistanceToPlayer { get; set;}
	public bool AlweysTargetEnemyInRange { get; set;}
	public DamageTypes DamageType { get; set;}
	public PriorityTargets PriorityTarget { get; set;}

	public void StartWalkable(){
		currentTile = "Hex_" + TileX + "_" + TileY;
		GameObject.Find (currentTile).GetComponent<ClickableTile> ().IsNotWalkable();
	}
	void Start()
	{
//		TileMap = GameObject.Find ("Map");	
//		map = TileMap.map;
//		movementSpeed = MovementSpeed;
//		tileX = TileX;
//		tileY = TileY;
//		hpPointsMax = HpPointsMax;
//		attackDamage = AttackDamage;
//		attackRange = AttackRange;
//		GameObject Enemy = GameObject.Find (this.name);	
//		HealthBar hpBar = Enemy.GetComponent<HealthBar> ();
//		hpBar.SetHealthBar();
	}

	public void CopyActionsFrom(BaseEnemy enemy)
	{
		this.MovementSpeed = enemy.MovementSpeed;
		this.AttackDamage = enemy.AttackDamage;
		this.AttackRange = enemy.AttackRange;
		this.HpPointsMax = enemy.HpPointsMax;
		this.EnemyName = enemy.EnemyName;
		this.EnemyDescription = enemy.EnemyDescription;
		this.AlweysTargetEnemyInRange = enemy.AlweysTargetEnemyInRange;
		this.DamageType = enemy.DamageType;
		this.PriorityTarget = enemy.PriorityTarget;

	}

	void CalculateDistance()
	{
		GameObject Player = GameObject.Find (selectedPlayer);	
		PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
		Vector3 ret = new Vector3();
		Vector3 unitRet = new Vector3();
		ret.y = TileY;
		ret.z = TileX - (TileY - (Mathf.Abs(TileY) % 2)) / 2;
		ret.x = - ret.y - ret.z;
		unitRet.y = player.PlayerClass.TileY;
		unitRet.z = player.PlayerClass.TileX - (player.PlayerClass.TileY - (Mathf.Abs(player.PlayerClass.TileY) % 2)) / 2;
		unitRet.x = - unitRet.y - unitRet.z;
		distance = (Mathf.Abs(ret.x - unitRet.x) + Mathf.Abs(ret.y - unitRet.y) + Mathf.Abs(ret.z - unitRet.z)) / 2;
	}

	void Attack()
    {
		if(distance >= AttackRange){
//		Debug.Log("Hit player");
//		GameObject Unit = GameObject.Find ("UnitOne");
		GameObject Player = GameObject.Find (selectedPlayer);	
		PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
		HealthBar healthBar = Player.GetComponent<HealthBar> ();
		
		healthBar.CurHealth -= 	(AttackDamage / player.PlayerClass.HpPointsMax) * 100;
//		healthBar.curHealth --; 	
//		Debug.Log(healthBar.curHealth);
		healthBar.SetHealthBarPlayer();
		healthBar.KillPlayer();
		
//		unit.hpPointsCurr--;

		remainingMovement --;
//		Debug.Log(remainingMovement);
		}
		else{
			Debug.Log("Dance!");
		}
	}

	public void RunEffects(){
		map.selectedEnemy = this.name;
		GameObject effects = GameObject.Find ("Effects");
		if (Burned) {
//			map.selectedEnemy = this.name;
//			
			Burn burn = effects.GetComponent<Burn> ();
			burn.RunBurn();
		}
		if (Slowed) {
//			map.selectedEnemy = this.name;
//			GameObject Slow = GameObject.Find ("_Scripts");
			Slow slow = effects.GetComponent<Slow> ();
			slow.RunSlow();			
		}
		if (Poisoned) {
//			map.selectedEnemy = this.name;
//			GameObject Poison = GameObject.Find ("_Scripts");
			Poison poison = effects.GetComponent<Poison> ();
			poison.RunPoison();			
		}
		if (Bleeding) {
//			map.selectedEnemy = this.name;
//			GameObject Bleed = GameObject.Find ("_Scripts");
			Bleed bleed = effects.GetComponent<Bleed> ();
			bleed.RunBleed();			
		}
		if (Stunned) {
//			map.selectedEnemy = this.name;
//			GameObject Stun = GameObject.Find ("_Scripts");
			Stun stun = effects.GetComponent<Stun> ();
			stun.RunStun();			
		}
		if (Chilled) {
			Chill chill = effects.GetComponent<Chill> ();
			chill.RunChill();			
		}
		if (Frozen) {
			Frozen frozen = effects.GetComponent<Frozen> ();
			frozen.RunFrozen();			
		}
		if (Blinded) {
			Blind blind = effects.GetComponent<Blind> ();
			blind.RunBlind();			
		}
	}
	
	public void MoveNextTile() {
		
		remainingMovement = MovementSpeed;
//		Debug.Log(remainingMovement);
//		CalculateDistancesToPlayers();
//		GameObject Unit = GameObject.Find ("UnitOne");
		selectTargetting();
//		CalculateDistancesToPlayers();
		GameObject Player = GameObject.Find (selectedPlayer);	
		PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();

		map.GeneratePathToEnemy (player.PlayerClass.TileX, player.PlayerClass.TileY);

		while(remainingMovement > 0 ) {
			currentTile = ("Hex_" + TileX + "_" + TileY);
			GameObject.Find (currentTile).GetComponent<ClickableTile> ().IsNotWalkable();
			
//			tile.IsNotWalkable();
			int tileXHolder = TileX;
			int tileYHolder = TileY;
			CalculateDistance();

			if((currentPath==null || distance <= AttackRange) && Blinded == false  ){
//				Debug.Log(remainingMovement);
				if(remainingMovement >= 1){
					Attack();
				}
				return;
			}
			if ((currentPath==null || distance <= AttackRange) && Blinded == true) {
				return;
			}
				// Get cost from current tile to next tile
			remainingMovement -= map.CostToEnterTile(currentPath[0].x, currentPath[0].y, currentPath[1].x, currentPath[1].y );
			
				// Move us to the next tile in the sequence
			TileX = currentPath[1].x;
			TileY = currentPath[1].y;
	
			transform.position = map.TileCoordToWorldCoord( TileX, TileY );	// Update our unity world position

			// Remove the old "current" tile
			currentPath.RemoveAt(0);
//			Debug.Log(this.name + " " + currentPath.Count);
			if(currentPath.Count == 1) {
					// We only have one tile left in the path, and that tile MUST be our ultimate
					// destination -- and we are standing on it!
					// So let's just clear our pathfinding info.
				currentPath = null;
			}
			currentTile = ("Hex_" + tileXHolder + "_" + tileYHolder);
			ClickableTile clickableTile = GameObject.Find (currentTile).GetComponent<ClickableTile> ();
			clickableTile.IsWalkable();
			currentTile = ("Hex_" + TileX + "_" + TileY);
			clickableTile = GameObject.Find (currentTile).GetComponent<ClickableTile> ();
			clickableTile.IsNotWalkable();

			if (clickableTile.trapped) 
			{
			clickableTile.trapped = false;
			GameObject Trap = GameObject.Find ("_Scripts");
			Trap trap = Trap.GetComponent<Trap> ();
			trap.TrapActivate();
			}
		}
	}
	private void CalculateDistancesToPlayers()
	{
		int minDistance = 30;
		Vector3 startLoc = new Vector3();
		Vector3 endLoc = new Vector3();
		startLoc.y = TileY;
		startLoc.z = TileX - (TileY - (Mathf.Abs(TileY) % 2)) / 2;
		startLoc.x = - startLoc.y - startLoc.z;
		GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject Player in Players) {
			PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
			endLoc.y = player.PlayerClass.TileY;
			endLoc.z = player.PlayerClass.TileX - (player.PlayerClass.TileY - (Mathf.Abs(player.PlayerClass.TileY) % 2)) / 2;
			endLoc.x = - endLoc.y - endLoc.z;
			int d = (int)(Mathf.Abs(startLoc.x - endLoc.x) + Mathf.Abs(startLoc.y - endLoc.y) + Mathf.Abs(startLoc.z - endLoc.z)) / 2;
			player.PlayerClass.DistanceToEnemy = d;
			if (d <= minDistance) {
				minDistance = d;
			}
		}
		foreach (GameObject Player in Players) {
			PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
			if (player.PlayerClass.DistanceToEnemy == minDistance) {
				selectedPlayer = player.name;
				return;
			}
		}

	}

	private void CalculateLowestHp()
	{
		int lowHp = 3000;

		GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject Player in Players) {
			PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
			if (player.PlayerClass.HpPointsRemaining <= lowHp) {
				lowHp = player.PlayerClass.HpPointsRemaining;
			}
		}
		foreach (GameObject Player in Players) {
			PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
			if (player.PlayerClass.HpPointsRemaining == lowHp) {
				selectedPlayer = player.name;
				return;
			}
		}

	}
	private void selectTargetting()
	{
		switch (PriorityTarget) {

			case PriorityTargets.Closest:
//			Debug.Log("closest target");
				CalculateDistancesToPlayers();
				break;
			case PriorityTargets.HighestDamage:
				CalculateDistancesToPlayers();
				break;
			case PriorityTargets.LowHp:
//			Debug.Log("low hp target");
				CalculateLowestHp();
				break;
		
			default:
				break;
		}
	}
}
