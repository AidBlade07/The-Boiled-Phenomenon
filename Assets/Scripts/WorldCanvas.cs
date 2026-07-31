using UnityEngine;

public class WorldCanvas : MonoBehaviour
{
    public Transform playerT;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    transform.LookAt(playerT);
    }
}
