using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
        if (collision.transform.name == "Player")
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;
            rb.AddForce(direction * 15, ForceMode.Impulse);
        }
    }
}
