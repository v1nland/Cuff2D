using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCharacterController : MonoBehaviour {

    public float movementSpeed;

    float horizontalInput;
    float verticalInput;
	
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
}
