using UnityEngine;
using System.Collections;

public class TownMainoptionScripts : MonoBehaviour {

	public GameObject battleOption;
	public GameObject libraryOption;
	public GameObject armoryOption;
	public GameObject tavernOption;
	public GameObject deckList;

	public void ShowBattleOptions()
	{
		HideOptions ();
		battleOption.SetActive(true);
//		Debug.Log("Battle");
	}

	public void ShowLibraryOptions()
	{
		HideOptions ();
		libraryOption.SetActive(true);
		deckList.SetActive(true);
//		Debug.Log("Library");
	}


	public void ShowTavernOptions()
	{
		HideOptions ();
		tavernOption.SetActive(true);
//		Debug.Log("Tavern");
	}


	public void ShowArmoryOptions()
	{
		HideOptions ();
		armoryOption.SetActive(true);
//		Debug.Log("Armory");
	}

	void HideOptions ()
	{
		GameObject[] Options = GameObject.FindGameObjectsWithTag("TownOptions");
		foreach (GameObject Option in Options) {
			Option.SetActive(false);
		}
		deckList.SetActive(false);
	}


}
