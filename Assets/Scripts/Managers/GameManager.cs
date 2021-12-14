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
    public Animator PlayerAnim;
    [SerializeField] float pushForce = 1f;

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
        PlayerAnim.SetBool("Jump", true);
        PlayerAnim.SetBool("Walk", false);
        Time.timeScale = 0.5f;
        player.DeactivateRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    }

    void onDrag()
    {
        Time.timeScale = 0.5f;
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        Distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * Distance * pushForce;

        Debug.DrawLine(startPoint, endPoint);

        trajectory.UpdateDots(player.position , force);
    }

    void onDragEnd()
    {
        PlayerAnim.SetBool("Jump", false);
        PlayerAnim.SetBool("Walk", true);
        Time.timeScale = 1f;
        player.ActivateRb();
        player.push(force);
        trajectory.Hide();
    }

}
