using System;
using System.Collections.Generic;
using Constants;
using Enviroment;
using UnityEngine;
using CharacterController = Characters.CharacterController;

public class WeaponController : MonoBehaviour
{
    public float weaponDmg;
    public float startAngle = 35;
    public float rotationAngle = 70;
    public float rotationSpeed = 10;

    private CharacterController _character;
    private readonly HashSet<int> _damaged = new HashSet<int>();
    private float _baseAngle;
    private bool _isMoving = true;

    public void SetData(CharacterController character, Vector2 direction)
    {
        _character = character;
        var forward = Vector2.right;
        if (Vector3.Cross(forward, direction).z > 0)
        {
            _baseAngle = Vector2.Angle(forward, direction);
        }
        else
        {
            _baseAngle = 360 - Vector2.Angle(forward, direction);
        }

        transform.localPosition = character.WeaponPivot();
        transform.Rotate(new Vector3(0, 0, _baseAngle + startAngle));
    }

    private void Update()
    {
        if (!_isMoving)
            return;
        var angle = rotationSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, -angle));
        rotationAngle -= angle;
        if (rotationAngle <= 0f)
        {
            DestroyWeapon();
        }
    }

    public void DestroyWeapon()
    {
        _character.OnWeaponDestroy();
        Destroy(gameObject);
    }

    public void ToggleWeapon(bool stop)
    {
        _isMoving = !stop;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_isMoving)
            return;
        var go = other.gameObject;
        if (_damaged.Contains(go.GetInstanceID()) || !(go.CompareTag(Tags.Destroyable) || go.CompareTag(Tags.Player))) return;
        var destroyableController = go.GetComponent<DestroyableController>();
        _damaged.Add(go.GetInstanceID());
        destroyableController.Damage(GetDamage());
        _character.OnHit();
    }

    private float GetDamage()
    {
        return weaponDmg * _character.GetBasicStats().str;
    }
}