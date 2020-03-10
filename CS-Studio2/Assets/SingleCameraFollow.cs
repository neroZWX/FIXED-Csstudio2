using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 cameraOffset;
    [Range(0.01f, 1.0f)]
    public float Smooth = 0.05f;
    void Start()
    {
        cameraOffset = transform.position - target.position;

    }
    void LateUpdate()
    {
        Vector3 targetPos = target.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, targetPos, Smooth);
    }
}
