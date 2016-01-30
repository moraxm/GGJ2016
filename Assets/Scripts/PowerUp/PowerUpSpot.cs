using UnityEngine;
using System.Collections;

public class PowerUpSpot : MonoBehaviour
{
    public PowerUp[] powerUps;
    public float timeToSpawnPowerUp = 5;
    public bool isFull
    {
        get { return m_powerUpToDrop != null; }
    }

    float m_acumTime;
    PowerUp m_powerUpToDrop;
    System.Random m_rnd;

    void Start()
    {
        m_rnd = new System.Random();
        CreatePowerUpInSpot();
    }

    void CreatePowerUpInSpot()
    {

        int indexPowerUp = m_rnd.Next(0, powerUps.Length); // creates a number between 0 and powerups.Length
        // Instantiate the prefab of the power up with the values in the inspector
        GameObject pu = (GameObject)Instantiate(powerUps[indexPowerUp].gameObject, transform.position, Quaternion.identity);
        pu.name = "PowerUp";
        m_powerUpToDrop = pu.GetComponent<PowerUp>();
        m_acumTime = 0;
    }

    void Update()
    {
        if (!isFull)
        {
            m_acumTime += Time.deltaTime;
            if (m_acumTime > timeToSpawnPowerUp)
            {
                CreatePowerUpInSpot();
                m_acumTime = 0;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // If this spot is empty do nothing
        if (!isFull) return;

        // Check for PowerUpOwner component 
        PowerUpOwner owner = other.GetComponent<PowerUpOwner>();
        if (owner == null) return;

        owner.SetPowerUp(m_powerUpToDrop);


        // Set the player as the parent of the power up 
        m_powerUpToDrop.transform.parent = other.transform;
        m_powerUpToDrop = null;
        
    }

}
