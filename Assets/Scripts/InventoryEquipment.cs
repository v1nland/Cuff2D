using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEquipment : MonoBehaviour {

    // INSTANCE REGION START

    public static InventoryEquipment instance;

    private void Awake(){
        instance = this;
    }

    // END OF INSTANCE REGION //

    public GameObject[] equipmentPositions;

    Equipment[] currentEquipment;

    Inventory inventory;

    private void Start(){
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames( typeof(EquipmentSlot)).Length;

        //equipmentPositions = new GameObject[numSlots];
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newEquipment){
        int slotIndex = (int)newEquipment.equipSlot;

        Equipment oldEquipment;

        if( currentEquipment[slotIndex] != null ){
            oldEquipment = currentEquipment[slotIndex];
            inventory.AddItem(oldEquipment);
        }

        equipmentPositions[slotIndex].GetComponent<SpriteRenderer>().sprite = newEquipment.equipSprite;
        currentEquipment[slotIndex] = newEquipment;

        Debug.Log("Equipando: " + newEquipment.name);
    }

    public void Unequip(int slotIndex){
        if(currentEquipment[slotIndex] != null){
            Equipment oldEquipment = currentEquipment[slotIndex];

            inventory.AddItem(oldEquipment);

            equipmentPositions[slotIndex].GetComponent<SpriteRenderer>().sprite = null;
            currentEquipment[slotIndex] = null;

            Debug.Log("Desequipando: " + oldEquipment.name);
        }
    }

    public void UnequipAllItems(){
        for (int i = 0; i < currentEquipment.Length; i++){
            Unequip(i);
        }
    }

    private void Update(){
        if(Input.GetKey(KeyCode.U)){
            UnequipAllItems();
        }
    }
}
