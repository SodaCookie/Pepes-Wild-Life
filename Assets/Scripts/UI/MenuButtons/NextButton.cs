using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MenuButton {
    public Navigatable navigationTarget;

    protected override void perform()
    {
        navigationTarget.displayNext();
    }
}
