using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Light : MonoBehaviour
{
    public GameObject FLASH;
    public int LightLeft = 100;
    public AudioClip otherClip;
    public bool ON = false;
    public AudioSource audio;
    public float waitTime = 1f;
    public float tempTime;
    public TextMeshProUGUI Text;
    public float range = 100f;
    public Camera fpsCam;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();  
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Light"){
            LightLeft = 100;
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(LightLeft > 0){
            if(ON){
                FLASH.SetActive(true);
                Shoot();
                tempTime += Time.deltaTime;
                if (tempTime > waitTime) {
                    tempTime = 0;
                    Battery();
                }
            }else{
                FLASH.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.E)){
                audio.Play();
                if(ON){
                    ON = false;
                    return;
                }
                ON = true;

            }
        }else{
            FLASH.SetActive(false);
        }
    }

    void Shoot(){
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit,range)){
            if(hit.transform.name == "MungDaal"){
                hit.collider.gameObject.GetComponent<Ai>().hitByLight();
            }
        }
    }

    public void Battery()
    {
        LightLeft--;
        Text.text = LightLeft.ToString() + "%";
    }

}
