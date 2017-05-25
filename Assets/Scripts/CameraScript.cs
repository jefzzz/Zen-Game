using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class CameraScript : MonoBehaviour {
    public Transform target;
    private Rigidbody targetRigid;
    private Vector3 adjTarget;
    private Vector3 currentVel;
    [Range(10, 100)]
    public float zoom = 10;
    public float smoothTime = 1;
	// Use this for initialization
	void Start () {
        targetRigid = target.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //float x = 5 * (targetRigid.velocity.magnitude / 10) + 10; //fit to range of 10-100 roughly
        //zoom = Mathf.Clamp(x, 10, 100);
        adjTarget = new Vector3(zoom, target.position.y, target.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, adjTarget, ref currentVel, smoothTime);
	}
}
