using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 2f;   // Player�I�u�W�F�N�g�̈ړ����x
    Vector3 mousePos;     // �ŏ��Ƀ^�b�`(���N���b�N)�����n�_�̏�������

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        // �}�E�X���N���b�N(��ʃ^�b�`)���s��ꂽ��
        if (Input.GetMouseButtonDown(0))
        {
            // �^�b�`�����ʒu����
            mousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            // �x�N�g���̈����Z���s���A���݂̃^�b�`�ʒu�Ƃ��̂P�t���[���O�̃^�b�`�ʒu�Ƃ̍���������Ƃ��đ��
            Vector3 mouseDiff = Input.mousePosition - mousePos;
            // ���̃t���[���̃^�b�`�����v�Z�ł���悤�Ɍ��݂̃^�b�`�ʒu��1�t���[���O�̃^�b�`�ʒu�Ƃ��đ��
            // ����ɂ��A�����̎擾���X�V���^�b�`���Ă���ԌJ��Ԃ��Ă���
            mousePos = Input.mousePosition;

            // ���݂�Player�̈ʒu�ɑ΂��āA�^�b�`�ʒu�̈ړ��������g���Ĉړ�����Z�o����
            // ���W�͉�ʂ�height�Ŋ��邱�Ƃňړ��ʒu�𒲐�
            // �^�b�`���ɂ�Z���̏�񂪂Ȃ��̂ŁAX���̈ړ�����X���̈ړ��p�Ɏg�p
            Vector3 newPos = transform.position + new Vector3(mouseDiff.x / Screen.width, 0, 0) * _moveSpeed;

            // Player�I�u�W�F�N�g�̈ʒu���X�V���Ĉړ�����������
            transform.position = newPos;
            if (transform.position.x > 1.8)
            {
                transform.position = new Vector3(1.8f, transform.position.y, 0);
            }
            if (transform.position.x < -1.8)
            {
                transform.position = new Vector3(-1.8f, transform.position.y, 0);
            }
        }
    }
}
