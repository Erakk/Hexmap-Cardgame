using UnityEngine;
using System.Collections;
//using UnityEditor.Events;
using UnityEngine.EventSystems;


public class ClickableTile : MonoBehaviour {

	public int tileX;
	public int tileY;
	public TileMap map;
	public bool isWalkable = true;
	public ChangeTilesArea changeTilesArea;
	public Material primaryMaterial;
//	public Material hoverMaterialMouse;
//	public Material hoverMaterialAllowed;
	public Vector3 worldPos;
	public bool hexVisible = false;
	public bool rangeTargetted = false;
	public bool lineTargetted = false;
	public bool canAttack;
	public bool enemyTarget;
	public bool willTakeHit = false;
//	public bool isInrange;
	public bool trapped;
	public float trapDamage;
	public Effects trapEffect;

	private GameObject ButtonScripts;
	private ButtonScripts buttonScripts;


	void Start()
	{	
//		map = TileMap.map;
		UpdateWorldPosition();
		UpdatePrimaryMaterial();
		ButtonScripts = GameObject.Find ("ButtonsCanvas");
		buttonScripts = ButtonScripts.GetComponent<ButtonScripts> ();
	}

	public void UpdateWorldPosition()
	{
		worldPos.y = tileY;
		worldPos.z = (tileX - (tileY - (Mathf.Abs(tileY) % 2)) / 2);
		worldPos.x = (- worldPos.y - worldPos.z);
	}
	public void UpdatePrimaryMaterial()
	{
		Material[] mat = this.GetComponent<Renderer>().materials;
		primaryMaterial = mat[1];
	}
	void OnMouseUp ()
	{
//		Debug.Log("tile " + tileX + " " + tileY);
		if (canAttack != false && rangeTargetted) {
//			GameObject ButtonScripts = GameObject.Find ("ButtonsCanvas");
//			ButtonScripts buttonScripts = ButtonScripts.GetComponent<ButtonScripts> ();
//			GameObject GameController = GameObject.Find ("GameController");
//			GameController gameController = GameController.GetComponent<GameController> ();
			GameObject CardDropArea = GameObject.Find ("CardDropArea");
			DropZone dropZone = CardDropArea.GetComponent<DropZone>();
			GameObject Player = GameObject.Find(map.selecterPlayer);
			PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
			GameObject HighlightTiles = GameObject.Find ("_Scripts");
			HighlightTiles highlightTiles = HighlightTiles.GetComponent<HighlightTiles> ();
		

			if (buttonScripts.moveSelected) 
			{
				map.GeneratePathToPlayer (tileX, tileY);
				player.MoveNextTile();
			}
			if (buttonScripts.trapSelected) 
			{
				if(EventSystem.current.IsPointerOverGameObject() )
				{
				return;
			}
				trapped = true;
				trapDamage = dropZone.damage;
				trapEffect = dropZone.effect;
			}
		
			if (buttonScripts.changeAreaTiles || buttonScripts.coneSelected || buttonScripts.drawSelected || buttonScripts.attackSelected)
			{
				if (!willTakeHit) {
					return;
				}
				if(EventSystem.current.IsPointerOverGameObject() )
				{
					return;
				}
				HitEnemy();
			}
			if (buttonScripts.changeAreaTilesNoMid)
			{
				if(EventSystem.current.IsPointerOverGameObject() )
				{
					return;
				}
				HitEnemy();
				player.PlayerClass.TileX = tileX;
				player.PlayerClass.TileY = tileY;
				player.TransformPosition();;
			}

			if (buttonScripts.allySelected)
			{
				if(EventSystem.current.IsPointerOverGameObject() )
				{
					return;
				}
				GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
//				bool skillHit = false;
				foreach (GameObject PlayerAlly in Players) {
					PlayableCharacter playerAlly = PlayerAlly.GetComponent<PlayableCharacter> ();
					if (playerAlly.PlayerClass.TileX == tileX && playerAlly.PlayerClass.TileY == tileY) {
						playerAlly.recentlyHit = true;
						HealthBar playerHpBar = playerAlly.GetComponent<HealthBar> ();
//						Debug.Log("dropZone.heal " + dropZone.heal);
						playerHpBar.CurHealth = playerHpBar.CurHealth + (dropZone.heal / playerAlly.PlayerClass.HpPointsMax) * 100;
						if (playerHpBar.CurHealth > playerHpBar.maxHealth) {
							playerHpBar.CurHealth = playerHpBar.maxHealth;
						}
						playerHpBar.SetHealthBarPlayer();
						playerHpBar.parentName = map.selecterPlayer;
//						skillHit = true;
					}
				}
			}
			GameController.control.CalculateEnemies();
			Draggable card = CardDropArea.GetComponentInChildren<Draggable>();
			if (card != null) {
				dropZone.RunEffect();
				GameController.control.CalculateRemainingMana();
				card.Discard();	
			}

			buttonScripts.TurnEverythingFalse();
			highlightTiles.HideAllAllowedTiles();
			map.CheckVisibleTiles();
		
			GameController.control.TurnTruePlayerButtons();
			GameObject[] Enemies2 = GameObject.FindGameObjectsWithTag("Enemy");
			foreach (GameObject enemyAi in Enemies2) {
				BaseEnemy enemy = enemyAi.GetComponent<BaseEnemy> ();
				enemy.Recentlyhit = false;
			}
			GameObject Stats = GameObject.Find("ScreenPlayerStats");
			BasicStatsGui stats = Stats.GetComponent<BasicStatsGui>();
			stats.StatsUpdate();
		}
	}

