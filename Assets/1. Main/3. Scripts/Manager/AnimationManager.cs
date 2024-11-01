using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator m_animator;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    public void MoveAnimation(float number)
    {

        m_animator.SetFloat("MoveSpeed", number);
    }
    public void ParameterBool(string boolname, bool onoff)
    {
        m_animator.SetBool(boolname, onoff);
    }
}
