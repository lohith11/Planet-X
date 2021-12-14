using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1st : MonoBehaviour
{
    //movement
    
    public Transform player;

    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float movespeed;
    int waypointindex;

    //shooting
    public float range;
    public float firerate;
    public float nextfire;
    public GameObject bullet;
    public GameObject gun1;
    public GameObject gun2;

    //Low Hp Enemy Spawn
    public float health;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = waypoints[waypointindex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointindex].transform.position, movespeed * Time.deltaTime);

        if (transform.position == waypoints[waypointindex].transform.position)
        {
            waypointindex += 1;
        }
        if (waypointindex == waypoints.Length)
        {
            waypointindex = 0;
        }

        //shooting
        float distancefromplayer = Vector2.Distance(player.position, transform.position);
        if (distancefromplayer <= range &&nextfire<Time.time)
        {
            Instantiate(bullet, gun1.transform.position, Quaternion.identity);
            nextfire = Time.time + firerate;
            Instantiate(bullet, gun2.transform.position, Quaternion.identity);
            nextfire = Time.time + firerate;
        }
        //Speedo Spawn
        if(health<=100)
        {
            enemy1.SetActive(true);
            enemy2.SetActive(true);
            enemy3.SetActive(true);
            enemy4.SetActive(true);
            enemy5.SetActive(true);
            enemy6.SetActive(true);

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
