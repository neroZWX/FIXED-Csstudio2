using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    //private Vector3 offset = new Vector3(0, 11f, -9f);
    [SerializeField] private Vector3 offset = new Vector3(0, 13f, -8f);
    private Quaternion cameraRotation = Quaternion.Euler(50f, 0, 0);
    private float smoothing = 0.5f;
    // Update is called once per frame

    private bool lerping = false;
    private Vector3 targetPosition;
    private float lerpStartTime = 0f;
    private float timeForLerp = 0.01f;
    private Vector3 startPosition;

    private void Start()
    {
        transform.rotation = cameraRotation;
    }

    void LateUpdate()
    {
        if (lerping)
        {
            float timeSinceStarted = Time.time - lerpStartTime;
            float t = timeSinceStarted / timeForLerp;
            targetPosition = target.position + offset;


            transform.position = Vector3.Slerp(startPosition, targetPosition, smoothing);

            if (t >= 1f)
            {
                lerping = false;
            }
        }
        else
        {
            targetPosition = target.position + offset;
            //targetPosition.y = offset.y;
            //targetPosition.z = target.position.z;
            startPosition = transform.position;
            lerpStartTime = Time.time;
            lerping = true;
            transform.rotation = cameraRotation;
        }
    }
}



