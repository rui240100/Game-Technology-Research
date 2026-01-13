using TMPro;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI coinText;

    void Update()
    {
        lifeText.text = "LIFE: " + GameManager.Instance.life;
        coinText.text = "COIN: " + GameManager.Instance.coin + " / " + GameManager.Instance.coinForLife;
    }
}
