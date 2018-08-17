using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    private Vector3 targetPosition;

    void Update () {
        targetPosition = new Vector3(target.position.x, target.position.y, -15f);

        transform.position = Vector3.Lerp( transform.position, targetPosition, 0.05f );
	}
}
