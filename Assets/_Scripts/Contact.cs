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
    public string username;
    public Sprite image;    
    public List<Message> chat = new();

}
