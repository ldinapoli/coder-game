using UnityEngine;

public class BulletProjectile : MonoBehaviour {

    private Rigidbody bulletRigidbody;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 60f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletTarget>() != null)
        {
            Debug.Log("Hit target");
        } else
        {
            Debug.Log("Hit something else");
        }
        Destroy(this.gameObject);
    }
}
