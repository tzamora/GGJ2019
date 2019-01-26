
// Manager that holds the connection between InControl and Action events.

// 2015/10/19 03:47 PM


using UnityEngine;
using InControl;
using System;


public class GamePlayerInput : MonoBehaviour
{
	public bool update = true;

	[Header("Options")]
	public bool useKeyboard = false;
	public bool forceActiveDevice = false; // This component will use the active device

	[Header("Info")]
	public InputDevice inputDevice; // if null, InControl will use the current active device
	public int inputDeviceOrder = 0; // InControl device index


	public GameInputActions actions;

	// Movement vector
	public Vector2 Movement
	{
		get
		{
			return actions != null ? actions.Movement.Value : Vector2.zero;
		}
	}


	void Start()
	{
		if (forceActiveDevice)
			SetInputDevice(inputDevice, -1);
	}

	public void SetInputDevice(InputDevice newInputDevice, int order)
	{
		actions = new GameInputActions();

		// Movement (Axis + Dpad + WASD + Keys)
		if (useKeyboard)
		{
			actions.Left.AddDefaultBinding(Key.A);
			actions.Left.AddDefaultBinding(Key.LeftArrow);

			actions.Right.AddDefaultBinding(Key.D);
			actions.Right.AddDefaultBinding(Key.RightArrow);

            actions.Up.AddDefaultBinding(Key.W);
            actions.Up.AddDefaultBinding(Key.UpArrow);

            actions.Down.AddDefaultBinding(Key.S);
            actions.Down.AddDefaultBinding(Key.DownArrow);

            actions.attack.AddDefaultBinding(Key.Space);

		}
		else
		{
			actions.Left.AddDefaultBinding(InputControlType.DPadLeft);
			actions.Left.AddDefaultBinding(InputControlType.LeftStickLeft);

			actions.Right.AddDefaultBinding(InputControlType.DPadRight);
			actions.Right.AddDefaultBinding(InputControlType.LeftStickRight);

			actions.Up.AddDefaultBinding(InputControlType.DPadUp);
			actions.Up.AddDefaultBinding(InputControlType.LeftStickUp);

			actions.Down.AddDefaultBinding(InputControlType.DPadDown);
			actions.Down.AddDefaultBinding(InputControlType.LeftStickDown);

			actions.attack.AddDefaultBinding(InputControlType.Action1);
		}


		// Force the input device
		if (newInputDevice != null)
		{
			actions.Device = newInputDevice;

			inputDevice = newInputDevice;
			inputDeviceOrder = order;

		}
	}

	void QuickInputTest()
	{
		// Movement
		if (actions.Left.WasPressed)
			Debug.Log("Left " + Time.time);

		if (actions.Right.WasPressed)
			Debug.Log("Right " + Time.time);

		if (actions.Up.WasPressed)
			Debug.Log("Up " + Time.time);

		if (actions.Down.WasPressed)
			Debug.Log("Down " + Time.time);
	}
}
