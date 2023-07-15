using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFall : MonoBehaviour
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        // タグの名前を入れる
        if (other.gameObject.CompareTag("Crush"))
        {
            StartCoroutine(ShipAnimation());
        }
    }
    public IEnumerator ShipAnimation()
    {
        float playerDisappearScale = 0.3f;
        float playerRotateAngle = 3.0f;
        float playerScaleMagnitude = 0.99f;
        while (true)
        {
            if (transform.localScale.x < playerDisappearScale && transform.localScale.y < playerDisappearScale)
            {
                transform.localScale = Vector3.zero;
                break;
            }
            transform.localRotation *= Quaternion.AngleAxis(playerRotateAngle, Vector3.forward);
            transform.localScale *= playerScaleMagnitude;
            yield return null;
        }
    }
}
