using UnityEngine;

public class FSM<T> : MonoBehaviour
{
    private T m_owner;    //���� ������
    private FSMState<T> m_currentState = null;    //���� ����
    private FSMState<T> m_previousState = null;   //���� ����

    public FSMState<T> _CurrentState { get { return m_currentState; } }
    public FSMState<T> _PreviousState { get { return m_previousState; } }

    //�ʱ� ���¿� ���� ������ ����
    protected void InitState(T owner, FSMState<T> initialState)
    {
        m_owner = owner;
        ChangeState(initialState);
    }
    //�� ������ �ǽð� ó��
    protected void FSMUpdate()
    {
        if(m_currentState != null)
        {
            m_currentState.Execute(m_owner);
        }
    }

    //���� ����
    public void ChangeState(FSMState<T> newstate)
    {
        //���� ���� ��ü
        m_previousState = m_currentState;

        //���� ���� ����
        if(m_previousState != null)
        {
            m_previousState.Exit(m_owner);
        }

        //���� ���� ��ü
        m_currentState = newstate;

        //���� ���� ����
        if(m_currentState != null)
        {
            m_currentState.Enter(m_owner);
        }
    }

    //���� ���·� ��ȯ
    public void RevertState()
    {
        if (m_previousState != null)
        {
            ChangeState(m_previousState);
        }
    }

    //������
    //���� ���� Ȯ��
    public override string ToString()
    {
        return m_currentState.ToString();
    }
}
