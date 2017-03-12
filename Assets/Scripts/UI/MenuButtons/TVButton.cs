using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVButton : MenuButton {
    private string[] quotes = new string[] {
        "Is that the tv?",
        "?",
        "Eugh I hate seinfeld!",
        "What's that racket!?!?",
        "Polarbear in a snowstorm... my favorite...",
        "*sigh* not again...",
        "I should really take the tv in for repair."
    };

    protected override void perform()
    {
        if (!targetRoom)
            Debug.LogError("Target room not set!");

        TVBehavior tv = GameObject.Find("TV").GetComponent<TVBehavior>();
        TVAction act = new TVAction(targetRoom, tv);
        act.execute(Game.instance());
        Game.instance().pepe.PostMessage(quotes[Random.Range(0, quotes.Length - 1)], 3);
    }
}
