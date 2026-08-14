using UnityEngine;
using System.Collections;
public class DoorController : MonoBehaviour
{

    private SpriteRenderer eRender;
    public Transform doorT;
    public Transform hingeT;
    public bool doorClosed;
    bool animating;


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

    IEnumerator OpenSesame()
    {
        animating = true;
            if (doorClosed)
            {
                for(int i = 0; i < 90; i++)
                {
                    doorT.RotateAround(hingeT.position, Vector3.up, 1f);
                    yield return null;
                }
                doorClosed = false;
            }
            else
            {
                for (int i = 0; i < 90; i++)
                {
                    doorT.RotateAround(hingeT.position, Vector3.up, -1f);
                yield return null;
                }
                doorClosed = true;
            }
        animating = false;
        yield return null;
    }

    IEnumerator DoorShake()
    {
        
        
        animating = true;
        for (int i = 0; i < 15; i++)
        {
            doorT.RotateAround(hingeT.position, Vector3.up, 1f);
            yield return null;
        }
        for (int i = 0; i< 30; i++)
        {
            doorT.RotateAround(hingeT.position, Vector3.up, -1f);
            yield return null;
        }
        for (int i = 0; i< 15; i++)
        {
            doorT.RotateAround(hingeT.position, Vector3.up, 1f);
            yield return null;
        }
        animating = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e") && eRender.enabled && !animating)
        {
            StartCoroutine(OpenSesame());
        }
        if (Input.GetKeyDown("f") && eRender.enabled && !animating)
        {
            StartCoroutine(DoorShake());
        }
    }
}
