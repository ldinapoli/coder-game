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
    [SerializeField]
    private float autoShootingTime;

    private float _autoShootingRemainingTime;

    private void Start()
    {
        ResetShootingTimer();
    }

    private void Update()
    {
        UpdateShootingTimer();
    }

    public void Fire()
    {
        GameObject cannonBall = Instantiate(bulletProjectile, shootPosition.position, Quaternion.identity);
        Rigidbody rb = cannonBall.GetComponent<Rigidbody>();          
        rb.AddForce(initialVelocity, ForceMode.Impulse);
    }

    void ResetShootingTimer()
    {
        _autoShootingRemainingTime = autoShootingTime;
    }

    void UpdateShootingTimer()
    {
        _autoShootingRemainingTime -= Time.deltaTime;
        if (_autoShootingRemainingTime <= 0)
        {
            ResetShootingTimer();
            Fire();
        }
    }
}
