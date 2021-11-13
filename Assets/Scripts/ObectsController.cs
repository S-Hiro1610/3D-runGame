using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObectsController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    /// <summary>�I�u�W�F�N�g��j������ʒu</summary>
    [SerializeField] float _endPos = -3f;

    void Update()
    {
        Move();
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
}
