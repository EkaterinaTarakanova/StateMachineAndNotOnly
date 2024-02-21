using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WalkingDogState : State
{
    private float speed;
    private Rigidbody2D rigidbody;
    private GameObject target;

    public WalkingDogState(float speed, Rigidbody2D rigidbody, GameObject target) 
    {
        this.speed = speed;
        this.rigidbody = rigidbody;
        this.target = target;
    }

    public override void OnLogic() 
    {
        var targetPosition = (Vector2)target.transform.position;
        var ourPosition = (Vector2) rigidbody.transform.position;
        var targetDirection = (Vector2) (targetPosition - ourPosition).normalized;

        rigidbody.MovePosition(ourPosition + targetDirection * speed * Time.deltaTime);
    }
}
