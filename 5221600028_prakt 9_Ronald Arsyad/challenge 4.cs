class RepairDrone : SpaceshipDecorator
{
    private bool active;
    private Timer timer;

    public RepairDrone(ISpaceship spaceship) : base(spaceship)
    {
        active = false;
    }

    public override void Method()
    {
        if (IsActive())
        {
            Console.WriteLine("Spaceship being repaired");
        }
        else
        {
            spaceship.Method();
        }
    }

    public override void Activate()
    {
        active = true;
        // Start timer to deactivate after duration
        timer = new Timer(state => Deactivate(), null, TimeSpan.FromSeconds(20), TimeSpan.Zero);
    }

    public override void Deactivate()
    {
        active = false;
        timer.Dispose();
    }

    public override bool IsActive()
    {
        return active;
    }
}
