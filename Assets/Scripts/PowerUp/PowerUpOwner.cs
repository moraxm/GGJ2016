using UnityEngine;
using System.Collections;

public class PowerUpOwner : MonoBehaviour {

    PowerUp m_currentPowerUp;

    PlayerController m_playerController;
    public PlayerController playerController
    {
        get { return m_playerController; }
    }

    public void SetPowerUp(PowerUp powerUp)
    {
        m_currentPowerUp = powerUp;
        m_currentPowerUp.StartPowerUp(this);
    }


	// Use this for initialization
	void Start () {
        m_currentPowerUp = null;
        m_playerController = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_currentPowerUp != null)
        {
            m_currentPowerUp.UpdatePowerUp();
        }
	}
}
