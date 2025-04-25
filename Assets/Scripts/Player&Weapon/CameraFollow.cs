using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private void LateUpdate()
    {
        Vector3 targetPos = target.position + offset;
        transform.position = targetPos;
    }
}
