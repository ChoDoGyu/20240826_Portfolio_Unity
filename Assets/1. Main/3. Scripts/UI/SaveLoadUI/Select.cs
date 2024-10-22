using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    [Header("플레이어 닉네임 입력 UI")]
    public GameObject m_creat;
    [Header("슬롯버튼 아래에 존재하는 Text들")]
    public TextMeshProUGUI[] m_slotText;
    [Header("새로 입력된 플레이어의 닉네임")]
    public TextMeshProUGUI m_newPlayerName;
    //세이브 파일 존재 유무 저장
    bool[] m_savefile = new bool[3];

    void Start()
    {
        //슬롯별로 저장된 데이터가 존재하는지 판단
        for(int i = 0; i < 3; i++)
        {
            //데이터가 있는 경우
            if(File.Exists(DataManager.Instance.m_path + $"{i}"))
            {
                m_savefile[i] = true;
                DataManager.Instance.m_nowSlot = i;
                DataManager.Instance.LoadData();
                m_slotText[i].text = DataManager.Instance.m_nowPlayer.m_name;
            }
            else
            {
                m_slotText[i].text = "비어있음";
            }
        }
        //불러온 데이터를 초기화시킴.
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
