using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] Transform m_Camera;

    void Awake()
    {
        if (m_Camera == null && Camera.main != null)
        {
            m_Camera = Camera.main.transform;
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + m_Camera.forward);
    }
}
