using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Ai : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    public GameObject GM;
    public bool walk = true;
    public float waitTime;
    public float tempTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();
        waitTime = 15f;
    }

    public void hitByLight(){
        agent.speed = 0;
    }

    public void Telport(){
        GM.GetComponent<GameManger>().CallSound();
        transform.position = new Vector3(player.transform.position.x - 5, player.transform.position.y, player.transform.position.z -5);
    }

    // Update is called once per frame
    void Update()
    {
        if(walk){
            agent.speed = 5;
        }
        agent.SetDestination(player.transform.position);
        tempTime += Time.deltaTime;
        if (tempTime > waitTime) {
            tempTime = 0;
            waitTime = Random.Range(20f,40f);
            Telport();
        }
        
    }

    private void OnTriggerStay(Collider other) {
        if(!GM.GetComponent<GameManger>().isDeath){
            if(other.gameObject.tag == "Player"){
                GM.GetComponent<GameManger>().isDeath = true;
            }
        }
    }

   
}
