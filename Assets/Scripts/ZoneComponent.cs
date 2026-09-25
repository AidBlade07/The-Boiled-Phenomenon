using UnityEngine;

public class ZoneComponent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == gameObject.tag)
        {
            Destroy(other.gameObject);
            print("Collected " + gameObject.tag);
            TaskController.instance.TaskUpdate(gameObject.tag);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
