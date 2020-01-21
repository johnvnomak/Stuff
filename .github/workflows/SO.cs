using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName ="Weapon")]
public class Weapon : ScriptableObject
{
    public new string name;
    public int dmg;
    public int ammo;
    public float speed;
    public float rate;
    public float range;
    public float qty;
    public Material mat;
    public Color color;
    public AudioClip shotSound;
}
