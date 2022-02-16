using System.Collections;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    private Transform shootPosition;
    [SerializeField]
    private GameObject bulletProjectile;
    [SerializeField]
    private Vector3 initialVelocity;

    public void Fire()
    {
        GameObject cannonBall = Instantiate(bulletProjectile, shootPosition.position, Quaternion.identity);
        Rigidbody rb = cannonBall.GetComponent<Rigidbody>();          
        rb.AddForce(initialVelocity, ForceMode.Impulse);
    }
}
