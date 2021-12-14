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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
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
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
