using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "Scriptable Objects/Task")]
public class Task : ScriptableObject
{
    public string name;
    public string[] descriptions;
    public string tag;
    public int maxCount;
    public int currentCount;
}
