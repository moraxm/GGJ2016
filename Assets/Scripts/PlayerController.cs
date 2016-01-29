using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
    public float speed = 1;

    Rigidbody m_rigidBody;
	// Use this for initialization
	void Start ()
    {
        m_rigidBody = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        
        Vector3 finalspeed = new Vector3(h * speed * Time.deltaTime, m_rigidBody.velocity.y, v *speed * Time.deltaTime);
        m_rigidBody.velocity = finalspeed;
    }
}
