using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MenuButton
{
    protected override void perform()
    {
        TestAction act = new TestAction();
        GameTime schedule = new GameTime(-1, -1, -1, -1, -1);
        ScheduleActionInteraction inter = new ScheduleActionInteraction(act, schedule, 5);
        inter.execute();
    }
}