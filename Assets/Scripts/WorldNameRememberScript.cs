using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorldNameRememberScript : MonoBehaviour {
    public InputField WorldNameInput;
    public static string WorldName;

    void Start()
    {
        if (WorldName != null)
        {

            WorldNameInput.text = WorldName;
        }
    }

    public void SaveData(string newName)
    {
        WorldName = newName;
    }
// Update is called once per frame
    void Update () {


                     }
   
}

