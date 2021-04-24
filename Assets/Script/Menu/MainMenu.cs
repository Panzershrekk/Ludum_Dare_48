using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
	[Header("Main Menu")]
	public GameObject MainMenuObject;
	public TextMeshProUGUI VersionLabel;

	private void Start()
    {
		MainMenuObject.SetActive(true);

		if(VersionLabel != null)
			VersionLabel.text = Application.version;
	}

	//Main Menu
    public void PlayScene(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
	}
}
