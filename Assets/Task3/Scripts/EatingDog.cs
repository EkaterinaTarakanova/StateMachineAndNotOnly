using UnityEngine;

public class EatingDog : State
{
    private float eatDuration;
    private float currentTime;
    private bool isEating;
    public bool IsEating => isEating;
    public EatingDog(float eatDuration)
    {
        this.eatDuration = eatDuration;
    }

    public override void OnExit()
    {
        currentTime = 0;
        isEating = false;
    }

    public override void OnLogic()
    {
        
        currentTime += Time.deltaTime;

        if (currentTime > eatDuration)
        {
            Debug.Log("Ест " + currentTime + " секунд");
            isEating = true;
        }
    }
}
