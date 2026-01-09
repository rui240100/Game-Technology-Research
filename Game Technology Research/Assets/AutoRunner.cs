using UnityEngine;

public class AutoRunner : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    public float fallY = -20f;

    private Rigidbody rb;
    private bool isGrounded;
    private bool dead;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (dead) return;

        rb.velocity = new Vector3(speed, rb.velocity.y, 0f);
    }

    void Update()
    {
        if (dead) return;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0f);
            isGrounded = false;
        }

        if (transform.position.y < fallY)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (dead) return;

        if (other.CompareTag("DeathZone"))
        {
            Die();
        }
    }

    void Die()
    {
        dead = true;
        GameManager.Instance.InstantDeath();
    }
}
