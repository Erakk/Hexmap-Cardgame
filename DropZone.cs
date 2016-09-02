using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler   {

	public TileMap map;
	
	public float damage = 0;
	public float heal;
	public float healDot;
	public int movementCost = 0;
	public int range = 0;
	public int areaRange = 0;
//	private string playingPlayer;
	public Effects effect;
	public Targets target;
	public DamageTypes damageType;
	public string selectedTarget;
	public bool mobility;
	private Draggable d;
	public int cardCost;

	private GameObject ButtonScripts;
	private ButtonScripts buttonScripts;
	
	void Start()
	{
		ButtonScripts = GameObject.Find ("ButtonsCanvas");
		buttonScripts = ButtonScripts.GetComponent<ButtonScripts> ();
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		if(eventData.pointerDrag == null){
			return;
		}

		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null) {
			
		}		
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		if (eventData.pointerDrag == null) {
			return;
		}
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null && d.placeholderParent == this.transform) {
			d.placeholderParent = d.parentToReturnTo;
		}
	}

	public void OnDrop (PointerEventData eventData)
	{
		d = eventData.pointerDrag.GetComponent<Draggable> ();
//		GameObject GameController = GameObject.Find ("GameController");
//		GameController gameController = GameController.GetComponent<GameController> ();
//		GameObject ButtonScripts = GameObject.Find ("ButtonsCanvas");
//		ButtonScripts buttonScripts = ButtonScripts.GetComponent<ButtonScripts> ();
		buttonScripts.TurnEverythingFalse();
		GameController.control.TurnFalsePlayerButtons();

	
//		Debug.Log("OnDrop cone");
		
//		if (d != null  ) {
//			Debug.Log(d.attack);
//			attack = d.attack;
//			movementCost = d.movementCost;
//			effect = d.effect;
			d.parentToReturnTo = this.transform;

//		}
		mobility = false;
//		else{
//			Debug.Log("OnDrop cone");
//			Debug.Log(d.cardType);
			switch (d.cardType) {
			
		case CardTypes.Damage:
				
//				GameObject Unit = GameObject.Find(map.selecterPlayer);
//				Unit unit = Unit.GetComponent<Unit> ();
				DamageCard damageCard = d.GetComponentInParent<DamageCard>();
//				DamageCard damageCard = eventData.pointerDrag.GetComponent<DamageCard>();
			Debug.Log (damageCard.DamageType);
				mobility = damageCard.Mobility;
				range = damageCard.Range;
				target = damageCard.Target;
				areaRange = damageCard.Area;
				damageType = damageCard.DamageType;
				GameController.control.cardCost = damageCard.CardCost;
				
				DamageType();
				
				effect = damageCard.Effect;
				RunTargets();
				break;
			case CardTypes.Heal:
				HealCard healCard = d.GetComponentInParent<HealCard>();
				GameObject Player = GameObject.Find(map.selecterPlayer);
				PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
//				DamageCard damageCard = eventData.pointerDrag.GetComponent<DamageCard>();
//				mobility = damageCard.Mobility;
//				buttonScripts.healSelected = true;
//				playingPlayer = map.selecterPlayer;
				range = healCard.Range;
				target = healCard.Target;
				areaRange = healCard.Area;
				effect = healCard.Effect;
				healDot = player.PlayerClass.HealValue / 2;			
				heal = (player.PlayerClass.HealValue * healCard.CardHeal) / 3;
				GameController.control.cardCost = healCard.CardCost;
				RunTargets();
				break;
			case CardTypes.Utility:
				UtilityCard utilityCard = d.GetComponentInParent<UtilityCard>();
//				DamageCard damageCard = eventData.pointerDrag.GetComponent<DamageCard>();
//				mobility = damageCard.Mobility;
				range = utilityCard.Range;
				target = utilityCard.Target;
				areaRange = utilityCard.Area;
				effect = utilityCard.Effect;
				GameController.control.cardCost = utilityCard.CardCost;
				RunTargets();
				break;
			default:
				break;
			}
			
//		}
		//TODO värjää väärin
		if (d != null  ) {
			GameObject HighlightTiles = GameObject.Find ("_Scripts");
			HighlightTiles highlightTiles = HighlightTiles.GetComponent<HighlightTiles> ();
			highlightTiles.HighlightTilesInRange();
		}

		
	}
	void RunTargets()
	{
//		GameObject ButtonScripts = GameObject.Find ("ButtonsCanvas");
//		ButtonScripts buttonScripts = ButtonScripts.GetComponent<ButtonScripts> ();
		GameObject HighlightTiles = GameObject.Find ("_Scripts");
		HighlightTiles highlightTiles = HighlightTiles.GetComponent<HighlightTiles> ();

		
//		Debug.Log(effect);
/*		if (effect == Effects.Attack) {
			buttonScripts.TurnEverythingFalse();
			map.HideAllowedTiles();
			map.ShowAttackableTiles();
//		GameObject Unit = GameObject.Find("UnitOne");
//		Unit unit = Unit.GetComponent<Unit> ();
//		unit.Attack();
			buttonScripts.attackSelected = true;
//		changeAreaTiles = false;
//		moveSelected = false;
//		moveSelected = false;
		} 
		else if (effect == Effects.ChangeArea) {
//			Debug.Log(effect);
			buttonScripts.TurnEverythingFalse();
			buttonScripts.changeAreaTiles = true;
			Debug.Log(buttonScripts.changeAreaTiles);
			map.HideAllowedTiles();
			
		} 
*/
		switch (target) {

			case Targets.Ally:
//				GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
//				foreach (GameObject PlayerAlly in Players) {
//					GameObject Distance = GameObject.Find ("_Scripts");
//					CalculateDistance distance = Distance.GetComponent<CalculateDistance> ();
//					PlayableCharacter playerAlly = PlayerAlly.GetComponent<PlayableCharacter> ();
//					GameObject TileAlly = GameObject.Find ("Hex_" + playerAlly.PlayerClass.TileX + "_" + playerAlly.PlayerClass.TileY );
//					ClickableTile tileAlly = TileAlly.GetComponent<ClickableTile> ();
			buttonScripts.allySelected = true;
//					distance.range = range;
//					tileAlly.ChangeMaterial();
//					}
				break;
			case Targets.Area:
				GameObject Area = GameObject.Find ("_Scripts");
				ChangeTilesArea area = Area.GetComponent<ChangeTilesArea> ();
				area.area = areaRange;
				area.skillDistance = range;
			buttonScripts.changeAreaTiles = true;
				break;
			case Targets.Cone:
//			Debug.Log("Runeffect Cone");
				GameObject Cone = GameObject.Find ("_Scripts");
				Cone cone = Cone.GetComponent<Cone> ();
				cone.skillDistance = range;
			buttonScripts.coneSelected = true;
				break;
			case Targets.Enemy:
			buttonScripts.attackSelected = true;
				break;
			case Targets.Line:
				GameObject Line = GameObject.Find ("LineRenderer");
				DrawLine line = Line.GetComponent<DrawLine> ();
				line.skillDistance = range;
			buttonScripts.drawSelected = true;
				break;
			case Targets.Self:
				selectedTarget = map.selecterPlayer;
				GameObject PlayerSelf = GameObject.Find (map.selecterPlayer);
				PlayableCharacter playerSelf = PlayerSelf.GetComponent<PlayableCharacter> ();
				
				GameObject TileSelf = GameObject.Find ("Hex_" + playerSelf.PlayerClass.TileX + "_" + playerSelf.PlayerClass.TileY );
				ClickableTile tileSelf = TileSelf.GetComponent<ClickableTile> ();
				highlightTiles.tileX = tileSelf.tileX;
				highlightTiles.tileY = tileSelf.tileY;
				highlightTiles.ShowHoveringTileSkill();
				break;
			case Targets.AreaMobility:
				GameObject AreaMobility = GameObject.Find ("_Scripts");
				ChangeTilesArea areaMobility = AreaMobility.GetComponent<ChangeTilesArea> ();
				areaMobility.area = areaRange;
				areaMobility.skillDistance = range;
			buttonScripts.changeAreaTilesNoMid = true;
				break;
			case Targets.Trap:
			buttonScripts.trapSelected = true;
				break;
	
			default:
				break;
		}
				
	}

	public void RunEffect(){
		GameObject effects = GameObject.Find ("Effects");
		switch (effect) {
			
			case Effects.ArmorUp:
				// less inc physical dmg
				break;
			case Effects.Burn:
				
				Burn burn = effects.GetComponent<Burn> ();
				damage = burn.Damage(damage, 3);
				//= damage / 3;
				burn.ApplyBurn(3, damage);
				break;
			case Effects.Bleed:
//				GameObject Bleed = GameObject.Find ("_Scripts");
				Bleed bleed = effects.GetComponent<Bleed> ();
				bleed.ApplyBleed();
				break;
			case Effects.Chill:
				// same as slow, but second proc will apply "frozen". Also apply frozen if speed = 0
				Chill chill = effects.GetComponent<Chill> ();
				chill.ApplyChill();	
				break;
			case Effects.Slow:
//				GameObject Slow = GameObject.Find ("_Scripts");
				Slow slow = effects.GetComponent<Slow> ();
				slow.ApplySlow();				
				break;
			case Effects.Freeze:
				// enemy will turns as long as frozen. Burn will neutralize effect. 50% less physical dmg
				Frozen frozen = effects.GetComponent<Frozen> ();
				frozen.ApplyFrozen();	
				break;
			case Effects.Poison:
//				GameObject Poison = GameObject.Find ("_Scripts");
				Poison poison = effects.GetComponent<Poison> ();
				poison.damage = damage / 5;
				poison.ApplyPoison();
				break;
			case Effects.ShieldUp:
				// block next melee or ranged attack
				break;
			case Effects.SpeedUp:
				// 20% more MS
				break;
			case Effects.Stun:
//				GameObject Stun = GameObject.Find ("_Scripts");
				Stun stun = effects.GetComponent<Stun> ();
				stun.ApplyStun();
				break;
			case Effects.Blind:
			//				GameObject Stun = GameObject.Find ("_Scripts");
				Blind blind = effects.GetComponent<Blind> ();
				blind.Applyblind();
				break;
			case Effects.RemoveBleed:
				// Remove bleed stacks from target
				break;
			case Effects.MagicResUp:
				// less inc magic dmg				
				break;
			case Effects.Restoration:
//				GameObject Restoration = GameObject.Find ("_Scripts");
				Restoration restoration = effects.GetComponent<Restoration> ();
				restoration.heal = healDot;
				restoration.ApplyRestoration();
				break;
			case Effects.Fly:
				// walk through objects
				break;
			case Effects.FullVision:
				// see full map
				break;
			case Effects.SharedVision:
				// all players see shared vision
				break;
			case Effects.VisionTotem:
				// tetem taht grands only vision
				break;
			case Effects.SpellTotem:
				// "playable" totem
				break;
			case Effects.Cure:
				// remove all negative effect
				break;
			case Effects.AiAlly:
				// summon AI ally
				break;
			case Effects.Empty:

				break;
		
			default:
				break;
		}
	}

	void DamageType()
	{
		GameObject Player = GameObject.Find(map.selecterPlayer);
		PlayableCharacter player = Player.GetComponent<PlayableCharacter> ();
		DamageCard damageCard = d.GetComponentInParent<DamageCard>();
		switch (damageType) {

			case DamageTypes.Magic:
			damage = player.PlayerClass.MagicAttackDMG * damageCard.CardDamage;
				break;
			case DamageTypes.Physical:
			damage = player.PlayerClass.PhysicalAttackDMG * damageCard.CardDamage;
				break;
			case DamageTypes.Ranged:
			damage = player.PlayerClass.RangedAttackDMG * damageCard.CardDamage;
				break;
		
			default:
				break;
		}
	}


}
