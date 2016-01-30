using UnityEngine;
using System.Collections;

public class CollisionEvents : MonoBehaviour {

	public delegate void CollisionEventDelegate(Collision coll);
	public CollisionEventDelegate onCollisionEnter;
	public CollisionEventDelegate onCollisionExit;

	void OnCollisionEnter(Collision col)
	{
		if (onCollisionEnter != null)
			onCollisionEnter (col);
	}

	void OnCollisionExit(Collision col)
	{
		if (onCollisionExit != null)
			onCollisionExit (col);
	}
}
