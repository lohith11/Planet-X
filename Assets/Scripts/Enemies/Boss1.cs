using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public float speed;
    public float range;
    public float firerate = 20f;
    public float nextfire;
    public GameObject bullet;
    public GameObject gun;
    public GameObject speedo;
    public Transform player;
    public float bhealth = 1000f;

    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float movespeed = 4f;
    int waypointindex;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = waypoints[waypointindex].transform.position;
        if (bhealth <= 50f)
        {
            for (int i = 0; i >= 5; i++)
            {
                var position = new Vector3(Random.Range(67, 10), 0, Random.Range(47, 10.0f));
                Instantiate(speedo, position, Quaternion.identity);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distancefromplayer = Vector2.Distance(player.position, transform.position);
        //shooting
        if (distancefromplayer <= range && nextfire < Time.time)
        {
            Instantiate(bullet, gun.transform.position, Quaternion.identity);
            nextfire = Time.time + firerate;
        }
        
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

        
        if (bhealth <= 50)
        {
            for (int i = 0; i <= 5; i++)
            {
                var position = new Vector3(Random.Range(67, 10), 0, Random.Range(47, 10.0f));
                Instantiate(speedo, position, Quaternion.identity);

            } 
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
