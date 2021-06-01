using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] public SpeechsDialogue speechsActors;
    [SerializeField] private bool isCollisionPlayer;
    [SerializeField] private bool isActiveDirect;
    [SerializeField] private bool isActiveDialogue;


    private void Start()
    {
        isActiveDialogue = false;
    }

    private void Update()
    {
        if (isActiveDirect)
        {
            DirectTriggerActivate();
        }
        else
        {
            IndirectTriggerActivate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCollisionPlayer = true;
        }
        else
        {
            isCollisionPlayer = false;
        }
    }

    public void DirectTriggerActivate() //Ativar direto
    {
        if (isCollisionPlayer && !isActiveDialogue)
        {
            ShowDialogue();
        }
    }

    public void IndirectTriggerActivate() //Ativar tando dentro do trigger e acionando uma tecla/bot�o na tela
    {

        if (isCollisionPlayer && Input.GetKeyDown(KeyCode.S) && !isActiveDialogue)
        {
            ShowDialogue();
        }

    }


    public void ShowDialogue()
    {
        Speech[] speechsDialogue = speechsActors.speechsDialogueObjects;
        DialogueControl.instance.GetDataDialogues(speechsDialogue);
        isActiveDialogue = true;
        Debug.Log("Entrou");
    }

    

}
