using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : SingletonMonoBehaviour<CameraController>
{
    public float duration = 3f; // ˆÚ“®‚É‚©‚©‚éŠÔi•bj
    public float distance = 1f; // ˆÚ“®‚·‚é‹——£

    private float elapsedTime = 0f;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;

    private bool isMovePlayer = false;
    private bool isLoopCourutine = false;

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
                isMovePlayer = true;
            }
        }

        if (isMovePlayer)
        {
            MonoGameManager.Player1Controller.gameObject.transform.position += Vector3.down * 500.0f * Time.deltaTime;
            MonoGameManager.Player2Controller.gameObject.transform.position += Vector3.down * 500.0f * Time.deltaTime;
            isLoopCourutine = true;
            if (isLoopCourutine)
            {
                MonoGameManager.Player1Controller.PlayAnimation();
                MonoGameManager.Player2Controller.PlayAnimation();
                isLoopCourutine = false;
            }
        }
    }

    private void StartCameraMovement()
    {
        isMoving = true;
    }
}
