using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard kb = InputSystem.GetDevice<Keyboard>();

        if(kb.aKey.isPressed)
        {
            transform.position += new Vector3(-1, 0,0) * speed * Time.deltaTime;
            Debug.Log("A key is pressed!");
        }


    }
}
