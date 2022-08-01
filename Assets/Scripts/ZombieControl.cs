using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieControl : MonoBehaviour
{
    public GameObject heart; 
    private GameObject player;
    private int zombieHeap = 3;
    private int zombieDeadPoint = 10;
    private float distance;
    private GameControl gameControl;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("FPSController");
        gameControl = GameObject.Find("Scripts").GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 10f)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
            GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
        }else
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("Bullet"))
        {
            zombieHeap--;
            if (zombieHeap == 0)
            {
                gameControl.PointUp(zombieDeadPoint);
                Instantiate(heart, transform.position, Quaternion.identity);
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject, 1.667f);
            }
        }
    }
}
