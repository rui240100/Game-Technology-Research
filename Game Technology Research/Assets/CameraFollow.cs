using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float xOffset = 0f;
    [SerializeField] float yFixed = 5f;
    [SerializeField] float zOffset = -10f;

    void LateUpdate()
    {
        transform.position = new Vector3(
            player.position.x + xOffset,
            yFixed,
            player.position.z + zOffset
        );
    }
}
