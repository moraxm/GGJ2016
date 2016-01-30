using UnityEngine;
using System.Collections;

public abstract class PowerUp : Collectable
{
	// Inspector values
	public float timeAlive = 3;

	protected float m_acumTime;

	public override void StartCollectable (CollectableOwner owner)
	{
		base.StartCollectable (owner);
		m_acumTime = 0;
	}

	public override void UpdateCollectable ()
	{
		base.UpdateCollectable ();
		IncrementTime ();
	}

	void Update()
	{
		if (owner == null) {
			IncrementTime ();
		}
	}

	void IncrementTime()
	{
		m_acumTime += Time.deltaTime;
		if (m_acumTime > timeAlive)
			FinishCollectable();
	}

	public override void FinishCollectable ()
	{
		base.FinishCollectable ();
		Destroy (this.gameObject);
	}


}
