using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

    public Canvas ExitMenu;
    public Button Singleplayer;
    public Button Exit;
    public Button Multiplayer;
    public Button Settings;

	// Use this for initialization
	void Start ()
    {
        ExitMenu = ExitMenu.GetComponent<Canvas> ();
        Singleplayer = Singleplayer.GetComponent<Button> ();
        Exit = Exit.GetComponent<Button> ();
        Settings = Settings.GetComponent<Button> ();
        Multiplayer = Multiplayer.GetComponent<Button> ();
        
        ExitMenu.enabled = false;
	}

    public void ExitPress()
    
    {
        ExitMenu.enabled = true;
        Singleplayer.enabled = false;
        Exit.enabled = false;
        Settings.enabled = false;
        Multiplayer.enabled = false;
    }
    
    public void NoPress()

    {
        ExitMenu.enabled = false;
        Singleplayer.enabled = true;
        Exit.enabled = true;
        Settings.enabled = true;
        Multiplayer.enabled = true;
    }

    public void StartLevel()

    {
        SceneManager.LoadScene (1);
    }

    public void ExitGame()

    {
        Application.Quit();
    }
    public void RunSettings()
    {
        SceneManager.LoadScene (4);
    }
    public void RunMultiplayer()
    {
        SceneManager.LoadScene(5);
    }
}
