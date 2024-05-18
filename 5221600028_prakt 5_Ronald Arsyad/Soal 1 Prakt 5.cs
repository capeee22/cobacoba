using System;
using System.Collections.Generic;

// Abstract Character class
public abstract class Character
{
    public string Name { get; protected set; }
    public Dictionary<string, int> Stats { get; protected set; }
    public List<string> Skills { get; protected set; }
    public List<string> Inventory { get; protected set; }

    public Character(string name)
    {
        Name = name;
        Stats = new Dictionary<string, int>();
        Skills = new List<string>();
        Inventory = new List<string>();
    }

    public abstract void ShowInfo();
}

// Builder interface for building characters
public interface ICharacterBuilder
{
    void SetName(string name);
    void SetClass();
    void SetStats();
    void SetSkills();
    void SetInventory();
    Character GetCharacter();
}

// Director class for directing the character building process
public class CharacterDirector
{
    private ICharacterBuilder _builder;

    public CharacterDirector(ICharacterBuilder builder)
    {
        _builder = builder;
    }

    public void ConstructCharacter(string name)
    {
        _builder.SetName(name);
        _builder.SetClass();
        _builder.SetStats();
        _builder.SetSkills();
        _builder.SetInventory();
    }
}

// Concrete builder for Warrior character
public class WarriorBuilder : ICharacterBuilder
{
    private Character _character;

    public WarriorBuilder()
    {
        _character = new Warrior("");
    }

    public void SetName(string name)
    {
        _character.Name = name;
    }

    public void SetClass()
    {
        _character.Stats["Class"] = "Warrior";
    }

    public void SetStats()
    {
        _character.Stats["HP"] = 100;
        _character.Stats["MP"] = 50;
        _character.Stats["Attack"] = 20;
        _character.Stats["Defense"] = 15;
    }

    public void SetSkills()
    {
        _character.Skills.AddRange(new[] { "Slash", "Block" });
    }

    public void SetInventory()
    {
        _character.Inventory.AddRange(new[] { "Sword", "Shield" });
    }

    public Character GetCharacter()
    {
        return _character;
    }
}

// Adapter interface for character
public interface ICharacterAdapter
{
    Dictionary<string, int> GetStats();
    List<string> GetSkills();
    List<string> GetInventory();
}

// Adapter for adapting Warrior character to ICharacterAdapter
public class WarriorAdapter : ICharacterAdapter
{
    private Warrior _warrior;

    public WarriorAdapter(Warrior warrior)
    {
        _warrior = warrior;
    }

    public Dictionary<string, int> GetStats()
    {
        return _warrior.Stats;
    }

    public List<string> GetSkills()
    {
        return _warrior.Skills;
    }

    public List<string> GetInventory()
    {
        return _warrior.Inventory;
    }
}

// Concrete Warrior class inheriting from Character
public class Warrior : Character
{
    public Warrior(string name) : base(name)
    {
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine("Stats:");
        foreach (var stat in Stats)
        {
            Console.WriteLine($"- {stat.Key}: {stat.Value}");
        }
        Console.WriteLine("Skills:");
        foreach (var skill in Skills)
        {
            Console.WriteLine($"- {skill}");
        }
        Console.WriteLine("Inventory:");
        foreach (var item in Inventory)
        {
            Console.WriteLine($"- {item}");
        }
    }
}

// GameManager class for controlling the game
public class GameManager
{
    private List<ICharacterAdapter> _characters;

    public GameManager()
    {
        _characters = new List<ICharacterAdapter>();
    }

    public void AddCharacter(ICharacterAdapter character)
    {
        _characters.Add(character);
    }

    public void ShowCharactersInfo()
    {
        foreach (var character in _characters)
        {
            Console.WriteLine("Character Info:");
            Console.WriteLine("-------------");
            Console.WriteLine("Stats:");
            foreach (var stat in character.GetStats())
            {
                Console.WriteLine($"- {stat.Key}: {stat.Value}");
            }
            Console.WriteLine("Skills:");
            foreach (var skill in character.GetSkills())
            {
                Console.WriteLine($"- {skill}");
            }
            Console.WriteLine("Inventory:");
            foreach (var item in character.GetInventory())
            {
                Console.WriteLine($"- {item}");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a warrior builder
        var warriorBuilder = new WarriorBuilder();

        // Create a character director
        var director = new CharacterDirector(warriorBuilder);

        // Construct a warrior character
        director.ConstructCharacter("Conan");
        var warriorCharacter = warriorBuilder.GetCharacter();

        // Create an adapter for warrior character
        var warriorAdapter = new WarriorAdapter(warriorCharacter);

        // Create a game manager
        var gameManager = new GameManager();

        // Add the adapted character to the game manager
        gameManager.AddCharacter(warriorAdapter);

        // Show characters' information
        gameManager.ShowCharactersInfo();
    }
}

