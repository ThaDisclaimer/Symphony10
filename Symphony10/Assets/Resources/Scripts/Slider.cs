using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public BeatMaker master;
    public float maxJump;
    public float curJump;
    public float minJump;
    public float t = 0.0f;
    public float fadeSpeed;
    public float jumpNoise;
    public bool canJump;
    public bool isRepeat;
    // Start is called before the first frame update
    void Start()
    {
        //curJump = minJump;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRepeat)
        {
            if (master.beat)
            {
                canJump = true;
            }
            if (canJump)
            {
                JumpOnce();
            }
        }
        
        
        if(isRepeat && master.beat && canJump)
        {
            canJump = false;
            t=0;
            if (!isRepeat)
            {
                curJump = maxJump + Random.Range(-jumpNoise, jumpNoise);
            }
            Jump();
        }
        if (master.beat == false && isRepeat)
        {
            canJump = true;
            Jump();
        }
    }

    public void Jump()
    {
        transform.position = new Vector3(Mathf.Lerp(curJump, minJump, t), transform.position.y , transform.position.z);

        // .. and increase the t interpolater
        t += fadeSpeed * Time.deltaTime;

    }
    public void JumpOnce()
    {
        transform.position = new Vector3(Mathf.Lerp(maxJump, minJump, t), transform.position.y, transform.position.z);

        // .. and increase the t interpolater
        t += fadeSpeed * Time.deltaTime;

    }
}
