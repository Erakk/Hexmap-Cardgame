using UnityEngine;
using System.Collections;

public class HealCardDatabase : HealCard {

	// Use this for initialization
	void Start () {
		GameObject cardGO;
		HealCard card;

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<HealCard>();
		card.CardName = "Basic Heal";
		card.CardDescription = "Heal";
		card.CardCost = 1;
		card.Range = 6;
		card.Rarity = Raritys.Basic;
		card.RequiredClass = RequiredClasses.Priest;
		card.CardHeal = 3;
		card.Target = Targets.Ally;
		GameController.control.AddHealCardToDatabase(card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<HealCard>();
		card.CardName = "Greater Heal";
		card.CardDescription = "Heal";
		card.CardCost = 2;
		card.Range = 6;
		card.Rarity = Raritys.Rare;
		card.RequiredClass = RequiredClasses.Priest;
		card.CardHeal = 6;
		card.Target = Targets.Ally;
		GameController.control.AddHealCardToDatabase(card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<HealCard>();
		card.CardName = "Light Wave";
		card.CardDescription = "Heal";
		card.CardCost = 2;
		card.Range = 0;
		card.Area = 6;
		card.Rarity = Raritys.Basic;
		card.RequiredClass = RequiredClasses.Priest;
		card.CardHeal = 3;
		card.Target = Targets.Self;
		GameController.control.AddHealCardToDatabase(card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<HealCard>();
		card.CardName = "Bandage";
		card.CardDescription = "Heal";
		card.CardCost = 1;
		card.Range = 1;
		card.Rarity = Raritys.Starter;
		card.RequiredClass = RequiredClasses.Any;
		card.Effect = Effects.RemoveBleed;
		card.CardHeal = 3;
		card.Target = Targets.Ally;
		GameController.control.AddHealCardToDatabase(card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<HealCard>();
		card.CardName = "Restoration";
		card.CardDescription = "Heal";
		card.CardCost = 1;
		card.Range = 5;
		card.Rarity = Raritys.Basic;
		card.RequiredClass = RequiredClasses.Priest;
		card.Effect = Effects.Restoration;
		card.Target = Targets.Ally;
		GameController.control.AddHealCardToDatabase(card);
	}
	

}
