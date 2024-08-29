using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaManager : MonoBehaviour
{
    [SerializeField]
    public SkillData m_skillData;
    public Transform m_transform;
    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

}
