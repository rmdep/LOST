using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public GameObject weaponObject;   // pedang / object yg mau dipindah
    public Transform handSlot;        // slot tangan

    void Update()
    {
        // Pindahkan ke tangan saat tekan E
        if (Input.GetKeyDown(KeyCode.E))
        {
            AttachToHand();
        }
    }

    void AttachToHand()
    {
        if (weaponObject != null && handSlot != null)
        {
            weaponObject.transform.SetParent(handSlot);
            weaponObject.transform.localPosition = Vector3.zero;
            weaponObject.transform.localRotation = Quaternion.identity;
        }
    }
}
