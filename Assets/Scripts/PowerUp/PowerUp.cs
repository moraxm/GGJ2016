using UnityEngine;
using System.Collections;

public abstract class PowerUp : MonoBehaviour
{
    // Inspector values
    public float timeAlive = 3;

    // Owner of this power up
    private PowerUpOwner m_owner;
    protected PowerUpOwner owner
    {
        get { return m_owner; }
    }
       
    private float m_acumTime;

    public virtual void StartPowerUp(PowerUpOwner owner)
    {
        m_acumTime = 0;
        m_owner = owner;
    }

    public virtual void FinishPowerUp()
    {
    }

    public virtual void UpdatePowerUp()
    {
        m_acumTime += Time.deltaTime;
        if (m_acumTime > timeAlive)
            Destroy(this);
    }

    void OnDestroy()
    {
        FinishPowerUp();
    }

}
