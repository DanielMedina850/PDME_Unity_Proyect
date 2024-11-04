using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    private AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
        if(!GameManager.instance.playerIsDeath){
            aS.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
