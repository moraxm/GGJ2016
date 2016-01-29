using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
    
	/**
	 * Public Atributtes
	 */
	public float speed = 1;
	public bool attacker;

	/**
	 * Private Atributtes
	 */
	private float h;
	private float v;

    Rigidbody m_rigidBody;
	// Use this for initialization
	void Start ()
    {
        m_rigidBody = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
		
		if (attacker) {
			h = Input.GetAxis ("HorizontalWASD");
			v = Input.GetAxis ("VerticalWASD");
		} else {
			h = Input.GetAxis ("HorizontalArrows");
			v = Input.GetAxis ("VerticalArrows");
		}
        
        Vector3 finalspeed = new Vector3(h * speed * Time.deltaTime, m_rigidBody.velocity.y, v *speed * Time.deltaTime);
        m_rigidBody.velocity = finalspeed;
    }
}
