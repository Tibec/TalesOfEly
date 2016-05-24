using UnityEngine;
using System.Collections;

public class UiController : tk2dUIBaseDemoController {
	// Attribute to easily get items //

	//Windows
	public GameObject mainWindow;
	public GameObject charSelectWindow;

	// Main menu
	public tk2dUIItem creditBtn;
	public tk2dUIItem playBtn;
	public tk2dUIItem quitBtn;

	// Char Select
	public tk2dUIItem maleBtn;
	public tk2dUIItem femaleBtn;
	public tk2dUIItem backBtn;

	////////////////////////////////////////////

	private GameObject currWindow;

	void Awake()
	{
		ShowWindow(mainWindow.transform);
		HideWindow(charSelectWindow.transform);
	}

	void OnEnable()
	{
		playBtn.OnClick += GoToCharSelect;
		backBtn.OnClick += GoToMainMenu;
		quitBtn.OnClickUIItem += HandleButton;
		maleBtn.OnClickUIItem += HandleButton;
		femaleBtn.OnClickUIItem += HandleButton;
		creditBtn.OnClickUIItem += HandleButton;
	}

	void OnDisable()
	{
		playBtn.OnClick -= GoToCharSelect;
		backBtn.OnClick -= GoToMainMenu;
		quitBtn.OnClickUIItem -= HandleButton;
		maleBtn.OnClickUIItem -= HandleButton;
		femaleBtn.OnClickUIItem -= HandleButton;
		creditBtn.OnClickUIItem -= HandleButton;

	}

	private void GoToMainMenu()
	{
		AnimateHideWindow(charSelectWindow.transform);
		AnimateShowWindow(mainWindow.transform);
	}

	private void GoToCharSelect()
	{
		AnimateHideWindow(mainWindow.transform);
		AnimateShowWindow(charSelectWindow.transform);
	}

	private void HandleButton(tk2dUIItem btn)
	{
		if (btn.name == quitBtn.name) {
			Application.Quit ();
		} else if (btn.name == maleBtn.name) {
			PlayerData.Instance.SetAvatar(PlayerData.AvatarType.Male);
			UnityEngine.SceneManagement.SceneManager.LoadScene("Scene/Colline");

		} else if (btn.name == femaleBtn.name) {
			PlayerData.Instance.SetAvatar(PlayerData.AvatarType.Female);
			UnityEngine.SceneManagement.SceneManager.LoadScene("Scene/Colline");
		} else if (btn.name == creditBtn.name) {
			// Load credit scene
			UnityEngine.SceneManagement.SceneManager.LoadScene("Scene/Credit");
		}


				
	}

	// Update is called once per frame
	void Update () {
	
	}
}
