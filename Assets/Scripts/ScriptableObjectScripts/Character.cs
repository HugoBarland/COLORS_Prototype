//Credit: based on Restful Coder's code
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public string fullName;
    public Sprite portraitNeutral;
    public Sprite portraitAngry;
    public Sprite portraitSad;
    public Sprite portraitFright;
    public Sprite portraitHappy;
}
