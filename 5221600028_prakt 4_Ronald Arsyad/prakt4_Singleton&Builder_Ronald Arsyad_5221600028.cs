// Singleton Pattern for InputManager
public class InputManager
{
    private static InputManager instance;

    private InputManager() { }

    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new InputManager();
            }
            return instance;
        }
    }

    // Other methods to manage player input
}

// Singleton Pattern for LevelManager
public class LevelManager
{
    private static LevelManager instance;

    private LevelManager() { }

    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LevelManager();
            }
            return instance;
        }
    }

    // Other methods to manage game levels
}

// Builder Pattern for creating levels
public class LevelBuilder
{
    private int size;
    private int obstacles;
    private int enemies;

    public LevelBuilder SetSize(int size)
    {
        this.size = size;
        return this;
    }

    public LevelBuilder SetObstacles(int obstacles)
    {
        this.obstacles = obstacles;
        return this;
    }

    public LevelBuilder SetEnemies(int enemies)
    {
        this.enemies = enemies;
        return this;
    }

    public Level Build()
    {
        return new Level(size, obstacles, enemies);
    }
}

// Sample Level class
public class Level
{
    private int size;
    private int obstacles;
    private int enemies;

    public Level(int size, int obstacles, int enemies)
    {
        this.size = size;
        this.obstacles = obstacles;
        this.enemies = enemies;
    }

    // Getters and setters
}

// Builder Pattern for creating items
public class ItemBuilder
{
    private string type;
    private int power;
    private string effect;

    public ItemBuilder SetType(string type)
    {
        this.type = type;
        return this;
    }

    public ItemBuilder SetPower(int power)
    {
        this.power = power;
        return this;
    }

    public ItemBuilder SetEffect(string effect)
    {
        this.effect = effect;
        return this;
    }

    public Item Build()
    {
        return new Item(type, power, effect);
    }
}

// Sample Item class
public class Item
{
    private string type;
    private int power;
    private string effect;

    public Item(string type, int power, string effect)
    {
        this.type = type;
        this.power = power;
        this.effect = effect;
    }

    // Getters and setters
}

// Singleton and Builder Pattern combined for creating levels
public class CustomLevelManager
{
    private static CustomLevelManager instance;

    private CustomLevelManager() { }

    public static CustomLevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CustomLevelManager();
            }
            return instance;
        }
    }

    public Level CreateLevel(int size, int obstacles, int enemies)
    {
        return new LevelBuilder()
                .SetSize(size)
                .SetObstacles(obstacles)
                .SetEnemies(enemies)
                .Build();
    }

    public Item CreateItem(string type, int power, string effect)
    {
        return new ItemBuilder()
                .SetType(type)
                .SetPower(power)
                .SetEffect(effect)
                .Build();
    }
}
