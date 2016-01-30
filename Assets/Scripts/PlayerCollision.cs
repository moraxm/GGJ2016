using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCollision : MonoBehaviour 
{
    public float collisionForce = 10;
	public delegate void onCollisionPlayerDelegate(Collision coll);
	public event onCollisionPlayerDelegate onCollisionPLayer;

    Rigidbody m_rigidBody;
	Vector3 m_lastSpeed;
	public Vector3 lastSpeed 
	{
		get { return m_lastSpeed; }
	}

    public void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }


    public void OnCollisionEnter(Collision collision)
    {
		if (onCollisionPLayer != null)
			onCollisionPLayer (collision);
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
			PlayerCollision rb = collision.collider.GetComponent<PlayerCollision>();
            if (rb)
            {
                //float explosionForce = collisionForce * m_rigidBody.velocity.magnitude;
				// Check wich collider has more speed
				Debug.Log ("Other speed ("+rb.name+"): "+rb.lastSpeed.magnitude+" , my speed ( "+m_rigidBody.name+"): "+lastSpeed.magnitude);
				if (rb.lastSpeed.magnitude < lastSpeed.magnitude) {
					
					// The velocity of the other player is lower than my velocity so drop rune
					InventaryRune inventary = collision.collider.GetComponent<InventaryRune> ();
					if (inventary != null) {
						inventary.DropRune ();
					} 
				}
				   
            }

			InventaryRune inventary = collision.collider.GetComponent<InventaryRune> ();
			if (inventary != null) {
				inventary.DropRune ();
			}


        }
    }

    void ApplySpeedTheNextFrame(Vector3 speed)
    {
        StartCoroutine(ApplySpeedTheNextFrameCoroutine(speed));
    }

    IEnumerator ApplySpeedTheNextFrameCoroutine(Vector3 speed)
    {
        yield return new WaitForEndOfFrame();
        // Apply other rigidbody direction to us
        m_rigidBody.velocity = speed;
    }

	void Update()
	{
		m_lastSpeed = m_rigidBody.velocity;
	}
}
