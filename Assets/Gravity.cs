using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
    float dist(Vector3 v1, Vector3 v2)
    {
        return (v1.x - v2.x) * (v1.x - v2.x) + (v1.y - v2.y) * (v1.y - v2.y);
    }
    public GameObject star;
    Rigidbody2D rb;
    const float G=0.01f;
    float M= 1000;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        float speed = Mathf.Sqrt(G * M / Mathf.Sqrt(dist(transform.position, star.transform.position))),
             xs = -speed * (transform.position.x - star.transform.position.x) / Mathf.Sqrt(dist(transform.position, star.transform.position)),
             ys = speed * (transform.position.y - star.transform.position.y) / Mathf.Sqrt(dist(transform.position, star.transform.position));
        rb.velocity =new Vector2(ys,xs );
	}
	
	// Update is called once per frame
	void Update () {
        float force =-G* rb.mass * M / dist(transform.position, star.transform.position),
        xf = force * (transform.position.x - star.transform.position.x) / Mathf.Sqrt(dist(transform.position, star.transform.position)),
        yf = force * (transform.position.y - star.transform.position.y) / Mathf.Sqrt(dist(transform.position, star.transform.position));
        rb.AddForce (new Vector2(xf, yf));
	}
}
