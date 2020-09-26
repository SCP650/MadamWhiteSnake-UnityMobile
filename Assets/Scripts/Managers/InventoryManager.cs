using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    public string equippedItem { get; private set; }

    private Dictionary<string,int> _item;   //   左边是物品名字，右边是数量 
    private NetworkService _network;

    public void Startup(NetworkService network)
    {
        Debug.Log("Inventory Manager is starting up...");
        _network = network;
        UpdateData(new Dictionary<string, int>());
        status = ManagerStatus.Started;
    }

    public void UpdateData(Dictionary<string,int> items)
    {
        _item = items;
    }

    public Dictionary<string,int> GetData()
    {
        return _item;  // 新的背copy包
    }

    public void DisplayItems()
    {
        string itemDisplay = "Item: ";
        foreach (KeyValuePair<string,int> item in _item) 
        {
            itemDisplay += item.Key +" ("+item.Value+") ";
        }
        Debug.Log(itemDisplay);

    }

    public void AddItems(string newItem)
    {
        if (_item.ContainsKey(newItem))
        {
            _item[newItem] += 1;
        }
        else
        {
            _item[newItem] = 1;   //  从0开始 
        }

        DisplayItems();

    }

    public List<string> GetItemList()
    {
        return new List<string>(_item.Keys);
    }

    public int GetItemCount(string name)
    {
        if (_item.ContainsKey(name))
        {
            return _item[name];
        }
        return 0;

    }
    //That method equips an item if it isn’t already equipped, or unequips if that item is already equipped.
    public bool EquipItem(string name)
    {
        if(_item.ContainsKey(name) && equippedItem != name)
        {
            equippedItem = name;
            Debug.Log("Equipped " + name);
            return true;
        }

        equippedItem = null;
        Debug.Log("Unequipped");
        return false;
    }

    public bool ConsumeItem(string name)
    {
        if (_item.ContainsKey(name))
        {
            _item[name]--;
            if (_item[name] == 0)
            {
                _item.Remove(name);
            }
        }
        else
        {
            Debug.Log("cannot consume " + _item);
            return false;
        }

        DisplayItems();
        return true;
    }

}
