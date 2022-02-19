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
    [SerializeField]
    private Transform mainCameraTransform;

    Vector3 _playerVelocity;
    bool _groundedPlayer;
    CharacterController _controller;
    float _jumpHeight = 1.0f;
    float _gravityValue = -9.81f;
    float _turnSmoothTime = 0.1f;
    float _turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start health: " + health);
        DamagePlayer(10);
        Debug.Log("player damaged current health: " + health);
        HealPlayer(5);
        Debug.Log("player healed current health: " + health);

        _controller = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _groundedPlayer = _controller.isGrounded;
        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _controller.Move(moveDir.normalized * Time.deltaTime * movementSpeed);
        }   

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            cam1.SetActive(!cam1.activeSelf);
            cam2.SetActive(!cam2.activeSelf);
        }
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
