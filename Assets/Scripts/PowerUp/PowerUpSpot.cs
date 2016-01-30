using UnityEngine;
using System.Collections;

public class PowerUpSpot : MonoBehaviour
{
	public Collectable[] collectables;
	public Transform powerUpHintPrefab;
	public float timeToSpawnHint = 5;
    public float hintLifetime = 2;
	public float powerupLifetime = 10;
	public float timeToCooldown = 5;
    public bool isFull
    {
        get { return m_currentCollectable != null; }
    }

	public bool hasHint
	{
		get { return m_currentHint != null; }
	}

	enum status {IDLE, HINT, POWERUPFULL, COOLDOWN};
	private status spotStatus = status.IDLE;

    float m_acumTime;
	Collectable m_currentCollectable;
	Transform m_currentHint;
    System.Random m_rnd;


    void Start()
    {
        m_rnd = new System.Random();

        //CreateCollectableInSpot();
    }

	void CreateCollectableHint()
    {
        // Instantiate the prefab of the power up with the values in the inspector
		GameObject hint = (GameObject)Instantiate (powerUpHintPrefab.gameObject, transform.position, Quaternion.identity);

		hint.name = "Hint";
		hint.transform.SetParent(transform);
		m_currentHint = hint.transform;
    }

	void CreateCollectableInSpot()
	{
		int indexPowerUp = m_rnd.Next(0, collectables.Length); // creates a number between 0 and powerups.Length
		// Instantiate the prefab of the power up with the values in the inspector
		GameObject pu = (GameObject)Instantiate(collectables[indexPowerUp].gameObject, transform.position, Quaternion.identity);
		pu.name = "Collectable";
		m_currentCollectable = pu.GetComponent<Collectable>();
		pu.transform.SetParent(transform);
		m_acumTime = 0;
	}

    void Update()
    {

		m_acumTime += Time.deltaTime;

		switch (spotStatus) {
		case status.IDLE:
			if (m_acumTime > timeToSpawnHint) {
				CreateCollectableHint();
				spotStatus = status.HINT;
				m_acumTime =0;
			}
			break;
		case status.HINT:
			if (m_acumTime > hintLifetime) {
				CreateCollectableInSpot();
				spotStatus = status.POWERUPFULL;
				m_acumTime =0;
			}
			break;
		case status.POWERUPFULL:
			if (m_acumTime > powerupLifetime) {
				spotStatus = status.COOLDOWN;
				m_acumTime =0;
			}
			break;
		case status.COOLDOWN:
			if (m_acumTime > timeToCooldown) {
				spotStatus = status.IDLE;
				m_acumTime =0;
			}
			break;
		}
		/*


        if (!isFull)
        {
            m_acumTime += Time.deltaTime;

			if (m_acumTime > timeToSpawnHint && !hasHint)
			{
				CreateCollectableHint();
				//m_acumTime =0;
			}

			if (m_acumTime > timeToSpawnPowerUp && !isFull)
            {
                CreateCollectableInSpot();
                //m_acumTime = 0;
            }
        }*/
    }

    void OnTriggerEnter(Collider other)
    {
        // If this spot is empty, we decrease the runes collected.
		if (!isFull && (other.gameObject.layer == LayerMask.NameToLayer("Player"))){
			//Debug.Log ("OnTriggerEnter.other: " + other);
			other.gameObject.GetComponent<InventaryRune> ().DropRune();
		}

        // Check for PowerUpOwner component 
		CollectableOwner owner = other.GetComponent<CollectableOwner>();
		if (owner == null || m_currentCollectable == null) return;

		owner.SetCollectable(m_currentCollectable);

        m_currentCollectable = null;

		m_acumTime = 0;
		spotStatus = status.IDLE;
    }

}
