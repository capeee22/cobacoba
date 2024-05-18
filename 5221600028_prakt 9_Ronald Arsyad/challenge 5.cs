class PowerUpManager
{
    private List<SpaceshipDecorator> activePowerUps;

    public PowerUpManager()
    {
        activePowerUps = new List<SpaceshipDecorator>();
    }

    public void AddPowerUp(SpaceshipDecorator powerUp)
    {
        activePowerUps.Add(powerUp);
        powerUp.Activate();
    }

    public void RemovePowerUp(SpaceshipDecorator powerUp)
    {
        activePowerUps.Remove(powerUp);
        powerUp.Deactivate();
    }
}
