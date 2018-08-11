using UnityEngine;

public class ItemPickup : MonoBehaviour {

	public Item item;

	public void PickUp(){
        Debug.Log("Recogiendo: " + item.name);

        bool wasPicked = Inventory.instance.AddItem(item);

        if (wasPicked)
		    Destroy( gameObject );
	}
}
