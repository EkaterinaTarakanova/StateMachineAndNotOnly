using UnityEngine;

public class WalkingAwayDog : State
{
    private float speed;
    private Rigidbody2D rigidbody;
    private bool isWalkedAway;
    private Vector2 targetPosition;

    public bool IsWalkedAway => isWalkedAway;


    public WalkingAwayDog(float speed, Rigidbody2D rigidbody)
    {
        this.speed = speed;
        this.rigidbody = rigidbody;
    }

    public override void OnEnter()
    {
        this.targetPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));

    }

    public override void OnLogic()
    {
        Vector2 currentPosition = rigidbody.position;
        Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
        rigidbody.MovePosition(newPosition);

        if (Vector2.Distance(currentPosition, targetPosition) <= 0.1f)
        {
            isWalkedAway = true;
        }
    }

    public override void OnExit()
    {
        isWalkedAway = false;
    }
}
