using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldUser : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] bool likeButton;

    [Header("User")]
    //[SerializeField] string username;
    [SerializeField] bool isBlockingYou;

    [Header("User Properties")]
    [SerializeField] float sendTime;
    [SerializeField] float answerTime;
    [SerializeField] int unansweredCount = 3;

    [Header("Chat History")]
    [SerializeField] int memesSent; 
    [SerializeField] int memesLiked;    

    private IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
        CheckForAnswer();
    }
    private void CheckForAnswer()
    {
        Debug.Log("Memes Send: " + memesSent + " | Memes Liked: " + memesLiked);
        if (memesSent > memesLiked) UserSendWarning();
        else UserForgivesPlayer();
    }    
    private void UserForgivesPlayer()
    {
        Debug.Log("You liked all my memes <3");
        unansweredCount = 3;
    }
    private void UserSendWarning()
    {
        unansweredCount -= 1;
        Debug.Log("You Dont Liked My Meme (" + unansweredCount + " Remaining)");

        if (unansweredCount == 0) UserBlocksPlayer();
        else StartCoroutine(WaitTime(answerTime));
    }
    private void UserBlocksPlayer()
    {
        isBlockingYou = true;
        Debug.Log("Im blocking you"); 
    }
    
    void Start()
    {
        CheckForAnswer();
    }

    void Update()
    {
        if (likeButton == true && memesLiked < memesSent)
        {            
            memesLiked++;
            likeButton = false;
        }
    }
}
