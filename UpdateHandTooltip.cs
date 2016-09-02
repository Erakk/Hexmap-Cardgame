using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateHandTooltip : MonoBehaviour {

	public TileMap map;

	public void UpdateHand()
	{
//		GameObject Map = GameObject.Find("Map");
//		TileMap map = Map.GetComponent<TileMap> ();
		GameObject Player = GameObject.Find(map.selecterPlayer);
		PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();

		GameObject Hand = GameObject.Find("Hand");

		DamageCard[] HealCards = Hand.GetComponentsInChildren<DamageCard> ();
		foreach (DamageCard card in HealCards) {
			int cardDamage = 0;
			int cardCost = Mathf.CeilToInt(card.CardCost * (1 - player.PlayerClass.CardCostReduction));
			switch (card.DamageType) {
				case DamageTypes.Physical:
					cardDamage = card.CardDamage * player.PlayerClass.PhysicalAttackDMG;
					break;
				case DamageTypes.Magic:
					cardDamage = card.CardDamage * player.PlayerClass.MagicAttackDMG;
					break;
				case DamageTypes.Ranged:
					cardDamage = card.CardDamage * player.PlayerClass.RangedAttackDMG;
					break;
				default:
					break;
			}
			card.transform.Find("CardAttack").GetComponent<Text>().text = cardDamage.ToString();
			card.transform.Find("CardCost").GetComponent<Text>().text = cardCost.ToString();
		}
	}
}
