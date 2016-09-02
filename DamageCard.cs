using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageCard :  Card {
	
	public GameObject cardPrefab;
//	private int cardDamage;
//	private DamageTypes damageType;

	
	public int CardDamage { get; set;}
	public DamageTypes DamageType { get; set;}

	void Start()
	{
		// Change card variable to physical copy here

		this.name = CardName + " Card";
		this.transform.Find("CardName").GetComponent<Text>().text = CardName;
		this.transform.Find("CardDecription").GetComponent<Text>().text = CardDescription;
		this.transform.Find("CardAttack").GetComponent<Text>().text = CardDamage.ToString();
		this.transform.Find("CardCost").GetComponent<Text>().text = CardCost.ToString();

		GetComponentInParent<Draggable>().cardType = CardTypes.Damage;

	}
	public void CopyActionsFrom(DamageCard c)
	{
		this.CardDamage = c.CardDamage;
		this.CardName = c.CardName;
		this.CardCost = c.CardCost;
		this.CardDescription = c.CardDescription;
		this.Target = c.Target;
		this.Area = c.Area;
		this.Range = c.Range;
		this.Effect = c.Effect;
		this.CardDraw = c.CardDraw;
		this.DamageType = c.DamageType;
	}
}
