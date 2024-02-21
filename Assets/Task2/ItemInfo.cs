using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/items" ) ]
public class ItemInfo : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private string description;

    public string ItemName { get { return itemName; } set { description = value; } }
    public string Description { get { return description; } set {  description = value; } }


}
