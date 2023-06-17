using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    // プレイヤーの耐久値
    [SerializeField]
    protected int _endurenceValue = 100;
    // 怪我をした場合のスプライト
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
    /// ダメージ処理
    /// </summary>
    /// <param name="obj">衝突したオブジェクト</param>
    /// <returns>ダメージの値</returns>
    protected abstract int Damage(GameObject obj);

    /// <summary>
    /// Player のスプライト画像を変更する
    /// </summary>
    protected abstract void ChangeSprite();
}
