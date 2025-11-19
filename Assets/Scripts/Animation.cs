using UnityEngine;

public class Animation : MonoBehaviour
{
    private float timerBullets;
    [SerializeField, Range(0.1f, 5f)] private float timeToLive = 0.5f;
    [SerializeField] private float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        timerBullets += Time.deltaTime;
        transform.position += transform.forward * speed * Time.deltaTime;

        if (timerBullets >= timeToLive)
        {
            Destroy(gameObject);
        }
    }
}
