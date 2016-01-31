using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
    
	/**
	 * Public Atributtes
	 */
	public float speed = 1;
    public float timeToReachMaxSpeed = 2;
    public float maxSpeed = 10;
	public bool attacker;

	/**
	 * Private Atributtes
	 */
	private float h;
	private float v;
    Vector3 m_oldSpeed;

    Rigidbody m_rigidBody;
	// Use this for initialization
	void Start ()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_oldSpeed = Vector3.zero;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (attacker) {
			h = Input.GetAxis ("HorizontalWASD");
			v = Input.GetAxis ("VerticalWASD");
		} else {
			h = Input.GetAxis ("HorizontalArrows");
			v = Input.GetAxis ("VerticalArrows");
		}
		changeDirection (h, v);
		Vector3 finalForce = new Vector3(h * speed * Time.deltaTime, Physics.gravity.y*m_rigidBody.mass, v * speed * Time.deltaTime);

        /*
        float acc = (m_rigidBody.velocity.magnitude - m_oldSpeed.magnitude) / Time.deltaTime;
        //Debug.Log(acc);
        Vector3 force = m_rigidBody.mass * acc *m_rigidBody.velocity.normalized;
        //Debug.Log(force);

        if ((force.x > 0 && h < 0) || (h > 0 && force.x < 0))
        {
            // The player wants to go to the inverse direction, apply double force
            //m_rigidBody.AddForce(new Vector3(-force.x *timeToReachMaxSpeed, 0, 0));
        }

        if ((force.z > 0 && v < 0) || (v > 0 && force.z < 0))
        {
            // The player wants to go to the inverse direction, apply double force
            //m_rigidBody.AddForce(new Vector3(0, 0, -force.z * timeToReachMaxSpeed));
        }
        */

        if (Mathf.Abs(m_rigidBody.velocity.x) > maxSpeed)
            finalForce.x = 0;

        if (Mathf.Abs(m_rigidBody.velocity.z) > maxSpeed)
            finalForce.z = 0;

        m_rigidBody.AddForce(finalForce);

        m_oldSpeed = m_rigidBody.velocity;
    }

	public void changeDirection(float xAxe, float yAxe){
		/*Vector2 basicVector = new Vector2 (1,0);
		Vector2 realVector = new Vector2 (xAxe, yAxe);
		float angleToRotate = Vector3.Angle (basicVector, realVector.normalized);*/

	}
		
}
