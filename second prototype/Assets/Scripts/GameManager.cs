using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI coinText;
    public Transform lootParent;
    public Transform inventoryIcon;
    public Transform collectionIcon;
    public Transform coinIcon;
    private int energyCount;
    private int coinCount;
    public int EnergyCount => energyCount;
    public int CoinCount => coinCount;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        energyCount = 10;
        energyText.text = "Energy :" + energyCount;
        coinCount = 0;
        coinText.text = "Coins :" + coinCount;
        regenCoroutine = StartCoroutine(EnergyRegen());
    }

    public void RemoveOneEnergy()
    {
        if (energyCount != 0) energyCount--;
        energyText.text = "Energy :" + energyCount;
    }

    public void AddCoin()
    {
        coinCount++;
        coinText.text = "Coins :" + coinCount;
    }

    Coroutine regenCoroutine;
    IEnumerator EnergyRegen()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            if (energyCount < 10 && energyCount >= 0)
            {
                energyCount++;
                energyText.text = "Energy :" + energyCount;
            }
        }
        
    }

    public void Save()
    {
        SaveSystem.SavePlayer(instance, InventoryManager.instance);
    }

    public void Load()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        energyCount = data.energy;
        energyText.text = "Energy :" + energyCount;
        coinCount = data.coins;
        coinText.text = "Coins :" + coinCount;

        for (int i = 0; i < data.itemTypeEnums.Length; i++)
        {
            switch (data.itemTypeEnums[i])
            {
                case 1:
                    foreach (var item in InventoryManager.instance.cells)
                    {
                        if (item.itemType == ResourceBD.ResourceItem.ResourceType.Sword)
                        {
                            item.amount = data.itemTypeAmounts[i] - 1;
                        }
                    }
                    InventoryManager.instance.SaveResource(ResourceBD.ResourceItem.ResourceType.Sword, ResourceBD.ResourceItem.CollectableType.Inventory);
                    break;
                case 2:
                    foreach (var item in InventoryManager.instance.cells)
                    {
                        if (item.itemType == ResourceBD.ResourceItem.ResourceType.Mace)
                        {
                            item.amount = data.itemTypeAmounts[i] - 1;
                        }
                    }
                    InventoryManager.instance.SaveResource(ResourceBD.ResourceItem.ResourceType.Mace, ResourceBD.ResourceItem.CollectableType.Inventory);
                    break;
                case 3:
                    foreach (var item in InventoryManager.instance.cells)
                    {
                        if (item.itemType == ResourceBD.ResourceItem.ResourceType.Keys)
                        {
                            item.amount = data.itemTypeAmounts[i] - 1;
                        }
                    }
                    InventoryManager.instance.SaveResource(ResourceBD.ResourceItem.ResourceType.Keys, ResourceBD.ResourceItem.CollectableType.Inventory);
                    break;
            }
        }

        for (int i = 0; i < data.collectionTypeEnums.Length; i++)
        {
            switch (data.collectionTypeEnums[i])
            {
                case 4:
                    foreach (var item in InventoryManager.instance.collectionCells)
                    {
                        if (item.itemType == ResourceBD.ResourceItem.ResourceType.Medal)
                        {
                            item.amount = data.collectionTypeAmounts[i] - 1;
                        }
                    }
                    InventoryManager.instance.SaveResource(ResourceBD.ResourceItem.ResourceType.Medal, ResourceBD.ResourceItem.CollectableType.Collection);
                    break;
                case 5:
                    foreach (var item in InventoryManager.instance.collectionCells)
                    {
                        if (item.itemType == ResourceBD.ResourceItem.ResourceType.FarmKeys)
                        {
                            item.amount = data.collectionTypeAmounts[i] - 1;
                        }
                    }
                    InventoryManager.instance.SaveResource(ResourceBD.ResourceItem.ResourceType.FarmKeys, ResourceBD.ResourceItem.CollectableType.Collection);
                    break;
                case 6:
                    foreach (var item in InventoryManager.instance.collectionCells)
                    {
                        if (item.itemType == ResourceBD.ResourceItem.ResourceType.GoldCoin)
                        {
                            item.amount = data.collectionTypeAmounts[i] - 1;
                        }
                    }
                    InventoryManager.instance.SaveResource(ResourceBD.ResourceItem.ResourceType.GoldCoin, ResourceBD.ResourceItem.CollectableType.Collection);
                    break;
                case 7:
                    foreach (var item in InventoryManager.instance.collectionCells)
                    {
                        if (item.itemType == ResourceBD.ResourceItem.ResourceType.Compass)
                        {
                            item.amount = data.collectionTypeAmounts[i] - 1;
                        }
                    }
                    InventoryManager.instance.SaveResource(ResourceBD.ResourceItem.ResourceType.Compass, ResourceBD.ResourceItem.CollectableType.Collection);
                    break;
                case 8:
                    foreach (var item in InventoryManager.instance.collectionCells)
                    {
                        if (item.itemType == ResourceBD.ResourceItem.ResourceType.Pot)
                        {
                            item.amount = data.collectionTypeAmounts[i] - 1;
                        }
                    }
                    InventoryManager.instance.SaveResource(ResourceBD.ResourceItem.ResourceType.Pot, ResourceBD.ResourceItem.CollectableType.Collection);
                    break;
            }
        }

    }
}
