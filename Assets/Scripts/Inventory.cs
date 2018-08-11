using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<Item> items = new List<Item>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

	public int maximumSlots = 10;

    public static Inventory instance;

    void Awake(){
        instance = this;
    }

    public bool AddItem(Item item){
        if(items.Count < maximumSlots){
            items.Add( item );
            Debug.Log("Agregado: " + item.name);

            if ( onItemChangedCallback != null)
                onItemChangedCallback.Invoke();

            return true;
        }else{
            Debug.Log("No hay espacio para recoger: " + item.name);

            return false;
        }
    }

    public void RemoveItem(Item item){
        items.Remove(item);
        Debug.Log("Removido: " + item.name);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
