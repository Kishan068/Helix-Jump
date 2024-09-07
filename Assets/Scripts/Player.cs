using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody r;
    bool isForced = false, isScore = false;
    int Score = 0;
    public Text ScoreText;
    public GameObject gameOver, win;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isForced)
        {
            addForce();
        }
        if (isScore)
        {
            increaseScore();
        }
    }

    void addForce()
    {
        isForced = false;
        r.velocity = Vector3.zero;
        r.AddForce(Vector3.up * 200);
    }

    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Play");
    }

    private void OnCollisionEnter(Collision c)
    {
        isForced = true;
        if (c.gameObject.tag == "danger")
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
        if (c.gameObject.tag == "win")
        {
            Time.timeScale = 0;
            win.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider f)
    {
        if (f.gameObject.tag == "score" && isScore == false)
        {
            isScore = true;
        }
        if (f.gameObject.tag == "score")
        {
            GameObject parentObj = f.gameObject.transform.parent.gameObject;
            foreach(Transform child in parentObj.transform)
            {
                if (child.tag != "score")
                {
                    child.GetComponent<MeshCollider>().convex = true;
                    child.gameObject.AddComponent<Rigidbody>();
                }
                Destroy(child.gameObject, 0.7f);
            }
        }
    }
    void increaseScore()
    {
        isScore = false;
        PlayerPrefs.GetInt("Score", 0);
        Score = Score + 1;
        PlayerPrefs.SetInt("Score", Score);
        ScoreText.text = Score.ToString();
    }
}
