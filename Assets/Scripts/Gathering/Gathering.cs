using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Gathering : MonoBehaviour {
    
    public float harvestCooldown = 2f;
    private float actualCooldown;

    private Inventory inventory;
    private Stat harvestSkill;

	void Start () {
        inventory = Inventory.instance;
        harvestSkill = GetComponent<PlayerStats>().harvest;

        actualCooldown = harvestCooldown;
	}

    void Update(){
        actualCooldown -= Time.deltaTime;
    }

    void OnCollisionStay2D(Collision2D other){
        Tilemap tilemap = other.gameObject.GetComponent<Tilemap>();
        HarvestableItem harvestableItem = other.gameObject.GetComponent<HarvestableItem>();

        Vector3 hitPosition = Vector3.zero;

        if(harvestableItem != null && tilemap != null){
            Debug.Log("<color=blue>[GATHERING] Click para cosechar: " + other.collider.name + "</color>");

            if (Input.GetMouseButton(0) && actualCooldown <= 0){
                bool wasObtained = harvestableItem.Harvest( harvestSkill.getValue() );

                if( wasObtained ){
                    inventory.AddItem( harvestableItem.item );

                    foreach (ContactPoint2D hit in other.contacts){
                        hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                        hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                        tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
                    }
                }

                actualCooldown = harvestCooldown;
            }
        }
    }
}
