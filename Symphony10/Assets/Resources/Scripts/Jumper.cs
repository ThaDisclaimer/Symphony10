using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public BeatMaker master;
    public float maxJump;
    public float curJump;
    public float minJump;
    public float t = 0.0f;
    public float fadeSpeed;
    public float jumpNoise;
    public bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        curJump = minJump;
    }

    // Update is called once per frame
    void Update()
    {
        if(master.beat && canJump)
        {
            canJump = false;
            t=0;
            curJump = maxJump + Random.Range(-jumpNoise, jumpNoise);
        }
        if (master.beat == false)
        {
            canJump = true;
        }
        Jump();
    }

    public void Jump()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(curJump, minJump, t), transform.position.z);

        // .. and increase the t interpolater
        t += fadeSpeed * Time.deltaTime;

    }
}
