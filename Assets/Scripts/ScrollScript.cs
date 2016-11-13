using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour {
    public float speed = 0.5f;
    public GameObject maincam = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 offset = new Vector2(maincam.transform.position.x * speed, 0);

        GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
