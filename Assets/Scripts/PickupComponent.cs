using UnityEngine;

public class PickupComponent : MonoBehaviour
{
    private Renderer renderer;
    private Material material;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<Renderer>();
        material = renderer.material;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableHighlight()
    {
        CancelInvoke("DisableHighlight");
        material.EnableKeyword("_EMISSION");
        Invoke("DisableHighlight", 0.01f);    
    }

    public void DisableHighlight()
    {
        material.DisableKeyword("_EMISSION");
    }
}
