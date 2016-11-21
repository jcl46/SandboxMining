using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorldNameRememberScript : MonoBehaviour {
    public InputField WorldNameInput;
    public static string WorldName;
    public string TheName;

    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;


    }
    public void SubmitName(string arg0)
    {
        Debug.Log(arg0);
        TheName = arg0;

    }


    // Update is called once per frame
    void Update () {


                     }
   
}

