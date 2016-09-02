using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartAreaDoor : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		SceneManager.LoadScene ("CharacterCreation");
	}

}
