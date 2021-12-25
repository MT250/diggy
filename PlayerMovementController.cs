using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private bool isGrounded ;

    private Rigidbody2D _rigidbody2d;
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        //_rigidbody2d.AddForce(Vector2.right * Input.GetAxisRaw("Horizontal") * playerStats.MoveSpeed * Time.deltaTime); //TODO: Extrude rb movement into FixedUpdate
        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * playerStats.MoveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rigidbody2d.AddForce(Vector2.up * playerStats.JumpForce);
            isGrounded = false; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
