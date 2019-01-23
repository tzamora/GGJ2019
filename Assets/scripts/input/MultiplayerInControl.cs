
// @matnesis
// 2015/10/23 11:44 PM


using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using matnesis.TeaTime;
using InControl;



public class MultiplayerInControl : MonoBehaviour
{
	public List<GamePlayerInput> players = null; // Players list
	public int deviceCount = 0; // Current controls connected

	[Header("Last Refresh")]
	public List<GamePlayerInput> playersWithoutDevice;
	public List<InputDevice> busyDevices;
	public List<InputDevice> freeDevices;
	public GamePlayerInput keyboardPlayer = null;


	void Start()
	{
		// When a new usb device is detected, the controls are reassigned
		// for the players without devices
		this.tt("RefreshDevices").Add(1, () =>
		{
			if (InputManager.Devices.Count != deviceCount)
			{
				deviceCount = InputManager.Devices.Count;
				AssignFreeDevicesToFreePlayers();
			}
		})
		.Repeat();


		// On 'Space' or 'Enter', a free tank will be activated for the
		// keyboard.
		this.tt("KeyboardPlayerDetection").Loop((ttHandler t) =>
		{
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				keyboardPlayer = players.Where(
				                     p => p.inputDevice == null ||
				                     !InputManager.Devices.Contains(p.inputDevice)).FirstOrDefault();


				// If there is a free lion
				if (keyboardPlayer != null)
				{
					keyboardPlayer.gameObject.SetActive(true);

					keyboardPlayer.useKeyboard = true;
					keyboardPlayer.forceActiveDevice = true;
					keyboardPlayer.SetInputDevice(null, -1);

					AssignFreeDevicesToFreePlayers();
				}
			}
		})
		.Wait();
		
		// Look for all the compatible players, except the active device
		players = FindObjectsOfType<GamePlayerInput>().ToList();
	}


	// Assign free devices to free players.
	void AssignFreeDevicesToFreePlayers()
	{
		// Queries
		playersWithoutDevice = 
			players.Where(p => !p.useKeyboard && (p.inputDevice == null || !InputManager.Devices.Contains (p.inputDevice) )).ToList();
		
		busyDevices = players.Where(p => p.inputDevice != null).Select(d => d.inputDevice).ToList();

		freeDevices = InputManager.Devices.Where(d => !busyDevices.Contains(d)).ToList();


		// Players & Devices
		for (int i = 0; i < playersWithoutDevice.Count; i++)
		{
			// Free devices are the limit
			if (i >= freeDevices.Count)
			{
				// Turn off players without device
				if (playersWithoutDevice[i] != keyboardPlayer)
					playersWithoutDevice[i].gameObject.SetActive(false);

				continue;
			}

			playersWithoutDevice[i].gameObject.SetActive(true);
			playersWithoutDevice[i].SetInputDevice(freeDevices[i], i);
		}
	}
}
