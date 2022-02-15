using System.Collections;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    private Transform shootPosition;
    [SerializeField]
    private GameObject bulletProjectile;

    private float cannonCooldown = 2f;
    private bool isAvailable = true;

    public void Fire()
    {
        if (isAvailable)
        {
            GameObject cannonBall = Instantiate(bulletProjectile, shootPosition.position, Quaternion.identity);
            Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
            Vector3 initialVelocity = new Vector3(0, 10, 20);
            rb.AddForce(initialVelocity, ForceMode.Impulse);
            StartCoroutine(StartCooldown());
        }        
    }

    private IEnumerator StartCooldown()
    {
        isAvailable = false;
        yield return new WaitForSeconds(cannonCooldown);
        isAvailable = true;
    }
}
