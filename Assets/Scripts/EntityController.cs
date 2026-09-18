using UnityEngine;

public class EntityController : MonoBehaviour
{

    private float lookTime = 0f;
    public float timeLimit = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = Camera.main.transform.position;

        Vector3 destination = transform.position;

        Vector3 direction = destination - origin;
        if(Physics.Raycast(origin, direction, out RaycastHit hitInfo, Mathf.Infinity, Physics.DefaultRaycastLayers))
        {
            if(hitInfo.collider.gameObject.name == gameObject.name)
            {                
                lookTime += Time.deltaTime;
                if(lookTime >= timeLimit)
                {
                    print("Jump scare");
                }
            }
            else
            {
                lookTime = 0f;
            }
        }
        else
        {
            lookTime = 0f;
        }
    }
}
