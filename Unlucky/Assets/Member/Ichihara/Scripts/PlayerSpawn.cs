using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : SingletonMonoBehaviour<PlayerSpawn>
{
    [SerializeField]
    private List<GameObject> _playerPoints = new List<GameObject>();
    public List<GameObject> PlayerPoints => _playerPoints;

    // Player のプレハブ
    [SerializeField]
    private GameObject _player1 = null;
    public GameObject Player1 { get; private set; }
    [SerializeField]
    private GameObject _player2 = null;
    public GameObject Player2 { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        var player1Controller = _player1.GetComponent<Player1Controller>();
        var player2Controller = _player2.GetComponent<Player2Controller>();
        Player1 = Instantiate(_player1, _playerPoints[player1Controller.GamePosition].transform.position, Quaternion.identity);
        Player2 = Instantiate(_player2, _playerPoints[player2Controller.GamePosition].transform.position, Quaternion.identity);
    }
}
