using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {
    private Rigidbody r;
    private Camera cam;
    private player_motor motor;

    private float speed;
    private float rotSpeed;
    public float jumpPow;

    void Start()
    {
        r = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
        motor = GetComponent<player_motor>();
        speed = 15f;
        rotSpeed = 10f;
        jumpPow = 20000f;
    }


    void Update()
    {
        //MOVEMENT
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 moveHorizontal = transform.right * x;
        Vector3 moveVertical = transform.forward * y;

        Vector3 _velocity = (moveHorizontal + moveVertical).normalized * speed;

        // run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _velocity *= 2f;
        }

        motor.Move(_velocity);

        //ROTATION
        float rotY = Input.GetAxis("Mouse X");
        Vector3 _rotation = new Vector3(0, rotY * rotSpeed, 0f);

        motor.Rotation(_rotation);

        float rotX = Input.GetAxis("Mouse Y");
        float _cameraRotation = rotX * rotSpeed;

        motor.CameraRotation(_cameraRotation);

        // jump
        Vector3 jump = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = Vector3.up * jumpPow;
        }

        motor.ApplyJump(jump);

    }

}
