using System.Collections.Generic;
using UnityEngine;
public enum PlayerType
{
    Kuntilanak,
    Pocong
}
[CreateAssetMenu(fileName = "NewEntity", menuName = "Entity/PlayerCharacter")]
public class CharacterData : ScriptableObject
{
    [Header("Player Settings")]
    public PlayerType playerType;

    [Header("Stats")]
    public int maxHealth;
    public float moveSpeed;
    public float jumpForce;

    public List<Ability> startingAbilities;
}
