using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    public Inventory Inventory { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Inventory = new Inventory(UseItem); // Khởi tạo inventory duy nhất
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void UseItem(Item item)
    {
        Inventory.RemoveItem(item);
    }
}