using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] protected float mainThrust = 1000f;
    [SerializeField] protected float rotateThrust = 1f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateTransform(rotateThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateTransform(-rotateThrust);
        }
    }

    void RotateTransform(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we an manually rotate
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false; // unfreezing rotation so physics take over 
    }
}
