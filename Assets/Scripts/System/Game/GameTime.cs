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

    public GameTime(int era, int day, int hour, int minute, int second)
    {
        this.era = era;
        this.day = day;
        this.hour = hour;
        this.minute = minute;
        this.second = second;
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
        g.hour = g.hour & HOURS_PER_DAY;
        g.era += g.day / DAYS_PER_ERA;
        g.day = g.day % DAYS_PER_ERA;
        return g;
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
