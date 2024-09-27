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
    public enum SkillGroup
    {
        Skill0,
        Skill1,
        Skill2,
        Skill3
    }
    [SerializeField,Header("���� ��ų")]
    SkillGroup m_curskill;
    [SerializeField, Header("���� ����")]
    public GameObject m_attackArea;
    [SerializeField, Header("��ų ������ ����Ʈ")]
    public List<SkillData> m_skillDataList = new List<SkillData>();

    public float m_curAttackRange;
    public float m_curAttackPoint;
    
    void Awake()
    {
        
    }
    void Start()
    {

    }
    void Update()
    {
        SkillChange();
    }
    void SkillChange()
    {
        switch(m_curskill)
        {
            case SkillGroup.Skill0:
                m_curAttackRange = m_skillDataList[0].m_attackRange;
                m_attackArea.transform.localScale = new Vector3(3, 2, m_skillDataList[0].m_attackRange);
                m_attackArea.transform.localPosition = new Vector3(0, 0, m_skillDataList[0].m_attackRange / 2);
                m_curAttackPoint = m_skillDataList[0].m_skillDamage;
                break;
            case SkillGroup.Skill1:
                m_curAttackRange = m_skillDataList[1].m_attackRange;
                m_attackArea.transform.localScale = new Vector3(3, 2, m_skillDataList[1].m_attackRange);
                m_attackArea.transform.localPosition = new Vector3(0, 0, m_skillDataList[1].m_attackRange / 2);
                m_curAttackPoint = m_skillDataList[1].m_skillDamage;
                break;
            case SkillGroup.Skill2:
                m_curAttackRange = m_skillDataList[2].m_attackRange;
                m_attackArea.transform.localScale = new Vector3(3, 2, m_skillDataList[2].m_attackRange);
                m_attackArea.transform.localPosition = new Vector3(0, 0, m_skillDataList[2].m_attackRange / 2);
                m_curAttackPoint = m_skillDataList[2].m_skillDamage;
                break;
            case SkillGroup.Skill3:
                m_curAttackRange = m_skillDataList[3].m_attackRange;
                m_attackArea.transform.localScale = new Vector3(3, 2, m_skillDataList[3].m_attackRange);
                m_attackArea.transform.localPosition = new Vector3(0, 0, m_skillDataList[3].m_attackRange / 2);
                m_curAttackPoint = m_skillDataList[3].m_skillDamage;
                break;

        }
    }
    public void UseSkill0()
    {
        m_curskill = SkillGroup.Skill0;
    }
    
}
