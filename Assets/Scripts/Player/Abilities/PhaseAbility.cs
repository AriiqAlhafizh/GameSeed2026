using System.Collections;
using UnityEngine;

public class PhaseAbility : Ability
{
    [SerializeField] private float phaseDuration = 1f;
    [SerializeField] private string enemyLayerName = "Enemy";
    [SerializeField] private string playerLayerName = "Player";

    private int enemyLayer;
    private int playerLayer;

    private void Start()
    {
        context.Input.DashPressed += HandlePhase;
        enemyLayer = LayerMask.NameToLayer(enemyLayerName);
        playerLayer = LayerMask.NameToLayer(playerLayerName);
    }

    private void HandlePhase()
    {
        StartCoroutine(PhaseCoroutine());
    }

    private IEnumerator PhaseCoroutine()
    {
        // Ignore collisions between player and enemy layers
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, true);

        yield return new WaitForSeconds(phaseDuration);

        // Re-enable collisions between player and enemy layers
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);
    }
}
