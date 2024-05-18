//implementasi contoh program pada c#
using System;
using System.Collections.Generic;

public class Subject
{
    private List<Observer> views = new List<Observer>();
    private int value;

    public void Attach(Observer obs)
    {
        views.Add(obs);
    }

    public void SetVal(int val)
    {
        value = val;
        Notify();
    }

    public int GetVal()
    {
        return value;
    }

    private void Notify()
    {
        foreach (var view in views)
        {
            view.Update();
        }
    }
}

public abstract class Observer
{
    protected Subject model;
    protected int denom;

    public Observer(Subject mod, int div)
    {
        model = mod;
        denom = div;
        model.Attach(this);
    }

    public abstract void Update();

    protected Subject GetSubject()
    {
        return model;
    }

    protected int GetDivisor()
    {
        return denom;
    }
}

public class DivObserver : Observer
{
    public DivObserver(Subject mod, int div) : base(mod, div) { }

    public override void Update()
    {
        int v = GetSubject().GetVal();
        int d = GetDivisor();
        Console.WriteLine($"{v} div {d} is {v / d}");
    }
}

public class ModObserver : Observer
{
    public ModObserver(Subject mod, int div) : base(mod, div) { }

    public override void Update()
    {
        int v = GetSubject().GetVal();
        int d = GetDivisor();
        Console.WriteLine($"{v} mod {d} is {v % d}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Subject subj = new Subject();
        DivObserver divObs1 = new DivObserver(subj, 4);
        DivObserver divObs2 = new DivObserver(subj, 3);
        ModObserver modObs3 = new ModObserver(subj, 3);
        subj.SetVal(14);
    }
}
