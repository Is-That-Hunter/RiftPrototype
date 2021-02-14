// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Raymond_InputManager/MainController.inputactions'

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
            ""name"": ""PlayerMovement"",
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
                },
                {
                    ""name"": ""Running"",
                    ""type"": ""Button"",
                    ""id"": ""95ca9876-e2b5-4696-b9c8-70338cd6ef22"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouching"",
                    ""type"": ""Button"",
                    ""id"": ""3dd40ee3-7cdf-441f-94b5-97073d3286cf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""38b7b38d-b3c3-4e9f-bafb-f72717bd6c53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""State_Switch"",
                    ""type"": ""Button"",
                    ""id"": ""55fcfbab-326e-47ee-8b0f-12ab55c5265a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pickup"",
                    ""type"": ""Button"",
                    ""id"": ""4b7d0cc5-58d2-43c6-b515-d343c1d20b84"",
                    ""expectedControlType"": ""Button"",
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
                    ""name"": ""2D Vector"",
                    ""id"": ""e8797ec4-bedb-4668-a8b5-d70bf97c91d5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""aec6e32e-1682-4f4e-b090-52b16a0921a4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e687c1cb-bff4-4609-bbe8-632e0e049ff2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f0146af4-84fa-49c0-b393-c766c9234a7c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""22b8a7dc-6553-4887-86bf-666e22f674e1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                },
                {
                    ""name"": """",
                    ""id"": ""72b2d912-5bc7-4ff2-9d36-a33f476aaf6d"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Running"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c905ca4-186d-4761-8d7a-5699369c9d57"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Running"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4c7a9b2-9be4-4d55-ae0a-36682b834c73"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouching"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cafd842b-79ad-41af-9414-707b4178ff69"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouching"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e960b14c-1e5c-4f47-bbf3-3cb9e490827a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79071ebb-9f8b-46d9-b84b-9f5eaa331c2a"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4185bff-864c-4ea5-9092-5908d423b2ed"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""State_Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a629994e-9821-4616-9394-30712a8c4cfe"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pickup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InventoryCraftNav"",
            ""id"": ""2417baee-f954-4de2-9aa7-44e4ef6a1048"",
            ""actions"": [
                {
                    ""name"": ""NavigateInv"",
                    ""type"": ""Value"",
                    ""id"": ""8800217e-86b1-4b13-9b94-32412492409e"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Craft"",
                    ""type"": ""Button"",
                    ""id"": ""9aed6952-94d2-416f-985d-31836c53b6ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MaterialSelect"",
                    ""type"": ""Button"",
                    ""id"": ""2f9e9796-b9d7-4945-807a-69f78fd60c73"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TypeSelect"",
                    ""type"": ""Button"",
                    ""id"": ""8c907510-7e69-4a60-a190-eb0dafa1703b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SizeSelect"",
                    ""type"": ""Button"",
                    ""id"": ""024f7fd3-c009-49b6-bf4c-bb9903d90a23"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NavigateSort"",
                    ""type"": ""Button"",
                    ""id"": ""2f430a2b-12a6-4fb7-9e02-fcc922a6b39a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""417b4ea4-2654-47a8-ae09-b251f2a6448b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateInv"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e956170d-b7b5-4c8b-bbc8-9bdad3023134"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateInv"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""85a3c7db-857b-4e68-b3e3-82393427a662"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateInv"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4f2fbc2a-02b1-4a5a-9490-5de89af83b74"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateInv"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0f50b12d-2e1b-4d17-89dc-6004dcaa509e"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateInv"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""90afe807-fe2b-40c1-a60e-7b6b58ce5f3e"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateInv"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bea11bdd-a831-4ec2-a8b1-ffb2afc8824f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Craft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4da5e5e1-30b7-4800-8e1c-53ff6f7f707c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MaterialSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27d2b7fe-1b42-4731-bfa0-86f6942f3760"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TypeSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dcb0d315-e9d5-47fb-813c-ec4b01bb7c18"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SizeSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b821ebee-c40c-4a51-8246-e48b21a2db2a"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateSort"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_Jump = m_PlayerMovement.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMovement_Move = m_PlayerMovement.FindAction("Move", throwIfNotFound: true);
        m_PlayerMovement_CameraMove = m_PlayerMovement.FindAction("CameraMove", throwIfNotFound: true);
        m_PlayerMovement_Running = m_PlayerMovement.FindAction("Running", throwIfNotFound: true);
        m_PlayerMovement_Crouching = m_PlayerMovement.FindAction("Crouching", throwIfNotFound: true);
        m_PlayerMovement_Dash = m_PlayerMovement.FindAction("Dash", throwIfNotFound: true);
        m_PlayerMovement_State_Switch = m_PlayerMovement.FindAction("State_Switch", throwIfNotFound: true);
        m_PlayerMovement_Pickup = m_PlayerMovement.FindAction("Pickup", throwIfNotFound: true);
        // InventoryCraftNav
        m_InventoryCraftNav = asset.FindActionMap("InventoryCraftNav", throwIfNotFound: true);
        m_InventoryCraftNav_NavigateInv = m_InventoryCraftNav.FindAction("NavigateInv", throwIfNotFound: true);
        m_InventoryCraftNav_Craft = m_InventoryCraftNav.FindAction("Craft", throwIfNotFound: true);
        m_InventoryCraftNav_MaterialSelect = m_InventoryCraftNav.FindAction("MaterialSelect", throwIfNotFound: true);
        m_InventoryCraftNav_TypeSelect = m_InventoryCraftNav.FindAction("TypeSelect", throwIfNotFound: true);
        m_InventoryCraftNav_SizeSelect = m_InventoryCraftNav.FindAction("SizeSelect", throwIfNotFound: true);
        m_InventoryCraftNav_NavigateSort = m_InventoryCraftNav.FindAction("NavigateSort", throwIfNotFound: true);
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

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Jump;
    private readonly InputAction m_PlayerMovement_Move;
    private readonly InputAction m_PlayerMovement_CameraMove;
    private readonly InputAction m_PlayerMovement_Running;
    private readonly InputAction m_PlayerMovement_Crouching;
    private readonly InputAction m_PlayerMovement_Dash;
    private readonly InputAction m_PlayerMovement_State_Switch;
    private readonly InputAction m_PlayerMovement_Pickup;
    public struct PlayerMovementActions
    {
        private @MainController m_Wrapper;
        public PlayerMovementActions(@MainController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_PlayerMovement_Jump;
        public InputAction @Move => m_Wrapper.m_PlayerMovement_Move;
        public InputAction @CameraMove => m_Wrapper.m_PlayerMovement_CameraMove;
        public InputAction @Running => m_Wrapper.m_PlayerMovement_Running;
        public InputAction @Crouching => m_Wrapper.m_PlayerMovement_Crouching;
        public InputAction @Dash => m_Wrapper.m_PlayerMovement_Dash;
        public InputAction @State_Switch => m_Wrapper.m_PlayerMovement_State_Switch;
        public InputAction @Pickup => m_Wrapper.m_PlayerMovement_Pickup;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @CameraMove.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCameraMove;
                @CameraMove.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCameraMove;
                @CameraMove.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCameraMove;
                @Running.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRunning;
                @Running.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRunning;
                @Running.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRunning;
                @Crouching.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCrouching;
                @Crouching.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCrouching;
                @Crouching.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCrouching;
                @Dash.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnDash;
                @State_Switch.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnState_Switch;
                @State_Switch.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnState_Switch;
                @State_Switch.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnState_Switch;
                @Pickup.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPickup;
                @Pickup.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPickup;
                @Pickup.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPickup;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
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
                @Running.started += instance.OnRunning;
                @Running.performed += instance.OnRunning;
                @Running.canceled += instance.OnRunning;
                @Crouching.started += instance.OnCrouching;
                @Crouching.performed += instance.OnCrouching;
                @Crouching.canceled += instance.OnCrouching;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @State_Switch.started += instance.OnState_Switch;
                @State_Switch.performed += instance.OnState_Switch;
                @State_Switch.canceled += instance.OnState_Switch;
                @Pickup.started += instance.OnPickup;
                @Pickup.performed += instance.OnPickup;
                @Pickup.canceled += instance.OnPickup;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // InventoryCraftNav
    private readonly InputActionMap m_InventoryCraftNav;
    private IInventoryCraftNavActions m_InventoryCraftNavActionsCallbackInterface;
    private readonly InputAction m_InventoryCraftNav_NavigateInv;
    private readonly InputAction m_InventoryCraftNav_Craft;
    private readonly InputAction m_InventoryCraftNav_MaterialSelect;
    private readonly InputAction m_InventoryCraftNav_TypeSelect;
    private readonly InputAction m_InventoryCraftNav_SizeSelect;
    private readonly InputAction m_InventoryCraftNav_NavigateSort;
    public struct InventoryCraftNavActions
    {
        private @MainController m_Wrapper;
        public InventoryCraftNavActions(@MainController wrapper) { m_Wrapper = wrapper; }
        public InputAction @NavigateInv => m_Wrapper.m_InventoryCraftNav_NavigateInv;
        public InputAction @Craft => m_Wrapper.m_InventoryCraftNav_Craft;
        public InputAction @MaterialSelect => m_Wrapper.m_InventoryCraftNav_MaterialSelect;
        public InputAction @TypeSelect => m_Wrapper.m_InventoryCraftNav_TypeSelect;
        public InputAction @SizeSelect => m_Wrapper.m_InventoryCraftNav_SizeSelect;
        public InputAction @NavigateSort => m_Wrapper.m_InventoryCraftNav_NavigateSort;
        public InputActionMap Get() { return m_Wrapper.m_InventoryCraftNav; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InventoryCraftNavActions set) { return set.Get(); }
        public void SetCallbacks(IInventoryCraftNavActions instance)
        {
            if (m_Wrapper.m_InventoryCraftNavActionsCallbackInterface != null)
            {
                @NavigateInv.started -= m_Wrapper.m_InventoryCraftNavActionsCallbackInterface.OnNavigateInv;
                @NavigateInv.performed -= m_Wrapper.m_InventoryCraftNavActionsCallbackInterface.OnNavigateInv;
                @NavigateInv.canceled -= m_Wrapper.m_InventoryCraftNavActionsCallbackInterface.OnNavigateInv;
                @Craft.started -= m_Wrapper.m_InventoryCraftNavActionsCallbackInterface.OnCraft;
                @Craft.performed -= m_Wrapper.m_InventoryCraftNavActionsCallbackInterface.OnCraft;
                @Craft.canceled -= m_Wrapper.m_InventoryCraftNavActionsCallbackInterface.OnCraft;
                @MaterialSelect.started -= m_Wrapper.m_InventoryCraftNavActionsCallbackInterface.OnMaterialSelect;
                @MaterialSelect.performed -= m_Wrapper.m_InventoryCraftNavActionsCallbackInterface.OnMaterialSelect;
                @MaterialSelect.canceled -= m_Wrapper.m_InventoryCraftNavActionsCallbackInterface.OnMaterialSelect;
                @TypeSelect.started -= m_Wrapper.m_InventoryCraftNavActionsCallbackInterface.OnTypeSelect;
                @TypeSelect.performed -= m_Wrapper.m_InventoryCraftNavActionsCallbackInterface.OnTypeSelect;
                @TypeSelect.canceled -= m_Wrapper.m_InventoryCraftNavActionsCallbackInterface.OnTypeSelect;
                @SizeSelect.started -= m_Wrapper.m_InventoryCraftNavActionsCallbackInterface.OnSizeSelect;
                @SizeSelect.performed -= m_Wrapper.m_InventoryCraftNavActionsCallbackInterface.OnSizeSelect;
                @SizeSelect.canceled -= m_Wrapper.m_InventoryCraftNavActionsCallbackInterface.OnSizeSelect;
                @NavigateSort.started -= m_Wrapper.m_InventoryCraftNavActionsCallbackInterface.OnNavigateSort;
                @NavigateSort.performed -= m_Wrapper.m_InventoryCraftNavActionsCallbackInterface.OnNavigateSort;
                @NavigateSort.canceled -= m_Wrapper.m_InventoryCraftNavActionsCallbackInterface.OnNavigateSort;
            }
            m_Wrapper.m_InventoryCraftNavActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NavigateInv.started += instance.OnNavigateInv;
                @NavigateInv.performed += instance.OnNavigateInv;
                @NavigateInv.canceled += instance.OnNavigateInv;
                @Craft.started += instance.OnCraft;
                @Craft.performed += instance.OnCraft;
                @Craft.canceled += instance.OnCraft;
                @MaterialSelect.started += instance.OnMaterialSelect;
                @MaterialSelect.performed += instance.OnMaterialSelect;
                @MaterialSelect.canceled += instance.OnMaterialSelect;
                @TypeSelect.started += instance.OnTypeSelect;
                @TypeSelect.performed += instance.OnTypeSelect;
                @TypeSelect.canceled += instance.OnTypeSelect;
                @SizeSelect.started += instance.OnSizeSelect;
                @SizeSelect.performed += instance.OnSizeSelect;
                @SizeSelect.canceled += instance.OnSizeSelect;
                @NavigateSort.started += instance.OnNavigateSort;
                @NavigateSort.performed += instance.OnNavigateSort;
                @NavigateSort.canceled += instance.OnNavigateSort;
            }
        }
    }
    public InventoryCraftNavActions @InventoryCraftNav => new InventoryCraftNavActions(this);
    public interface IPlayerMovementActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnCameraMove(InputAction.CallbackContext context);
        void OnRunning(InputAction.CallbackContext context);
        void OnCrouching(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnState_Switch(InputAction.CallbackContext context);
        void OnPickup(InputAction.CallbackContext context);
    }
    public interface IInventoryCraftNavActions
    {
        void OnNavigateInv(InputAction.CallbackContext context);
        void OnCraft(InputAction.CallbackContext context);
        void OnMaterialSelect(InputAction.CallbackContext context);
        void OnTypeSelect(InputAction.CallbackContext context);
        void OnSizeSelect(InputAction.CallbackContext context);
        void OnNavigateSort(InputAction.CallbackContext context);
    }
}
