using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObject/PlayerData", order = int.MaxValue)]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private int m_level;
    public int m_Level => m_Level;
    [SerializeField]
    private int m_hp;
    public int m_Hp => m_hp;
    [SerializeField]
    private int m_damage;
    public int m_Damage => m_damage;
    [SerializeField]
    private int m_armor;
    public int m_Armor => m_armor;
    [SerializeField]
    private int m_moveSpeed;
    public int m_MoveSpeed => m_moveSpeed;
    [SerializeField]
    private int m_attackSpeed;
    public int m_AttackSpeed => m_attackSpeed;
}
