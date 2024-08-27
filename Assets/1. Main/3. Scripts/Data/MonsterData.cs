using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MonsterData", menuName = "ScriptableObject/MonsterData", order = int.MaxValue)]
public class MonsterData : ScriptableObject
{
    [SerializeField]
    public string m_name;
    [SerializeField]
    public int m_hp;
    [SerializeField]
    public int m_damage;
    [SerializeField]
    public float m_sightRange;
    [SerializeField]
    public float m_attackRange;
    [SerializeField]
    public float m_attackDelay;
}
