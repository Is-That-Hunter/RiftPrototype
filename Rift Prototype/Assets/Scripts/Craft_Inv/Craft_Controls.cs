// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Craft_Inv/Craft_Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Craft_Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Craft_Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Craft_Controls"",
    ""maps"": [
        {
            ""name"": ""Inventory_Craft"",
            ""id"": ""3df6879b-f7c0-4ada-b397-ef197ded9329"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""ed49156e-5628-4caf-94d9-a7d4a358cfa9"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Craft"",
                    ""type"": ""Button"",
                    ""id"": ""8c81d710-400c-4dbc-9d63-774f17af02f6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Size_Select"",
                    ""type"": ""Button"",
                    ""id"": ""a889e380-255a-4dc1-b17d-1261dabc5862"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Material_Select"",
                    ""type"": ""Button"",
                    ""id"": ""ff8e7a58-6c04-4537-82fa-2dd04b5d0882"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Type_Select"",
                    ""type"": ""Button"",
                    ""id"": ""4be8b1be-f9a7-4f5a-ad23-7ce81176b795"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""State_Switch"",
                    ""type"": ""Button"",
                    ""id"": ""8855fa03-25d5-49c8-80b3-0bd0f67d6a75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""97b3e921-0452-43ab-83af-8fadb0bb851a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""Value"",
                    ""id"": ""edfe245b-90ca-4b8a-b5a7-d9681738471d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b1d954d3-7d83-40cb-8248-aabff4d91c9e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Craft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""26e7bf88-817f-4a5a-87ac-a75fdadda495"",
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
                    ""id"": ""89330ad6-e9fb-44a2-933c-c32dbace699e"",
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
                    ""id"": ""d8e37c64-def4-4f42-b6c7-38b22c83ec62"",
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
                    ""id"": ""9ff32bbb-9843-4f01-b1f4-78bf56d711a5"",
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
                    ""id"": ""a0349f1e-6cf3-409d-a487-aa5dec61db10"",
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
                    ""id"": ""3db26123-0565-4251-bf6d-c083aae3a72e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Size_Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83a48810-014f-4f0c-ae35-6e66851a1310"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Material_Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b85b403-5ee9-4641-a12d-55c55c6bc45b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Type_Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""257757b1-c10d-4a77-b970-fd7d01ad2395"",
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
                    ""id"": ""033a3b0b-8df3-4730-bb63-e76465a8b79e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d36305f2-df65-4faf-b892-c8cb49e2892c"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Inventory_Craft
        m_Inventory_Craft = asset.FindActionMap("Inventory_Craft", throwIfNotFound: true);
        m_Inventory_Craft_Move = m_Inventory_Craft.FindAction("Move", throwIfNotFound: true);
        m_Inventory_Craft_Craft = m_Inventory_Craft.FindAction("Craft", throwIfNotFound: true);
        m_Inventory_Craft_Size_Select = m_Inventory_Craft.FindAction("Size_Select", throwIfNotFound: true);
        m_Inventory_Craft_Material_Select = m_Inventory_Craft.FindAction("Material_Select", throwIfNotFound: true);
        m_Inventory_Craft_Type_Select = m_Inventory_Craft.FindAction("Type_Select", throwIfNotFound: true);
        m_Inventory_Craft_State_Switch = m_Inventory_Craft.FindAction("State_Switch", throwIfNotFound: true);
        m_Inventory_Craft_Click = m_Inventory_Craft.FindAction("Click", throwIfNotFound: true);
        m_Inventory_Craft_Point = m_Inventory_Craft.FindAction("Point", throwIfNotFound: true);
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

    // Inventory_Craft
    private readonly InputActionMap m_Inventory_Craft;
    private IInventory_CraftActions m_Inventory_CraftActionsCallbackInterface;
    private readonly InputAction m_Inventory_Craft_Move;
    private readonly InputAction m_Inventory_Craft_Craft;
    private readonly InputAction m_Inventory_Craft_Size_Select;
    private readonly InputAction m_Inventory_Craft_Material_Select;
    private readonly InputAction m_Inventory_Craft_Type_Select;
    private readonly InputAction m_Inventory_Craft_State_Switch;
    private readonly InputAction m_Inventory_Craft_Click;
    private readonly InputAction m_Inventory_Craft_Point;
    public struct Inventory_CraftActions
    {
        private @Craft_Controls m_Wrapper;
        public Inventory_CraftActions(@Craft_Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Inventory_Craft_Move;
        public InputAction @Craft => m_Wrapper.m_Inventory_Craft_Craft;
        public InputAction @Size_Select => m_Wrapper.m_Inventory_Craft_Size_Select;
        public InputAction @Material_Select => m_Wrapper.m_Inventory_Craft_Material_Select;
        public InputAction @Type_Select => m_Wrapper.m_Inventory_Craft_Type_Select;
        public InputAction @State_Switch => m_Wrapper.m_Inventory_Craft_State_Switch;
        public InputAction @Click => m_Wrapper.m_Inventory_Craft_Click;
        public InputAction @Point => m_Wrapper.m_Inventory_Craft_Point;
        public InputActionMap Get() { return m_Wrapper.m_Inventory_Craft; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Inventory_CraftActions set) { return set.Get(); }
        public void SetCallbacks(IInventory_CraftActions instance)
        {
            if (m_Wrapper.m_Inventory_CraftActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnMove;
                @Craft.started -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnCraft;
                @Craft.performed -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnCraft;
                @Craft.canceled -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnCraft;
                @Size_Select.started -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnSize_Select;
                @Size_Select.performed -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnSize_Select;
                @Size_Select.canceled -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnSize_Select;
                @Material_Select.started -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnMaterial_Select;
                @Material_Select.performed -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnMaterial_Select;
                @Material_Select.canceled -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnMaterial_Select;
                @Type_Select.started -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnType_Select;
                @Type_Select.performed -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnType_Select;
                @Type_Select.canceled -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnType_Select;
                @State_Switch.started -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnState_Switch;
                @State_Switch.performed -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnState_Switch;
                @State_Switch.canceled -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnState_Switch;
                @Click.started -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnClick;
                @Point.started -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnPoint;
            }
            m_Wrapper.m_Inventory_CraftActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Craft.started += instance.OnCraft;
                @Craft.performed += instance.OnCraft;
                @Craft.canceled += instance.OnCraft;
                @Size_Select.started += instance.OnSize_Select;
                @Size_Select.performed += instance.OnSize_Select;
                @Size_Select.canceled += instance.OnSize_Select;
                @Material_Select.started += instance.OnMaterial_Select;
                @Material_Select.performed += instance.OnMaterial_Select;
                @Material_Select.canceled += instance.OnMaterial_Select;
                @Type_Select.started += instance.OnType_Select;
                @Type_Select.performed += instance.OnType_Select;
                @Type_Select.canceled += instance.OnType_Select;
                @State_Switch.started += instance.OnState_Switch;
                @State_Switch.performed += instance.OnState_Switch;
                @State_Switch.canceled += instance.OnState_Switch;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
            }
        }
    }
    public Inventory_CraftActions @Inventory_Craft => new Inventory_CraftActions(this);
    public interface IInventory_CraftActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnCraft(InputAction.CallbackContext context);
        void OnSize_Select(InputAction.CallbackContext context);
        void OnMaterial_Select(InputAction.CallbackContext context);
        void OnType_Select(InputAction.CallbackContext context);
        void OnState_Switch(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
    }
}
