using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UtilityCard : Card {

	public GameObject cardPrefab;

	void Start()
	{
		// Change card variable to physical copy here

		this.name = CardName + " Card";
		transform.Find("CardName").GetComponent<Text>().text = CardName;
		transform.Find("CardDecription").GetComponent<Text>().text = CardDescription;
		transform.Find("CardCost").GetComponent<Text>().text = CardCost.ToString();

		GetComponentInParent<Draggable>().cardType = CardTypes.Utility;
	}

	public void CopyActionsFrom(UtilityCard c)
	{
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
