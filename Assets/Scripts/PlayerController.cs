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
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 movement = hori * camT.right + vert * camT.forward;

        movement.Normalize();

        transform.position += movement * speed * Time.deltaTime;

        camT.position = transform.position;

        Vector3 rotation = new Vector3(mouseY * mouseSens, mouseX * mouseSens, 0);

        //Vector3 rotation = rotation.z = 0

        camT.Rotate(rotation);
    }
}
