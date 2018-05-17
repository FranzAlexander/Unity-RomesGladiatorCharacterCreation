using UnityEngine;

[CreateAssetMenu()]
public class Character : ScriptableObject
{

    public string Name;
    public int Age;
    public string Sex;
    public string Race;
    public string Class;
    public string SocialRank;
    public float Height;
    public string Weight;

    public int Strength;
    public int Dexterity;
    public int Consitution;
    public int Intelligence;
    public int Wisdom;
    public int Charisma;

    public float health = 100f;
    public float armor = 0f;
    public float speed = 0f;
    public float gold = 100f;
}
