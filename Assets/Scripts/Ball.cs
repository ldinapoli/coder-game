using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private float destroyTime = 5f;
    [SerializeField]
    private Vector3 scaleToTransform;

    private void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale = scaleToTransform;
        }
    }
}
