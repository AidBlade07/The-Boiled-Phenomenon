// using System.Numerics;
// using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class JumpscareController : MonoBehaviour
{
    public static JumpscareController instance {get; private set;}

    public Image scaryFace;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void ShowFace()
    {
        scaryFace.enabled = true;
    }

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(instance);
        }

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (scaryFace.enabled)
        {
            int x = Random.Range(-20, 20);
            int y = Random.Range(-20, 20);
            scaryFace.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
        }
    }
}
