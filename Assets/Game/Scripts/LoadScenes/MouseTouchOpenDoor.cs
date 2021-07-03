using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseTouchOpenDoor : MonoBehaviour
{

    public GameObject fadeUI;
    public Animator animFade;
    [SerializeField] private Animator animObject;
    public bool isMouseDown;
    public bool isCollider;
    public Player player;
    public Animator animPlayer;
    public GameObject controlsUI;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        animPlayer = player.GetComponent<Animator>();
        controlsUI = GameObject.FindGameObjectWithTag("Controls");
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
    }

    private void OnMouseExit()
    {
        isMouseDown = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCollider = true;   
        }
    }

    private void Update()
    {
        if (isMouseDown && isCollider)
        {
            animObject.SetBool("open", true);
            player.RestartControls(false);
            controlsUI.SetActive(false);
        }
    }
  
}
