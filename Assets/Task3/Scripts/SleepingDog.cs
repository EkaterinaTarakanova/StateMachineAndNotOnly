using UnityEngine;

public class SleepingDog : State
{
    private bool isSlept;
    private float sleepDuration;
    private float currentTime;

    public bool IsSlept => isSlept;
    public SleepingDog(float sleepDuration) 
    {
        this.sleepDuration = sleepDuration;
    }

    public override void OnExit()
    {
        currentTime = 0;
        isSlept = false;
    }

    public override void OnLogic()
    {
        currentTime += Time.deltaTime;
        
        if (currentTime >= sleepDuration) 
        {
            Debug.Log("Спит " + currentTime + " секунд");
            isSlept = true;
        }
    }
}
