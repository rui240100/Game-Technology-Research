using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 120f;

    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
    }
}
