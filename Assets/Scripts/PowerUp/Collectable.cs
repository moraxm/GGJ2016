using UnityEngine;
using System.Collections;

public abstract class Collectable : MonoBehaviour {


	// Owner of this power up
	private CollectableOwner m_owner;
	public CollectableOwner owner
	{
		get { return m_owner; }
		set { m_owner = value; }
	}

	public virtual void StartCollectable(CollectableOwner owner)
	{
		
		m_owner = owner;
	}

	public virtual void FinishCollectable()
	{
	}

	public virtual void UpdateCollectable()
	{
		
	}
}
