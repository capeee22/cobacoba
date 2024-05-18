// Kelas GameManager
public class GameManager
{
    private List<Tower> towers;
    private List<Enemy> enemies;

    public GameManager()
    {
        towers = new List<Tower>();
        enemies = new List<Enemy>();
    }

    public void SpawnTower(string type, Vector3 position)
    {
        TowerFactory factory = new TowerFactory();
        Tower tower = factory.CreateTower(type);
        if (tower == null)
            return;

        tower.transform.position = position;
        towers.Add(tower);
    }

    public void Update()
    {
        foreach (Tower tower in towers)
        {
            foreach (Enemy enemy in enemies)
            {
                if (tower.GetAttackRange() > Vector3.Distance(tower.transform.position, enemy.transform.position))
                {
                    tower.Attack(enemy);
                }
            }
        }

        // ... (kode game lainnya)
    }
}
