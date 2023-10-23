using UnityEngine;

public class AIControlInput : InputHandler
{
    [SerializeField]
    private string horizontalAxisName = "Horizontal";

    [SerializeField]
    private string verticalAxisName = "Vertical";
    
    [SerializeField]
    private string fire1ButtonName = "Fire1";

    public override float GetHorizontalAxis()
    {
        return Input.GetAxis("Horizontal");
    }

    public override float GetVerticalAxis()
    {
        return Input.GetAxis("Vertical");
    }

    public override bool GetFire1Button()
    {
        return Input.GetButton("Fire1");
    }
}
