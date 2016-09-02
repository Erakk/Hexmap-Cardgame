using UnityEngine;
using System.Collections;

public class UtilityCardDatabase : UtilityCard {

	// Use this for initialization
	void Start () {
		GameObject cardGO;
		UtilityCard card;

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Create Mountains";
		card.CardDescription = "Some mountains";
		card.CardCost = 3;
		card.Range = 8;
		card.Area = 2;
		card.Effect = Effects.Empty;
		card.Rarity = Raritys.Rare;
		card.RequiredClass = RequiredClasses.Mage;
		card.Target = Targets.Area;
		GameController.control.AddUtilityCardToDatabase(card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Freeze";
		card.CardDescription = "Freeze";
		card.CardCost = 2;
		card.Range = 5;
		card.Area = 0;
		card.Effect = Effects.Freeze;
		card.Rarity = Raritys.Rare;
		card.RequiredClass = RequiredClasses.Mage;
		card.Target = Targets.Enemy;
		GameController.control.AddUtilityCardToDatabase(card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Leap";
		card.CardDescription = "Leap";
		card.CardCost = 1;
		card.Range = 6;
		card.Area = 0;
		card.Effect = Effects.Empty;
		card.Rarity = Raritys.Basic;
		card.RequiredClass = RequiredClasses.Warrior;
		card.Target = Targets.Area;
		GameController.control.AddUtilityCardToDatabase(card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Sprint";
		card.CardDescription = "Sprint";
		card.CardCost = 1;
		card.Range = 0;
		card.Area = 0;
		card.Effect = Effects.SpeedUp;
		card.Rarity = Raritys.Basic;
		card.RequiredClass = RequiredClasses.Rogue;
		card.Target = Targets.Self;
		GameController.control.AddUtilityCardToDatabase(card);
		
		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Shield Wall";
		card.CardDescription = "Shield Wall";
		card.CardCost = 1;
		card.Range = 0;
		card.Area = 0;
		card.Effect = Effects.ShieldUp;
		card.Rarity = Raritys.Basic;
		card.RequiredClass = RequiredClasses.Warrior;
		card.Target = Targets.Self;
		GameController.control.AddUtilityCardToDatabase(card);
	
		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Airwalk";
		card.CardDescription = "Airwalk";
		card.CardCost = 2;
		card.Range = 5;
		card.Area = 0;
		card.Effect = Effects.Fly;
		card.Rarity = Raritys.Basic;
		card.RequiredClass = RequiredClasses.Mage;
		card.Target = Targets.Ally;
		GameController.control.AddUtilityCardToDatabase(card);
	
		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Chilly Wind";
		card.CardDescription = "Chilly Wind";
		card.CardCost = 1;
		card.Range = 5;
		card.Area = 0;
		card.Effect = Effects.Chill;
		card.Rarity = Raritys.Basic;
		card.RequiredClass = RequiredClasses.Mage;
		card.Target = Targets.Cone;
		GameController.control.AddUtilityCardToDatabase(card);
	
		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Earth Shield";
		card.CardDescription = "Earth Shield";
		card.CardCost = 2;
		card.Range = 4;
		card.Area = 0;
		card.Effect = Effects.ArmorUp;
		card.Rarity = Raritys.Basic;
		card.RequiredClass = RequiredClasses.Mage;
		card.Target = Targets.Ally;
		GameController.control.AddUtilityCardToDatabase(card);
	
		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Shadowstep";
		card.CardDescription = "Shadowstep";
		card.CardCost = 1;
		card.Range = 4;
		card.Area = 0;
		card.Effect = Effects.Empty;
		card.Rarity = Raritys.Rare;
		card.RequiredClass = RequiredClasses.Rogue;
		card.Target = Targets.AreaMobility;
		GameController.control.AddUtilityCardToDatabase(card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Chill";
		card.CardDescription = "Chill";
		card.CardCost = 1;
		card.Range = 5;
		card.Area = 0;
		card.Effect = Effects.Chill;
		card.Rarity = Raritys.Basic;
		card.RequiredClass = RequiredClasses.Mage;
		card.Target = Targets.Enemy;
		GameController.control.AddUtilityCardToDatabase(card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Magic Shield";
		card.CardDescription = "Magic Shield";
		card.CardCost = 1;
		card.Range = 5;
		card.Area = 0;
		card.Effect = Effects.MagicResUp;
		card.Rarity = Raritys.Basic;
		card.RequiredClass = RequiredClasses.Mage;
		card.Target = Targets.Ally;
		GameController.control.AddUtilityCardToDatabase(card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Vision Totem";
		card.CardDescription = "Vision Totem";
		card.CardCost = 1;
		card.Range = 5;
		card.Area = 0;
		card.Effect = Effects.VisionTotem;
		card.Rarity = Raritys.Basic;
		card.RequiredClass = RequiredClasses.Priest;
		card.Target = Targets.Area;
		GameController.control.AddUtilityCardToDatabase(card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Spell Totem";
		card.CardDescription = "Spell Totem";
		card.CardCost = 2;
		card.Range = 5;
		card.Area = 0;
		card.Effect = Effects.SpellTotem;
		card.Rarity = Raritys.Rare;
		card.RequiredClass = RequiredClasses.Mage;
		card.Target = Targets.Area;
		GameController.control.AddUtilityCardToDatabase(card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Hawk Eye";
		card.CardDescription = "Hawk Eye";
		card.CardCost = 2;
		card.Range = 0;
		card.Area = 0;
		card.Effect = Effects.FullVision;
		card.Rarity = Raritys.Rare;
		card.RequiredClass = RequiredClasses.Rogue;
		card.Target = Targets.Self;
		GameController.control.AddUtilityCardToDatabase(card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Linked Minds";
		card.CardDescription = "Linked Minds";
		card.CardCost = 1;
		card.Range = 0;
		card.Area = 0;
		card.Effect = Effects.SharedVision;
		card.Rarity = Raritys.Rare;
		card.RequiredClass = RequiredClasses.Priest;
		card.Target = Targets.Self;
		GameController.control.AddUtilityCardToDatabase(card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Blood Brother";
		card.CardDescription = "Blood Brother";
		card.CardCost = 1;
		card.Range = 0;
		card.Area = 0;
		card.Effect = Effects.AiAlly;
		card.Rarity = Raritys.Rare;
		card.RequiredClass = RequiredClasses.Warrior;
		card.Target = Targets.Self;
		GameController.control.AddUtilityCardToDatabase(card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Soothing Wind";
		card.CardDescription = "Soothing Wind";
		card.CardCost = 2;
		card.Range = 4;
		card.Area = 0;
		card.Effect = Effects.Cure;
		card.Rarity = Raritys.Rare;
		card.RequiredClass = RequiredClasses.Priest;
		card.Target = Targets.Cone;
		GameController.control.AddUtilityCardToDatabase(card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Teleport";
		card.CardDescription = "Teleport";
		card.CardCost = 2;
		card.Range = 6;
		card.Area = 0;
		card.Effect = Effects.Empty;
		card.Rarity = Raritys.Rare;
		card.RequiredClass = RequiredClasses.Mage;
		card.Target = Targets.AreaMobility;
		GameController.control.AddUtilityCardToDatabase(card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Harden";
		card.CardDescription = "Harden";
		card.CardCost = 1;
		card.Range = 0;
		card.Area = 0;
		card.Effect = Effects.ArmorUp;
		card.Rarity = Raritys.Basic;
		card.RequiredClass = RequiredClasses.Warrior;
		card.Target = Targets.Self;
		GameController.control.AddUtilityCardToDatabase(card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<UtilityCard>();
		card.CardName = "Meditate";
		card.CardDescription = "Meditate";
		card.CardCost = 2;
		card.Range = 0;
		card.Area = 0;
		card.Effect = Effects.Empty;
		card.Rarity = Raritys.Starter;
		card.RequiredClass = RequiredClasses.Any;
		card.Target = Targets.Self;
		card.CardDraw = 2;
		GameController.control.AddUtilityCardToDatabase(card);
	}
	
}
