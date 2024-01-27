using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message
{
    public string type;
    public int contentID;
    public Time schedule;
}
public class Contact : MonoBehaviour
{
    
    [SerializeField] List<Message> chat = new();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
