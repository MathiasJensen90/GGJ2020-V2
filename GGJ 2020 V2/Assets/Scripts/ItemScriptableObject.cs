using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Item", order = 1)]
public abstract class ItemScriptableObject : ScriptableObject
{

    public abstract void Effect(Patient patient);
}