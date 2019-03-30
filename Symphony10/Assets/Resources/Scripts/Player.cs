using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Animator animCont;
    public float pose;
    public float step;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InputControl();
    }
    private void FixedUpdate()
    {
        
    }

    public void InputControl()
    {
        if (Input.anyKeyDown)
        {
            pose = Random.Range(0f,1f);
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
        SceneManager.LoadScene("Main");
    }
}
