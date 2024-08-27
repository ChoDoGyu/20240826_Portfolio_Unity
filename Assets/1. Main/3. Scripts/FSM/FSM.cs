using UnityEngine;

public class FSM<T> : MonoBehaviour
{
    private T m_owner;    //상태 소유자
    private FSMState<T> m_currentState = null;    //현재 상태
    private FSMState<T> m_previousState = null;   //이전 상태

    public FSMState<T> _CurrentState { get { return m_currentState; } }
    public FSMState<T> _PreviousState { get { return m_previousState; } }

    //초기 상태와 상태 소유자 설정
    protected void InitState(T owner, FSMState<T> initialState)
    {
        m_owner = owner;
        ChangeState(initialState);
    }
    //각 상태의 실시간 처리
    protected void FSMUpdate()
    {
        if(m_currentState != null)
        {
            m_currentState.Execute(m_owner);
        }
    }

    //상태 변경
    public void ChangeState(FSMState<T> newstate)
    {
        //이전 상태 교체
        m_previousState = m_currentState;

        //이전 상태 종료
        if(m_previousState != null)
        {
            m_previousState.Exit(m_owner);
        }

        //현재 상태 교체
        m_currentState = newstate;

        //현재 상태 시작
        if(m_currentState != null)
        {
            m_currentState.Enter(m_owner);
        }
    }

    //이전 상태로 전환
    public void RevertState()
    {
        if (m_previousState != null)
        {
            ChangeState(m_previousState);
        }
    }

    //디버깅용
    //현재 상태 확인
    public override string ToString()
    {
        return m_currentState.ToString();
    }
}
