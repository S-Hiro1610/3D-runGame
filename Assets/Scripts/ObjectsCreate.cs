using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsCreate : MonoBehaviour
{
    /// <summary>生成するオブジェクトのプレハブ</summary>
    [SerializeField] GameObject _objectPrefab = default;
    /// <summary>同時に生成可能な最大数</summary>
    [SerializeField] int _maxCount = 10;
    /// <summary>生成する間隔</summary>
    [SerializeField] float _createInterval = 3f;
    [SerializeField] List<Transform> _lanes = new List<Transform>();

    List<GameObject> _poolObjList;
     GameObject _poolObj;
    float _timer = 0f;
    bool _createFlag = false;

    void Start()
    {
        CreatePool(_objectPrefab, _maxCount);
    }

    void Update()
    {
        if (_createFlag)
        {
            if (_timer > _createInterval)
            {
                Create();
                _timer = 0;
            }
            _timer += Time.deltaTime;
        }
    }
    // オブジェクトプールを作成
    public void CreatePool(GameObject obj, int maxCount)
    {
        _poolObj = obj;
        _poolObjList = new List<GameObject>();
        for (int i = 0; i < maxCount; i++)
        {
            var newObj = CreateNewObject();
            newObj.SetActive(false);
            _poolObjList.Add(newObj);
        }
    }
    public GameObject GetObject()
    {
        // 使用中でないものを探して返す
        foreach (var obj in _poolObjList)
        {
            if (obj.activeSelf == false)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        // 全て使用中だったら新しく作って返す
        var newObj = CreateNewObject();
        newObj.SetActive(true);
        _poolObjList.Add(newObj);

        return newObj;
    }

    GameObject CreateNewObject()
    {
        var newObj = Instantiate(_poolObj);
        newObj.transform.parent = gameObject.transform;
        newObj.name = _poolObj.name + (_poolObjList.Count + 1);

        return newObj;
    }

    void Create()
    {
        int lane = Random.Range(0, 3);// 0～2のなかの整数乱数
        GameObject go = GetObject();
        go.transform.position = _lanes[lane].position;
    }

    void CreateStart()
    {
        _createFlag = true;
    }
    void CreateStop()
    {
        _createFlag = false;
    }
}
