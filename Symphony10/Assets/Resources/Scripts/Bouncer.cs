using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public BeatMaker master;
    public float maxBounce;
    public float curBounce;
    public float minBounce;
    public float t = 0.0f;
    public float fadeSpeed;
    public float bounceNoise;
    public bool canBounce;
    // Start is called before the first frame update
    void Start()
    {
        curBounce = minBounce;
    }

    // Update is called once per frame
    void Update()
    {
        if(master.beat == true && canBounce)
        {
            canBounce = false;
            t=0;
            curBounce = maxBounce + Random.Range(-bounceNoise, bounceNoise);
        }
        if (master.beat == false)
        {
            canBounce = true;
        }
        Bounce();
    }

    public void Bounce()
    {
        transform.localScale = new Vector3(Mathf.Lerp(curBounce, minBounce, t), transform.localScale.y, transform.localScale.z);

        // .. and increase the t interpolater
        t += fadeSpeed * Time.deltaTime;

    }
}
