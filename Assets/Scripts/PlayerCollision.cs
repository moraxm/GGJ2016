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
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
            if (rb)
            {
                float explosionForce = collisionForce * m_rigidBody.velocity.magnitude;
                
                //rb.AddForce(m_rigidBody.velocity * collisionForce, ForceMode.VelocityChange);
                //rb.AddExplosionForce(explosionForce, transform.position, 5, 0.0f, ForceMode.Impulse);
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
}
