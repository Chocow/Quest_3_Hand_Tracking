using UnityEngine;

public class RightHandSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_Sword;

    public void SpawnSword()
    {
        m_Sword.SetActive(true);
    }

    public void DespawnSword()
    {
        m_Sword.SetActive(false);
    }
}
