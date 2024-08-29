using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public float m_hp;
    public void ReduceHp(float damage)
    {
        m_hp -= damage;
    }
    public void IncreaseHp(float heal)
    {
        m_hp += heal;
    }
}
