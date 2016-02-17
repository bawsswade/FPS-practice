using UnityEngine;
using System.Collections;

public class player_motor : MonoBehaviour {

    public Camera cam;
    public float camLimit = 85f;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotationX = Vector3.zero;
    private float cameraRot = 0;
    private float currCamRot = 0;
    private Vector3 jump = Vector3.zero;

    private Rigidbody rb;
	
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotation(Vector3 _rotation)
    {
        rotationX = _rotation;
    }

    public void CameraRotation(float _camRotationX)
    {
        cameraRot = _camRotationX;
    }

    public void ApplyJump(Vector3 _jump)
    {
        jump = _jump;
    }

    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
        
        if(jump != Vector3.zero)
        {
            rb.AddForce(jump * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotationX));
        if(cam != null)
        {
            currCamRot -= cameraRot;
            //currCamRot = Mathf.Clamp(currCamRot, -currCamRot, camLimit);

            cam.transform.localEulerAngles = new Vector3(currCamRot, 0f, 0f);
        }
    }
}
