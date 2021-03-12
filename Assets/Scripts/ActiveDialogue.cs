using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDialogue : MonoBehaviour
{
    
    public string[] speechText;
    public string actorName;

    public LayerMask playerLayer;
    public float radious;

    private DialogueControl dc;
    bool onRadius;

    private void Start() {
        dc = FindObjectOfType<DialogueControl>();
    }

    private void FixedUpdate(){
        ShowDialogue();
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.S) && onRadius){
            dc.Speech(speechText, actorName);
        }
    }

    public void ShowDialogue(){
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);
        if(hit != null){
            onRadius = true;
        }else{
            onRadius = false;
        }

    }

    private void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(transform.position, radious);
    }

}
