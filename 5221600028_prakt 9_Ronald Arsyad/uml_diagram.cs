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
}

// Concrete decorator for shield power-up
class ShieldPowerUp : SpaceshipDecorator {
    public ShieldPowerUp(ISpaceship spaceship) : base(spaceship) {}

    public override void Method() {
        base.Method();
        Console.WriteLine("Shield power-up method");
    }
}

// Concrete decorator for laser power-up
class LaserPowerUp : SpaceshipDecorator {
    public LaserPowerUp(ISpaceship spaceship) : base(spaceship) {}

    public override void Method() {
        base.Method();
        Console.WriteLine("Laser power-up method");
    }
}

// Concrete decorator for speed boost power-up
class SpeedBoostPowerUp : SpaceshipDecorator {
    public SpeedBoostPowerUp(ISpaceship spaceship) : base(spaceship) {}

    public override void Method() {
        base.Method();
        Console.WriteLine("Speed boost power-up method");
    }
}

// Concrete decorator for triple shot power-up
class TripleShotDecorator : SpaceshipDecorator {
    public TripleShotDecorator(ISpaceship spaceship) : base(spaceship) {}

    public override void Method() {
        base.Method();
        Console.WriteLine("Triple shot power-up method");
    }
}

// Concrete decorator for homing missiles power-up
class HomingMissilesDecorator : SpaceshipDecorator {
    public HomingMissilesDecorator(ISpaceship spaceship) : base(spaceship) {}

    public override void Method() {
        base.Method();
        Console.WriteLine("Homing missiles power-up method");
    }
}

// Concrete decorator for cloaking device power-up
class CloakingDeviceDecorator : SpaceshipDecorator {
    public CloakingDeviceDecorator(ISpaceship spaceship) : base(spaceship) {}

    public override void Method() {
        base.Method();
        Console.WriteLine("Cloaking device power-up method");
    }
}
