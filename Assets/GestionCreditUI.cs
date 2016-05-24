using UnityEngine;
using System.Collections;

public class GestionCreditUI : tk2dUIBaseDemoController {
	// Attribute to easily get items //
	public tk2dUIItem menuBtn;

	////////////////////////////////////////////



	void OnEnable()
	{
		menuBtn.OnClick += GoToMainMenu;
	}

	void OnDisable()
	{
		menuBtn.OnClick += GoToMainMenu;
	}

	private void GoToMainMenu()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Scene/Menu");
	}
		
}
