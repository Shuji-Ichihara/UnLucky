using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : PlayerBase
{
    #region Input Keyes
    // 左右移動
    [SerializeField]
    private KeyCode _moveLeftKey = KeyCode.A;
    [SerializeField]
    private KeyCode _moveRightKey = KeyCode.D;
    // 決定
    [SerializeField]
    private KeyCode _entryKey = KeyCode.S;
    #endregion

    // プレイヤーの蓄積ダメージ
    public static int AccumulatedDamage = 0;
    // 相手プレイヤーの情報
    private Player2Controller _player2Controller = null;

    // Start is called before the first frame update
    void Start()
    {
        _player2Controller = MonoGameManager.Player2Controller;
        // レーン選択になる為
        _isEntried = false;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        int spriteNum = _playerSprites.FindIndex(item => item == sprite.sprite);
        sprite.sprite = ChangeSprite(spriteNum);
    }

    // Update is called once per frame
    void Update()
    {
        DisidePlayerPoint();
        if (_isEntried == false)
        {
            Move();
        }
    }

    protected override void Move()
    {
        if (Input.GetKeyDown(_moveLeftKey))
        {
            switch (_gamePosition)
            {
                case 0:
                    break;
                case 1:
                    if ((_gamePosition - 1) == _player2Controller.GamePosition)
                    {
                        return;
                    }
                    _gamePosition--;
                    transform.position = PlayerSpawn.Instance.PlayerPoints[_gamePosition].transform.position;
                    break;
                case 2:
                    _gamePosition--;
                    if (_gamePosition == _player2Controller.GamePosition)
                    {
                        _gamePosition--;
                    }
                    transform.position = PlayerSpawn.Instance.PlayerPoints[_gamePosition].transform.position;
                    break;
                default:
                    break;
            }
        }
        else if (Input.GetKeyDown(_moveRightKey))
        {
            switch (_gamePosition)
            {
                case 0:
                    _gamePosition++;
                    if (_gamePosition == _player2Controller.GamePosition)
                    {
                        _gamePosition++;
                    }
                    transform.position = PlayerSpawn.Instance.PlayerPoints[_gamePosition].transform.position;
                    break;
                case 1:
                    if ((_gamePosition + 1) == _player2Controller.GamePosition)
                    {
                        return;
                    }
                    _gamePosition++;
                    transform.position = PlayerSpawn.Instance.PlayerPoints[_gamePosition].transform.position;
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
    }

    protected override void DisidePlayerPoint()
    {
        if (Input.GetKeyDown(_entryKey) || CameraController.Instance.duration < 0.0f)
        {
            _isEntried = true;
        }
    }

    // シーン読み込み時のみに使用する前提
    protected override Sprite ChangeSprite(int spriteNum = 0)
    {
        var nowSprite = GetComponent<SpriteRenderer>().sprite;
        if (spriteNum >= 0 && spriteNum < _playerSprites.Count - 1)
        {
            if (AccumulatedDamage >= 0 && AccumulatedDamage < 30)
            {
                nowSprite = _playerSprites[0];
            }
            else if (AccumulatedDamage >= 30 && AccumulatedDamage < 70)
            {
                nowSprite = _playerSprites[1];
            }
            else if (AccumulatedDamage >= 70)
            {
                nowSprite = _playerSprites[2];
            }
        }
        return nowSprite;
    }

    public override void PlayAnimation()
    {
        if (MonoGameManager.Instance.GameState == MonoGameManager.GameSceneState.Stage2
            || MonoGameManager.Instance.GameState == MonoGameManager.GameSceneState.Stage3)
        {
            StartCoroutine(PlayerAnimation());
        }
    }

    private IEnumerator PlayerAnimation()
    {
        float playerDisappearScale = 0.3f;
        float playerRotateAngle = 5.0f;
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
