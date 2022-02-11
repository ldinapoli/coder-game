using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Vector3 scale;

    [SerializeField]
    private Vector3 direction;

    [SerializeField]
    private int movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0,0,1) * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -1) * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * movementSpeed * Time.deltaTime;
        }
    }
}
