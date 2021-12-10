using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbEnemy : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float movespeed = 2f;

    int waypointindex = 0;

    void Start()
    {
        transform.position = waypoints[waypointindex].transform.position;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointindex].transform.position, movespeed * Time.deltaTime);

        if(transform.position == waypoints [waypointindex].transform.position)
        {
            waypointindex += 1;
        }
        if(waypointindex == waypoints.Length)
        {
            waypointindex = 0;
        }
    }

}


//[SerializeField]
//private float speed;

//[SerializeField]
//private Vector3[] positions;
//public GameObject Waypoint1;
//public GameObject waypoint2;

//private int index;

//Rigidbody2D rb;

//// Start is called before the first frame update
//void Start()
//{
//    rb = GetComponent<Rigidbody2D>();
//}

//// Update is called once per frame
//void Update()
//{
//    transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);

//    if (transform.position == positions[index])
//    {
//        if (index == positions.Length - 1)
//        {
//            index = 0;
//        }
//        else
//        {
//            index++;
//        }
//    }
//}
