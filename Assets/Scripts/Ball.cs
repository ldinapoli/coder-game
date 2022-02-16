using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private int damage;

    private void Start()
    {
        Destroy(this.gameObject, 5f);
    }
}
