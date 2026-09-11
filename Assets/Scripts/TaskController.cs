using UnityEngine;
using TMPro;
// using System.Threading.Tasks.Dataflow;

public class TaskController : MonoBehaviour
{
    public Task[] tasks; // TODO show all tasks in the UI
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject taskText;
    public float taskOffsetY;

    void Start()
    {
        for(int i = 0; i < tasks.Length; i++)
        {
            string text = tasks[i].name + " (" + tasks[i].currentCount + "/" + tasks[i].maxCount + ")";;
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
