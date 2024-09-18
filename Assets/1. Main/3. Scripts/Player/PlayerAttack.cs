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
        Skill1,
        Skill2,
        Skill3,
        Skill4,
        Skill5,
        Skill6
    }
    [SerializeField,Header("���� ��ų")]
    SkillGroup m_curskill;
    [SerializeField, Header("���� ����")]
    public GameObject m_attackArea;
    [SerializeField, Header("��ų ������ ����Ʈ")]
    public List<SkillData> m_skillDataList = new List<SkillData>();
    public float m_curAttackRange;
    void Awake()
    {
        
    }
    void Start()
    {
        //m_attackArea.SetActive(false);

    }
    void Update()
    {
        SkillChange();
    }
    void SkillChange()
    {
        switch(m_curskill)
        {
            case SkillGroup.Skill1:
                m_curAttackRange = m_skillDataList[0].m_attackRange;
                m_attackArea.transform.localScale = new Vector3(1, 1, m_skillDataList[0].m_attackRange);
                m_attackArea.transform.localPosition = new Vector3(0, 0, m_skillDataList[0].m_attackRange / 2);
                break;
            case SkillGroup.Skill2:
                m_curAttackRange = m_skillDataList[1].m_attackRange;
                m_attackArea.transform.localScale = new Vector3(1, 1, m_skillDataList[1].m_attackRange);
                m_attackArea.transform.localPosition = new Vector3(0, 0, m_skillDataList[1].m_attackRange / 2);
                break;
            case SkillGroup.Skill3:
                m_curAttackRange = m_skillDataList[2].m_attackRange;
                m_attackArea.transform.localScale = new Vector3(1, 1, m_skillDataList[2].m_attackRange);
                m_attackArea.transform.localPosition = new Vector3(0, 0, m_skillDataList[2].m_attackRange / 2);
                break;
            case SkillGroup.Skill4:
                m_curAttackRange = m_skillDataList[3].m_attackRange;
                m_attackArea.transform.localScale = new Vector3(1, 1, m_skillDataList[3].m_attackRange);
                m_attackArea.transform.localPosition = new Vector3(0, 0, m_skillDataList[3].m_attackRange / 2);
                break;

            case SkillGroup.Skill5:
                m_curAttackRange = m_skillDataList[4].m_attackRange;
                m_attackArea.transform.localScale = new Vector3(1, 1, m_skillDataList[4].m_attackRange);
                m_attackArea.transform.localPosition = new Vector3(0, 0, m_skillDataList[4].m_attackRange / 2);
                break;

            case SkillGroup.Skill6:
                m_curAttackRange = m_skillDataList[5].m_attackRange;
                m_attackArea.transform.localScale = new Vector3(1, 1, m_skillDataList[5].m_attackRange);
                m_attackArea.transform.localPosition = new Vector3(0, 0, m_skillDataList[5].m_attackRange / 2);
                break;
        }
    }
    public void UseSkill1()
    {
        m_curskill = SkillGroup.Skill1;
        print("Player Attack!!");
    }
}
