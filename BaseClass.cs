using UnityEngine;
using System.Collections.Generic;

public abstract class BaseClass : MonoBehaviour{



	public string CharacterClassName { get; set;}
	public string CharacterClassDescription { get; set;}
	public int Strength { get; set;}
	public int Intelligence { get; set;}
	public int Wisdom { get; set;}
	public int Dexterity { get; set;}
	public int TileX { get; set;}
	public int TileY { get; set;}
	public int AttackRange { get; set;}
	public int AttackableTiles { get; set;}
	public int PhysicalAttackDMG { get; set;}
	public int MagicAttackDMG { get; set;}
	public int RangedAttackDMG { get; set;}
	public int DistanceToEnemy { get; set;}
	public float HealValue { get; set;}
	public float AttackDMG { get; set;}
	public int MoveSpeed { get; set;}
	public int Distance { get; set;}
	public float CardCostReduction { get; set;}
	public float CardRangeIncrease { get; set;}
	public float RemainingMovement { get; set;}
	public int HpPointsMax { get; set;}
	public int HpPointsRemaining { get; set;}

	public int ManaMax { get; set;}
	public int ManaRemaining { get; set;}
	public bool Alive { get; set;}
//	public List VisibleTiles { get; set;}
	

}
// Stats
//	strength; 		// Physical skill dmg + Health points
//	intelligence;	// Magic skill dmg + reduced card play cost
//	wisdom; 		// Healing amount + card play range
//	dexterity; 		// Ranged weapon skill dmg + movement points