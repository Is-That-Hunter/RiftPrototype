// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Raymond/MainController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainController"",
    ""maps"": [
        {
            ""name"": ""PlayerMovment"",
            ""id"": ""9a221ac5-c676-47d7-912f-bdf05666828b"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""84610392-deb4-4a70-9a58-c1c2c5d57b6c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""843ea650-fe8b-4fc0-9769-bea1fa413204"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraMove"",
                    ""type"": ""Value"",
                    ""id"": ""3502a555-4205-49c1-8bbd-5b4cb8012d0a"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a95b27b5-92a4-4521-8e89-3e824133c2ad"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59950a01-0623-41be-bcd6-a98317d15bb3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba687e4b-40bc-4efd-a79e-4b6def407c7f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17fa6c35-84c8-485c-b3ab-79ed827c4dc8"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovment
        m_PlayerMovment = asset.FindActionMap("PlayerMovment", throwIfNotFound: true);
        m_PlayerMovment_Jump = m_PlayerMovment.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMovment_Move = m_PlayerMovment.FindAction("Move", throwIfNotFound: true);
        m_PlayerMovment_CameraMove = m_PlayerMovment.FindAction("CameraMove", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerMovment
    private readonly InputActionMap m_PlayerMovment;
    private IPlayerMovmentActions m_PlayerMovmentActionsCallbackInterface;
    private readonly InputAction m_PlayerMovment_Jump;
    private readonly InputAction m_PlayerMovment_Move;
    private readonly InputAction m_PlayerMovment_CameraMove;
    public struct PlayerMovmentActions
    {
        private @MainController m_Wrapper;
        public PlayerMovmentActions(@MainController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_PlayerMovment_Jump;
        public InputAction @Move => m_Wrapper.m_PlayerMovment_Move;
        public InputAction @CameraMove => m_Wrapper.m_PlayerMovment_CameraMove;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovment; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovmentActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovmentActions instance)
        {
            if (m_Wrapper.m_PlayerMovmentActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerMovmentActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMovmentActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMovmentActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_PlayerMovmentActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMovmentActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMovmentActionsCallbackInterface.OnMove;
                @CameraMove.started -= m_Wrapper.m_PlayerMovmentActionsCallbackInterface.OnCameraMove;
                @CameraMove.performed -= m_Wrapper.m_PlayerMovmentActionsCallbackInterface.OnCameraMove;
                @CameraMove.canceled -= m_Wrapper.m_PlayerMovmentActionsCallbackInterface.OnCameraMove;
            }
            m_Wrapper.m_PlayerMovmentActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @CameraMove.started += instance.OnCameraMove;
                @CameraMove.performed += instance.OnCameraMove;
                @CameraMove.canceled += instance.OnCameraMove;
            }
        }
    }
    public PlayerMovmentActions @PlayerMovment => new PlayerMovmentActions(this);
    public interface IPlayerMovmentActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnCameraMove(InputAction.CallbackContext context);
    }
}
