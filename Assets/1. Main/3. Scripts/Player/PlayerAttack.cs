using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using System.IO;
using UnityEditor;
//enum������ ���� ��ų�� ���� ���� ����
//�����ϸ� ������Ʈ �ϳ��� ��
//��ų �����ʹ� ����Ʈ�� �־���� ���Ҷ����� �ٲ㼭 �����ϸ� ��
public class PlayerAttack : MonoBehaviour
{
    [Header("���� ��ų")]
    public UseSkill m_curSkill;
    [Header("�⺻ ��ų")]
    public UseSkill m_defaultSkill;
    public UseSkill m_lastSkill;

    [SerializeField, Header("���� ����")]
    public GameObject m_attackArea;

    public float m_curAttackRange;
    public float m_curAttackPoint;

    PlayerManager m_player;

    private void Awake()
    {
        m_defaultSkill = GetComponent<DefaultSkill>();
        m_player = GetComponent<PlayerManager>();
    }
    void Start()
    {
        m_curSkill = m_defaultSkill;
        m_curSkill.InitSeting();
        m_lastSkill = m_curSkill;
    }
    void Update()
    {
        if (m_lastSkill != m_curSkill)
        {
            m_lastSkill = m_curSkill;
            m_curSkill.InitSeting();
        }
        m_curSkill.Using();
        ChangeSkill();
        SkillUsing();
    }
    void ChangeSkill()
    {
        
        if (Input.GetKeyDown(KeyManager.Instance.GetKeyCode("SkillQuickSlot1")))
        {
            Skill1 skill1 = GetComponent<Skill1>();
            m_curSkill = skill1;
            
        }
        else if (Input.GetKeyDown(KeyManager.Instance.GetKeyCode("SkillQuickSlot2")))
        {
            Skill2 skill2 = GetComponent<Skill2>();
            m_curSkill = skill2;
        }
        else if (Input.GetKeyDown(KeyManager.Instance.GetKeyCode("SkillQuickSlot3")))
        {
            Skill3 skill3 = GetComponent<Skill3>();
            m_curSkill = skill3;
            m_player.m_aniManager.ParameterBool("Skill3", true);
        }
    }
    void SkillUsing()
    {
        if (m_player.m_aniManager.m_animator.GetCurrentAnimatorStateInfo(0).IsName("Skill3"))
        {
            if (m_player.m_aniManager.m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            {
                m_curSkill = m_defaultSkill;
                m_player.m_aniManager.ParameterBool("Skill3", false);
            }
        }
    }
}
