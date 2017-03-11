using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    // Inspector
    [Tooltip("Realtime * timeScale = gameTime")]
    public float timeScale = 5f;

    // Public
    [HideInInspector]
    public House house;

    // Private
    // State variables
    private float dayStartTime;
    private int elapsedDays;
    private GameTime lastTimedEventsExecution;

    // list of timed events
    private List<TimedEvent> timedEvents = new List<TimedEvent>();

	// Use this for initialization
	void Start () {
        lastTimedEventsExecution = new GameTime();

        // TEST
        GameTime sched = new GameTime(-1, -1, -1, -1, -1);
        TimedEvent test = new TimedEvent(sched, -1);
        scheduleTimedEvent(test);
        // TEST
	}
	
	// Update is called once per frame
	void Update () {
        HandleTimedEvents();
	}

    // Calls timed events that need to called
    void HandleTimedEvents()
    {
        GameTime curTime = getCurrentGameTime();
        List<TimedEvent> toRemove = new List<TimedEvent>();

        //Simulate each second between last update and now
        while(lastTimedEventsExecution != curTime)
        {
            lastTimedEventsExecution++;
            // Call and execute each event, check if it should be removed
            foreach (TimedEvent te in timedEvents)
            {
                if (te.shouldExecute(lastTimedEventsExecution))
                    te.executeEvent(this);
                if (te.isFinished())
                    toRemove.Add(te);
            }
        }

        // Remove events that are done
        foreach (TimedEvent te in toRemove)
            timedEvents.Remove(te);
    }

    public void scheduleTimedEvent(TimedEvent te)
    {
        timedEvents.Add(te);
    }

    // Code to handle starting the next day
    public void startNextDay()
    {
        elapsedDays++;
        dayStartTime = Time.time;
    }

    // Get elapsed time in the day in real time
    public float getElapsedRealTimeForToday()
    {
        return Time.time - dayStartTime;
    }

    // Get elapsed time in the day scaled to game time
    public float getElapsedGameTimeForToday()
    {
        return timeScale * getElapsedRealTimeForToday();
    }

    // Get current time values for the state of the game
    public GameTime getCurrentGameTime()
    {
        int curTimeInSeconds = Mathf.FloorToInt(getElapsedGameTimeForToday());
        GameTime to_ret = new GameTime();
        to_ret.era = elapsedDays / GameTime.DAYS_PER_ERA;
        to_ret.day = (elapsedDays % GameTime.DAYS_PER_ERA);
        to_ret.minute = curTimeInSeconds / GameTime.SECONDS_PER_MINUTE;
        to_ret.second = curTimeInSeconds % GameTime.SECONDS_PER_MINUTE;
        return to_ret;
    }

    public float realSecondsToGameSeconds(float realSeconds)
    {
        return realSeconds * timeScale;
    }

    public float gameSecondsToRealMusic(float gameSeconds)
    {
        return gameSeconds * timeScale;
    }
}
