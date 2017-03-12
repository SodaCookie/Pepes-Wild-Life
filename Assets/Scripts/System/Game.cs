using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    // Top Level
    public static GameTime END_OF_DAY = new GameTime(-1, -1, 23, 59, 59);

    // Inspector
    [Tooltip("Realtime * timeScale = gameTime")]
    public float timeScale = 5f;

    // Public
    [HideInInspector]
    public House house; // Set on awake by the object itself
    public PepeBehaviour pepe; // Set on awake by the object itself
    public CircleMenu actionMenu; // Set on awake by the object itself

	public const float MAX_SUSPICION = 100f;

    // Private
    // State variables
    private float dayStartTime;
    private int elapsedDays = -1; // When we start the day it will increment to 0
    private GameTime lastTimedEventsExecution = new GameTime();
    private float currentEntertainment = 0;
    private float currentSuspicion = 0;
    private float currentWealth = 1000;
    private bool nightTime = true;

    // list of timed events
    private List<TimedEvent> timedEvents = new List<TimedEvent>();

    public static Game instance()
    {
        return GameObject.Find("GameSystem").GetComponent<Game>();
    }

	// Use this for initialization
	void Start () {
        SetupDayNightCycles();

        //TEST
        //scheduleTimedEvent(new TestTimedEvent(new GameTime(-1, -1, -1, 0, 0), Time.time.ToString() , -1));
        //scheduleTimedEvent(new TestTimedEvent(new GameTime(-1, -1, -1, -1, 0), "MINUTE", -1));

        startNextDay();
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
        while (lastTimedEventsExecution != curTime)
        {
            if (nightTime)
                break;
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

    private void SetupDayNightCycles()
    {
        scheduleTimedEvent(new EndDayTimedEvent(END_OF_DAY));
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
        nightTime = false;
    }

    public void endDay()
    {
        Debug.Log("Day Ended!");
        nightTime = true;
        tallyScore();
        startNextDay();
    }

    private void tallyScore()
    {
        currentWealth += currentEntertainment;
        currentEntertainment = 0;
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
        to_ret.second = curTimeInSeconds % GameTime.SECONDS_PER_MINUTE;
        to_ret.minute = curTimeInSeconds / GameTime.SECONDS_PER_MINUTE;
        to_ret.hour = to_ret.minute / GameTime.MINUTES_PER_HOUR;
        to_ret.minute = to_ret.minute % GameTime.MINUTES_PER_HOUR;
        // Special check so hours dont go above 60 causing infinite loops
        if (to_ret.hour >= GameTime.HOURS_PER_DAY)
        {
            to_ret.hour = 0;
            to_ret.minute = 0;
            to_ret.second = 0;
            to_ret.day += 1;
        }
        return to_ret;
    }

    public float getCurrentSuspicion()
    {
        return currentSuspicion;
    }

    public float getCurrentEntertainment()
    {
        return currentEntertainment;
    }

    public float getCurrentWealth()
    {
        return currentWealth;
    }

    public float realSecondsToGameSeconds(float realSeconds)
    {
        return realSeconds * timeScale;
    }

    public float gameSecondsToRealMusic(float gameSeconds)
    {
        return gameSeconds * timeScale;
    }

    public void addSuspicion(float amount)
    {
        currentSuspicion += amount;
    }

    public void addEntertainment(float amount)
    {
        currentEntertainment += amount;
    }

    public void spendMoney(float amount)
    {
        currentWealth -= amount;
    }
}
