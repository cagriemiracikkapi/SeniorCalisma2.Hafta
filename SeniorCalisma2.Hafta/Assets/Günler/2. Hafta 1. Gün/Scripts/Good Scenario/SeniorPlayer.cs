using UnityEngine;

public class SeniorPlayer : MonoBehaviour
{
    private IWeapon[] _currentWeapon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // IWeapon arayüzünü implemente eden TÜM component'leri al.
        _currentWeapon = GetComponents<IWeapon>();

        // Hiç silah bulunup bulunmadığını kontrol et.
        if (_currentWeapon == null || _currentWeapon.Length == 0)
        {
            Debug.LogError(
                "Bu GameObject üzerinde IWeapon implemente eden hiçbir component bulunamadı!"
            );
            // Hiç silah yoksa, bu component'in Update metodunun her frame çalışmasını engelle.
            // Bu, gereksiz işlem gücü tüketimini önler.
            enabled = false;
        }
        else
        {
            Debug.Log($"{_currentWeapon.Length} adet silah bulundu.");
            foreach (var i in _currentWeapon)
            {
                Debug.Log($"{i} silahı mevcut.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Start metodunda silahların varlığı zaten kontrol edildi.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Tüm silahları ateşle
            foreach (var weapon in _currentWeapon)
            {
                weapon.Fire();
            }
        }
    }
}
