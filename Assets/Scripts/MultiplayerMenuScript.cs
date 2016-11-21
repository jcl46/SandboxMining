using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MultiplayerMenuScript : MonoBehaviour
{
    public Button Cancel;

    // Use this for initialization
    void Start()
    {
    }

    public void CancelCLick()

    {
    SceneManager.LoadScene(1);
    }
}