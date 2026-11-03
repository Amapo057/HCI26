using UnityEngine;

public class ShowPosition : MonoBehaviour
{
    public Color color = Color.yellow;
    void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
