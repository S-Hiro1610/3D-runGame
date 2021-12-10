using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsCreate : MonoBehaviour
{
    /// <summary>��������I�u�W�F�N�g�̃v���n�u</summary>
    [SerializeField] GameObject _objectPrefab = default;
    /// <summary>�����ɐ����\�ȍő吔</summary>
    [SerializeField] int _maxCount = 10;
    /// <summary>��������Ԋu</summary>
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
    // �I�u�W�F�N�g�v�[�����쐬
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
        // �g�p���łȂ����̂�T���ĕԂ�
        foreach (var obj in _poolObjList)
        {
            if (obj.activeSelf == false)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        // �S�Ďg�p����������V��������ĕԂ�
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
        int lane = Random.Range(0, 3);// 0�`2�̂Ȃ��̐�������
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
