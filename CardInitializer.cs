using UnityEngine;
using System.Collections;
using System;

public class CardInitializer : MonoBehaviour {
/*	public GameObject cardPrefab;

	public void Start() {
		GameObject cardGO;
		Draggable card;
		GameObject deck = GameObject.Find ("Deck");
		//  STARTER
		
		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Draggable>();
		card.title = "Attack";
//		card.typeDescription = "Maneuver";
		card.effect = Effects.Attack;
		card.description = "Basic Attack";
		card.movementCost = 1;
		card.attack = 3;
		card.transform.SetParent(deck.transform); 
		card.transform.gameObject.SetActive(false);
		
//		card.onPlayedMonster = (c, m) => { c.DealDamage(m, c.CalculatedAttack()); };
//		GameManager.instance.AddCardToDatabase(Rarity.Starter, card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Draggable>();
		card.title = "Change tiles";
		card.effect = Effects.ChangeArea;
//		card.typeDescription = "Maneuver";
		card.description = "Change tiles: Area 2";
		card.movementCost = 2;
		card.attack = 0;
		card.transform.SetParent(deck.transform); 
		card.transform.gameObject.SetActive(false);
*///		}
/*
		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Punch";
		card.typeDescription = "Maneuver";
		card.description = "";
		card.endCost = 0;
		card.attack = 2;
		card.onPlayedMonster = (c, m) => { c.DealDamage(m, c.CalculatedAttack()); };
		GameManager.instance.AddCardToDatabase(Rarity.Starter, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Block";
		card.typeDescription = "Maneuver";
		card.description = "Take no damage from one attack.";
		card.endCost = 0;
		card.endsTurn = false;
		card.playability = Playability.Utility;
		card.onPlayed = (c) => { GameManager.instance.blockHits++; };
		GameManager.instance.AddCardToDatabase(Rarity.Starter, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Cup of Tea";
		card.typeDescription = "Tool";
		card.description = "Regain 2 END.";
		card.endCost = 0;
		card.endsTurn = false;
		card.playability = Playability.Utility;
		card.onPlayed = (c) => { GameManager.instance.HealPlayer(2); };
		GameManager.instance.AddCardToDatabase(Rarity.Starter, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Strategize";
		card.typeDescription = "Maneuver";
		card.description = "Draw Two Cards.";
		card.endCost = 0;
		card.playability = Playability.Utility;
		card.onPlayed = (c) => { GameManager.instance.DrawCard(); GameManager.instance.DrawCard();  };
		GameManager.instance.AddCardToDatabase(Rarity.Starter, card);



		//  COMMON


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Bandages";
		card.typeDescription = "Tool";
		card.description = "Draw a card, then destroy a wound card from your hand. Destroy this card after use.";
		card.endCost = 0;
		card.playability = Playability.Utility;
		card.onPlayed = (c) => { 
			Utilities.PlayerDeck().GetComponent<Deck>().DrawCard(); 
			GameManager.instance.ShowCardSelectionWindow(
				"Choose a card to destroy. (This will also destroy Bandages.)",
			(selection) => { selection.DestroyCard(); c.DestroyCard(); },
			true,
			false,
			false,
			CardSelectionDialog.Filter_IsWound
			);
		};
		GameManager.instance.AddCardToDatabase(Rarity.Common, card);

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Venom Glands";
		card.description = "Deals damage to an enemy for 2 turns.";
		card.endCost = 0;
		card.attack = 2;
		card.onPlayedMonster = (c, m) => { m.AddPoisonStack( new PoisonStack(c.attack, 3)); };
		GameManager.instance.AddCardToDatabase(Rarity.Common, card);



		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Orc Teeth";
		card.description = "Chomp!";
		card.endCost = 0;
		card.attack = 3;
		card.onPlayedMonster = (c, m) => { c.DealDamage(m, c.CalculatedAttack()); };
		GameManager.instance.AddCardToDatabase(Rarity.Common, card);



		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Sharp Claws";
		card.description = "Swipe at all enemies.";
		card.endCost = 2;
		card.attack = 2;
		card.onPlayed = (c) => { GameManager.instance.DamageAllMonsters(c.attack); };
		GameManager.instance.AddCardToDatabase(Rarity.Common, card);



		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Hard Shell";
		card.description = "Reduce all damage you receive by 1 for 1 turn.";
		card.endCost = 0;
		card.playability = Playability.Utility;
		card.endsTurn = false;
		card.onPlayed = (c) => { GameManager.instance.AddDamageReduction(new DamageReduction(1, 1)); };
		GameManager.instance.AddCardToDatabase(Rarity.Common, card);



		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Tough Cranium";
		card.description = "";
		card.endCost = 1;
		card.attack = 4;
		card.onPlayedMonster = (c, m) => { c.DealDamage(m, c.CalculatedAttack()); };
		GameManager.instance.AddCardToDatabase(Rarity.Common, card);



		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Scalpel";
		card.typeDescription = "Tool";
		card.description = "";
		card.endCost = 1;
		card.attack = 1;
		card.endsTurn = false;
		card.onPlayedMonster = (c, m) => { c.DealDamage(m, c.CalculatedAttack()); };
		GameManager.instance.AddCardToDatabase(Rarity.Common, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Horns";
		card.description = "Knock over the enemy, stunning it for one turn.";
		card.endCost = 0;
		card.attack = 2;
		card.onPlayedMonster = (c, m) => { c.DealDamage(m, c.CalculatedAttack()); m.ApplyCondition( Condition.Stunned, 1 ); };
		GameManager.instance.AddCardToDatabase(Rarity.Common, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Leathery Wings";
		card.description = "You can't be hit by melee for one turn.";
		card.endCost = 0;
		card.playability = Playability.Utility;
		card.onPlayed = (c) => {  GameManager.instance.flying++; };
		GameManager.instance.AddCardToDatabase(Rarity.Common, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Frog Tongue";
		card.description = "Ranged";
		card.endCost = 0;
		card.attack = 2;
		card.onPlayedMonster = (c, m) => { c.DealDamage(m, c.CalculatedAttack(), false); };
		GameManager.instance.AddCardToDatabase(Rarity.Common, card);





		// RARE

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Stitches";
		card.typeDescription = "Tool";
		card.description = "Destroy one wound card from your hand, deck, or discard";
		card.endCost = 0;
		card.endsTurn = false;
		card.playability = Playability.Utility;
		card.onPlayed = (c) => { GameManager.instance.ShowCardSelectionWindow(
			"Choose a card to destroy.",
			(selection) => { selection.DestroyCard(); },
			true,
			true,
			true,
			CardSelectionDialog.Filter_IsWound
		);
		};
		GameManager.instance.AddCardToDatabase(Rarity.Rare, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Constricting Tail";
		card.description = "Stun an enemy for two turns.";
		card.endCost = 2;
		card.attack = 2;
		card.onPlayedMonster = (c, m) => { c.DealDamage(m, c.CalculatedAttack()); m.ApplyCondition( Condition.Stunned, 2 ); };
		GameManager.instance.AddCardToDatabase(Rarity.Rare, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Spiked Tail";
		card.description = "Swipe at all enemies.";
		card.endCost = 2;
		card.attack = 3;
		card.onPlayed = (c) => { GameManager.instance.DamageAllMonsters(c.attack); };
		GameManager.instance.AddCardToDatabase(Rarity.Rare, card);




		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Adrenal Extract";
		card.description = "Add +1 Damage to a card in your hand.";
		card.endCost = 0;
		card.playability = Playability.Utility;
		card.onPlayed = (c) => { GameManager.instance.ShowCardSelectionWindow(
			"Choose a card to add +1 damage to.",
			(selection) => { selection.attack += 1; },
			true,
			false,
			false,
			CardSelectionDialog.Filter_IsAttack
		);
		};
		GameManager.instance.AddCardToDatabase(Rarity.Rare, card);




		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Spiked Shell";
		card.description = "IN HAND: Injures anyone who hits you with melee.\nPLAY: Reduce all damage you receive by 1 for 1 turn.";
		card.endCost = 0;
		card.attack = 1;
		card.playability = Playability.Utility;
		card.endsTurn = false;
		card.onPlayerDamaged = (c, m, dmg_in) => { if(m.type == MonsterType.Melee ) { m.DamageMonster( c.CalculatedAttack(), false ); } return dmg_in; };
		card.onPlayed = (c) => { GameManager.instance.AddDamageReduction(new DamageReduction(1, 1)); };
		GameManager.instance.AddCardToDatabase(Rarity.Rare, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Bloodhound Nose";
		card.endCost = 0;
		card.endsTurn = false;
		card.playability = Playability.Utility;
		card.description = "Sniff through your discard pile and add a card to your hand.";
		card.onPlayed = (c) => { 
			GameManager.instance.ShowCardSelectionWindow(
				"Choose a card to add to your hand.",
				(selected) => { selected.transform.SetParent(Utilities.PlayerHand().transform); selected.gameObject.SetActive(true); },
				false, false, true); 
		};
		GameManager.instance.AddCardToDatabase(Rarity.Rare, card);



		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Vampire Fangs";
		card.description = "Heals END equal to damage dealt.\n<i>NOM NOM NOM</i>";
		card.endCost = 0;
		card.attack = 2;
		card.onPlayedMonster = (c, m) => { GameManager.instance.HealPlayer( m.DamageMonster( c.CalculatedAttack(), true ) ); };
		GameManager.instance.AddCardToDatabase(Rarity.Rare, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Acid Spray";
		card.description = "Deals damage for 2 turns.\n<i>The goggles, they do nothing.</i>";
		card.endCost = 2;
		card.attack = 4;
		card.onPlayedMonster = (c, m) => { m.AddPoisonStack( new PoisonStack(c.attack, 2) ); };
		GameManager.instance.AddCardToDatabase(Rarity.Rare, card);



		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Poisonous Skin";
		card.description = "IN HAND: Melee attackers are poisoned for 3 turns.";
		card.endCost = 0;
		card.attack = 1;
		card.playability = Playability.Utility;
		card.onPlayerDamaged = (c, m, dmg_in) => { if(m.type == MonsterType.Melee ) { m.AddPoisonStack(new PoisonStack(c.attack, 3)); } return dmg_in; };
		GameManager.instance.AddCardToDatabase(Rarity.Rare, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Orc Head";
		card.description = "Also deals damage to one other random enemy.\n<i>Double Headbutt!</i>";
		card.endCost = 0;
		card.attack = 2;
		card.onPlayedMonster = (c, m) => { c.DealDamage(m, c.CalculatedAttack()); GameManager.instance.DamageRandomMonster(c.CalculatedAttack(), true, m);  };
		GameManager.instance.AddCardToDatabase(Rarity.Rare, card);




		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Cheetah Legs";
		card.description = "Next card costs no endurance.";
		card.endCost = 0;
		card.playability = Playability.Utility;
		card.endsTurn = false;
		card.onPlayed = (c) => { GameManager.instance.freeCasts++; };
		GameManager.instance.AddCardToDatabase(Rarity.Rare, card);



		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Extra Heart";
		card.description = "IN HAND: Heal 1 END per turn. PLAY: Increase your maximum endurance by 1.";
		card.endCost = 0;
		card.playability = Playability.Utility;
		card.onTurnStart = (c) => { GameManager.instance.HealPlayer(1); };
		card.onPlayed = (c) => { GameManager.instance.maxEndurance += 1; };
		GameManager.instance.AddCardToDatabase(Rarity.Rare, card);



		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Narwhal Horn";
		card.description = "Stun an enemy for 1 turns.";
		card.endCost = 0;
		card.attack = 2;
		card.onPlayedMonster = (c, m) => { c.DealDamage(m, c.CalculatedAttack()); m.ApplyCondition( Condition.Stunned, 1 ); };
		GameManager.instance.AddCardToDatabase(Rarity.Rare, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Phoenix Feathers";
		card.description = "Destroy all wound cards in your hand. Destroyed after use.";
		card.endCost = 0;
		card.playability = Playability.Utility;
		card.endsTurn = false;
		card.onPlayed = (c) => { 
			Transform hand = Utilities.PlayerHand().transform;
			for (int i = 0; i < hand.childCount; i++) {
				Card handCard = hand.GetChild(i).GetComponent<Card>();
				if(handCard.rarity == Rarity.Wound) {
					Destroy(handCard.gameObject);
				}
			}
			Destroy(c.gameObject);
		};
		GameManager.instance.AddCardToDatabase(Rarity.Rare, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Extra Finger";
		card.description = "IN HAND: Hand limit is 6.";
		card.endCost = 0;
		card.attack  = 3;
		card.onTurnStart     = (c) => { if(GameManager.instance.handMax < 6) {GameManager.instance.handMax = 6;} };
		card.onDrawn         = (c) => { if(GameManager.instance.handMax < 6) {GameManager.instance.handMax = 6;} };
		card.onPlayedMonster = (c, m) => { c.DealDamage(m, c.CalculatedAttack());  };
		GameManager.instance.AddCardToDatabase(Rarity.Rare, card);



		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Eagle Eyes";
		card.description = "Draw three cards, then discard two cards.";
		card.endCost = 0;
		card.playability = Playability.Utility;
		card.onPlayed = (c) => {
			for (int i = 0; i < 3; i++) {
				GameManager.instance.DrawCard(true);
			}

			GameManager.instance.ShowCardSelectionWindow(
				"Discard 2 more cards.",
				(selection) => { 
					Utilities.PlayerDiscard().GetComponent<Deck>().AddCard(selection); 
					GameManager.instance.ShowCardSelectionWindow(
						"Discard 1 more card.",
						(selection2) => { Utilities.PlayerDiscard().GetComponent<Deck>().AddCard(selection2); },
						true,
						false,
						false
					);
				},
				true,
				false,
				false
			);
		};
		GameManager.instance.AddCardToDatabase(Rarity.Rare, card);



		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Tapeworm";
		card.typeDescription = "Companion";
		card.description = "Draw a card, then optionally destroy a card from your hand.";
		card.endCost = 0;
		card.endsTurn=false;
		card.playability = Playability.Utility;
		card.onPlayed = (c) => { 
			Utilities.PlayerDeck().GetComponent<Deck>().DrawCard(); 
			GameManager.instance.ShowCardSelectionWindow(
				"Choose a card to destroy.",
				(selection) => { selection.DestroyCard(); },
				true,
				false,
				false
		);
		};
		GameManager.instance.AddCardToDatabase(Rarity.Rare, card);



		// EPIC

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Bonesaw";
		card.typeDescription = "Tool";
		card.description = "Destroy any card in your hand, deck, or discard.";
		card.endCost = 0;
		card.playability = Playability.Utility;
		card.onPlayed = (c) => { GameManager.instance.ShowCardSelectionWindow(
			"Choose a card to destroy.",
			(selection) => { selection.DestroyCard(); },
			true,
			true,
			true
		);
		};
		GameManager.instance.AddCardToDatabase(Rarity.Epic, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Troll Blood";
		card.description = "IN HAND: Heal 2 END per turn. PLAY: Increase your maximum endurance by 1.";
		card.endCost = 0;
		card.playability = Playability.Utility;
		card.endsTurn = false;
		card.onTurnStart = (c) => { GameManager.instance.HealPlayer(2); };
		card.onPlayed = (c) => { GameManager.instance.maxEndurance += 1; };
		GameManager.instance.AddCardToDatabase(Rarity.Epic, card);



		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Quills";
		card.description = "IN HAND: Injures anyone who hits you with melee.\nPLAY: Damage all enemies, ranged.";
		card.endCost = 0;
		card.attack = 2;
		card.endsTurn = false;
		card.onPlayerDamaged = (c, m, dmg_in) => { if(m.type == MonsterType.Melee ) { m.DamageMonster( c.CalculatedAttack(), false ); } return dmg_in; };
		card.onPlayed = (c) => { GameManager.instance.DamageAllMonsters( c.CalculatedAttack(), false ); };
		GameManager.instance.AddCardToDatabase(Rarity.Epic, card);



		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Stink Gland";
		card.description = "Stun all enemies for one round.";
		card.endCost = 2;
		card.playability = Playability.Utility;
		card.onPlayed = (c) => { 
			foreach(Monster m in GameManager.instance.AllMonsters()) {
				m.ApplyCondition(Condition.Stunned, 1);
			}
		};
		GameManager.instance.AddCardToDatabase(Rarity.Epic, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Cup of Coffee";
		card.typeDescription = "Tool";
		card.description = "Next card played is quick!\n<i>The tool of choice for all LDers!</i>";
		card.endCost = 0;
		card.playability = Playability.Utility;
		card.endsTurn = false;
		card.onPlayed = (c) => { GameManager.instance.quickCasts++; };
		GameManager.instance.AddCardToDatabase(Rarity.Epic, card);





		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Rabies";
		card.typeDescription = "Disease";
		card.description = "Discard your hand. <i>Bwarawarwwreawr!</i>";
		card.endCost = 0;
		card.attack = 10;
		card.onPlayedMonster = (c, m) => { m.DamageMonster( c.CalculatedAttack(), true ); GameManager.instance.DiscardHand(); };
		GameManager.instance.AddCardToDatabase(Rarity.Epic, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Sensitive Nose";
		card.description = "Discard 3 cards at random and then draw 3 cards.";
		card.endCost = 0;
		card.playability = Playability.Utility;
		card.onPlayed = (c) => {
			int r = 3;//UnityEngine.Random.Range(1, 4);

			for (int i = 0; i < r; i++) {
				GameManager.instance.DiscardRandomCard();
			}

			for (int i = 0; i < r; i++) {
				GameManager.instance.DrawCard(true);
			}

		};
		GameManager.instance.AddCardToDatabase(Rarity.Epic, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Angel Wings";
		card.description = "You can't be hit by melee for one turn.";
		card.endCost = 2;
		card.endsTurn = false;
		card.playability = Playability.Utility;
		card.onPlayed = (c) => {  GameManager.instance.flying++; };
		GameManager.instance.AddCardToDatabase(Rarity.Epic, card);



		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Owl Head";
		card.description = "Draw 2 cards.";
		card.endCost = 0;
		card.endsTurn = false;
		card.playability = Playability.Utility;
		card.onPlayed = (c) => {  GameManager.instance.DrawCard(); GameManager.instance.DrawCard(true);  };
		GameManager.instance.AddCardToDatabase(Rarity.Epic, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Basilisk Eyes";
		card.description = "Turn an enemy to stone for 3 turns! (They can't be damaged.)";
		card.endCost = 4;
		card.playability = Playability.Utility;
		card.onPlayedMonster = (c, m) => { m.ApplyCondition( Condition.Stoned, 3 );  };
		GameManager.instance.AddCardToDatabase(Rarity.Epic, card);



		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Octopus Tentacle";
		card.description = "IN HAND: Hand limit is 7.";
		card.endCost = 0;
		card.attack  = 3;
		card.onTurnStart     = (c) => { if(GameManager.instance.handMax < 7) {GameManager.instance.handMax = 7;} };
		card.onDrawn         = (c) => { if(GameManager.instance.handMax < 7) {GameManager.instance.handMax = 7;} };
		card.onPlayedMonster = (c, m) => { c.DealDamage(m, c.CalculatedAttack());  };
		GameManager.instance.AddCardToDatabase(Rarity.Epic, card);



		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Chameleon Ichor";
		card.typeDescription = "Goo";
		card.description = "Play to turn this card into a copy of any card in your hand. The card will turn back into Chameleon Ichor after use.";
		card.endCost = 0;
		card.endsTurn = false;
		card.playability = Playability.Utility;
		card.onPlayed = (c) => { 
			GameManager.instance.ShowCardSelectionWindow(
				"Choose a card to clone.",
				(selected) => {
					// Clone the selected card
					Card clone = ((GameObject)Instantiate(selected.gameObject)).GetComponent<Card>();
					clone.CopyActionsFrom(selected);
					// Add to your hand
					clone.transform.SetParent( Utilities.PlayerHand().transform );
					clone.transform.localScale = Vector3.one;

					// Destroy this Chameleon Ichor
					c.DestroyCard();

					clone.onPlayed += (c2) => { 
						c2.DestroyCard();
						GameManager.instance.AddCardToDiscard("Chameleon Ichor");
					};
				},
				true,
				false,
				false
			);
		};
		GameManager.instance.AddCardToDatabase(Rarity.Epic, card);




		// LEGENDARY

		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Shapeshift";
		card.typeDescription = "Maneuver";
		card.description = "Discard your hand and draw cards to your hand limit.";
		card.endCost = 0;
		card.playability = Playability.Utility;
		card.onPlayed = (c) => { 
			GameManager.instance.DiscardHand(true);
			for (int i = 0; i < GameManager.instance.handMax; i++) {
				GameManager.instance.DrawCard();
			}
		};
		GameManager.instance.AddCardToDatabase(Rarity.Legendary, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Venomous Quills";
		card.description = "IN HAND: Injures anyone who hits you with melee.\nPLAY: Poisons all enemies for 3 turns, ranged.";
		card.endCost = 2;
		card.attack = 2;
		card.endsTurn = false;
		card.onPlayerDamaged = (c, m, dmg_in) => { if(m.type == MonsterType.Melee ) { m.DamageMonster( c.CalculatedAttack(), false ); } return dmg_in; };
		card.onPlayed = (c) => { 
			foreach(Monster m in GameManager.instance.AllMonsters() ) {
				m.AddPoisonStack( new PoisonStack( c.CalculatedAttack(), 3));
			}
		};
		GameManager.instance.AddCardToDatabase(Rarity.Epic, card);



		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Hydra Head";
		card.description = "IN HAND: If you take damage, add a Hydra Head to your discard pile.";
		card.endCost = 2;
		card.attack = 4;
		card.onPlayerDamaged = (c, m, dmg_in) => { 		GameManager.instance.AddCardToDiscard("Spawned Hydra Head");
			; return dmg_in; };
		card.onPlayedMonster = (c, m) => { c.DealDamage(m, c.CalculatedAttack()); };
		GameManager.instance.AddCardToDatabase(Rarity.Epic, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Spawned Hydra Head";
		card.description = "Does not copy itself.";
		card.endCost = 2;
		card.attack = 4;
		card.onPlayedMonster = (c, m) => { c.DealDamage(m, c.CalculatedAttack()); };
		GameManager.instance.AddCardToDatabase(Rarity.Spawned, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Headbutt of Vecna";
		card.typeDescription = "Maneuver";
		card.description = "This doesn't even make sense.";
		card.endCost = 2;
		card.attack = 6;
		card.onPlayedMonster = (c, m) => { c.DealDamage(m, c.CalculatedAttack()); };
		GameManager.instance.AddCardToDatabase(Rarity.Legendary, card);


		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Kittenzilla's Laser Eyes";
		card.description = "Hits all enemies, ranged. And fuzzy.";
		card.endCost = 2;
		card.attack = 4;
		card.onPlayed = (c) => { GameManager.instance.DamageAllMonsters(c.CalculatedAttack(), false); };
		GameManager.instance.AddCardToDatabase(Rarity.Legendary, card);



		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Medusa's Hair";
		card.description = "Deals Damage for 3 turns.\n<i>So many snakes!</i>";
		card.endCost = 0;
		card.attack = 3;
		card.onPlayedMonster = (c, m) => { m.AddPoisonStack( new PoisonStack(c.CalculatedAttack(), 3)); };
		GameManager.instance.AddCardToDatabase(Rarity.Legendary, card);




		cardGO = (GameObject)Instantiate(cardPrefab);
		card = cardGO.GetComponent<Card>();
		card.title = "Unicorn Horn";
		card.description = "Stun the enemy for 1 turn.";
		card.endCost = 0;
		card.attack = 4;
		card.onPlayedMonster = (c, m) => { m.DamageMonster( c.CalculatedAttack(), true); m.ApplyCondition(Condition.Stunned, 1); };
		GameManager.instance.AddCardToDatabase(Rarity.Legendary, card);








		// WOUND

		string[] woundNames = {
			"Cracked Rib",
			"Bloody Nose",
			"Stubbed Toe",
			"Boneitis",
			"Broken Femur",
			"Hang Nail",
			"Concussion",
			"Shin Splints",
			"Torn ACL",
			"Arrow's Knee",
			"Bruised Spirit",
			"Black Eye",
			"Paper Cut",
			"Punctured Lung",
			"Achilles Heel",
			"Bruised Ego",
			"Claw Marks",
			"Missing Tooth",
			"Poked Eye",
			"Fat Lip",
			"Flesh Wound",
			"Gangrene"
		};

		foreach(string wn in woundNames) {
			cardGO = (GameObject)Instantiate(cardPrefab);
			card = cardGO.GetComponent<Card>();
			card.title = wn;
			card.attack = 0;
			card.endCost = 0;
			card.description = "You LOSE if you have 3 wounds in your hand.";
			card.playability = Playability.Utility;
			card.onDrawn = (c) => { GameManager.instance.CheckLoseCondition(); };
			GameManager.instance.AddCardToDatabase(Rarity.Wound, card);
		}


		BuildInitialPlayerDeck();

	}

	void BuildInitialPlayerDeck() {
		GameManager.instance.AddCardToDeck("Punch");
		GameManager.instance.AddCardToDeck("Punch");
		GameManager.instance.AddCardToDeck("Punch");
		GameManager.instance.AddCardToDeck("Headbutt");
		GameManager.instance.AddCardToDeck("Trip");
		GameManager.instance.AddCardToDeck("Block");
		GameManager.instance.AddCardToDeck("Cup of Tea");
		GameManager.instance.AddCardToDeck("Strategize");

/*		GameManager.instance.AddCardToDeck("Bloodhound Nose");
		GameManager.instance.AddCardToDeck("Bloodhound Nose");
		GameManager.instance.AddCardToDeck("Bloodhound Nose");
		GameManager.instance.AddCardToDeck("Bloodhound Nose");

*/		/*foreach(string s in GameManager.instance.allCards.Keys) {
			GameManager.instance.AddCardToDeck(s);
		}*/

//		Utilities.PlayerDeck().GetComponent<Deck>().Shuffle();
//	}

}
