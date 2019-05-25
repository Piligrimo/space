using UnityEngine;
using System.Collections;

public class Gps : MonoBehaviour {
   public GameObject planet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = planet.transform.position*1.5f;
        transform.rotation = planet.transform.rotation;
	}
}
