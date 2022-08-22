using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ResourceDB", menuName = "ScriptableObjects/InventoryManagerScriptableObject", order = 1)]
public class ResourceBD : ScriptableObject
{ 
    [Serializable]
    public class ResourceItem
    {
        public enum ResourceType
        {
            Null,
            Sword,
            Mace,
            Keys,
            Medal,
            FarmKeys,
            GoldCoin,
            Compass,
            Pot,
            Coin
        }

        public enum CollectableType
        {
            Inventory,
            Collection,
            Currency
        }
        public ResourceType itemType;
        public CollectableType collectableType;
        public Sprite sprite;
    }

    public List<ResourceItem> itemList;
}
