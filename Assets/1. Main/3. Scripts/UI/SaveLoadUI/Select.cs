using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    [Header("�÷��̾� �г��� �Է� UI")]
    public GameObject m_creat;
    [Header("���Թ�ư �Ʒ��� �����ϴ� Text��")]
    public TextMeshProUGUI[] m_slotText;
    [Header("���� �Էµ� �÷��̾��� �г���")]
    public TextMeshProUGUI m_newPlayerName;
    //���̺� ���� ���� ���� ����
    bool[] m_savefile = new bool[3];

    void Start()
    {
        //���Ժ��� ����� �����Ͱ� �����ϴ��� �Ǵ�
        for(int i = 0; i < 3; i++)
        {
            //�����Ͱ� �ִ� ���
            if(File.Exists(DataManager.Instance.m_path + $"{i}"))
            {
                m_savefile[i] = true;
                DataManager.Instance.m_nowSlot = i;
                DataManager.Instance.LoadData();
                m_slotText[i].text = DataManager.Instance.m_nowPlayer.m_name;
            }
            else
            {
                m_slotText[i].text = "�������";
            }
        }
        //�ҷ��� �����͸� �ʱ�ȭ��Ŵ.
        DataManager.Instance.DataClear();
    }

    public void Slot(int number)
    {
        DataManager.Instance.m_nowSlot = number;

        if (m_savefile[number])
        {
            DataManager.Instance.LoadData();

            GoGame();
        }
        else
        {
            Creat();
        }
    }

    public void GoGame()
    {
        if (!m_savefile[DataManager.Instance.m_nowSlot])
        {
            DataManager.Instance.m_nowPlayer.m_name = m_newPlayerName.text;
            DataManager.Instance.SaveData();
        }
        SceneManager.LoadScene(1);
    }

    public void Creat()
    {
        m_creat.gameObject.SetActive(true);
    }
}
