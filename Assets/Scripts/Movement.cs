using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //tuning in Editor
    [SerializeField] protected float mainThrust = 1000f;
    [SerializeField] protected float rotateThrust = 1f;
    [SerializeField] protected AudioClip mainEngineAudio;

    [SerializeField] protected ParticleSystem leftThruster;
    [SerializeField] protected ParticleSystem rightThruster;
    [SerializeField] protected ParticleSystem mainThruster;
    
    Rigidbody rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
    
    void StartThrusting()
    {
        //deltatime - to make it frame independent, regardless of fps
        //Add relative force - adds a force relative to its coordinate system
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngineAudio);
        }

        if (!mainThruster.isPlaying)
        {
            mainThruster.Play();
        }
    }
    
    private void StopThrusting()
    {
        audioSource.Stop();
        mainThruster.Stop();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    private void RotateRight()
    {
        RotateTransform(-rotateThrust);
        if (!leftThruster.isPlaying)
        {
            leftThruster.Play();
        }
    }

    private void RotateLeft()
    {
        RotateTransform(rotateThrust);
        if (!rightThruster.isPlaying)
        {
            rightThruster.Play();
        }
    }
    
    private void StopRotating()
    {
        rightThruster.Stop();
        leftThruster.Stop();
    }

    void RotateTransform(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we an manually rotate
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false; // unfreezing rotation so physics take over 
    }


}
