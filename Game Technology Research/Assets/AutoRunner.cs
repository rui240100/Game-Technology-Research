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
    [Tooltip("ダメージ後の無敵時間")]
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
        // 自動前進
        rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0f);
    }

    void Update()
    {
        // ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0f);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 地面判定
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // デスゾーンに触れたらダメージ
        if (!isInvincible && other.CompareTag("DeathZone"))
        {
            TakeDamage();
        }

        // コイン取得
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
