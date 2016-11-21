using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class LoadDataScript : MonoBehaviour {
    public Button World1;
    public Text WorldNameText;
	// Use this for initialization
	void Start () {
        World1 = World1.GetComponent<Button>();
        WorldNameText = WorldNameText.GetComponent<Text>();
        GameObject imo = GameObject.Find("WorldNameRememberScriptFind");
        WorldNameRememberScript ims = imo.GetComponent<WorldNameRememberScript>();


    }
	
	// Update is called once per frame
	void Update () {
       

    }
    public void SaveData(string newName)
    {

        WorldNameText.text = newName;
        Debug.Log(newName);
    }
}
