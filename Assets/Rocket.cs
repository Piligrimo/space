using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {
    float dist(Vector3 v1, Vector3 v2)
    {
        return (v1.x - v2.x) * (v1.x - v2.x) + (v1.y - v2.y) * (v1.y - v2.y);
    }
    public GameObject star;
    Rigidbody2D rb;
    const float G = 0.01f;
    float M = 1000;
    public GameObject[] planets; 
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 3);
        planets = GameObject.FindGameObjectsWithTag("planet");
    }
	
	// Update is called once per frame
	void Update () {
        float force = -G * rb.mass * M / dist(transform.position, star.transform.position),
       xf = force * (transform.position.x - star.transform.position.x) / Mathf.Sqrt(dist(transform.position, star.transform.position)),
       yf = force * (transform.position.y - star.transform.position.y) / Mathf.Sqrt(dist(transform.position, star.transform.position));
        rb.AddForce(new Vector2(xf, yf));
        for (int i=0;i< planets.Length;i++)
        {
            float pforce = -G * rb.mass * M / dist(transform.position, planets[i].transform.position),
            pxf = force * (transform.position.x - planets[i].transform.position.x) / Mathf.Sqrt(dist(transform.position, planets[i].transform.position)),
            pyf = force * (transform.position.y - planets[i].transform.position.y) / Mathf.Sqrt(dist(transform.position, planets[i].transform.position));
            rb.AddForce(new Vector2(pxf, pyf));
            
         

        }
        float s = 0.1f;
        transform.rotation = Quaternion.Euler(0, 0, 180*Mathf.Atan2(rb.velocity.y , rb.velocity.x)/3.141596f-90);
        if(Input.GetAxis("Horizontal")!=0)
        rb.velocity -= new Vector2(0.08f *Input.GetAxis("Horizontal")* Mathf.Cos(90+transform.rotation.z * 3.1415926f / 180), 0.08f * Input.GetAxis("Horizontal")* Mathf.Sin(90  + transform.rotation.z * 3.1415926f / 180));
    }
}
