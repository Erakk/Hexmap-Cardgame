using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum DamageTypes{
	Physical,
	Magic,
	Ranged
}

public enum Effects {
	Burn,
	Chill,
	Slow,
	Freeze,
	Stun,
	Poison,
	Bleed,
	RemoveBleed,
	ArmorUp,
	MagicResUp,
	ShieldUp,
	SpeedUp,
	Restoration,
	Fly,
	VisionTotem,
	SpellTotem,
	FullVision,
	SharedVision,
	AiAlly,
	Cure,
	Blind,
	Empty

}

public enum CardTypes{
	Damage,
	Utility,
	Heal
}

public enum Raritys{
	Starter,
	Basic,
	Rare,
	Epic,
	Legendary
}

public enum RequiredClasses{
	Warrior,
	Rogue,
	Mage,
	Priest,
	Any
}

public enum Targets{
	Self,
	Enemy,
	Ally,
	Line,
	Cone,
	Area,
	AreaMobility,
	Trap
}


public abstract class Card : MonoBehaviour {

/*
	private string cardName;
	private string cardDescription;
	private int cardCost;
	private Effects effect;
	private RequiredClasses requiredClass;
	private Raritys rarity;
	private Targets target;
	private int area;
	private int range;
	private bool mobility;
*/
	public string CardName { get; set;}
	public string CardDescription { get; set;}
	public int CardCost { get; set;}
	public int Area { get; set;}
	public int Range { get; set;}
	public int CardDraw { get; set;}
	public bool Mobility { get; set;}
	public Effects Effect { get; set;}
	public Raritys Rarity { get; set;}
	public RequiredClasses RequiredClass { get; set;}
	public Targets Target { get; set;}

	

}

