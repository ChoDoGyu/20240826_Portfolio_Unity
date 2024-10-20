using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/ItemData", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    [SerializeField]//������ �̸�
    public string m_itemName;
    [SerializeField]//����, ����, �Ź�, �尩
    public string m_itemCategory;
    [SerializeField]//0, 1, 2, 3
    public int m_itemCategoryNum;
    [SerializeField]//���ݷ�, ����, �̵��ӵ�, ���ݼӵ�
    public float m_effectNum;
    [SerializeField]//����
    public int m_itemPrice;
    [SerializeField]//����
    public string m_itemTooltip;
    [SerializeField]
    public Sprite m_itemImage;
    [SerializeField]
    public GameObject m_itemPrefab;
}
