using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCharacterController : MonoBehaviour {

    //Camera camera;

    public float movementSpeed;
    private float lastPressed;

    float horizontalInput;
    float verticalInput;

    void Start(){
        //camera = Camera.main;
        lastPressed = Time.time;
    }

    // WE WANT TO READ THE INPUT HERE, AND USE IT ON THE FIXED UPDATE
    void Update () {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
	}

    // WE APPLY THE INPUT INTO THE CHARACTER
    private void FixedUpdate() {
        transform.Translate( new Vector3( horizontalInput * Time.fixedDeltaTime * movementSpeed, 0f, 0f ) );
        transform.Translate( new Vector3( 0f, verticalInput * Time.fixedDeltaTime * movementSpeed, 0f) );
    }

    // THIS LET US 
    void OnTriggerStay2D (Collider2D other){
        if ( other.GetComponent<ItemPickup>() != null && lastPressed != Time.time){
            Debug.Log("Usa F para recoger " + other.GetComponent<ItemPickup>().item.name);

            if (Input.GetKeyDown(KeyCode.F)){
                lastPressed = Time.time;
                other.GetComponent<ItemPickup>().PickUp();
            }
        }
    }
}
