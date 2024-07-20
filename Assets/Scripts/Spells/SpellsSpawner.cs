using UnityEngine;
using System.Linq;
using System.Collections;

public class SpellsSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spellSlots;
    [SerializeField] private GameObject[] _spells;

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
        GameObject spell = Instantiate(GetRandomSpell(), slot);
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

    GameObject GetRandomSpell()
    {
        return _spells.OrderBy(x => Random.value).FirstOrDefault();
    }

}
