using UnityEngine;
using System.Collections;

public class Rose : MonoBehaviour {
    public GameObject rocket;
    // Use this for initialization
    Vector3 v ;
    void Start () {
       v = rocket.transform.position-transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = rocket.transform.position - v;

    }
}
