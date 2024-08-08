using UnityEngine;

public struct SpellShotData {
    public SpellShotData(Vector3 position, int damage, bool instakill = false) {
        Position = position;
        Damage = damage;
        Instakill = instakill;
    }

    public Vector3 Position;
    public int Damage;
    public bool Instakill;
}