using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] GameObject m_HealthBar;
    [SerializeField] int m_MaxLife = 5;
    private int m_CurrentLife;

    private Transform cameraMain;
    [SerializeField] float moveSpeed = 2f;

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
        MoveTowardsPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collsion");

        if (other.CompareTag("Laser"))
        {
            m_CurrentLife--;
            m_HealthBar.GetComponent<HealthBar>().SetHealth(m_CurrentLife);
        }

        if (other.CompareTag("Melee"))
        {
            Debug.Log("melee");
            m_CurrentLife--;
            m_HealthBar.GetComponent<HealthBar>().SetHealth(m_CurrentLife);
        }
    }

    private void MoveTowardsPlayer()
    {
       
        transform.LookAt(SpawnerManager.Instance.target);

        Vector3 direction = (SpawnerManager.Instance.target.position - transform.position).normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
