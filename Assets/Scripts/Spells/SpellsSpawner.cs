using UnityEngine;
using System.Linq;
using System.Collections;

public class SpellsSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spellSlots;
    [SerializeField] private GameObject _spellPrefab;
    private SpellsSpawnGetter _spellsSpawnGetter;

    void Awake() {
        _spellsSpawnGetter = gameObject.GetComponent<SpellsSpawnGetter>();
    }

    void Start()
    {
        SpawnSpellsInEmptySlots();
        EventManager.Instance.SpellCasted += SpawnSpellsWithDelay;
    }

    void SpawnSpellsInEmptySlots()
    {
        foreach (Transform slot in _spellSlots)
        {
            if (slot.childCount == 0)
            {
                SpawnSpellInSlot(slot);
            }
        }
    }

    void SpawnSpellInSlot(Transform slot)
    {
        GameObject spell = Instantiate(_spellPrefab, slot);
        Spell spellComponent = spell.GetComponent<Spell>();
        spellComponent.Setup(_spellsSpawnGetter.GetRandom());
    }

    void SpawnSpellsWithDelay()
    {
        StartCoroutine(SpawnSpellsInEmptySlotsWithDelay(0.1f));
    }

    private IEnumerator SpawnSpellsInEmptySlotsWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnSpellsInEmptySlots();
    }
}
