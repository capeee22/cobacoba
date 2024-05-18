//IMPLEMENTASI CONTOH PROGRAM PADA C#
using System;
using System.Collections.Generic;

// AlarmListener interface
public interface IAlarmListener
{
    void Alarm();
}

// SensorSystem
public class SensorSystem
{
    private List<IAlarmListener> _listeners = new List<IAlarmListener>();

    public void Attach(IAlarmListener listener)
    {
        _listeners.Add(listener);
    }

    public void SoundTheAlarm()
    {
        foreach (var listener in _listeners)
        {
            listener.Alarm();
        }
    }
}

// Lighting
public class Lighting : IAlarmListener
{
    public void Alarm()
    {
        Console.WriteLine("lights up");
    }
}

// Gates
public class Gates : IAlarmListener
{
    public void Alarm()
    {
        Console.WriteLine("gates close");
    }
}

// CheckList
public abstract class CheckList
{
    protected virtual void Localize()
    {
        Console.WriteLine("   establish a perimeter");
    }

    protected virtual void Isolate()
    {
        Console.WriteLine("   isolate the grid");
    }

    protected virtual void Identify()
    {
        Console.WriteLine("   identify the source");
    }

    public void ByTheNumbers()
    {
        Localize();
        Isolate();
        Identify();
    }
}

// Surveillance
public class Surveillance : CheckList, IAlarmListener
{
    protected override void Isolate()
    {
        Console.WriteLine("   train the cameras");
    }

    public void Alarm()
    {
        Console.WriteLine("Surveillance - by the numbers:");
        ByTheNumbers();
    }
}

class Program
{
    static void Main(string[] args)
    {
        SensorSystem ss = new SensorSystem();
        ss.Attach(new Gates());
        ss.Attach(new Lighting());
        ss.Attach(new Surveillance());
        ss.SoundTheAlarm();
    }
}
