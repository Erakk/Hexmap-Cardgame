using UnityEngine;
using System.Collections;

public class CharScreenButton : MonoBehaviour {

	public GameObject thePanel;

	public void CloseCharacterScreen()
	{
		
//		GameObject closeCharScreen = GameObject.Find ("CharacterScreenPanel");
		thePanel.SetActive(false); 
	}

	public void OpenCharacterScreen()
	{
//		GameObject openCharScreen = GameObject.Find ("CharacterScreenPanel");
		thePanel.SetActive(true); 
	}
}
