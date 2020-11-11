using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public GameObject text;
    public GameObject FireObj;
    public GameObject FireLight;
    public bool point = false;
    public bool point1 = false;
    public bool point2 = false;
    public GameObject GM;
    public bool isActive = false;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Player" && !isActive){
            text.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F)){
                FireObj.SetActive(true);
                FireLight.SetActive(true);
                audio.Play();
                if(point){
                    GM.GetComponent<GameManger>().fire = true;
                }
                if(point1){
                    GM.GetComponent<GameManger>().fire1 = true;
                }
                if(point2){
                    GM.GetComponent<GameManger>().fire2 = true;
                }   
            }
        }else{
            text.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player"){
            text.SetActive(false);
        }
    }
}
