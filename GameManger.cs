using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public bool fire = false;
    public bool fire1 = false;
    public bool fire2 = false;
    public GameObject text; 
    public GameObject text1;
    public AudioClip chow;
    public AudioSource audioSource;
    public bool isDeath = false;
    public bool inTheact = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fire == true && fire1 == true && fire2 == true){
            text.SetActive(true);
        }
        if(isDeath && inTheact){
            inTheact = false;
            audioSource.PlayOneShot(chow);
            StartCoroutine(GameOver("Text", 1));
        }
    }

    public void CallSound(){
        audioSource.PlayOneShot(chow);
    }

    IEnumerator GameOver(string text, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameInprogress", LoadSceneMode.Single);
    }
}
