using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    // 現在のレーン番号
    [SerializeField, Range(0, 2)]
    protected int _gamePosition = 0;
    public int GamePosition => _gamePosition;
    // レーン決定のフラグ
    protected bool _isEntried = false;
    public bool IsEntried => _isEntried;
    // プレイヤー画像のスプライト
    [SerializeField]
    protected List<Sprite> _playerSprites = new List<Sprite>();

    /// <summary>
    /// プレイヤー移動
    /// </summary>
    protected abstract void Move();

    /// <summary>
    /// プレイヤーのルート決定
    /// </summary>
    protected abstract void DisidePlayerPoint();

    /// <summary>
    /// Player のスプライト画像を変更する
    /// </summary>
    protected abstract Sprite ChangeSprite(int num);
}
