using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CollisionEvents : MonoBehaviour {

	public delegate void CollisionEventDelegate(Collision coll);
	public CollisionEventDelegate onCollisionEnter;
	public CollisionEventDelegate onCollisionExit;

	void OnCollisionEnter(Collision collision)
	{
		if (onCollisionEnter != null)
			onCollisionEnter (collision);
	}

	void OnCollisionExit(Collision col)
	{
		if (onCollisionExit != null)
			onCollisionExit (col);
	}
}
