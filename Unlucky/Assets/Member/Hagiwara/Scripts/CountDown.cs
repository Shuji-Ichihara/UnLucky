using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
	#region 変数定義
	[SerializeField]
	private Text _countText = null;

	private int _countSecondsInt = 4;

	private float _countSecondsFloat = 4.0f;

	private bool _countDownEnabled = true;
	#endregion

	#region 主要処理
	private void FixedUpdate()
	{
		// カウントダウンが有効であれば、秒数を減らし続ける。
		if(_countDownEnabled)
		{
			// 毎秒減少させる。
			_countSecondsFloat -= Time.deltaTime;
			// 小数点以下の数値に用はないので、整数に変更。
			_countSecondsInt = (int)_countSecondsFloat;
			// 文字列としてテキストに出力。
			_countText.text = _countSecondsInt.ToString();

			// カウントの秒数が 0 になったらカウントダウンを無効にし、テキストを非表示にする。
			if(_countSecondsInt == 0)
			{
				// カウントダウンを無効化。
				_countDownEnabled = false;
				// テキストを非表示。
				_countText.enabled = false;
			}
		}
	}
	#endregion
}