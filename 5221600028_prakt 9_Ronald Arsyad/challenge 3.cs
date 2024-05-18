// Add VisualEffect method to ISpaceship interface and implement in decorators
interface ISpaceship
{
    void Method();
    void VisualEffect();
}

class BasicSpaceship : ISpaceship
{
    public void Method()
    {
        Console.WriteLine("Basic spaceship method");
    }

    public void VisualEffect()
    {
        Console.WriteLine("No visual effect");
    }
}

abstract class SpaceshipDecorator : ISpaceship
{
    protected ISpaceship spaceship;

    public SpaceshipDecorator(ISpaceship spaceship)
    {
        this.spaceship = spaceship;
    }

    public virtual void Method()
    {
        spaceship.Method();
    }

    public abstract void Activate();
    public abstract void Deactivate();
    public abstract bool IsActive();

    public virtual void VisualEffect()
    {
        spaceship.VisualEffect();
    }
}

class ShieldPowerUp : SpaceshipDecorator
{
    // Implement Activate, Deactivate, IsActive methods

    public override void VisualEffect()
    {
        Console.WriteLine("Glowing shield visual effect");
    }
}
