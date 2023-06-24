using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : PlayerBase
{
    #region Input Keys
    // 左右移動
    [SerializeField]
    private KeyCode _moveLeftKey = KeyCode.J;
    [SerializeField]
    private KeyCode _moveRightKey = KeyCode.L;
    // 決定
    [SerializeField]
    private KeyCode _entryKey = KeyCode.K;
    #endregion

    private Player1Controller _player1Controller = null;

    // Start is called before the first frame update
    void Start()
    {
        // DEBUG : スプライト切り替え用
        _accumulatedDamage = 80;

        _isEntried = false; // レーン選択になる為
        var sprite = GetComponent<SpriteRenderer>();
        var spriteNum = _playerSprites.FindIndex(item => item == sprite.sprite);
        sprite.sprite = ChangeSprite(spriteNum);
        _player1Controller = PlayerSpawn.Instance.Player1.GetComponent<Player1Controller>();
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
                    if ((_gamePosition - 1) == _player1Controller.GamePosition)
                    {
                        return;
                    }
                    _gamePosition--;
                    transform.position = PlayerSpawn.Instance.PlayerPoints[_gamePosition].transform.position;
                    break;
                case 2:
                    _gamePosition--;
                    if (_gamePosition == _player1Controller.GamePosition)
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
                    if (_gamePosition == _player1Controller.GamePosition)
                    {
                        _gamePosition++;
                    }
                    transform.position = PlayerSpawn.Instance.PlayerPoints[_gamePosition].transform.position;
                    break;
                case 1:
                    if ((_gamePosition + 1) == _player1Controller.GamePosition)
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
        if (Input.GetKeyDown(_entryKey))
        {
            _isEntried = true;
        }
    }

    protected override int Damage(GameObject obj)
    {
        throw new System.NotImplementedException();
    }

    protected override Sprite ChangeSprite(int spriteNum = 0)
    {
        var nowSprite = GetComponent<SpriteRenderer>().sprite;
        if (spriteNum >= 0 && spriteNum < _playerSprites.Count - 1)
        {
            if (_accumulatedDamage >= 0 && _accumulatedDamage < 30)
            {
                nowSprite = _playerSprites[0];
            }
            else if (_accumulatedDamage >= 30 && _accumulatedDamage < 70)
            {
                nowSprite = _playerSprites[1];
            }
            else if (_accumulatedDamage >= 70)
            {
                nowSprite = _playerSprites[2];
            }
        }
        return nowSprite;
    }
}
