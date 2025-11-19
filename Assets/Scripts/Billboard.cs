using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] Transform m_Camera;
    
    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + m_Camera.forward);
    }
}
