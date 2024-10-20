using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static UnityEditor.Progress;

public class GoogleSheetManager : MonoBehaviour
{
    [SerializeField]
    ItemDataSO m_itmeSO;
    const string m_itmeDataURL = "https://docs.google.com/spreadsheets/d/1_VUxh2fhvP-RLoUBafHvxa3vU-UTfqmi9QHx8m5HFsY/export?format=tsv&range=A2:F";

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(m_itmeDataURL);
        yield return www.SendWebRequest();

        SetItemSO(www.downloadHandler.text);
    }
    
    void SetItemSO(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;
        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split("\t");
            
            for (int j = 0; j < columnSize; j++)
            {
                ItemDataStruct targetItem = m_itmeSO.m_itmeDataList[i];

                targetItem.m_itemName = column[0];
                targetItem.m_itemCategory = column[1];
                targetItem.m_itemCategoryNum = int.Parse(column[2]);
                targetItem.m_effectNum = float.Parse(column[3]);
                targetItem.m_itemPrice = int.Parse(column[4]);
                targetItem.m_itemTooltip = column[5];
            }
            
        }
    }
}
