using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    // Start is called before the first frame update
    private Rigidbody player;
    public int walkSpeed;
    private bool quit;
    private float controlWalkX, controlWalkZ, mouseHorizontal, mouseVertical ,speedX, speedY;
    public GameObject camera;
    private Vector3 dir;
    void Start()
    {
        player = GetComponent<Rigidbody>();
        player.transform.localEulerAngles = new Vector3(0, -180, 0);


    }

    // Update is called once per frame
    void Update()
    {
        controlWalkX = Input.GetAxis("Horizontal");
        controlWalkZ = Input.GetAxis("Vertical");
        mouseHorizontal = Input.GetAxis("Mouse X");
        mouseVertical = Input.GetAxis("Mouse Y");
        quit = Input.GetKey(KeyCode.Escape);

        
        //Se vc colocar só o valor mouseHorizontal sempre vai voltar para o zero, para evitar isso armazene todo o valor que entrar em outra variavel
        //e assim colocar essa variavel nos vetores
        speedX += mouseHorizontal;
        speedY += mouseVertical;

        speedY = Mathf.Clamp(speedY,-90F,90F);
        
        dir = transform.TransformVector(new Vector3(controlWalkX, 0, -controlWalkZ));
        player.MovePosition(player.position + dir * walkSpeed * Time.deltaTime);
        player.rotation = Quaternion.Euler(0, speedX, 0);
        camera.transform.localEulerAngles = new Vector3(-speedY, 0,0);

        // Também funciona camera.transform.rotation= Quaternion.Euler(0,speedX,0);

        //if (open == true && enter == true) { door.Play(); Debug.Log("funfou"); };
        //if (close == true) { door.Rewind(); }

        if(quit == true) {Application.Quit(); }

    }

}
/*
     Porem existe um metodo melhor é preciso criar um outro doc, armazenar na camera 
    colocar um empty object no corpo e a camera não precisa ficar no corpo e depois é 
    só colocar o empty e o corpo nas variaveis respectivas, esse metodo é o melhor e mais usado
    dando mais controle sobre a camera.
     
    public Transform Head, Body;
    private float mouseHorizontal, mouseVertical, speedX, speedY;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;



    }
    private void LateUpdate()
    {
        transform.position = Head.position;

    }



    // Update is called once per frame
    void Update()
    {
        mouseHorizontal = Input.GetAxisRaw("Mouse X") * 0.5f;
        mouseVertical = Input.GetAxisRaw("Mouse Y") * 0.5f;

        speedX += mouseHorizontal;
        speedY += mouseVertical;

        speedY = Mathf.Clamp(speedY, -90, 90);


        Body.localEulerAngles = new Vector3(0, speedX, 0);

        transform.localEulerAngles = new Vector3(-speedY, speedX, 0);

    }*/
