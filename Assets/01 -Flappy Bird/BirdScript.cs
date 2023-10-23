using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

// using System.Numerics;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicManagerScript logic;
    public bool isBirdAlive;
    Vector2 currentPos;
    public float deadZoneTop = -12;
    public float deadZoneBot = -20;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        isBirdAlive = true;
        currentPos = myRigidbody.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Controler logic
        if (Input.GetKeyDown(KeyCode.Space) && isBirdAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
        // Animations
        if (myRigidbody.position != currentPos)
        {
            if (currentPos.y < myRigidbody.position.y)
            {
                SetWingDown(gameObject);
                transform.Rotate(0, 0, -50 * Time.deltaTime);
            }
            else
            {
                SetWingUp(gameObject);
                transform.Rotate(0, 0, 50 * Time.deltaTime);
            }
            currentPos = myRigidbody.position;
        }
    }

    private void SetWingDown(GameObject bird)
    {
        GameObject wingDown = bird.transform.GetChild(0).gameObject;
        GameObject wingUp = bird.transform.GetChild(1).gameObject;
        if (!wingDown.activeInHierarchy)
        {
            wingDown.SetActive(true);
            wingUp.SetActive(false);
        }
    }
    private void SetWingUp(GameObject bird)
    {
        GameObject wingDown = bird.transform.GetChild(0).gameObject;
        GameObject wingUp = bird.transform.GetChild(1).gameObject;
        if (!wingUp.activeInHierarchy)
        {
            wingDown.SetActive(false);
            wingUp.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isBirdAlive = false;
        logic.gameOver();
    }
}
