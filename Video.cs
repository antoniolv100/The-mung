using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : MonoBehaviour
{
    public GameObject Object;
    public GameObject Object2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Player"){
           Object.SetActive(true);
           Object2.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        Object.SetActive(false);
        Object2.SetActive(false);
    }
}
