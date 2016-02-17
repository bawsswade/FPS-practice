using UnityEngine;
using UnityEngine.Networking;

public class playerShoot : NetworkBehaviour {

    public playerWeapon weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;
	// Use this for initialization
	void Start ()
    {
	    if(cam ==null)
        {
            Debug.LogError("no cam referenced");
            this.enabled = false;
        }
	}

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    
    // use raycast
    void Shoot()
    {
        RaycastHit _hit;

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
        {
            // hit something
            Debug.Log("we hit " + _hit.collider.name);

        }
    }
}
