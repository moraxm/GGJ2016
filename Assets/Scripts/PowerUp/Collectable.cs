using UnityEngine;
using System.Collections;

public abstract class Collectable : MonoBehaviour {




	// Owner of this power up
	private CollectableOwner m_owner;
	protected CollectableOwner owner
	{
		get { return m_owner; }
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
