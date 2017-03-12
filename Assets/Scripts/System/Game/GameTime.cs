using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime {
    public static int DAYS_PER_ERA = 7;
    public static int HOURS_PER_DAY = 24;
    public static int MINUTES_PER_HOUR = 60;
    public static int SECONDS_PER_MINUTE = 60;

    public int era;
    public int day;
    public int hour;
    public int minute;
    public int second;

    public GameTime() { }

    public GameTime(GameTime copy)
    {
        this.era = copy.era;
        this.day = copy.day;
        this.hour = copy.hour;
        this.minute = copy.minute;
        this.second = copy.second;
    }

    public GameTime(int era, int day, int hour, int minute, int second)
    {
        this.era = era;
        this.day = day;
        this.hour = hour;
        this.minute = minute;
        this.second = second;
    }

    public void addSeconds(int seconds)
    {
        second += seconds;
        minute += second / SECONDS_PER_MINUTE;
        second = second % SECONDS_PER_MINUTE;
        hour += minute / MINUTES_PER_HOUR;
        minute = minute % MINUTES_PER_HOUR;
        day += hour / HOURS_PER_DAY;
        hour = hour & HOURS_PER_DAY;
        era += day / DAYS_PER_ERA;
        day = day % DAYS_PER_ERA;
    }

    public void addMinutes(int minutes)
    {
        int seconds = minutes * SECONDS_PER_MINUTE;
        addSeconds(seconds);
    }

    public void addHours(int hours)
    {
        int minutes = hours * MINUTES_PER_HOUR;
        addMinutes(minutes);
    }

    public void addDays(int days)
    {
        int hours = days * HOURS_PER_DAY;
        addHours(hours);
    }


    // Operator overrides
    public static bool operator ==(GameTime g1, GameTime g2)
    {
        return (g1.era == g2.era && g1.day == g2.day && g1.hour == g2.hour && g1.minute == g2.minute && g1.second == g2.second);
    }

    public static bool operator !=(GameTime g1, GameTime g2)
    {
        return !(g1 == g2);
    }

    public static bool operator >(GameTime g1, GameTime g2)
    {
        if (g1.era != g2.era)
            return g1.era > g2.era;
        if (g1.day != g2.day)
            return g1.day > g2.day;
        if (g1.hour != g2.hour)
            return g1.hour > g2.hour;
        if (g1.minute != g2.minute)
            return g1.minute > g2.minute;
        return g1.second > g2.second;
    }

    public static bool operator <(GameTime g1, GameTime g2)
    {
        return (!(g1 > g2) && g1 != g2);
    }

    public static bool operator <=(GameTime g1, GameTime g2)
    {
        return !(g1 > g2);
    }

    public static bool operator >=(GameTime g1, GameTime g2)
    {
        return !(g1 < g2);
    }

    public static GameTime operator ++(GameTime g)
    {
        g.second++;
        g.minute += g.second / SECONDS_PER_MINUTE;
        g.second = g.second % SECONDS_PER_MINUTE;
        g.hour += g.minute / MINUTES_PER_HOUR;
        g.minute = g.minute % MINUTES_PER_HOUR;
        g.day += g.hour / HOURS_PER_DAY;
        g.hour = g.hour % HOURS_PER_DAY;
        g.era += g.day / DAYS_PER_ERA;
        g.day = g.day % DAYS_PER_ERA;
        return g;
    }

    public static GameTime operator +(GameTime g, int seconds)
    {
        GameTime g_new = new GameTime(g);
        g_new.second+= seconds;
        g_new.minute += g_new.second / SECONDS_PER_MINUTE;
        g_new.second = g_new.second % SECONDS_PER_MINUTE;
        g_new.hour += g_new.minute / MINUTES_PER_HOUR;
        g_new.minute = g_new.minute % MINUTES_PER_HOUR;
        g_new.day += g_new.hour / HOURS_PER_DAY;
        g_new.hour = g_new.hour & HOURS_PER_DAY;
        g_new.era += g_new.day / DAYS_PER_ERA;
        g_new.day = g_new.day % DAYS_PER_ERA;
        return g_new;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
