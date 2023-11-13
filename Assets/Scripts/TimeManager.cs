using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    float timer = 0;
    float MaxTime = 100f;

    bool isStart = false;

    void Start()
    {
        isStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.touchCount > 0)
        {
            timer = 0;
        }
        if (isStart && timer > MaxTime)
        {
            isStart = false;
            timer = 0;
            SceneManager.LoadScene("Title");
        }
    }

}
