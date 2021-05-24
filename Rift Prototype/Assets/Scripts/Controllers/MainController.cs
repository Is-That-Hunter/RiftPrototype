// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controllers/MainController.inputactions'

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
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""4b7d0cc5-58d2-43c6-b515-d343c1d20b84"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""075e1e8a-e5cc-41be-a0bb-5f8a7f31eb92"",
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
                    ""path"": ""<Keyboard>/f"",
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
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8da3efb9-d1b0-43a9-aa74-4fc4b99a38df"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Inventory_Craft"",
            ""id"": ""42e30998-1a42-4144-88f5-56a32d03af3d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""5f7b3625-7ace-4855-8e9d-160c2b51932b"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Craft"",
                    ""type"": ""Button"",
                    ""id"": ""fc65945b-114d-4b99-a6c5-99ef855e58ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Type_Select"",
                    ""type"": ""Button"",
                    ""id"": ""bd796c62-4d82-4d6c-bb77-c9d9a2a2833f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Size_Select"",
                    ""type"": ""Button"",
                    ""id"": ""c7f376ec-3281-4a82-b37f-6030c1b4337d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Material_Select"",
                    ""type"": ""Button"",
                    ""id"": ""3713d095-4eb4-4d08-a890-88da7284cd49"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""State_Switch"",
                    ""type"": ""Button"",
                    ""id"": ""42b47cb5-63b2-44bf-b0f4-1db541c56a5e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""ae83aa86-74e1-44c7-bbf9-1365948310d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""Value"",
                    ""id"": ""3d870612-ebf5-4365-88b7-ef1c40401259"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""826287ea-967f-416a-b084-0eb967b0021a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a896204e-a7eb-4a5a-b27f-08273ab51dad"",
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
                    ""id"": ""14f06696-3d0c-4c34-b837-302f41cfa06d"",
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
                    ""id"": ""b3139ad4-ad58-4905-b54e-2116919737b3"",
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
                    ""id"": ""7ca50a34-a457-4536-b96d-2587ddf942dc"",
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
                    ""id"": ""25305f14-35ea-4ebb-947a-0c2b6850e0f4"",
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
                    ""id"": ""59cae343-058e-48e2-bf7a-e5589cf6891a"",
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
                    ""id"": ""d757c6c6-c577-4e38-a103-3fecd015982b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Type_Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7589261-bb59-48d0-ab3d-958136e5f7df"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Size_Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26e3f043-57b1-4665-a743-64656898a913"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Material_Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca44447f-3ad6-41b1-8fdb-31a37ac510df"",
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
                    ""id"": ""36da544b-6681-4e8f-92cd-ce4416cb28a7"",
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
                    ""id"": ""982614ef-ab2e-4893-8b84-eda179879c96"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0d2bcfa-0a2c-4cbc-baa9-dd86e7442388"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Pause_Menu"",
            ""id"": ""5d21da12-b0d8-4ac4-b69e-1132e97a89dc"",
            ""actions"": [
                {
                    ""name"": ""Unpause"",
                    ""type"": ""Button"",
                    ""id"": ""c891cd26-996a-4654-bd9d-94183b77a082"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a0d3cebe-b4f2-4d78-81de-d7ad9cb7b36b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Unpause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Report"",
            ""id"": ""bf86a65c-7e7f-4d2b-af2b-3dc9d3bc7263"",
            ""actions"": [
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""57cc72bc-8fec-4d64-aecb-746406245962"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d56414eb-28c0-4ece-b4b5-91de9968a528"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Develop"",
            ""id"": ""a900ead4-4037-4a73-b026-738117b04081"",
            ""actions"": [
                {
                    ""name"": ""Carnival"",
                    ""type"": ""Button"",
                    ""id"": ""946934f7-5728-4e8a-a4c0-65e6e5309c6a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f4e7b79a-3ca7-44a0-b24c-aaab4d2c0f2f"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Carnival"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GlobalButtons"",
            ""id"": ""d0aaa540-3ecb-44c4-ac77-38dc4a3be5e3"",
            ""actions"": [
                {
                    ""name"": ""EndCutscene"",
                    ""type"": ""Button"",
                    ""id"": ""59d5dae9-2abc-46ff-a3cf-483899f3733e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""92762af1-d365-448d-8da5-e253ba7903d8"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EndCutscene"",
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
        m_PlayerMovement_Interact = m_PlayerMovement.FindAction("Interact", throwIfNotFound: true);
        m_PlayerMovement_Pause = m_PlayerMovement.FindAction("Pause", throwIfNotFound: true);
        // Inventory_Craft
        m_Inventory_Craft = asset.FindActionMap("Inventory_Craft", throwIfNotFound: true);
        m_Inventory_Craft_Move = m_Inventory_Craft.FindAction("Move", throwIfNotFound: true);
        m_Inventory_Craft_Craft = m_Inventory_Craft.FindAction("Craft", throwIfNotFound: true);
        m_Inventory_Craft_Type_Select = m_Inventory_Craft.FindAction("Type_Select", throwIfNotFound: true);
        m_Inventory_Craft_Size_Select = m_Inventory_Craft.FindAction("Size_Select", throwIfNotFound: true);
        m_Inventory_Craft_Material_Select = m_Inventory_Craft.FindAction("Material_Select", throwIfNotFound: true);
        m_Inventory_Craft_State_Switch = m_Inventory_Craft.FindAction("State_Switch", throwIfNotFound: true);
        m_Inventory_Craft_Click = m_Inventory_Craft.FindAction("Click", throwIfNotFound: true);
        m_Inventory_Craft_Point = m_Inventory_Craft.FindAction("Point", throwIfNotFound: true);
        m_Inventory_Craft_Drop = m_Inventory_Craft.FindAction("Drop", throwIfNotFound: true);
        // Pause_Menu
        m_Pause_Menu = asset.FindActionMap("Pause_Menu", throwIfNotFound: true);
        m_Pause_Menu_Unpause = m_Pause_Menu.FindAction("Unpause", throwIfNotFound: true);
        // Report
        m_Report = asset.FindActionMap("Report", throwIfNotFound: true);
        m_Report_Escape = m_Report.FindAction("Escape", throwIfNotFound: true);
        // Develop
        m_Develop = asset.FindActionMap("Develop", throwIfNotFound: true);
        m_Develop_Carnival = m_Develop.FindAction("Carnival", throwIfNotFound: true);
        // GlobalButtons
        m_GlobalButtons = asset.FindActionMap("GlobalButtons", throwIfNotFound: true);
        m_GlobalButtons_EndCutscene = m_GlobalButtons.FindAction("EndCutscene", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerMovement_Interact;
    private readonly InputAction m_PlayerMovement_Pause;
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
        public InputAction @Interact => m_Wrapper.m_PlayerMovement_Interact;
        public InputAction @Pause => m_Wrapper.m_PlayerMovement_Pause;
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
                @Interact.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnInteract;
                @Pause.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPause;
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
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // Inventory_Craft
    private readonly InputActionMap m_Inventory_Craft;
    private IInventory_CraftActions m_Inventory_CraftActionsCallbackInterface;
    private readonly InputAction m_Inventory_Craft_Move;
    private readonly InputAction m_Inventory_Craft_Craft;
    private readonly InputAction m_Inventory_Craft_Type_Select;
    private readonly InputAction m_Inventory_Craft_Size_Select;
    private readonly InputAction m_Inventory_Craft_Material_Select;
    private readonly InputAction m_Inventory_Craft_State_Switch;
    private readonly InputAction m_Inventory_Craft_Click;
    private readonly InputAction m_Inventory_Craft_Point;
    private readonly InputAction m_Inventory_Craft_Drop;
    public struct Inventory_CraftActions
    {
        private @MainController m_Wrapper;
        public Inventory_CraftActions(@MainController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Inventory_Craft_Move;
        public InputAction @Craft => m_Wrapper.m_Inventory_Craft_Craft;
        public InputAction @Type_Select => m_Wrapper.m_Inventory_Craft_Type_Select;
        public InputAction @Size_Select => m_Wrapper.m_Inventory_Craft_Size_Select;
        public InputAction @Material_Select => m_Wrapper.m_Inventory_Craft_Material_Select;
        public InputAction @State_Switch => m_Wrapper.m_Inventory_Craft_State_Switch;
        public InputAction @Click => m_Wrapper.m_Inventory_Craft_Click;
        public InputAction @Point => m_Wrapper.m_Inventory_Craft_Point;
        public InputAction @Drop => m_Wrapper.m_Inventory_Craft_Drop;
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
                @Type_Select.started -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnType_Select;
                @Type_Select.performed -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnType_Select;
                @Type_Select.canceled -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnType_Select;
                @Size_Select.started -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnSize_Select;
                @Size_Select.performed -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnSize_Select;
                @Size_Select.canceled -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnSize_Select;
                @Material_Select.started -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnMaterial_Select;
                @Material_Select.performed -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnMaterial_Select;
                @Material_Select.canceled -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnMaterial_Select;
                @State_Switch.started -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnState_Switch;
                @State_Switch.performed -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnState_Switch;
                @State_Switch.canceled -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnState_Switch;
                @Click.started -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnClick;
                @Point.started -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnPoint;
                @Drop.started -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_Inventory_CraftActionsCallbackInterface.OnDrop;
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
                @Type_Select.started += instance.OnType_Select;
                @Type_Select.performed += instance.OnType_Select;
                @Type_Select.canceled += instance.OnType_Select;
                @Size_Select.started += instance.OnSize_Select;
                @Size_Select.performed += instance.OnSize_Select;
                @Size_Select.canceled += instance.OnSize_Select;
                @Material_Select.started += instance.OnMaterial_Select;
                @Material_Select.performed += instance.OnMaterial_Select;
                @Material_Select.canceled += instance.OnMaterial_Select;
                @State_Switch.started += instance.OnState_Switch;
                @State_Switch.performed += instance.OnState_Switch;
                @State_Switch.canceled += instance.OnState_Switch;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
            }
        }
    }
    public Inventory_CraftActions @Inventory_Craft => new Inventory_CraftActions(this);

    // Pause_Menu
    private readonly InputActionMap m_Pause_Menu;
    private IPause_MenuActions m_Pause_MenuActionsCallbackInterface;
    private readonly InputAction m_Pause_Menu_Unpause;
    public struct Pause_MenuActions
    {
        private @MainController m_Wrapper;
        public Pause_MenuActions(@MainController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Unpause => m_Wrapper.m_Pause_Menu_Unpause;
        public InputActionMap Get() { return m_Wrapper.m_Pause_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Pause_MenuActions set) { return set.Get(); }
        public void SetCallbacks(IPause_MenuActions instance)
        {
            if (m_Wrapper.m_Pause_MenuActionsCallbackInterface != null)
            {
                @Unpause.started -= m_Wrapper.m_Pause_MenuActionsCallbackInterface.OnUnpause;
                @Unpause.performed -= m_Wrapper.m_Pause_MenuActionsCallbackInterface.OnUnpause;
                @Unpause.canceled -= m_Wrapper.m_Pause_MenuActionsCallbackInterface.OnUnpause;
            }
            m_Wrapper.m_Pause_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Unpause.started += instance.OnUnpause;
                @Unpause.performed += instance.OnUnpause;
                @Unpause.canceled += instance.OnUnpause;
            }
        }
    }
    public Pause_MenuActions @Pause_Menu => new Pause_MenuActions(this);

    // Report
    private readonly InputActionMap m_Report;
    private IReportActions m_ReportActionsCallbackInterface;
    private readonly InputAction m_Report_Escape;
    public struct ReportActions
    {
        private @MainController m_Wrapper;
        public ReportActions(@MainController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Escape => m_Wrapper.m_Report_Escape;
        public InputActionMap Get() { return m_Wrapper.m_Report; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ReportActions set) { return set.Get(); }
        public void SetCallbacks(IReportActions instance)
        {
            if (m_Wrapper.m_ReportActionsCallbackInterface != null)
            {
                @Escape.started -= m_Wrapper.m_ReportActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_ReportActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_ReportActionsCallbackInterface.OnEscape;
            }
            m_Wrapper.m_ReportActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
            }
        }
    }
    public ReportActions @Report => new ReportActions(this);

    // Develop
    private readonly InputActionMap m_Develop;
    private IDevelopActions m_DevelopActionsCallbackInterface;
    private readonly InputAction m_Develop_Carnival;
    public struct DevelopActions
    {
        private @MainController m_Wrapper;
        public DevelopActions(@MainController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Carnival => m_Wrapper.m_Develop_Carnival;
        public InputActionMap Get() { return m_Wrapper.m_Develop; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DevelopActions set) { return set.Get(); }
        public void SetCallbacks(IDevelopActions instance)
        {
            if (m_Wrapper.m_DevelopActionsCallbackInterface != null)
            {
                @Carnival.started -= m_Wrapper.m_DevelopActionsCallbackInterface.OnCarnival;
                @Carnival.performed -= m_Wrapper.m_DevelopActionsCallbackInterface.OnCarnival;
                @Carnival.canceled -= m_Wrapper.m_DevelopActionsCallbackInterface.OnCarnival;
            }
            m_Wrapper.m_DevelopActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Carnival.started += instance.OnCarnival;
                @Carnival.performed += instance.OnCarnival;
                @Carnival.canceled += instance.OnCarnival;
            }
        }
    }
    public DevelopActions @Develop => new DevelopActions(this);

    // GlobalButtons
    private readonly InputActionMap m_GlobalButtons;
    private IGlobalButtonsActions m_GlobalButtonsActionsCallbackInterface;
    private readonly InputAction m_GlobalButtons_EndCutscene;
    public struct GlobalButtonsActions
    {
        private @MainController m_Wrapper;
        public GlobalButtonsActions(@MainController wrapper) { m_Wrapper = wrapper; }
        public InputAction @EndCutscene => m_Wrapper.m_GlobalButtons_EndCutscene;
        public InputActionMap Get() { return m_Wrapper.m_GlobalButtons; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GlobalButtonsActions set) { return set.Get(); }
        public void SetCallbacks(IGlobalButtonsActions instance)
        {
            if (m_Wrapper.m_GlobalButtonsActionsCallbackInterface != null)
            {
                @EndCutscene.started -= m_Wrapper.m_GlobalButtonsActionsCallbackInterface.OnEndCutscene;
                @EndCutscene.performed -= m_Wrapper.m_GlobalButtonsActionsCallbackInterface.OnEndCutscene;
                @EndCutscene.canceled -= m_Wrapper.m_GlobalButtonsActionsCallbackInterface.OnEndCutscene;
            }
            m_Wrapper.m_GlobalButtonsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @EndCutscene.started += instance.OnEndCutscene;
                @EndCutscene.performed += instance.OnEndCutscene;
                @EndCutscene.canceled += instance.OnEndCutscene;
            }
        }
    }
    public GlobalButtonsActions @GlobalButtons => new GlobalButtonsActions(this);
    public interface IPlayerMovementActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnCameraMove(InputAction.CallbackContext context);
        void OnRunning(InputAction.CallbackContext context);
        void OnCrouching(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnState_Switch(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IInventory_CraftActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnCraft(InputAction.CallbackContext context);
        void OnType_Select(InputAction.CallbackContext context);
        void OnSize_Select(InputAction.CallbackContext context);
        void OnMaterial_Select(InputAction.CallbackContext context);
        void OnState_Switch(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
    }
    public interface IPause_MenuActions
    {
        void OnUnpause(InputAction.CallbackContext context);
    }
    public interface IReportActions
    {
        void OnEscape(InputAction.CallbackContext context);
    }
    public interface IDevelopActions
    {
        void OnCarnival(InputAction.CallbackContext context);
    }
    public interface IGlobalButtonsActions
    {
        void OnEndCutscene(InputAction.CallbackContext context);
    }
}
