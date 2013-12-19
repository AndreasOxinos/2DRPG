
using UnityEngine;


[AddComponentMenu("Game/UI/Key Binding")]
public class UIKeyBind : MonoBehaviour
{
	public enum Action
	{
		PressAndClick,
        Click,
		Select,
	}

	public enum Modifier
	{
		None,
		Shift,
		Control,
		Alt,
	}

	/// <summary>
	/// Key that will trigger the binding.
	/// </summary>

	public KeyCode keyCode = KeyCode.None;

	/// <summary>
	/// Modifier key that must be active in order for the binding to trigger.
	/// </summary>

	public Modifier modifier = Modifier.None;

	/// <summary>
	/// Action to take with the specified key.
	/// </summary>

	public Action action = Action.PressAndClick;

	bool mIgnoreUp = false;
	bool mIsInput = false;

	/// <summary>
	/// If we're bound to an input field, subscribe to its Submit notification.
	/// </summary>

	void Start ()
	{
		UIInput input = GetComponent<UIInput>();
		mIsInput = (input != null);
		if (input != null) EventDelegate.Add(input.onSubmit, OnSubmit);
	}

	/// <summary>
	/// Ignore the KeyUp message if the input field "ate" it.
	/// </summary>

	void OnSubmit () { if (UICamera.currentKey == keyCode && IsModifierActive()) mIgnoreUp = true; }

	/// <summary>
	/// Convenience function that checks whether the required modifier key is active.
	/// </summary>

	bool IsModifierActive ()
	{
		if (modifier == Modifier.None) return true;

		if (modifier == Modifier.Alt)
		{
			if (Input.GetKey(KeyCode.LeftAlt) ||
				Input.GetKey(KeyCode.RightAlt)) return true;
		}
		else if (modifier == Modifier.Control)
		{
			if (Input.GetKey(KeyCode.LeftControl) ||
				Input.GetKey(KeyCode.RightControl)) return true;
		}
		else if (modifier == Modifier.Shift)
		{
			if (Input.GetKey(KeyCode.LeftShift) ||
				Input.GetKey(KeyCode.RightShift)) return true;
		}
		return false;
	}

	/// <summary>
	/// Process the key binding.
	/// </summary>

	void Update ()
	{
		if (keyCode == KeyCode.None || !IsModifierActive()) return;

		if (action == Action.PressAndClick)
		{
			if (UICamera.inputHasFocus) return;

			if (Input.GetKeyDown(keyCode))
			{
				SendMessage("OnPress", true, SendMessageOptions.DontRequireReceiver);
			}

			if (Input.GetKeyUp(keyCode))
			{
				SendMessage("OnPress", false, SendMessageOptions.DontRequireReceiver);
				SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
			}
		}
		else if (action == Action.Select)
		{
			if (Input.GetKeyUp(keyCode))
			{
				if (mIsInput)
				{
					if (!mIgnoreUp && !UICamera.inputHasFocus)
					{
						UICamera.selectedObject = gameObject;
					}
					mIgnoreUp = false;
				}
				else
				{
					UICamera.selectedObject = gameObject;
				}
			}
		}
        else if (action == Action.Click)
        {
            if(Input.GetKeyDown(keyCode))
            {
                SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
            }
        }
	}
}
