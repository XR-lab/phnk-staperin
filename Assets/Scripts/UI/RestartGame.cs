using UnityEngine;
using UnityEngine.Animations;

public class RestartGame : MonoBehaviour
{
	[SerializeField] private InteractionMachine _interactionMachine;

    void Update()
    {
        bool restart = Input.GetKeyDown(KeyCode.R);
        
        if (restart)
        {
            SceneUtils.Reset();
			_interactionMachine.ReloadStates();
        } 
    }
}