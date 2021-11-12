using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScroller : MonoBehaviour
{
    [SerializeField]
    GameObject _stage;
    
    [SerializeField]
    float _scrollSpeed = 5.0f;
    /// <summary>�N���[������Obj������ϐ�</summary>
    GameObject _clone;
    GameObject _clone2;
    /// <summary>Obj�̃T�C�Y������ϐ�</summary>
    float m_objSize;
    /// <summary>�ŏ���Obj������ꏊ</summary>
    Vector3 m_startPos;
    private void Start()
    {
        m_objSize = _stage.GetComponent<Renderer>().bounds.size.z;
        m_startPos = _stage.transform.position;
        _clone = Instantiate(_stage);
        _clone2 = Instantiate(_stage);
        _clone.transform.Translate(new Vector3(0, 0, m_objSize));
        _clone2.transform.Translate(new Vector3(0, 0, m_objSize * 2));
    }
    private void Update()
    {
        MoveScroll();
    }
    void MoveScroll()
    {
        _stage.transform.Translate(0, 0, _scrollSpeed * -1 * Time.deltaTime);
        _clone.transform.Translate(0, 0, _scrollSpeed * -1 * Time.deltaTime);
        _clone2.transform.Translate(0, 0, _scrollSpeed * -1 * Time.deltaTime);
        if (_stage.transform.position.z < m_startPos.z - m_objSize)
        {
            _stage.transform.Translate(0, 0, m_objSize * 3);
        }
        
        if (_clone.transform.position.z < m_startPos.z - m_objSize)
        {
            _clone.transform.Translate(0, 0, m_objSize * 3);
        }

        if (_clone2.transform.position.z < m_startPos.z - m_objSize)
        {
            _clone2.transform.Translate(0, 0, m_objSize * 3);
        }
    }
}
