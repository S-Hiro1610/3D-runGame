using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuard : MonoBehaviour
{
    [SerializeField] GameObject _player = default;
    [SerializeField] GameObject _stage = default;
    float _stageSizeX;
    float _playerSizeX;

    private void Start()
    {
        _stageSizeX = _stage.GetComponent<Renderer>().bounds.size.x;
        _playerSizeX = _player.GetComponent<Renderer>().bounds.size.x;
    }
    private void Update()
    {
        if (_player.transform.position.x > _stageSizeX / 2 - _playerSizeX / 2)
        {
            _player.transform.position = new Vector3(_stageSizeX / 2 - _playerSizeX / 2, transform.position.y, 0);
        }
        if (_player.transform.position.x < -_stageSizeX / 2 + _playerSizeX / 2)
        {
            _player.transform.position = new Vector3(-_stageSizeX / 2 + _playerSizeX / 2, transform.position.y, 0);
        }
    }
}
