using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : PlayerBase
{
    #region Input Keyes
    private KeyCode _moveLeftKey = KeyCode.A;
    private KeyCode _moveRightKey = KeyCode.D;
    private KeyCode _entryKey = KeyCode.S;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // 選択中の場合は false にする
        _isEntried = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSprite();
        DisidePlayerPoint();
        if(_isEntried == false)
        {
            Move();
        }
        ChangeSprite();
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

    protected override void ChangeSprite(int spriteNum = 0)
    {
        if(spriteNum >= 0 && spriteNum < _playerSprites.Count - 1)
        {
            switch (_endurenceValue)
            {
                case 100:
                    gameObject.GetComponent<SpriteRenderer>().sprite = _playerSprites[spriteNum];
                    break;
                case 100 - 31:
                    gameObject.GetComponent<SpriteRenderer>().sprite = _playerSprites[spriteNum++];
                    break;
                case 100 - 31 * 2:
                    gameObject.GetComponent<SpriteRenderer>().sprite = _playerSprites[spriteNum += 2];
                    break;
                default:
                    break;
            }
        }
    }
}
