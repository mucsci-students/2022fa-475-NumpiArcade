using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public void LoadGame(string sceneToLoad)
	{
		PlayerPrefs.SetInt("GameSelected", 1);
		SceneManager.LoadScene(sceneToLoad);
	}
}
