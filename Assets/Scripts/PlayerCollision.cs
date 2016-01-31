using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour 
{
    public float collisionForce = 10;
	public delegate void onCollisionPlayerDelegate(Collider coll);
	public event onCollisionPlayerDelegate onCollisionPLayer;
	public GameObject collisionEffect;

    public Rigidbody m_rigidBody;
	SphereCollider m_sphereCollider;
	Vector3 m_lastSpeed;
	public Vector3 lastSpeed 
	{
		get { return m_lastSpeed; }
	}

	float m_acumTime;

    public void Start()
    {
        //m_rigidBody = GetComponentInParent<Rigidbody>();
		m_sphereCollider = GetComponent<SphereCollider>();
		m_acumTime = 2;
    }

	void Update()
	{
		m_lastSpeed = m_rigidBody.velocity;
		Collider[] colliders = Physics.OverlapSphere (transform.position, m_sphereCollider.radius + 3f, 1 << LayerMask.NameToLayer ("Force"));
		foreach (Collider c in colliders) {
			if (c.gameObject != gameObject) {
				if (m_acumTime > 1) {
					OnCollisionEnterCollider (c);
					m_acumTime = 0;
				}
			}
		}
		m_acumTime += Time.deltaTime;
	}

	public void OnCollisionEnterCollider(Collider other)
	{
		if (onCollisionPLayer != null)
			onCollisionPLayer (other);

		if (other.gameObject.layer == LayerMask.NameToLayer("Force"))
		{

			GameObject go = (GameObject)Instantiate(collisionEffect, transform.position, Quaternion.identity);
			Destroy(go, 3.0f);

			PlayerCollision rb = other.GetComponent<PlayerCollision>();
			if (rb)
			{
				//float explosionForce = collisionForce * m_rigidBody.velocity.magnitude;
				// Check wich collider has more speed
				//Debug.Log ("Other speed ("+rb.name+"): "+rb.lastSpeed.magnitude+" , my speed ( "+m_rigidBody.name+"): "+lastSpeed.magnitude);
				if (rb.lastSpeed.magnitude < lastSpeed.magnitude) {

					// The velocity of the other player is lower than my velocity so drop rune
					InventaryRune inventary = other.transform.parent.GetComponentInChildren<InventaryRune> ();
					if (inventary != null) {
						inventary.DropRune ();
					} 
				}

			}

		}
	}
    public void OnCollisionEnter(Collision collision)
    {
		OnCollisionEnterCollider (collision.collider);
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
