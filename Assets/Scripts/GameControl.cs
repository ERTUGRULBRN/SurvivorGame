using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public UnityEngine.UI.Text pointText;
    public GameObject zombie;
    private float timeCounter;
    private float formationProcess = 10f;
    private int point;
    // Start is called before the first frame update
    void Start()
    {
        timeCounter = formationProcess;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter -= Time.deltaTime;
        if (timeCounter < 0)
        {
            Vector3 pos = new Vector3(Random.Range(215f,335f),25f, Random.Range(329f, 265f));
            Instantiate(zombie, pos, Quaternion.identity);
            timeCounter = formationProcess;
        }
    }
    public void PointUp(int p)
    {
        point += p;
        pointText.text = "" + point;
    }
    public void GameOver()
    {
        PlayerPrefs.SetInt("point", point);
        SceneManager.LoadScene("GameOver");

    }
}
