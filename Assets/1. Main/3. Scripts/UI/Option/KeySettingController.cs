using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class KeySettingController : MonoBehaviour
{
    private KeyCode m_originKeyCode;
    [SerializeField]
    private string m_keyBindingName;

    //키설정버튼
    [SerializeField]
    private Image m_keyButtonImage;//현재 할당된 키와 그 키를 수정할 수 있게 하는 버튼의 이미지
    private Coroutine m_keyButtonColorCor;//키 수정 버튼의 색상 변경을 수행하는 코루틴을 담는 변수

    //버튼 텍스트
    [SerializeField]
    private TextMeshProUGUI m_keyButtonText; //버튼의 하위 자식의 텍스트필드

    //키설정 옵션이 활성화되는 경우 현재 슬롯에 맞는 키를 가져오고 택스트로 표시
    private void OnEnable()
    {
        m_originKeyCode = KeyManager.Instance.GetKeyCode(m_keyBindingName);
        m_keyButtonText.text = ((char)m_originKeyCode).ToString().ToUpper();
    }

    //UI로부터 호출되며 해당 슬롯에 키 설정을 시도
    public void BTN_ModifyKey()
    {
        m_keyButtonText.text = "< >";
        StartCoroutine(Coroutine_AssignKey());
    }

    //코루틴을 이용하여 키 입력을 기다리고, 키를 입력받은 경우 키 유효성을 검사합니다.
    private IEnumerator Coroutine_AssignKey()
    {
        while(true)
        {
            if(Input.anyKey)
            {
                foreach(KeyCode code in Enum.GetValues(typeof(KeyCode)))
                {
                    if(Input.GetKey(code))
                    {
                        //기존의 코루틴 제거
                        if(m_keyButtonColorCor != null)
                        {
                            StopCoroutine(m_keyButtonColorCor);
                        }
                        //키 설정을 할 수 있는 경우?
                        if(KeyManager.Instance.CheckKey(code, m_originKeyCode))
                        {
                            //키 지정
                            KeyManager.Instance.AssignKey(code, m_keyBindingName);
                            m_originKeyCode = code;

                            //키 레이블을 변경
                            m_keyButtonText.text = ((char)code).ToString().ToUpper();

                            //녹색으로 설정 완료됨을 연출
                            m_keyButtonColorCor = StartCoroutine(Coroutine_ChangeButtonColor(Color.green));
                        }
                        else
                        {
                            //키 레이블을 변경
                            m_keyButtonText.text = ((char)m_originKeyCode).ToString().ToUpper();

                            //빨간색으로 설정 완료됨을 연출
                            m_keyButtonColorCor = StartCoroutine(Coroutine_ChangeButtonColor(Color.red));
                        }
                    }
                }
                yield break;
            }
            yield return null;
        }
    }
    private IEnumerator Coroutine_ChangeButtonColor(Color targetColor, float colorSpeed = 2.0f)
    {
        float progress = 0;

        //targetColor로 변경
        while(true)
        {
            m_keyButtonImage.color = Color.Lerp(m_keyButtonImage.color, targetColor, progress);
            progress += colorSpeed + Time.deltaTime;

            //progress가 1이면 > 보간 완료
            if(progress > 1)
            {
                progress = 0;

                //targetColor에서 다시 돌아오기
                while (true)
                {
                    m_keyButtonImage.color = Color.Lerp(m_keyButtonImage.color, Color.white, progress);
                    progress += colorSpeed + Time.deltaTime;

                    //색상 전환 완료
                    if(progress > 1 )
                    {
                        yield break;
                    }
                    yield return null;
                }
            }
            yield return null;
        }
    }
}
