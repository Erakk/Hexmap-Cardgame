using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TownBuildingOptionsScripts : MonoBehaviour {

//	GameObject GameController;
//	GameController gameController;

	void Start () 
	{	
//		GameController = GameObject.Find ("GameController");
//		gameController = GameController.GetComponent<GameController> ();
	}

	public void LoadStarttingArea()
	{
		GameController.control.LoadTutorialBattle();
	}
	public void LoadFireBattleOne()
	{
		GameController.control.LoadFireBattleOne();
	}
	public void SelectClassMage()
	{
		GameController.control.SelectClassMage();
	}
	public void SelectClassPriest()
	{
		GameController.control.SelectClassPriest();
	}
	public void SelectClassWarrior()
	{
		GameController.control.SelectClassWarrior();
	}
	public void SelectClassRogue()
	{
		GameController.control.SelectClassRogue();
	}
	public void SelectedPlayerOne()
	{
		GameController.control.SelectedPlayerOne();
	}
	public void SelectedPlayerTwo()
	{
		GameController.control.SelectedPlayerTwo();
	}
	public void SelectedPlayerThree()
	{
		GameController.control.SelectedPlayerThree();
	}
	
}
