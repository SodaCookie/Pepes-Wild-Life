using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneButton : MenuButton {
    public GameObject phoneSoundSource;

    private string[] quotes = new string[] {
        "I wonder who that could be...",
        "Who could be calling me at this hour...",
        "Probably some stupid telemarketer!",
        "Eugh... I hate talking to people.",
        "Can't wait for my boss to yell at me again.",
        "DAMMIT JANICE!! I TOLD YOU I'M NOT GOING TO SIGN THE DIVORCE PAPERS SO STOP CALLING!",
        "Stop calling me! We no longer watch wrestling in this household!"
    };

    protected override void perform()
    {
        if (!targetRoom)
            Debug.LogError("Target room not set!");

        var ring = Instantiate(phoneSoundSource); // Doesn't play on creation
        TelephoneAction act = new TelephoneAction(targetRoom, ring);

        // Spawn animation and sound
        if (act.canExecute(Game.instance()))
        {
            GameTime newTime = Game.instance().getCurrentGameTime() + (int)Game.instance().realSecondsToGameSeconds(3);
            Game.instance().scheduleTimedEvent(new ActionTimedEvent(newTime, act));
            ring.transform.position = targetRoom.transform.position;
            ring.GetComponent<AudioSource>().Play();
            GameObject.Destroy(ring, 20); // Let it ring for 20 seconds
            // Create message
            Game.instance().pepe.PostMessage(quotes[Random.Range(0, quotes.Length - 1)], 3);
        } else
        {
            GameObject.Destroy(ring);
        }
    }
}
