using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int energy;
    public int coins;
    public int[] itemTypeEnums;
    public int[] itemTypeAmounts;
    public int[] collectionTypeEnums;
    public int[] collectionTypeAmounts;

    public PlayerData (GameManager gameManager, InventoryManager inventoryManager)
    {
        energy = gameManager.EnergyCount;
        coins = gameManager.CoinCount;

        itemTypeEnums = new int[3];
        itemTypeAmounts = new int[3];
        collectionTypeEnums = new int[5];
        collectionTypeAmounts = new int[5];

        for (int i = 0; i < inventoryManager.cells.Count; i++)
        {
            switch (inventoryManager.cells[i].itemType)
            {
                case ResourceBD.ResourceItem.ResourceType.Null:
                    itemTypeEnums[i] = 0;
                    itemTypeAmounts[i] = inventoryManager.cells[i].amount;
                    break;
                case ResourceBD.ResourceItem.ResourceType.Sword:
                    itemTypeEnums[i] = 1;
                    itemTypeAmounts[i] = inventoryManager.cells[i].amount;
                    break;
                case ResourceBD.ResourceItem.ResourceType.Mace:
                    itemTypeEnums[i] = 2;
                    itemTypeAmounts[i] = inventoryManager.cells[i].amount;
                    break;
                case ResourceBD.ResourceItem.ResourceType.Keys:
                    itemTypeEnums[i] = 3;
                    itemTypeAmounts[i] = inventoryManager.cells[i].amount;
                    break;
            }
        }

        for (int i = 0; i < inventoryManager.collectionCells.Count; i++)
        {
            switch (inventoryManager.collectionCells[i].itemType)
            {
                case ResourceBD.ResourceItem.ResourceType.Medal:
                    collectionTypeEnums[i] = 4;
                    collectionTypeAmounts[i] = inventoryManager.collectionCells[i].amount;
                    break;
                case ResourceBD.ResourceItem.ResourceType.FarmKeys:
                    collectionTypeEnums[i] = 5;
                    collectionTypeAmounts[i] = inventoryManager.collectionCells[i].amount;
                    break;
                case ResourceBD.ResourceItem.ResourceType.GoldCoin:
                    collectionTypeEnums[i] = 6;
                    collectionTypeAmounts[i] = inventoryManager.collectionCells[i].amount;
                    break;
                case ResourceBD.ResourceItem.ResourceType.Compass:
                    collectionTypeEnums[i] = 7;
                    collectionTypeAmounts[i] = inventoryManager.collectionCells[i].amount;
                    break;
                case ResourceBD.ResourceItem.ResourceType.Pot:
                    collectionTypeEnums[i] = 8;
                    collectionTypeAmounts[i] = inventoryManager.collectionCells[i].amount;
                    break;
            }
        }
    }
}
