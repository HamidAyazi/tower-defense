using System.Collections;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    /*-------- Logic Attributes --------*/
    [SerializeField] private ProjectileScriptableObject ProjectileSO;
    [SerializeField] private float MaxScale;
    [SerializeField] private float DefaultScale;
    private float currentScale;
    private float TotalDistance;
    private Vector3 FallPosition;
    private Vector3 moveDirection;
    private State state;

    /*-------- Projectile Attributes --------*/
    
    private float Speed;
    private float TimeToDie;
    private float SlowMP;
    private float Radius;
    private float SlowTime;

    // Start is called before the first frame update
    private void Start()
    {
        // Here goes to calculations based on level
        Speed = ProjectileSO.BaseSpeed += GameStats.ProjectileSpeed;
        TimeToDie = ProjectileSO.MaxTimeToDie;

        moveDirection = (FallPosition - transform.position).normalized;
        TotalDistance = Vector3.Distance(FallPosition, transform.position);
        currentScale = DefaultScale;
    }

    private void Update()
    {
        float CurrentDistance = Vector3.Distance(transform.position, FallPosition);

        if (state == State.Rising)
        {
            // Calculate the progress towards the TotalDistance
            float progress = (TotalDistance - CurrentDistance) * 2 / TotalDistance;

            // Get bigger gradually based on progress
            currentScale = Mathf.Lerp(DefaultScale, MaxScale, progress);
            transform.localScale = new Vector3(currentScale, currentScale, 1f);

            transform.position += moveDirection * Speed * Time.deltaTime;
            if (CurrentDistance <= TotalDistance / 2)
            {
                state = State.Falling;
            }
        }
        else if (state == State.Falling)
        {
            // Calculate the progress from the TotalDistance to the target
            float progress = 1f - (CurrentDistance / TotalDistance * 2);

            // Get smaller gradually based on progress
            currentScale = Mathf.Lerp(MaxScale, DefaultScale, progress);
            transform.localScale = new Vector3(currentScale, currentScale, 1f);

            transform.position += moveDirection * Speed * Time.deltaTime;
            if (CurrentDistance <= 0.05)
            {
                state = State.Dropped;
            }
        }
        else if (state == State.Dropped)
        {
            // Splash and deal slow effect
            StartCoroutine(ExpandSplash());
            SlowEffect();
            TimeToDie -= Time.deltaTime;
            if (TimeToDie <= 0)
            {
                StartCoroutine(FadeOut());
            }
        }
    }

    private IEnumerator ExpandSplash()
    {
        GetComponent<SpriteRenderer>().sortingLayerName = "Tower"; 
        GetComponent<SpriteRenderer>().sortingOrder = 0;
        float splashDuration = 2f;
        float elapsedTime = 0f;
        while (elapsedTime < splashDuration)
        {
            float scaleFactor = Mathf.Lerp(currentScale, Radius, elapsedTime / splashDuration);
            transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the scale reaches exactly the maxScale
        transform.localScale = new Vector3(Radius, Radius, 1);
    }

    private IEnumerator FadeOut()
    {
        float splashDuration = 0.5f;
        float elapsedTime = 0f;
        float a;
        Color c = GetComponent<Renderer>().material.color;
        while (elapsedTime < splashDuration)
        {
            a = Mathf.Lerp(1, 0, elapsedTime / splashDuration);
            GetComponent<Renderer>().material.color = new Color(c.r, c.g, c.b, a);
            elapsedTime += Time.deltaTime + 0.01f;
            yield return null;
        }

        Destroy(gameObject);
    }

    private void SlowEffect()
    {
        Collider2D[] Collider2DArray = Physics2D.OverlapCircleAll(transform.position, Radius);
        foreach (Collider2D Collider2D in Collider2DArray)
        {
            Enemy FoundEnemy = Collider2D.GetComponent<Enemy>();
            if (FoundEnemy != null) // if object is an Enemy
            {
                FoundEnemy.GetComponent<EnemyMovement>().ChangeSpeed(FoundEnemy.EnemySO.MovementSpeed * SlowMP, SlowTime);
            } 
        }
    }

    /// <summary>
    /// Creates a <c>SnowBall</c> and launches it to enemy location.
    /// </summary>
    /// <param name="ProjectilePrefab">Prefab of the Projectile.</param>
    /// <param name="SpawnPosition">Spawn position of the projectile.</param>
    /// <param name="Target">Target of the projectile.</param>
    /// <returns>Game object of the projectile.</returns>
    public static SnowBall CreateProjectile(Transform ProjectilePrefab, Vector3 SpawnPosition,
                                            Vector3 Target, float SlowMP, float SlowTime, float Radius)
    {
        Transform ProjectileTransform = Instantiate(ProjectilePrefab, SpawnPosition, Quaternion.identity);
        SnowBall Projectile = ProjectileTransform.GetComponent<SnowBall>();
        Projectile.FallPosition = Target;
        Projectile.SlowMP = SlowMP;
        Projectile.SlowTime = SlowTime;
        Projectile.Radius = Radius;
        Projectile.state = State.Rising;
        return Projectile;
    }

    private enum State
    {
        Rising,
        Falling,
        Dropped
    }
}
