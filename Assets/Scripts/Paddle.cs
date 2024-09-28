using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //config params
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float min;
    [SerializeField] float max;
    float avg;
    int count=0;
    bool firstTouched = false;
    bool Allowed = true;
    //cached references
    GameStatus theGameStatus;
    Ball theBall;
    Touch touch;

    private void Start() {
        avg = max - min;
            theGameStatus = FindObjectOfType<GameStatus>();
            theBall = FindObjectOfType<Ball>();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Vector3 paddlePos = new Vector3(transform.position.x, transform.position.y, 1);
            paddlePos.x = Mathf.Clamp(GetXPos(), min, max);
            transform.position = Vector3.MoveTowards(transform.position, paddlePos, 1000);
            firstTouched = true;
        }
        else 
        {
            if(Allowed)
                ShootOrNot();
        }
    }
    private void ShootOrNot() 
    {
        if (firstTouched)
        {
            FindObjectOfType<Ball>().SET();
            count++;
            Allowed = false;
        }
        else
            return;
    }
    private float GetXPos()
    {
        if (theGameStatus.IsAutoPlayEnabled())
            return theBall.transform.position.x;
        else
        {
            Vector3 TouchPos = Camera.main.ScreenToViewportPoint(touch.position);
            TouchPos.z = 1;
            float what = TouchPos.x * avg;
            Debug.Log(what);
            return what;
        }
            
    }
}
