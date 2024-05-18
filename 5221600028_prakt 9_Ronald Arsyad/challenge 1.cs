using System;
using System.Threading;

// Interface for spaceship and power-ups
interface ISpaceship {
    void Method();
}

// Basic spaceship implementation
class BasicSpaceship : ISpaceship {
    public void Method() {
        Console.WriteLine("Basic spaceship method");
    }
}

// Abstract decorator class
abstract class SpaceshipDecorator : ISpaceship {
    protected ISpaceship spaceship;

    public SpaceshipDecorator(ISpaceship spaceship) {
        this.spaceship = spaceship;
    }

    public virtual void Method() {
        spaceship.Method();
    }

    public abstract void Activate();
    public abstract void Deactivate();
    public abstract bool IsActive();
}

// Concrete decorator for shield power-up
class ShieldPowerUp : SpaceshipDecorator {
    private bool active;

    public ShieldPowerUp(ISpaceship spaceship) : base(spaceship) {
        active = false;
    }

    public override void Method() {
        if (IsActive()) {
            Console.WriteLine("Shielded spaceship method");
        } else {
            spaceship.Method();
        }
    }

    public override void Activate() {
        active = true;
        // Start timer to deactivate after duration
        Timer timer = new Timer(state => Deactivate(), null, TimeSpan.FromSeconds(10), TimeSpan.Zero);
    }

    public override void Deactivate() {
        active = false;
    }

    public override bool IsActive() {
        return active;
    }
}

// Implementation of other power-ups and challenges would follow a similar pattern
