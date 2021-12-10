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
    float _objSizeZ;
    /// <summary>最初にObjがある場所</summary>
    Vector3 _startPos;
    bool _scrollFlag = false;

    void Start()
    {
        Initialize();
        EventManager.OnGameStart += ScrollStart;
        EventManager.OnStop += ScrollStop;
    }
    void Update()
    {
        if (_scrollFlag)
        {
            MoveScroll();
        }
        
    }
    void Initialize()
    {
        _objSizeZ = _stage.GetComponent<Renderer>().bounds.size.z;
        _startPos = _stage.transform.position;
        _clone = Instantiate(_stage);
        _clone.transform.Translate(new Vector3(0, 0, _objSizeZ));
    }
    void MoveScroll()
    {
        _stage.transform.Translate(0, 0, -_scrollSpeed * Time.deltaTime);
        _clone.transform.Translate(0, 0, -_scrollSpeed * Time.deltaTime);
        if (_stage.transform.position.z < _startPos.z - _objSizeZ)
        {
            _stage.transform.Translate(0, 0, _objSizeZ * 2);
        }
        
        if (_clone.transform.position.z < _startPos.z - _objSizeZ)
        {
            _clone.transform.Translate(0, 0, _objSizeZ * 2);
        }
    }

    void ScrollStart()
    {
        _scrollFlag = true;
    }

    void ScrollStop()
    {
        _scrollFlag = false;
    }
}
