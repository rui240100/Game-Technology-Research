using UnityEngine;

public class GameTimer : MonoBehaviour
{
    float time;
    bool goal = false;

    void Update()
    {
        if (!goal)
            time += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            goal = true;
            Debug.Log("Clear Time: " + time.ToString("F2"));
        }
    }
}
