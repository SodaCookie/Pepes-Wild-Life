using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleActionInteraction : Interaction {
    Action action;
    GameTime schedule;
    int repeat;

    public ScheduleActionInteraction(Action action, GameTime schedule) : base()
    {
        this.action = action;
        this.schedule = schedule;
        this.repeat = 1;
    }

    public ScheduleActionInteraction(Action action, GameTime schedule, int repeat) : base()
    {
        this.action = action;
        this.schedule = schedule;
        this.repeat = repeat;
    }

    protected override void performInteraction(Game game)
    {
        ActionTimedEvent te = new ActionTimedEvent(schedule, action, repeat);
        game.scheduleTimedEvent(te);
    }
}
