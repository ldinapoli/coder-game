using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int movementSpeed;
    [SerializeField]
    private int health;
    [SerializeField]
    private float mouseSens;
    [SerializeField]
    private GameObject cam1;
    [SerializeField]
    private GameObject cam2;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start health: " + health);
        DamagePlayer(10);
        Debug.Log("player damaged current health: " + health);
        HealPlayer(5);
        Debug.Log("player healed current health: " + health);

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.N))
        {
            cam1.SetActive(!cam1.activeSelf);
            cam2.SetActive(!cam2.activeSelf);
        }
    }

    void MoveToDirectionWithSpeed(Vector3 direction, int movementSpeed)
    {
        transform.position += direction * movementSpeed * Time.deltaTime;
    }

    void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(hor, 0, ver) * movementSpeed * Time.deltaTime);
    }

    void DamagePlayer(int damageDealt)
    {
        this.health = this.health - damageDealt;
    }

    void HealPlayer(int healAmount)
    {
        this.health = this.health + healAmount;

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Cannon>())
        {
            Cannon cannon = other.GetComponent<Cannon>();
            if (Input.GetKey(KeyCode.J))
            {
                cannon.Fire();
            }
            if (Input.GetKey(KeyCode.K))
            {
                cannon.Fire();
            }
            if (Input.GetKey(KeyCode.L))
            {
                cannon.Fire();
            }
        }
    }
}
