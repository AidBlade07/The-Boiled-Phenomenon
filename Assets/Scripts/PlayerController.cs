using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float jumpForce;
    public float mouseSens;
    public Transform camT;
    Rigidbody rb;
    private LayerMask layerMask;
    public float pickupDistance;
    bool hasPickup;
    public float speedMultiplier = 1f;
    private LayerMask groundLayer;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        layerMask = LayerMask.GetMask("Pickup");
        groundLayer = LayerMask.GetMask("ground");
    }
    


void HandleRaycasting()
{
    RaycastHit hitInfo;

    if(Physics.Raycast(camT.position, camT.forward, out hitInfo, pickupDistance))
    {
        PickupComponent pc = hitInfo.collider.gameObject.GetComponent<PickupComponent>();

        if (pc != null)
        {
            pc.EnableHighlight();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(hasPickup)
                    {
                        pc.Drop();
                        hasPickup = false;
                    }
                    else
                    {
                        pc.Pickup(camT);
                        hasPickup = true;
                    }
                }
        }
    }
}

// Update is called once per frame
void Update()
    {


        HandleRaycasting();

        float speedMulti = 1;

        if (hasPickup)
        {
            PickupComponent pc = camT.GetComponentInChildren<PickupComponent>();
            speedMulti = pc.speedMulti;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Physics.BoxCast(transform.position, new Vector3(0.5f, 0, 0.5f), -Vector3.up, Quaternion.identity, 1f, groundLayer))
            {
                rb.AddForce(Vector3.up * jumpForce);
            }
            
        }
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 movement = hori * camT.right + vert * camT.forward;

        movement = Vector3.Scale(movement, new Vector3(1, 0, 1));

        movement.Normalize();

        transform.position += movement * speed * Time.deltaTime * speedMulti;

        camT.position = transform.position;

        Vector3 rotation = new Vector3(-mouseY * mouseSens, mouseX * mouseSens, 0);

        //Vector3 rotation = rotation.z = 0

        camT.Rotate(rotation);

        camT.eulerAngles = Vector3.Scale(camT.eulerAngles, new Vector3(1, 1, 0));

        transform.eulerAngles = Vector3.Scale(transform.eulerAngles, new Vector3(0, 1, 0));

        rb.linearVelocity = Vector3.Scale(rb.linearVelocity, new Vector3(0.9f, 1, 0.9f));


    }

    private void LateUpdate()
    {
       // HandleRaycasting();
    }
}
