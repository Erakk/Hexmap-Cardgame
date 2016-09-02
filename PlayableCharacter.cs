using UnityEngine;
using System.Collections.Generic;

public class PlayableCharacter : MonoBehaviour, EffectForUnits {

	public BaseClass PlayerClass { get; set;}
	
//	private TileMap map;
	public List<Node> currentPath = null;
	public List<Node> VisibleNodes = null;
	public bool isSelected = false;
	public bool recentlyHit = false;
	private string currentTile;
	private float MagicDmgReduction = 0;
	private float PhysDmgReduction = 0;

	void Start()
	{
		//TODO
		//Saattaa olla parempi merkitä tää uudessä Tilemapsissa
//		map = TileMap.map;
	}

	public void StartWalkable(){
//		currentTile = "Hex_" + PlayerClass.TileX + "_" + PlayerClass.TileY;
//		GameObject.Find (currentTile).GetComponent<ClickableTile> ().IsNotWalkable();
	}
	public void CalculateMainStats()
	{

		PlayerClass.MoveSpeed = PlayerClass.Dexterity / 2;
		PlayerClass.HpPointsMax = PlayerClass.Strength * 3;
		PlayerClass.CardCostReduction = PlayerClass.Intelligence / 25f;
		PlayerClass.CardRangeIncrease = PlayerClass.Wisdom / 50f;
		PlayerClass.PhysicalAttackDMG = PlayerClass.Strength / 2;
		PlayerClass.RangedAttackDMG = PlayerClass.Dexterity / 2;
		PlayerClass.MagicAttackDMG = PlayerClass.Intelligence / 2;
		PlayerClass.HealValue = PlayerClass.Wisdom;
		PlayerClass.HpPointsRemaining = PlayerClass.HpPointsMax;
		PlayerClass.RemainingMovement = PlayerClass.MoveSpeed;
		PlayerClass.Alive = true;
	}
	public void MoveNextTile() {
//		PlayerClass.RemainingMovement = PlayerClass.MoveSpeed;
		GameObject Map = GameObject.Find ("Map");
		TileMap map = Map.GetComponent<TileMap> ();
		GameObject ButtonScripts = GameObject.Find ("ButtonsCanvas");
		ButtonScripts buttonScripts = ButtonScripts.GetComponent<ButtonScripts> ();
		if (buttonScripts.moveSelected){
			while(PlayerClass.RemainingMovement > 0 ) {	
//				currentTile = ("Hex_" + PlayerClass.TileX + "_" + PlayerClass.TileY);
//				GameObject.Find (currentTile).GetComponent<ClickableTile> ().IsNotWalkable();

//				int tileXHolder = PlayerClass.TileX;
//				int tileYHolder = PlayerClass.TileY;

				if(currentPath==null )
					return;
				PlayerClass.RemainingMovement -= map.CostToEnterTile(currentPath[0].x, currentPath[0].y, currentPath[1].x, currentPath[1].y );
				PlayerClass.TileX = currentPath[1].x;
				PlayerClass.TileY = currentPath[1].y;
				TransformPosition();
				currentPath.RemoveAt(0);
				if(currentPath.Count == 1) {
					currentPath = null;
				}
				buttonScripts.moveSelected = false;	
//				currentTile = ("Hex_" + tileXHolder + "_" + tileYHolder);
//				ClickableTile clickableTile = GameObject.Find (currentTile).GetComponent<ClickableTile> ();
//				clickableTile.IsWalkable();
//				currentTile = ("Hex_" + PlayerClass.TileX + "_" + PlayerClass.TileY);
//				clickableTile = GameObject.Find (currentTile).GetComponent<ClickableTile> ();
//				clickableTile.IsNotWalkable();
			}
//			map.CalculateAttackableTiles();
		}	
		return;
	}
	public void TransformPosition(){
		GameObject Map = GameObject.Find ("Map");
		TileMap map = Map.GetComponent<TileMap> ();
		transform.position = map.TileCoordToWorldCoord( PlayerClass.TileX, PlayerClass.TileY );
	}
	public void RunEffects(){
		GameObject effects = GameObject.Find ("Effects");
		GameObject Map = GameObject.Find ("Map");
		TileMap map = Map.GetComponent<TileMap> ();
		map.selecterPlayer = this.name;
		if (Restoration) {
//			map.selectedEnemy = this.name;
//			
			Restoration restoration = effects.GetComponent<Restoration> ();
			restoration.RunRestoration();
		}
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
	
	public void RemainingHp()
	{

	}
}
