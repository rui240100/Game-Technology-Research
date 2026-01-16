using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int life = 3;
    public int coin = 0;
    public int coinForLife = 50;
    public Transform respawnPoint;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Damage(int amount)
    {
        life -= amount;
        if (life <= 0) GameOver();
        else Respawn();
    }

    public void AddCoin(int amount)
    {
        coin += amount;

        if (coin >= coinForLife)
        {
            coin -= coinForLife;
            life += 1;
            Debug.Log("1UP!");
        }
    }

    void Respawn()
    {
        Debug.Log("Respawn called");

        Time.timeScale = 1f;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = respawnPoint.position;

        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
