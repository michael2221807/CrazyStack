using UnityEngine;

public class AwardBlock : MonoBehaviour
{

    public GameObject awardBlock;

    public GManager gameManager;

    public Vector3 rotation;

    private void OnTriggerEnter()
    {
        gameManager.GetAward();
    }

    private void Spin()
    {
        awardBlock.transform.Rotate(rotation, Space.Self);
    }

    public void FixedUpdate()
    {
        Spin();
        
    }

}
