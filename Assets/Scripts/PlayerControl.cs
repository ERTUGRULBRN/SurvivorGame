using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour 
{
    public AudioClip shotVoice, deadVoice, heartVoice, injuryVoice;
    public Transform bulletPos;
    public GameObject bullet;
    public GameObject explosionEffect;
    public Image heapImage;
    public GameControl gameControl;
    private float heapCounter = 10f;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<AudioSource>().PlayOneShot(shotVoice, 1f);
            GameObject game = Instantiate(bullet, bulletPos.position, bulletPos.rotation) as GameObject;
            GameObject gameExplosion = Instantiate(explosionEffect, bulletPos.position, bulletPos.rotation) as GameObject;
            game.GetComponent<Rigidbody>().velocity = bulletPos.transform.forward * 10f; 
            Destroy(game.gameObject, 2f);
            Destroy(gameExplosion.gameObject, 2f);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("zombi"))
        {
            GetComponent<AudioSource>().PlayOneShot(injuryVoice, 1f);
            float x = heapCounter / 100f;
            heapCounter -= 5f;
            heapImage.fillAmount = x;
            heapImage.color = Color.Lerp(Color.red, Color.green, x);
            if (heapCounter <= 0)
            {
                GetComponent<AudioSource>().PlayOneShot(deadVoice, 1f);
                gameControl.GameOver();
            }
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Heart"))
        {
            GetComponent<AudioSource>().PlayOneShot(heartVoice, 1f);
            float x = heapCounter / 100f;
          if (heapCounter < 100f)
            {
                heapCounter += 20f;
                heapImage.fillAmount = x;
                heapImage.color = Color.Lerp(Color.red, Color.green, x);
                Destroy(collider.gameObject);

            }
            
        }
    }
}
