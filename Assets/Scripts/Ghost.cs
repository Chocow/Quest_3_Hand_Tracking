using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] GameObject m_HealthBar;
    [SerializeField] int m_MaxLife = 5;
    private int m_CurrentLife;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_CurrentLife = m_MaxLife;
        m_HealthBar.GetComponent<HealthBar>().SetMaxHealth(m_MaxLife);
    }

    private void Update()
    {
        if(m_CurrentLife <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Laser"))
        {
            m_CurrentLife--;
            m_HealthBar.GetComponent<HealthBar>().SetHealth(m_CurrentLife);
        }

        if (other.CompareTag("Melee"))
        {
            m_CurrentLife--;
            m_HealthBar.GetComponent<HealthBar>().SetHealth(m_CurrentLife);
        }
    }
}
