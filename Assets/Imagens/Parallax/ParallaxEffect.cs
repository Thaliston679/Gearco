using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    /*
    //Movimentação Parallax Horizontal e Vertical(Travandod mas funcionando)
    
    public Transform cam;
    public Transform[] layersParallax;
    public float[] mult;
    private Vector3[] startPos;

    private void Awake()
    {
        startPos = new Vector3[layersParallax.Length];

        for (int i = 0; i < layersParallax.Length; i++)
        {
            startPos[i] = layersParallax[i].position;
        }
    }

    private void Update()
    {
        for (int i = 0; i < layersParallax.Length; i++)
        {
            layersParallax[i].position = startPos[i] + mult[i] * (new Vector3(cam.position.x, cam.position.y, layersParallax[i].position.z));
        }
    }
    */



    /*
    //Movimentação Parallax Horizontal somente
    
    private float lenght, startpos;
    public GameObject cam;
    public float parallaxEffect;

    void //Start()
    {
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void //FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + lenght)
        {
            startpos += lenght;
        }
        else if (temp < startpos - lenght)
        {
            startpos -= lenght;
        }
    }
    */


    /*
    //Modo simples

    public GameObject cam;
    public float moveX;
    public float moveY;
    public float distYcamCenter;
    private float length;
    private float startPos;

    private void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startPos = transform.position.x;

    }

    //Quanto mais longe maior o X e menor o Y

    private void FixedUpdate()
    {
        float posX = cam.transform.position.x * moveX;
        float posY = cam.transform.position.y * moveY;
        float restartPosition = cam.transform.position.x * (1 - moveX);

        transform.position = new Vector3(startPos + posX, posY + distYcamCenter, transform.position.z);

        if(restartPosition > startPos + length)
        {
            startPos += length;
        }
        else if(restartPosition < startPos - length)
        {
            startPos -= length;
        }
    }

    //Falta criar parte do script q clone as partes passadas do parallax

    //p - moveX moveY distYcam
    //0 - 0.1 0.2 -3
    //1 - 0.2 0.4 -2
    //2 - 0.3 0.5 -1
    //3 - 0.5 0.7 1
    //4 - 0.7 0.8 3
    */

    //Tentativa mesclada

    private Transform cam;
    public float moveY;
    public float distYcamCenter;
    private float length;
    private float startPos;
    public float parallaxEffect;

    private void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startPos = transform.position.x;
        cam = Camera.main.transform;
    }

    //Quanto mais longe maior o X e menor o Y

    private void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        float posY = cam.transform.position.y * moveY;

        transform.position = new Vector3(startPos + distance, posY + distYcamCenter, transform.position.z);
        
        //float posX = cam.transform.position.x * moveX;
        
        float restartPosition = cam.transform.position.x * (1 - parallaxEffect);
        /*
        transform.position = new Vector3(startPos + posX, posY + distYcamCenter, transform.position.z);
        */
        if (restartPosition > startPos + length)
        {
            startPos += length;
        }
        else if (restartPosition < startPos - length)
        {
            startPos -= length;
        }
        
    }

    //Falta criar parte do script q clone as partes passadas do parallax

    //p - moveX moveY distYcam transform.position.y
    //0 - 0.1 0.2 -3    -4.956
    //1 - 0.2 0.4 -2    -3.912
    //2 - 0.3 0.5 -1    -2.89
    //3 - 0.5 0.7 1     -0.846
    //4 - 0.7 0.8 3     1.198


}
