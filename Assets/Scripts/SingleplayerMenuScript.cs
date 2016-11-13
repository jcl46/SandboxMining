using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SingleplayerMenuScript : MonoBehaviour
{

    public Canvas SingleplayerMenu;
    public Button CreateNewWorld;
    public Button Back;

    // Use this for initialization
    void Start()
    {
    }

    public void CreateNewWorldCLick()

    {
        SceneManager.LoadScene(2);
    }

    public void BackClick()

    {
    SceneManager.LoadScene(0);
    }
}