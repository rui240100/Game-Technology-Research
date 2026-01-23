using UnityEngine;

public class MessageTrigger : MonoBehaviour
{
    [TextArea]
    public string message = "‚±‚±‚ÍŠëŒ¯‚¾I";

    public bool showOnce = true;
    private bool used = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger hit by: " + other.name);

        if (used && showOnce) return;

        if (other.CompareTag("Player"))
        {
            if (MessageUI.Instance != null)
            {
                MessageUI.Instance.ShowMessage(message);
                used = true;
            }
            else
            {
                Debug.LogError("MessageUI Instance is null");
            }
        }
    }
}
