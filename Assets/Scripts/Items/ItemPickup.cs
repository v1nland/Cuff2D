using UnityEngine;

public class ItemPickup : MonoBehaviour {

	public Item item;

	public void PickUp(){
        Debug.Log("<color=aqua>[ITEM] Recogiendo: " + item.name + "</color>");

        bool wasPicked = Inventory.instance.AddItem(item);

        if (wasPicked)
		    Destroy( gameObject );
	}
}
