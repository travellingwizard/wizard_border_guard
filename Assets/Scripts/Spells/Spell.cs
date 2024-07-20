using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    [SerializeField] private Image _spellIcon;
    [SerializeField] private GameObject _dmgIcon;
    [SerializeField] private TextMeshProUGUI _dmgText;
    private int _damage = 0;
    private SpellScriptableObj _spellObj;


    public void Setup(SpellScriptableObj spellObj)
    {
        _spellObj = spellObj;

        _spellIcon.sprite = _spellObj.view;

        if (_spellObj.isInstakill)
        {
            _dmgText.text = "KILL";
            _dmgIcon.SetActive(false);
        }
        else
        {
            _damage = _spellObj.GetDamage();
            _dmgText.text = _damage.ToString();
        }
    }

    public void OnCast(Vector3 worldPosition)
    {
        if (_spellObj.isInstakill)
        {
            EventManager.Instance.OnCastSpell(worldPosition);
        }
        else
        {
            EventManager.Instance.OnCastSpell(worldPosition, _damage);
        }

        Destroy(gameObject);
    }
}
