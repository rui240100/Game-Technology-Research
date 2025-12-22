using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8f;
    public float rotateSpeed = 180f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Rotate(0, h * rotateSpeed * Time.deltaTime, 0);
        transform.Translate(Vector3.forward * v * speed * Time.deltaTime);
    }
}
