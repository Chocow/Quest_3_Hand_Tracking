using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class Pistolet : MonoBehaviour
{
    public float addedForce = 380.0f;
    public GameObject ballPref;
    public float destroyAfter = 10.0f;


    public void Shoot()
    {
        var ball = Instantiate(ballPref, transform.position, Quaternion.identity);
        ball.GetComponent<Rigidbody>().AddForce(transform.forward * addedForce);
        Destroy(ball, destroyAfter);
    }
}
