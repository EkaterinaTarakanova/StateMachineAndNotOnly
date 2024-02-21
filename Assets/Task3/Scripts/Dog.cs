using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject dish;
    [SerializeField] private float eatDuration;
    [SerializeField] private float distanceToEat;
    [SerializeField] private float sleepDuration;

    private Rigidbody2D dogRigidbody;
    private StateMachine stateMachine;
    private WalkingDogState walkingDogState;
    private EatingDog eatingDog;
    private WalkingAwayDog walkingAwayDog;
    private SleepingDog sleepingDog;

    private void Awake()
    {
        dogRigidbody = GetComponent<Rigidbody2D>();
        InitializeState();
    }

    private void InitializeState() 
    {
        stateMachine = new StateMachine();
        walkingDogState = new WalkingDogState(speed, dogRigidbody, dish.gameObject);
        eatingDog = new EatingDog(eatDuration);
        walkingAwayDog = new WalkingAwayDog(speed, dogRigidbody);
        sleepingDog = new SleepingDog(sleepDuration);

        stateMachine.AddTransition(walkingDogState, eatingDog, TransitionFromWalkingToEating);
        stateMachine.AddTransition(eatingDog, walkingAwayDog, TransitionFromEatingToWalkingAway);
        stateMachine.AddTransition(walkingAwayDog, sleepingDog, TransitionFromWalkingAwayToSleeping);
        stateMachine.AddTransition(sleepingDog, walkingDogState, TransitionFromSleepingToWalking);
    }

    private bool TransitionFromWalkingToEating() 
    {
        var distance = Vector2.Distance((Vector2)transform.position, (Vector2)dish.transform.position);
        return distance < distanceToEat;
    }

    private bool TransitionFromEatingToWalkingAway()
    {
        return eatingDog.IsEating;
    }

    private bool TransitionFromWalkingAwayToSleeping() 
    {
        return walkingAwayDog.IsWalkedAway;
    }

    private bool TransitionFromSleepingToWalking() 
    {
        return sleepingDog.IsSlept;
    }

    private void Start()
    {
        stateMachine.SetState(walkingDogState);
    }

    private void Update()
    {
        stateMachine.OnLogic();
    }

    private void FixedUpdate()
    {
        stateMachine.OnPhysics();
    }
}
