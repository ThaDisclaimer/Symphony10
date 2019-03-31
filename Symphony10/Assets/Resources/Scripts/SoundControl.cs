using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public Player master;
    [FMODUnity.EventRef]
    public string PlayerStateEvent;

    public FMOD.Studio.EventInstance playerState;
    FMOD.Studio.EventInstance btn;
    FMOD.Studio.EventInstance start;
    FMOD.Studio.EventInstance popup;

    [FMODUnity.EventRef]
    public string ButtonPress;
    [FMODUnity.EventRef]
    public string StartGame;
    [FMODUnity.EventRef]
    public string Music;
    [FMODUnity.EventRef]
    public string PopUp;
    public FMOD.Studio.Bus masterBus;

    public static SoundControl musicInstance = null;

    // Start is called before the first frame update
    void Start()
    {
        masterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
        playerState = FMODUnity.RuntimeManager.CreateInstance(Music);
        playerState.start();
        btn = FMODUnity.RuntimeManager.CreateInstance(ButtonPress);
    }

    // Update is called once per frame
    void Update()
    {
        Progress();
    }

    public void Progress()
    {
        playerState.setParameterValue("Progress", (float)(master.transform.position.z) / 10);
    }
    public void Death()
    {
        if(master.death==1)
            playerState.setParameterValue("Death", (float)1f);
        if (master.death == 0)
            playerState.setParameterValue("Death", (float)0f);
    }

    public void Step()
    {
        btn.start();
    }

    public void BtnPressed()
    {
        btn.start();
    }

    public void StrConfirm()
    {
        start.start();
    }

    public void PopUpper()
    {
        popup.start();
    }

}
