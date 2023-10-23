using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffLimitScript : MonoBehaviour
{
    public LogicManagerScript logic;
    public BirdScript bird;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider?.gameObject?.layer == 6) {
            bird.isBirdAlive = false;
            logic.gameOver();
        }
    }
}
