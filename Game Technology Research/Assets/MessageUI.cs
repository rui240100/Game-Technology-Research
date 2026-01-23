using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageUI : MonoBehaviour
{
    public static MessageUI Instance;

    [Header("UI")]
    public GameObject messagePanel; // Panel（Textの親）
    public Text messageText;        // Legacy Text
    public float displayTime = 2f;

    void Awake()
    {
        // Singleton 安全版
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("MessageUI Instance set");
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        if (messagePanel != null)
        {
            messagePanel.SetActive(false);
        }
        else
        {
            Debug.LogError("messagePanel is not assigned");
        }

        if (messageText == null)
        {
            Debug.LogError("messageText is not assigned");
        }
    }

    public void ShowMessage(string message)
    {
        Debug.Log("ShowMessage called: " + message);

        StopAllCoroutines();
        StartCoroutine(ShowRoutine(message));
    }

    IEnumerator ShowRoutine(string message)
    {
        messageText.text = message;
        messagePanel.SetActive(true);

        yield return new WaitForSeconds(displayTime);

        messagePanel.SetActive(false);
    }
}
