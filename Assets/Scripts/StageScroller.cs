using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScroller : MonoBehaviour
{
    [SerializeField]
    GameObject _stage;
    
    [SerializeField]
    float _scrollSpeed = 5.0f;
    public float ScrollSpeed => _scrollSpeed;
    /// <summary>クローンしたObjを入れる変数</summary>
    GameObject _clone;
    /// <summary>Objのサイズを入れる変数</summary>
    float m_objSizeZ;
    /// <summary>最初にObjがある場所</summary>
    Vector3 m_startPos;
    void Start()
    {
        m_objSizeZ = _stage.GetComponent<Renderer>().bounds.size.z;
        m_startPos = _stage.transform.position;
        _clone = Instantiate(_stage);
        _clone.transform.Translate(new Vector3(0, 0, m_objSizeZ));
    }
    void Update()
    {
        MoveScroll();
    }
    void MoveScroll()
    {
        _stage.transform.Translate(0, 0, -_scrollSpeed * Time.deltaTime);
        _clone.transform.Translate(0, 0, -_scrollSpeed * Time.deltaTime);
        if (_stage.transform.position.z < m_startPos.z - m_objSizeZ)
        {
            _stage.transform.Translate(0, 0, m_objSizeZ * 2);
        }
        
        if (_clone.transform.position.z < m_startPos.z - m_objSizeZ)
        {
            _clone.transform.Translate(0, 0, m_objSizeZ * 2);
        }
    }
}
