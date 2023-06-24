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

    // Start is called before the first frame update
    void Start()
    {
        // DEBUG : sprite 切り替え用
        _accumulatedDamage = 50;
        
        _isEntried = false; // レーン選択になる為
        var sprite = GetComponent<SpriteRenderer>();
        var spriteNum = _playerSprites.FindIndex(item => item == sprite.sprite);
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
            var player2 = GameObject.Find(PlayerSpawn.Instance.Player2.name).GetComponent<Player2Controller>();
            switch (_gamePosition)
            {
                case 0:
                    break;
                case 1:
                    if ((_gamePosition - 1) == player2.GamePosition)
                    {
                        return;
                    }
                    _gamePosition--;
                    transform.position = PlayerSpawn.Instance.PlayerPoints[_gamePosition].transform.position;
                    break;
                case 2:
                    _gamePosition--;
                    if (_gamePosition == player2.GamePosition)
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
            var player2 = GameObject.Find(PlayerSpawn.Instance.Player2.name).GetComponent<Player2Controller>();
            switch (_gamePosition)
            {
                case 0:
                    _gamePosition++;
                    if (_gamePosition == player2.GamePosition)
                    {
                        _gamePosition++;
                    }
                    transform.position = PlayerSpawn.Instance.PlayerPoints[_gamePosition].transform.position;
                    break;
                case 1:
                    if ((_gamePosition + 1) == player2.GamePosition)
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

    // シーン読み込み時のみに使用する前提
    protected override Sprite ChangeSprite(int spriteNum = 0)
    {
        var nowSprite = GetComponent<SpriteRenderer>().sprite;
        if(spriteNum >= 0 && spriteNum < _playerSprites.Count - 1)
        {
            if(_accumulatedDamage >= 0 && _accumulatedDamage < 30)
            {
                nowSprite = _playerSprites[0];
            }
            else if(_accumulatedDamage >= 30 && _accumulatedDamage < 70)
            {
                nowSprite = _playerSprites[1];
            }
            else if(_accumulatedDamage >= 70)
            {
                nowSprite = _playerSprites[2];
            }
        }
        return nowSprite;
    }
}
