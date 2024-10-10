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

    //Ű������ư
    [SerializeField]
    private Image m_keyButtonImage;//���� �Ҵ�� Ű�� �� Ű�� ������ �� �ְ� �ϴ� ��ư�� �̹���
    private Coroutine m_keyButtonColorCor;//Ű ���� ��ư�� ���� ������ �����ϴ� �ڷ�ƾ�� ��� ����

    //��ư �ؽ�Ʈ
    [SerializeField]
    private TextMeshProUGUI m_keyButtonText; //��ư�� ���� �ڽ��� �ؽ�Ʈ�ʵ�

    //Ű���� �ɼ��� Ȱ��ȭ�Ǵ� ��� ���� ���Կ� �´� Ű�� �������� �ý�Ʈ�� ǥ��
    private void OnEnable()
    {
        m_originKeyCode = KeyManager.Instance.GetKeyCode(m_keyBindingName);
        m_keyButtonText.text = ((char)m_originKeyCode).ToString().ToUpper();
    }

    //UI�κ��� ȣ��Ǹ� �ش� ���Կ� Ű ������ �õ�
    public void BTN_ModifyKey()
    {
        m_keyButtonText.text = "< >";
        StartCoroutine(Coroutine_AssignKey());
    }

    //�ڷ�ƾ�� �̿��Ͽ� Ű �Է��� ��ٸ���, Ű�� �Է¹��� ��� Ű ��ȿ���� �˻��մϴ�.
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
                        //������ �ڷ�ƾ ����
                        if(m_keyButtonColorCor != null)
                        {
                            StopCoroutine(m_keyButtonColorCor);
                        }
                        //Ű ������ �� �� �ִ� ���?
                        if(KeyManager.Instance.CheckKey(code, m_originKeyCode))
                        {
                            //Ű ����
                            KeyManager.Instance.AssignKey(code, m_keyBindingName);
                            m_originKeyCode = code;

                            //Ű ���̺��� ����
                            m_keyButtonText.text = ((char)code).ToString().ToUpper();

                            //������� ���� �Ϸ���� ����
                            m_keyButtonColorCor = StartCoroutine(Coroutine_ChangeButtonColor(Color.green));
                        }
                        else
                        {
                            //Ű ���̺��� ����
                            m_keyButtonText.text = ((char)m_originKeyCode).ToString().ToUpper();

                            //���������� ���� �Ϸ���� ����
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

        //targetColor�� ����
        while(true)
        {
            m_keyButtonImage.color = Color.Lerp(m_keyButtonImage.color, targetColor, progress);
            progress += colorSpeed + Time.deltaTime;

            //progress�� 1�̸� > ���� �Ϸ�
            if(progress > 1)
            {
                progress = 0;

                //targetColor���� �ٽ� ���ƿ���
                while (true)
                {
                    m_keyButtonImage.color = Color.Lerp(m_keyButtonImage.color, Color.white, progress);
                    progress += colorSpeed + Time.deltaTime;

                    //���� ��ȯ �Ϸ�
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
