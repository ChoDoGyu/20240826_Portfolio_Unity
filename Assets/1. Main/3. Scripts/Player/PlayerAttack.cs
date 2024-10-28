using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using System.IO;
using UnityEditor;
//enum형으로 공격 스킬이 뭔지 정한 다음
//공격하면 오브젝트 하나로 됨
//스킬 데이터는 리스트에 넣어놓고 정할때마다 바꿔서 적용하면 됨
public class PlayerAttack : MonoBehaviour
{
    [Header("현재 스킬")]
    public UseSkill m_curSkill;
    [Header("기본 스킬")]
    public UseSkill m_defaultSkill;
    public UseSkill m_lastSkill;

    [SerializeField, Header("공격 지역")]
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
