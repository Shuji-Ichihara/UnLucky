using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _playerPoints = new List<GameObject>();

    // Player のプレハブ
    [SerializeField]
    private GameObject _player1 = null;
    [SerializeField]
    private GameObject _player2 = null;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_player1, _playerPoints[0].transform.position, Quaternion.identity);
        Instantiate(_player2, _playerPoints[2].transform.position, Quaternion.identity);
    }
}
