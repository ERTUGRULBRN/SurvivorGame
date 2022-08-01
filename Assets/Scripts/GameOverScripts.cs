using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScripts : MonoBehaviour
{
    public UnityEngine.UI.Text point;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        point.text = "Point: "+PlayerPrefs.GetInt("point");
        
    }
   void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
    }
    // Update is called once per frame
   public void Replay()
    {

        SceneManager.LoadScene("GAME");

    }
}
