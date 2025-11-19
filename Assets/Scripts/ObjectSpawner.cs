using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_Object;

    public void SpawnSword()
    {
        m_Object.SetActive(true);
    }

    public void DespawnSword()
    {
        m_Object.SetActive(false);
    }
}
