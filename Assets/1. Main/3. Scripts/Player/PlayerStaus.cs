using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStaus : MonoBehaviour
{
    [SerializeField]
    PlayerDataSO m_playerData;

    [SerializeField]
    public int m_level;
    [SerializeField]
    public int m_hp;
    [SerializeField]
    public int m_damage;
    [SerializeField]
    public int m_armor;
    [SerializeField]
    public int m_moveSpeed;
    [SerializeField]
    public int m_attackDelay;

    void Awake()
    {
        HpStaus();
        DamageStaus();
        ArmorStaus();
        MoveSpeedStaus();
        AttackSpeedStaus();
    }

    void Update()
    {
        HpStaus();
        DamageStaus();
        ArmorStaus();
        MoveSpeedStaus();
        AttackSpeedStaus();
    }
    void HpStaus()
    {
        m_hp = m_playerData.m_hp + m_level * 10;
    }
    void DamageStaus()
    {
        m_damage = m_playerData.m_damage + m_level;
    }
    void ArmorStaus()
    {
        m_armor = m_playerData.m_armor;
    }
    void MoveSpeedStaus()
    {
        m_moveSpeed = m_playerData.m_moveSpeed;
    }
    void AttackSpeedStaus()
    {
        m_attackDelay = m_playerData.m_attackDelay;
    }
}
