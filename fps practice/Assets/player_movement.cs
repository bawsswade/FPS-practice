using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {
    private Rigidbody r;
    private Camera cam;
    private GameObject g;

    public float speed;
    public float rotSpeed;
    public float jumpPow;
    void Start()
    {
        r = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
        g = GetComponentInChildren<GameObject>();
        rotSpeed = 200f;
        speed = 200f;
        jumpPow = 10f;
    }

    void FixedUpdate()
    {
        Debug.Log(Time.deltaTime);
        // change to wasd
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float rotX = Input.GetAxis("Mouse X");
        float rotY = Input.GetAxis("Mouse Y");

        Vector3 moveHorizontal = transform.right * x;
        Vector3 moveVertical = transform.forward * y;

        Vector3 movement = (moveHorizontal + moveVertical).normalized;
        r.velocity = movement * speed * Time.deltaTime;
        if (rotX < 0)
        {
            r.transform.Rotate(new Vector3(0, -rotSpeed * Time.deltaTime, 0));
        }
        if (rotX > 0)
        {
            r.transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
        }
        if (rotY > 0)
        {
            cam.transform.Rotate(new Vector3(-rotSpeed * Time.deltaTime *.5f, 0, 0));
        }
        if (rotY < 0)
        {
            cam.transform.Rotate(new Vector3(rotSpeed * Time.deltaTime *.5f, 0, 0));
        }
        if (Input.GetKey(KeyCode.Space))
        {
            
        }
    }

}
