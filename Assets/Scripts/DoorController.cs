using UnityEngine;

public class DoorController : MonoBehaviour
{

    private SpriteRenderer eRender;
    public Transform doorT;
    public Transform hingeT;
    public bool doorClosed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eRender = GetComponentInChildren<SpriteRenderer>();
        eRender.enabled = false;
        doorClosed = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            eRender.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            eRender.enabled = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e") && eRender.enabled)
        {
            if (doorClosed)
            {
                doorT.RotateAround(hingeT.position, Vector3.up, 90f);
                doorClosed = false;
            }
            else
            {
                doorT.RotateAround(hingeT.position, Vector3.up, -90f);
                doorClosed = true;
            }
        }
    }
}
