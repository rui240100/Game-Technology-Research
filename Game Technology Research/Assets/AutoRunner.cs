using UnityEngine;
using System.Collections;

public class AutoRunner : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("プレイヤーの横移動速度")]
    public float moveSpeed = 5f;

    [Tooltip("ジャンプの強さ")]
    public float jumpForce = 7f;

    [Header("Damage")]
    public float fallY = -20f;
    public float invincibleTime = 1.0f;

    private Rigidbody rb;
    private bool isGrounded;
    private bool isInvincible;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0f);
            isGrounded = false;
        }

        if (!isInvincible && transform.position.y < fallY)
        {
            TakeDamage();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isInvincible && other.CompareTag("DeathZone"))
        {
            TakeDamage();
        }

        if (other.CompareTag("Coin"))
        {
            GameManager.Instance.AddCoin(1);
            Destroy(other.gameObject);
        }
    }

    void TakeDamage()
    {
        isInvincible = true;
        GameManager.Instance.Damage(1);
        StartCoroutine(InvincibleTimer());
    }

    IEnumerator InvincibleTimer()
    {
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }
}
