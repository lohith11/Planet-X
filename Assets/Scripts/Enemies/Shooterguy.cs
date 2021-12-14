using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooterguy : MonoBehaviour
{
    //movement
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float movespeed = 2f;
    int waypointindex = 0;

    //shooting
    public float range;
    public float firerate = 1f;
    private float nextfire;
    public GameObject bullet;
    public GameObject gun;
    private Transform player;

    void Start()
    {
        //movement
        transform.position = waypoints[waypointindex].transform.position;
        //shooting
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {

            float distancefromplayer = Vector2.Distance(player.position, transform.position);
        if(distancefromplayer>range)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointindex].transform.position, movespeed * Time.deltaTime);

            if (transform.position == waypoints[waypointindex].transform.position)
            {
                waypointindex += 1;
            }
            if (waypointindex == waypoints.Length)
            {
                waypointindex = 0;
            }
        }
        else if(distancefromplayer <= range && nextfire <Time.time)
        {
            Instantiate(bullet, gun.transform.position, Quaternion.identity);
            nextfire = Time.time + firerate;
        }


       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
//[SerializeField]
//Transform[] waypoints;

//[SerializeField]
//float movespeed = 2f;
//int waypointindex = 0;

//public float speed;
//public float range;
//public float firerate = 1f;
//private float nextfire;
//public GameObject bullet;
//public GameObject gun;
//private Transform player;
//// Start is called before the first frame update
//void Start()
//{
//    transform.position = waypoints[waypointindex].transform.position;
//    player = GameObject.FindGameObjectWithTag("Player").transform;
//}

//// Update is called once per frame
//void Update()
//{
//    float distancefromplayer = Vector2.Distance(player.position, transform.position);
//    if (distancefromplayer > range)
//    {
//        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointindex].transform.position, movespeed * Time.deltaTime);
//        if (transform.position == waypoints[waypointindex].transform.position)
//        {
//            waypointindex = 1;
//        }
//        if (waypointindex == waypoints.Length)
//        {
//            waypointindex = 0;
//        }
//    }
//    else if (distancefromplayer <= range && nextfire < Time.time)
//    {
//        Instantiate(bullet, gun.transform.position, Quaternion.identity);
//        nextfire = Time.time + firerate;
//    }
//}
//private void OnDrawGizmosSelected()
//{
//    Gizmos.color = Color.blue;
//    Gizmos.DrawWireSphere(transform.position, range);
//}