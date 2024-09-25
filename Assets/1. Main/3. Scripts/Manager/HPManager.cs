using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public float m_hp;
    public bool m_reduceHpCheck = false;
    public bool m_increaseHpCheck = false;
    public void ReduceHp(float damage)
    {
        m_hp -= damage;
        //m_reduceHpCheck = true;
    }
    public void IncreaseHp(float heal)
    {
        m_hp += heal;
        //m_increaseHpCheck = true;
    }
}
