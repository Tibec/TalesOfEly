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
			PlayerData.Instance.Avatar = PlayerData.AvatarType.Male;
			PlayerData.Instance.Scene = 0;
			UnityEngine.SceneManagement.SceneManager.LoadScene("colline");
			AnimateHideWindow(charSelectWindow.transform);
		} else if (btn.name == femaleBtn.name) {
			AnimateHideWindow(charSelectWindow.transform);
			PlayerData.Instance.Avatar = PlayerData.AvatarType.Female;
			PlayerData.Instance.Scene = 0;
			UnityEngine.SceneManagement.SceneManager.LoadScene("colline");
		} else if (btn.name == creditBtn.name) {
			// Load credit scene
			AnimateHideWindow(mainWindow.transform);
			UnityEngine.SceneManagement.SceneManager.LoadScene("credit");
		}


				
	}

	// Update is called once per frame
	void Update () {
	
	}
}
