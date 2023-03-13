using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool open, exit;
    public Animator door;
    // Start is called before the first frame update
    void Start()
    {
        open = false;
        exit = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (open == true &&  exit == false) { door.SetBool("Open",true); open = false; exit = false; door.SetBool("Close", false); }
        if (exit == true) { door.SetBool("Close",true); exit = false; door.SetBool("Open", false); }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player") { open = true; }
        
    }
    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "Player") { exit = true; }
    }
}
