using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealCard : Card {

	public GameObject cardPrefab;
	public int CardHeal { get; set;}

	void Start()
	{
		// Change card variable to physical copy here

		this.name = CardName + " Card";
		transform.Find("CardName").GetComponent<Text>().text = CardName;
		transform.Find("CardDecription").GetComponent<Text>().text = CardDescription;
		transform.Find("CardHeal").GetComponent<Text>().text = CardHeal.ToString();
		transform.Find("CardCost").GetComponent<Text>().text = CardCost.ToString();

		GetComponentInParent<Draggable>().cardType = CardTypes.Heal;
	}

	public void CopyActionsFrom(HealCard c)
	{
		this.CardHeal = c.CardHeal;
		this.CardName = c.CardName;
		this.CardCost = c.CardCost;
		this.CardDescription = c.CardDescription;
		this.Target = c.Target;
		this.Area = c.Area;
		this.Range = c.Range;
		this.Effect = c.Effect;
		this.CardDraw = c.CardDraw;
	}
	

}
