using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{
    public static Quaternion startPosition;
    public GameObject gameover;
    private void Start()
    {
        startPosition = transform.rotation;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "ground")
        {
            Time.timeScale = 0;
            gameover.SetActive(true);
        }
            

    }
}
