using UnityEngine;
using System.Collections;

public class DestructableDecoration : MonoBehaviour
{
    [SerializeField] private int maxHealth;

    private SpriteRenderer _sprRend;
    private Color _origColor;
    private int _health;

    private void Awake()
    {
        _sprRend = GetComponent<SpriteRenderer>();
        _origColor = _sprRend.color;

        _health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        StartCoroutine(DamageIndicate());

        if (_health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator DamageIndicate()
    {
        _sprRend.color = new Color(0.8f, 0.2f, 0.0f, 1.0f);
        yield return new WaitForSeconds(0.1f);
        _sprRend.color = _origColor;
    }
    IEnumerator Die()
    {
        _sprRend.color = _origColor = Color.red;
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }
}
