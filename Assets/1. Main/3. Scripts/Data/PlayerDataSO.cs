using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObject/PlayerData", order = int.MaxValue)]
public class PlayerDataSO : ScriptableObject
{
    [SerializeField]
    public string m_name;
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
    [SerializeField]
    public int m_coin;

}
