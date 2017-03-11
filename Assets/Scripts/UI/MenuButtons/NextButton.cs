using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MenuButton {
    public CircleMenu navigationTarget;

    protected override void perform()
    {
        navigationTarget.displayNext();
    }
}
