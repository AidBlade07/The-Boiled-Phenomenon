using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float jumpForce;
    public float mouseSens;
    public Transform camT;
    Rigidbody rb;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Physics.BoxCast(transform.position, new Vector3(0.5f, 0, 0.5f), -Vector3.up, Quaternion.identity, 1f))
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

        transform.position += movement * speed * Time.deltaTime;

        camT.position = transform.position;

        Vector3 rotation = new Vector3(-mouseY * mouseSens, mouseX * mouseSens, 0);

        //Vector3 rotation = rotation.z = 0

        camT.Rotate(rotation);

        camT.eulerAngles = Vector3.Scale(camT.eulerAngles, new Vector3(1, 1, 0));

        transform.eulerAngles = Vector3.Scale(transform.eulerAngles, new Vector3(0, 1, 0));
    }

    private void LateUpdate()
    {
       // HandleRaycasting();
    }
}
