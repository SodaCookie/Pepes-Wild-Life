using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEvent {
    // Private
    protected GameTime executionTime; //-1 means match any time for that time unit
    protected int executionTimes = 1; //-1 means infinite

    public TimedEvent(GameTime executionTime)
    {
        this.executionTime = executionTime;
    }

    public TimedEvent(GameTime executionTime, int executionTimes)
    {
        this.executionTime = executionTime;
        this.executionTimes = executionTimes;
    }

    public void executeEvent(Game game)
    {
        if (executionTimes > 0)
            executionTimes--;
        performAction(game);
    }

    // Returns true if it's executed all it's times
    public bool isFinished()
    {
        return executionTimes == 0;
    }

    public bool shouldExecute(GameTime curTime)
    {
        // check if it has executions left
        if (executionTimes == 0)
            return false;
        // first check if they are equal, or any time
        bool correctEra = executionTime.era < 0 || executionTime.era == curTime.era;
        bool correctDay = executionTime.day < 0 || executionTime.day == curTime.day;
        bool correctHour = executionTime.hour < 0 || executionTime.hour == curTime.hour;
        bool correctMinute = executionTime.minute < 0 || executionTime.minute == curTime.minute;
        bool correctSecond = executionTime.second < 0 || executionTime.second == curTime.second;

        return correctEra && correctDay && correctHour && correctMinute && correctSecond;
    }

    // Override this to change the behavior of the timed event
    protected virtual void performAction(Game game)
    {
        // Override execution code here
    }
}
