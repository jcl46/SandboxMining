using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadDataScript : MonoBehaviour {
    public Button World1;
    public Text WorldNameText;
	// Use this for initialization
	void Start () {
        World1 = World1.GetComponent<Button>();
        WorldNameText = WorldNameText.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void LoadData(string newName)
    {
        WorldNameText.text = newName;
    }
}
