using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementSpeed;
    public Animator animator;

    float horizontalInput;
    float verticalInput;

    // WE WANT TO READ THE INPUT HERE, AND USE IT ON THE FIXED UPDATE
    void Update() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    // WE APPLY THE INPUT INTO THE CHARACTER
    private void FixedUpdate() {
        float horizontalSpeed = horizontalInput * Time.fixedDeltaTime * movementSpeed;
        float verticalSpeed = verticalInput * Time.fixedDeltaTime * movementSpeed;

        transform.Translate(new Vector3(horizontalSpeed, 0f, 0f));
        transform.Translate(new Vector3(0f, verticalSpeed, 0f));

        animator.SetFloat("horizontalSpeed", horizontalSpeed*100);
        animator.SetFloat("verticalSpeed", verticalSpeed*100);
    }
}