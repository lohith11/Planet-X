using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton Class

    public static GameManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    Camera cam;
    public Trajectory trajectory; 
    public Player1 player; 
    [SerializeField] float pushForce = 4f;

    bool isDragging = false;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float Distance;

    private void Start()
    {
        cam = Camera.main;
        player.DeactivateRb();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            onDragStart();
        }

        if (isDragging)
        {
            onDrag();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            onDragEnd();
        }

        
    }

    void onDragStart()
    {
        Time.timeScale = 0.5f;
        player.DeactivateRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    }

    void onDrag()
    {
        Time.timeScale = 1f;
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        Distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * Distance * pushForce;

        Debug.DrawLine(startPoint, endPoint);

        trajectory.UpdateDots(player.position , force);
    }

    void onDragEnd()
    {
        Time.timeScale = 1f;
        player.ActivateRb();
        player.push(force);
        trajectory.Hide();
    }

}