	void OnMouseEnter()
	{	
		if (map != null) {
			
		
			canAttack = true;
//		Material[] mat = this.GetComponent<Renderer>().materials;
//		mat[1] = hoverMaterialMouse;
//		GameObject ButtonScripts = GameObject.Find ("ButtonsCanvas");
//		ButtonScripts buttonScripts = ButtonScripts.GetComponent<ButtonScripts> ();
			GameObject Player = GameObject.Find (map.selecterPlayer);
			PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
			GameObject HighlightTiles = GameObject.Find ("_Scripts");
			HighlightTiles highlightTiles = HighlightTiles.GetComponent<HighlightTiles> ();
//		highlightTiles.HighlightTilesInRange();

			if (buttonScripts.moveSelected) {
				highlightTiles.tileX = tileX;
				highlightTiles.tileY = tileY;
				highlightTiles.ShowHoveringTileMovement ();
			}

			if (buttonScripts.changeAreaTiles && hexVisible) {

				highlightTiles.ColorTargettedTiles ();
				if (EventSystem.current.IsPointerOverGameObject ()) {
					return;
				}
				GameObject ChangeTilesArea = GameObject.Find ("_Scripts");
				ChangeTilesArea changeTilesArea = ChangeTilesArea.GetComponent<ChangeTilesArea> ();
				changeTilesArea.tileX = tileX;
				changeTilesArea.tileY = tileY;
				changeTilesArea.CalculateArea (tileX, tileY);
			}

		
			if (buttonScripts.changeAreaTilesNoMid && map.UnitCanEnterTile (tileX, tileY) == true && hexVisible) {

				highlightTiles.ColorTargettedTiles ();

				GameObject[] Enemies = GameObject.FindGameObjectsWithTag ("Enemy");
				foreach (GameObject enemyAi in Enemies) {
					BaseEnemy enemy = enemyAi.GetComponent<BaseEnemy> ();
					if (enemy.TileX == tileX && enemy.TileY == tileY) {
						canAttack = false;
						return;
					}
				}

				if (EventSystem.current.IsPointerOverGameObject ()) {
					return;
				}
				GameObject ChangeTilesArea = GameObject.Find ("_Scripts");
				ChangeTilesArea changeTilesArea = ChangeTilesArea.GetComponent<ChangeTilesArea> ();
				changeTilesArea.tileX = tileX;
				changeTilesArea.tileY = tileY;
				changeTilesArea.CalculateAreaNoMid (tileX, tileY);
			}

		
			if (buttonScripts.drawSelected && hexVisible) {
				highlightTiles.ColorTargettedTiles ();
				GameObject DrawLine = GameObject.Find ("LineRenderer");
				DrawLine drawLine = DrawLine.GetComponent<DrawLine> ();
				GameObject[] Tiles = GameObject.FindGameObjectsWithTag ("Hex");
				foreach (GameObject tile in Tiles) {
					ClickableTile clickableTile = tile.GetComponent<ClickableTile> ();
					clickableTile.lineTargetted = false;	
				}
				drawLine.CheckLineTiles (player.PlayerClass.TileX, player.PlayerClass.TileY, tileX, tileY);

				drawLine.CheckEnemiesInLine ();
			}

			if (buttonScripts.coneSelected) {
			
//			Debug.Log("tile " + tileX + " " + tileY);
				GameObject Cone = GameObject.Find ("_Scripts");
				Cone cone = Cone.GetComponent<Cone> ();
//			GameObject Unit = GameObject.Find (map.selecterPlayer);
//			Unit unit = Unit.GetComponent<Unit> ();
//			Debug.Log("tile " + unit.tileX + " " + unit.tileY);
				cone.CalculateCone (player.PlayerClass.TileX, player.PlayerClass.TileY, tileX, tileY);
				if (!willTakeHit) {
					cone.CalculateConeEquals (player.PlayerClass.TileX, player.PlayerClass.TileY, tileX, tileY);
				}
			
			}
			if (buttonScripts.allySelected) {
				canAttack = false;
				enemyTarget = false;
				// Makes basic coloring for all tiles in range
				highlightTiles.ShowTilesThatInRangeGeneral (player.PlayerClass.TileX, player.PlayerClass.TileY);
				highlightTiles.tileX = tileX;
				highlightTiles.tileY = tileY;
				if (canAttack) {
					highlightTiles.ShowTilesThatWillBeHitSkill ();
				} else if (!canAttack) {
					highlightTiles.ShowTilesThatWillNotBeHitSkill ();
				}

			}
			if (buttonScripts.trapSelected) {
				canAttack = false;
//			enemyTarget = true;
				// Makes basic coloring for all tiles in range
				highlightTiles.ShowTilesThatInTrapRange (player.PlayerClass.TileX, player.PlayerClass.TileY);
				highlightTiles.tileX = tileX;
				highlightTiles.tileY = tileY;
				if (canAttack) {
					highlightTiles.ShowTilesThatWillBeHitSkill ();
				} else if (!canAttack) {
					highlightTiles.ShowTilesThatWillNotBeHitSkill ();
				}				
			}
		
			if (buttonScripts.attackSelected) {
				canAttack = false;
				enemyTarget = true;
				// Makes basic coloring for all tiles in range
				highlightTiles.ShowTilesThatInRangeGeneral (player.PlayerClass.TileX, player.PlayerClass.TileY);
				highlightTiles.tileX = tileX;
				highlightTiles.tileY = tileY;
				if (canAttack) {
					highlightTiles.ShowTilesThatWillBeHitSkill ();
				} else if (!canAttack) {
					highlightTiles.ShowTilesThatWillNotBeHitSkill ();
				}				
			}
		}
	}

