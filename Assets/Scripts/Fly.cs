using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private Rigidbody rigid;
    public float dragInWater = 0.95f;
    public float dragClimbing = 1;
    public float dragGliding = 2;
    public bool isFlying;
    public bool isGliding;
    [Range(10, 20)]
    public float flyingPower = 15;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
           // Pop();
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Rise();
        }
        else
        {
            rigid.drag = dragGliding;
        }
    }
    void Pop()
    {
       // rigid.velocity = Vector3.zero;
        rigid.AddForce(Vector3.up * Mathf.Abs(rigid.velocity.y /2 ), ForceMode.VelocityChange);
        rigid.drag = dragClimbing;
    }
    void Rise()
    {
        rigid.AddForce(Vector3.up * flyingPower * Time.deltaTime, ForceMode.VelocityChange);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer.Equals(4))
        {
            //print("bird in water");
            float y;
            y = rigid.velocity.y * dragInWater;
            rigid.velocity = new Vector3(rigid.velocity.x, y, rigid.velocity.z);
            rigid.AddForce(Vector3.up * 20, ForceMode.Acceleration);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer.Equals(8))
        {
            print("bird ate fish");
            rigid.AddForce(Vector3.up * 10, ForceMode.VelocityChange);
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, 20);
        }
    }
}
