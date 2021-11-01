using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[RequireComponent(typeof(PlayableDirector))]
public class EventManager : MonoBehaviour
{
    // �����ɃC���X�y�N�^�[��ł��炩���ߕ����̃Z�b�g
    [SerializeField] private TimelineAsset[] timelines;

    private PlayableDirector director;//PlayableDirector�^�̕ϐ�director��錾

    void Start()
    {
        //�����I�u�W�F�N�g�ɕt���Ă���PlayableDirector�R���|�[�l���g���擾
        director = this.GetComponent<PlayableDirector>();
    }

    //�C�x���g�Đ����\�b�h �{�^���Ɋ��蓖�Ă�
    public void EventPlay(int id)
    {

        //�{�^���̈����ɂ���ă^�C�����C�����w�肵�čĐ�
        switch (id)
        {
            case 1:
                // �Đ��������^�C�����C����PlayableDirector�ɍĐ�������
                director.Play(timelines[0]);
                break;
            case 2:
                // �Đ��������^�C�����C����PlayableDirector�ɍĐ�������
                director.Play(timelines[1]);
                break;
            case 3:
                // �Đ��������^�C�����C����PlayableDirector�ɍĐ�������
                director.Play(timelines[2]);
                break;
        }
    }
}