using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turner : MonoBehaviour
{
    public BeatMaker master;
    public float maxTurn;
    public float curTurn;
    public float minTurn;
    public float t = 0.0f;
    public float fadeSpeed;
    public float turnNoise;
    public bool canTurn;
    // Start is called before the first frame update
    void Start()
    {
        curTurn = minTurn;
    }

    // Update is called once per frame
    void Update()
    {
        if(master.beat && canTurn)
        {
            canTurn = false;
            t=0;
            curTurn = maxTurn + Random.Range(-turnNoise, turnNoise);
        }
        if (master.beat == false)
        {
            canTurn = true;
        }
        Turn();
    }

    public void Turn()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(curTurn, minTurn, t), transform.position.z);

        // .. and increase the t interpolater
        t += fadeSpeed * Time.deltaTime;

    }
}
