using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bullets;
    private float shootRate;
    [SerializeField, Range(0.1f, 5f)] private float timeToWaitShoot = 2f;
    [SerializeField] private Transform spawnBullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootRate += Time.deltaTime;
        if(shootRate >= timeToWaitShoot)
        {
            GameObject go = Instantiate(bullets, spawnBullet);
            go.transform.localPosition = Vector3.zero;
            go.transform.parent = null;



            shootRate = 0f;
        }
    }
}
