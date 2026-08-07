using System.Runtime.InteropServices;
using UnityEngine;

public class PickupComponent : MonoBehaviour
{
    private Renderer renderer;
    private Material material;
    Rigidbody rb;
    public float speedMulti = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<Renderer>();
        material = renderer.material;
        rb = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableHighlight()
    {
        CancelInvoke("DisableHighlight");
        material.EnableKeyword("_EMISSION");
        Invoke("DisableHighlight", 0.1f);    
    }

    public void DisableHighlight()
    {
        material.DisableKeyword("_EMISSION");
    }

    public void Pickup(Transform newParent)
    {
        transform.parent = newParent;
        rb.isKinematic = true;
    }

    public void Drop()
    {
        transform.parent = null;
        rb.isKinematic = false;
    }
}
