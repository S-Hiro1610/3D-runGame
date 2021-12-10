using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObectsController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    /// <summary>オブジェクトを破棄する位置</summary>
    [SerializeField] float _endPos = -3f;
    bool _moveFlag = false;

    void Start()
    {
        EventManager.OnGameStart += MoveStart;
        EventManager.OnStop += MoveStop;
    }
    void Update()
    {
        if (_moveFlag)
        {
            Move();
        }
    }

    void Move()
    {
        if (gameObject.transform.position.z < _endPos)
        {
            gameObject.SetActive(false);
            return;
        }
        else
        {
            transform.Translate(0, 0, -_moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            EventManager.GameEnd();
        }
    }
    void MoveStart()
    {
        _moveFlag = true;
    }
    void MoveStop()
    {
        _moveFlag = false;
    }
}
