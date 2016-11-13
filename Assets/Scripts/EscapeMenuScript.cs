using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EscapeMenuScript : MonoBehaviour
{

    public Canvas EscapeMenu;
    public Canvas InventoryMenu;
    public Button Resume;
    public Button Settings;
    public Button Quit;

    private bool bEscapeMenuVisible = false;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (bEscapeMenuVisible)
                ResumePress();
            else
                EscapePress();
        }
    }


    // Use this for initialization
    void Start()
    {
        EscapeMenu = EscapeMenu.GetComponent<Canvas>();
        Resume = Resume.GetComponent<Button>();
        Settings = Settings.GetComponent<Button>();
        Quit = Quit.GetComponent<Button>();

        EscapeMenu.enabled = false;
        Resume.enabled = false;
        Settings.enabled = false;
        Quit.enabled = false;
    }

    public void EscapePress()

    {
        EscapeMenu.enabled = true;
        Resume.enabled = true;
        Settings.enabled = true;
        Quit.enabled = true;
        bEscapeMenuVisible = true;
        Time.timeScale = 0;
    }

    public void ResumePress()

    {
        EscapeMenu.enabled = false;
        Resume.enabled = false;
        Settings.enabled = false;
        Quit.enabled = false;
        bEscapeMenuVisible = false;
        Time.timeScale = 1;
    }

    public void QuitPress()

    {
        SceneManager.LoadScene(0);
    }
}
