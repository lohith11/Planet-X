using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int dotNumbers;
    [SerializeField] GameObject dotsParent;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] float spacing;

    Transform[] dotsList;

    Vector2 pos;
    float timeStamp;

    private void Start()
    {
        Hide();
        prepareDots();
    }

    void prepareDots()
    {
        dotsList = new Transform[dotNumbers];

        for(int i = 0; i < dotNumbers; i++)
        {
            dotsList[i] = Instantiate(dotPrefab , null).transform;
            dotsList[i].parent = dotsParent.transform;
        }
    }

    public void UpdateDots(Vector3 playerPos , Vector2 forceApplied)
    {
        timeStamp = spacing;
        for(int i = 0; i < dotNumbers; i++)
        {
            pos.x = (playerPos.x + forceApplied.x * timeStamp);
            pos.y = (playerPos.y + forceApplied.y * timeStamp) - (Physics2D.gravity.magnitude * timeStamp * timeStamp) / 2f;

            dotsList[i].position = pos;
            timeStamp += spacing;
        }
    }

    public void Show()
    {
        dotsParent.SetActive(true);
    }

    public void Hide()
    {
        dotsParent.SetActive(false);
    }
}
