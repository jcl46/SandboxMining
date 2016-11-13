using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateNewWorldScript : MonoBehaviour
{

    public Canvas CreateNewWorldMenu;
    public Button CreateWorld;
    public Button Cancel;

    // Use this for initialization
    void Start()
    {
    }

    public void CreateWorldCLick()

    {
        SceneManager.LoadScene(3);
    }

    public void CancelCLick()

    {
    SceneManager.LoadScene(1);
    }
}