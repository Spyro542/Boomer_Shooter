using UnityEngine;

public class Winchester : MonoBehaviour
{
    [Header("GameObjects")]
    public Camera PlayerCamera = Camera.main;
    public Animator GunAnimator;

    [Header("Constants")]
    public float Damage = 5f;
    public int ClipSize = 14;
    public int MaxAmmo = 500;

    [Header("Temporary")]
    public int Ammo = 0;    //ammo being the reserves that can be loaded
    public int Clip = 14;   //clip being what is currently in the clip

    private bool CanFire = true;



    public void Fire()
    {
        if (!CanFire)
        {
            return;
        }
        CanFire = false;
        if (Clip <= 0 && Ammo > 0)
        {
            GunAnimator.SetTrigger("Reload");
            for (int i = 0; i < ClipSize; i++)
            {
                if (Ammo > 0)
                {
                    Clip++;
                    Ammo--;
                }
            }
            CanFire = false;
            return;
        }
        if (Clip <= 0) 
        {
            return;
        }


        GunAnimator.SetTrigger("Fire");
        Clip--;

        RaycastHit hit;
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit))
        {
            Health TargetHealth = hit.transform.root.GetComponent<Health>();
            if (TargetHealth != null)
            {
                TargetHealth.Damage(Damage);
            }
        }


    }

    private void ReadyToShoot()
    {
        CanFire = true;
    }

    void Start()
    {
        
    }

    void Update()
    {
        Fire();
    }
}
