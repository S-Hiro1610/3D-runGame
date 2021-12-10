using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 2f;   // Player�I�u�W�F�N�g�̈ړ����x
    Vector3 _touchPos;     // �ŏ��Ƀ^�b�`(���N���b�N)�����n�_�̏�������
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
            Dive();
        }
    }

    void Dive()
    {
        
    }

    void Move() // Player�̈ړ�����
    {
        if (Application.isEditor) // �G�f�B�^��ł̓}�E�X
        {
            // �}�E�X���N���b�N(��ʃ^�b�`)���s��ꂽ��
            if (Input.GetMouseButtonDown(0))
            {
                // �^�b�`�����ʒu����
                _touchPos = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                // �x�N�g���̈����Z���s���A���݂̃^�b�`�ʒu�Ƃ��̂P�t���[���O�̃^�b�`�ʒu�Ƃ̍���������Ƃ��đ��
                Vector3 mouseDiff = Input.mousePosition - _touchPos;
                // ���̃t���[���̃^�b�`�����v�Z�ł���悤�Ɍ��݂̃^�b�`�ʒu��1�t���[���O�̃^�b�`�ʒu�Ƃ��đ��
                // ����ɂ��A�����̎擾���X�V���^�b�`���Ă���ԌJ��Ԃ��Ă���
                _touchPos = Input.mousePosition;

                // ���݂�Player�̈ʒu�ɑ΂��āA�^�b�`�ʒu�̈ړ��������g���Ĉړ�����Z�o����
                // ���W�͉�ʂ�height�Ŋ��邱�Ƃňړ��ʒu�𒲐�
                // �^�b�`���ɂ�Z���̏�񂪂Ȃ��̂ŁAX���̈ړ�����X���̈ړ��p�Ɏg�p
                Vector3 newPos = transform.position + new Vector3(mouseDiff.x / Screen.width, 0, 0) * _moveSpeed;

                // Player�I�u�W�F�N�g�̈ʒu���X�V���Ĉړ�����������
                transform.position = newPos;
            }
        }
        else
        {
            if (Input.touchCount < 1) return;

            foreach (var t in Input.touches)
            {
                switch (t.phase)
                {
                    case TouchPhase.Began:
                        _touchPos = t.position;
                        break;
                    case TouchPhase.Moved:
                        Vector2 touchDiff = t.position - new Vector2(_touchPos.x, _touchPos.y);
                        Vector3 newPos = transform.position + new Vector3(touchDiff.x / Screen.width, 0, 0) * _moveSpeed;
                        transform.position = newPos;
                        break;
                    //case TouchPhase.Stationary:
                    //    break;
                    //case TouchPhase.Ended:
                    //    break;
                    //case TouchPhase.Canceled:
                    //    break;
                }
            }
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