	void OnMouseExit()
	{	
		Material[] mat = this.GetComponent<Renderer>().materials;
		mat[1] = primaryMaterial;
//		GameObject ButtonScripts = GameObject.Find ("ButtonsCanvas");
//		ButtonScripts buttonScripts = ButtonScripts.GetComponent<ButtonScripts> ();
		GameObject HighlightTiles = GameObject.Find ("_Scripts");
		HighlightTiles highlightTiles = HighlightTiles.GetComponent<HighlightTiles> ();

		canAttack = false;
		if (buttonScripts.coneSelected || buttonScripts.drawSelected || buttonScripts.changeAreaTiles || buttonScripts.changeAreaTilesNoMid  || buttonScripts.moveSelected)
		{
			highlightTiles.HideAllowedTiles();
		}
	}
	public void IsNotWalkable()
	{
		isWalkable = false;
	}
	public void IsWalkable()
	{
		isWalkable = true;
	}


	void HitEnemy()
	{
		GameObject CardDropArea = GameObject.Find ("CardDropArea");
		DropZone dropZone = CardDropArea.GetComponent<DropZone>();
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject Enemy in Enemies) {
			BaseEnemy enemy = Enemy.GetComponent<BaseEnemy> ();
			GameObject Tile = GameObject.Find("Hex_" + enemy.TileX + "_" + enemy.TileY);
			ClickableTile tile = Tile.GetComponent<ClickableTile> ();
			if (tile.willTakeHit) {
				enemy.Recentlyhit = true;
				HealthBar enemyHpBar = enemy.GetComponent<HealthBar> ();		
				//TODO
				//if lauseke johonkin, joka tarkistaa onko kyseess' physDMG vai magic DMG
				enemyHpBar.CurHealth -= (dropZone.damage / enemy.HpPointsMax) * ( 100 * (enemy.PhysDmgReduction + enemy.MagicDmgReduction));
				enemyHpBar.SetHealthBarEnemy();
				enemyHpBar.parentName = Enemy.name;
				enemyHpBar.KillUnit();
				tile.willTakeHit = false;
			}
		}
	}

}
