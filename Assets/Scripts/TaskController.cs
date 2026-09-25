using UnityEngine;
using TMPro;
// using System.Threading.Tasks.Dataflow;
// using System.Threading.Tasks.Dataflow;

public class TaskController : MonoBehaviour
{
    // this makes it a singleton so we can access it anywhere

    public static TaskController instance {get; private set;}

    public Task[] tasks; // TODO show all tasks in the UI
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject taskText;
    public float taskOffsetY;

    public void TaskUpdate(string taskTag)
    {
        for(int i = 0; i < tasks.Length; i++)
        {
            if(taskTag == tasks[i].tag)
            {
                tasks[i].currentCount++;
                string text = tasks[i].name + " (" + tasks[i].currentCount + "/" + tasks[i].maxCount + ")";
                transform.GetChild(i).GetComponent<TMP_Text>().text = text;
            }
        }
    }

    void Awake()
    {
        // this makes sure that there is only one task controller instance
        if(instance != null && instance != this)
            Destroy(instance.gameObject);

        instance = this;
    }

    void Start()
    {
        for(int i = 0; i < tasks.Length; i++)
        {
            string text = tasks[i].name + " (" + tasks[i].currentCount + "/" + tasks[i].maxCount + ")";
            GameObject clone = Instantiate(taskText, transform);
            clone.transform.position += new Vector3(0, i * taskOffsetY, 0);
            clone.GetComponent<TMP_Text>().text = text;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
