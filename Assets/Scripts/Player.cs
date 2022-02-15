using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Vector3 scale;

    [SerializeField]
    private int movementSpeed;

    [SerializeField]
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = scale;
        Debug.Log("start health: " + health);
        DamagePlayer(10);
        Debug.Log("player damaged current health: " + health);
        HealPlayer(5);
        Debug.Log("player healed current health: " + health);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveToDirectionWithSpeed(new Vector3(0, 0, 1), this.movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveToDirectionWithSpeed(new Vector3(0, 0, -1), this.movementSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveToDirectionWithSpeed(new Vector3(-1, 0, 0), this.movementSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveToDirectionWithSpeed(new Vector3(1, 0, 0), this.movementSpeed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    void MoveToDirectionWithSpeed(Vector3 direction, int movementSpeed)
    {
        transform.position += direction * movementSpeed * Time.deltaTime;
    }

    void DamagePlayer(int damageDealt)
    {
        this.health = this.health - damageDealt;
    }

    void HealPlayer(int healAmount)
    {
        this.health = this.health + healAmount;

    }

    void Jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Cannon>())
        {
            if (Input.GetMouseButton(0))
            {
                other.GetComponent<Cannon>().Fire();
            }            
        }
    }
}
