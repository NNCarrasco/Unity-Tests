using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public PipeScript pipe;
    public float timer = 0;
    public float spawnRate = 2;
    public float offsetHeight = 5; 
    public float offsetSpawnRate = 2;
    private float spawn;
    public LogicManagerScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        spawn = spawnRate;
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Spawn logic
        if (timer < spawn)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            
            timer = 0;
            spawn = Random.Range(spawnRate, offsetSpawnRate/logic.currentLevel);
        }
    }

    void spawnPipe () {
        float lowestpoint = transform.position.y - offsetHeight;
        float highesPoint =  transform.position.y + offsetHeight; 
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestpoint, highesPoint), 0), transform.rotation);
    }

}
