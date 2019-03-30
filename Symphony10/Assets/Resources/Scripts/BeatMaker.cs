using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMaker : MonoBehaviour
{
    public float bpm;
    public float tick = 0;
    public bool beat = false;
    public Bouncer mapEl;
    public int size;
    public bool isGenerating;

    // Start is called before the first frame update
    void Start()
    {
        if (isGenerating)
        {
            for (int i = 0; i <= size; i++)
            {
                Bouncer cube = Instantiate(mapEl);
                Vector3 tempPos = transform.position;
                tempPos.z = i * 2;
                cube.transform.position = tempPos;
                cube.master = this;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        tick += bpm;
        if (tick > 1)
        {
            tick = 0;
            beat = !beat;
        }
    }
}
