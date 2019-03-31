using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Animator animCont;
    public float pose;
    public float step;
    public enum gamestate { };
    public gamestate state;
    public SoundControl sc;
    public float death;
    public bool isDying;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InputControl();


        if (isDying)
        {
            ResetPosition();
        }
    }
    private void FixedUpdate()
    {
        
    }

    public void InputControl()
    {
        if (Input.anyKeyDown)
        {
            pose = Random.Range(0f,1f);
            sc.Step();
            Move();
            PoseControl();
            Debug.Log("Beat, Pose: " + pose);
        }
    }

    public void Move()
    {
        Vector3 tempPos = this.transform.position;
        tempPos.z+=step;
        this.transform.position = tempPos;
    }

    public void PoseControl()
    {
        animCont.SetFloat("Pose", pose);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isDying = true;   
    }

    public void ResetPosition()
    {
        isDying = false;
        transform.position = new Vector3(0,0,0);
        if (death == 0)
        {
            death = 1;
        }
        else
        {
            death = 0;
        }
        sc.Death();
    }
}
