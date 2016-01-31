using UnityEngine;
using System.Collections;

public class CollectableSpot : MonoBehaviour
{
	public Collectable[] collectables;
    public float timeToSpawnPowerUp = 5;
    public bool isFull
    {
        get { return m_currentCollectable != null; }
    }

    float m_acumTime;
	Collectable m_currentCollectable;
    System.Random m_rnd;

    void Start()
    {
        m_rnd = new System.Random();
        CreateCollectableInSpot();
    }

    void CreateCollectableInSpot()
    {

        int indexPowerUp = m_rnd.Next(0, collectables.Length); // creates a number between 0 and powerups.Length
        // Instantiate the prefab of the power up with the values in the inspector
        GameObject pu = (GameObject)Instantiate(collectables[indexPowerUp].gameObject, transform.position, Quaternion.identity);
        pu.name = "Collectable";
		m_currentCollectable = pu.GetComponent<Collectable>();
        m_acumTime = 0;
    }

    void Update()
    {
        if (!isFull)
        {
            m_acumTime += Time.deltaTime;
            if (m_acumTime > timeToSpawnPowerUp)
            {
                CreateCollectableInSpot();
                m_acumTime = 0;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // If this spot is empty, we decrease the runes collected.
		if (!isFull && (other.gameObject.layer == LayerMask.NameToLayer("Force"))){
			
			other.gameObject.transform.parent.GetComponentInChildren<InventaryRune> ().DropRune();
		}

        // Check for PowerUpOwner component 
		CollectableOwner owner = other.transform.parent.GetComponentInChildren<CollectableOwner>();
		if (owner == null || m_currentCollectable == null) return;

		owner.SetCollectable(m_currentCollectable);

        m_currentCollectable = null;
        
    }

}
