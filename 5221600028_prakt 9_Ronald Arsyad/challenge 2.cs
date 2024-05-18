// Modify ShieldPowerUp class to allow stacking
class ShieldPowerUp : SpaceshipDecorator
{
    private int stackCount;

    public ShieldPowerUp(ISpaceship spaceship) : base(spaceship)
    {
        stackCount = 0;
    }

    public override void Method()
    {
        if (IsActive())
        {
            Console.WriteLine($"Shielded spaceship with {stackCount} stacks method");
        }
        else
        {
            spaceship.Method();
        }
    }

    public override void Activate()
    {
        stackCount++;
    }

    public override void Deactivate()
    {
        stackCount--;
        if (stackCount < 0)
        {
            stackCount = 0;
        }
    }

    public override bool IsActive()
    {
        return stackCount > 0;
    }
}
