using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 12f, -6f);

    void LateUpdate()
    {
        if (target != null)
            transform.position = target.position + offset;
    }
}
