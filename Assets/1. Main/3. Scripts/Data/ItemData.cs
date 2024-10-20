using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/ItemData", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    [SerializeField]//아이템 이름
    public string m_itemName;
    [SerializeField]//무기, 갑옷, 신발, 장갑
    public string m_itemCategory;
    [SerializeField]//0, 1, 2, 3
    public int m_itemCategoryNum;
    [SerializeField]//공격력, 방어력, 이동속도, 공격속도
    public float m_effectNum;
    [SerializeField]//가격
    public int m_itemPrice;
    [SerializeField]//설명
    public string m_itemTooltip;
    [SerializeField]
    public Sprite m_itemImage;
    [SerializeField]
    public GameObject m_itemPrefab;
}
