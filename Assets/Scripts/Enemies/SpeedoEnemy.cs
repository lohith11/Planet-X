using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedoEnemy : MonoBehaviour
{

    public float speed;
    public float lineofsight;
    public float range;
    public float firerate = 1f;
    private float nestfire;
    public GameObject bullet;
    public GameObject gun;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distancefromplayer = Vector2.Distance(player.position, transform.position);
        if(distancefromplayer < lineofsight && distancefromplayer>range)
        {
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if(distancefromplayer <= range && nestfire <Time.time)
        {
            Instantiate(bullet, gun.transform.position, Quaternion.identity);
            nestfire = Time.time + firerate;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lineofsight);
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
