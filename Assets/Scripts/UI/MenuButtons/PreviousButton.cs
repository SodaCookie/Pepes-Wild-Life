﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousButton : MenuButton {
    public Navigatable navigationTarget;

    protected override void perform()
    {
        navigationTarget.displayPrevious();
    }
}
