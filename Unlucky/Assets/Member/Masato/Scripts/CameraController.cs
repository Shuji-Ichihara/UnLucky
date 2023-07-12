using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float duration = 3f; // 移動にかかる時間（秒）
    public float distance = 1f; // 移動する距離

    private float elapsedTime = 0f;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;

    private void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition - new Vector3(0f, distance, 0f);
        Invoke("StartCameraMovement", 3f);
    }

    private void Update()
    {
        if (isMoving)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime <= duration)
            {
                float t = elapsedTime / duration;
                transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            }
            else
            {
                transform.position = targetPosition;
                isMoving = false;
            }
        }
    }

    private void StartCameraMovement()
    {
        isMoving = true;
    }
}
