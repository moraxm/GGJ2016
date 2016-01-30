using UnityEngine;
using System.Collections;

public class CollectableOwner : MonoBehaviour {

	Collectable m_currentCollectable;

    PlayerController m_playerController;
	public  PlayerController playerController
    {
        get { return m_playerController; }
		set { m_playerController = value; }
    }

	public void SetCollectable(Collectable powerUp)
    {
		if (m_currentCollectable != null)
			m_currentCollectable.FinishCollectable ();
		
        m_currentCollectable = powerUp;
        m_currentCollectable.StartCollectable(this);
    }


	// Use this for initialization
	void Start () {
        m_currentCollectable = null;
        m_playerController = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_currentCollectable != null)
        {
            m_currentCollectable.UpdateCollectable();
        }
	}
}
