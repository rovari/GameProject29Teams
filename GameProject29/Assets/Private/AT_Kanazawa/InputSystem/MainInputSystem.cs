// GENERATED AUTOMATICALLY FROM 'Assets/Private/AT_Kanazawa/InputSystem/MainInputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainInputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainInputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainInputSystem"",
    ""maps"": [
        {
            ""name"": ""GAME"",
            ""id"": ""10c60f9b-dd8e-4e02-8088-e805f56dd2fb"",
            ""actions"": [
                {
                    ""name"": ""LStick"",
                    ""type"": ""Value"",
                    ""id"": ""b72c1531-e6dd-458f-89a1-71bc1fbb7bae"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RStick"",
                    ""type"": ""Value"",
                    ""id"": ""24eb0c39-c317-4baa-9fc7-4939d168807e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CrossButton"",
                    ""type"": ""Value"",
                    ""id"": ""e46661a6-3244-4e4c-817d-3bed93a7f320"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NorthButtonY"",
                    ""type"": ""Button"",
                    ""id"": ""52e7ade3-ab48-4e42-8ac4-c381b334a425"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SouthButtonA"",
                    ""type"": ""Button"",
                    ""id"": ""80e65fd7-eb4d-40cf-819d-5a75b20808b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WestButtonX"",
                    ""type"": ""Button"",
                    ""id"": ""605682de-f3ba-459d-9baf-08678d1d16d7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EastButtonB"",
                    ""type"": ""Button"",
                    ""id"": ""95be503b-b65a-44a3-ae07-7e6db1295595"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenueButton"",
                    ""type"": ""Button"",
                    ""id"": ""1f7190a4-3f28-42b2-88c3-720a0f45129a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ViewButton"",
                    ""type"": ""Button"",
                    ""id"": ""da7c00ca-254b-4a76-99d5-95d834cbcfd4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TriggerL"",
                    ""type"": ""Button"",
                    ""id"": ""211dcba3-100f-4659-b2a4-33c0d32a7759"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TriggerR"",
                    ""type"": ""Button"",
                    ""id"": ""65766f9d-8df6-493f-86a9-9b7ac893e482"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LButton"",
                    ""type"": ""Button"",
                    ""id"": ""b30f739a-8e1e-4e60-b0a3-4b4e4c39cb6e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RButton"",
                    ""type"": ""Button"",
                    ""id"": ""ecc3b15b-befb-449a-890f-9fae63c47a01"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""16288dde-5c36-4b5d-9cbd-d333a6a53fc6"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""01a9e9dd-de72-4a0c-b67c-bc7b5434f75a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LStick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ae5c6f69-c01d-4a1b-8de8-bb9b7674c5dd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6bc97365-e455-468e-8a3f-13a951bff1c2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4f30a264-58b9-4846-b76e-b6317f173c8b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f8063412-0eef-4144-94c8-05da9e6dba98"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b71e7ad2-d076-489d-a644-b04b8cb01ad8"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f260223-1ae4-441f-9880-353c23aedc3b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc1712a4-c009-45a5-b327-a03e34842db6"",
                    ""path"": ""<DualShockGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8994b057-9158-4126-b162-ed8b9ff7076a"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CrossButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7fc22e9-8231-48af-bda1-e597c3ee84f8"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NorthButtonY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""385b07e6-e640-4032-a13f-896311244ba3"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SouthButtonA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98f2c2da-01b9-4452-98a3-d0a13b7281e7"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WestButtonX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c3fd77bd-7b48-49bc-801a-8ead6442a3dd"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EastButtonB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0d0290f-de7c-4fa0-b8ff-b08a0ca207d3"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TriggerL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""598f8e7e-75b9-4ac5-9ea8-37eec8a5cc8e"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TriggerR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f7d4bc4-dc4a-4294-93e9-5a8dac384f8a"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3b76ac6-8617-4436-aa11-59251c006f8f"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6e15168-3b94-4fea-bc00-84dc32108b02"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenueButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2648e60-009e-430d-9766-28fd4b255c35"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ViewButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""LOAD"",
            ""id"": ""8a7ef7dc-67cb-44b5-a646-2247ac291e2d"",
            ""actions"": [
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""e8ad8cd4-aee8-415b-9f9b-a6feed1310f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6585d41e-b5aa-47af-90df-4330071e9831"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59c576ff-77f2-4686-806c-de1ca4c7629d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""EVENT"",
            ""id"": ""4c735c4b-a49d-477e-8ba2-d5546155f372"",
            ""actions"": [
                {
                    ""name"": ""Menue"",
                    ""type"": ""Button"",
                    ""id"": ""bb784e33-a423-4a15-b894-82d100c0a832"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""32a4b7d9-1e04-4452-98ae-db6922d1f539"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MENU"",
            ""id"": ""f19e911b-3493-4e19-a606-1fc05fc8f110"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Value"",
                    ""id"": ""9f1f2342-ef80-4544-bb11-7417e2fff512"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": "" Decision"",
                    ""type"": ""Button"",
                    ""id"": ""a7bb7979-d323-429b-b8f8-17dbdc7a52f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""95ee0e73-c42d-4198-ac2c-5b88f0c93f07"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""737d6c9e-54e0-4ed8-9187-12bbb2f386e7"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2a9b5f1-bd21-4af8-a7cf-6a64178e86e1"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": "" Decision"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GAME
        m_GAME = asset.FindActionMap("GAME", throwIfNotFound: true);
        m_GAME_LStick = m_GAME.FindAction("LStick", throwIfNotFound: true);
        m_GAME_RStick = m_GAME.FindAction("RStick", throwIfNotFound: true);
        m_GAME_CrossButton = m_GAME.FindAction("CrossButton", throwIfNotFound: true);
        m_GAME_NorthButtonY = m_GAME.FindAction("NorthButtonY", throwIfNotFound: true);
        m_GAME_SouthButtonA = m_GAME.FindAction("SouthButtonA", throwIfNotFound: true);
        m_GAME_WestButtonX = m_GAME.FindAction("WestButtonX", throwIfNotFound: true);
        m_GAME_EastButtonB = m_GAME.FindAction("EastButtonB", throwIfNotFound: true);
        m_GAME_MenueButton = m_GAME.FindAction("MenueButton", throwIfNotFound: true);
        m_GAME_ViewButton = m_GAME.FindAction("ViewButton", throwIfNotFound: true);
        m_GAME_TriggerL = m_GAME.FindAction("TriggerL", throwIfNotFound: true);
        m_GAME_TriggerR = m_GAME.FindAction("TriggerR", throwIfNotFound: true);
        m_GAME_LButton = m_GAME.FindAction("LButton", throwIfNotFound: true);
        m_GAME_RButton = m_GAME.FindAction("RButton", throwIfNotFound: true);
        // LOAD
        m_LOAD = asset.FindActionMap("LOAD", throwIfNotFound: true);
        m_LOAD_Enter = m_LOAD.FindAction("Enter", throwIfNotFound: true);
        // EVENT
        m_EVENT = asset.FindActionMap("EVENT", throwIfNotFound: true);
        m_EVENT_Menue = m_EVENT.FindAction("Menue", throwIfNotFound: true);
        // MENU
        m_MENU = asset.FindActionMap("MENU", throwIfNotFound: true);
        m_MENU_Select = m_MENU.FindAction("Select", throwIfNotFound: true);
        m_MENU_Decision = m_MENU.FindAction(" Decision", throwIfNotFound: true);
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

    // GAME
    private readonly InputActionMap m_GAME;
    private IGAMEActions m_GAMEActionsCallbackInterface;
    private readonly InputAction m_GAME_LStick;
    private readonly InputAction m_GAME_RStick;
    private readonly InputAction m_GAME_CrossButton;
    private readonly InputAction m_GAME_NorthButtonY;
    private readonly InputAction m_GAME_SouthButtonA;
    private readonly InputAction m_GAME_WestButtonX;
    private readonly InputAction m_GAME_EastButtonB;
    private readonly InputAction m_GAME_MenueButton;
    private readonly InputAction m_GAME_ViewButton;
    private readonly InputAction m_GAME_TriggerL;
    private readonly InputAction m_GAME_TriggerR;
    private readonly InputAction m_GAME_LButton;
    private readonly InputAction m_GAME_RButton;
    public struct GAMEActions
    {
        private @MainInputSystem m_Wrapper;
        public GAMEActions(@MainInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @LStick => m_Wrapper.m_GAME_LStick;
        public InputAction @RStick => m_Wrapper.m_GAME_RStick;
        public InputAction @CrossButton => m_Wrapper.m_GAME_CrossButton;
        public InputAction @NorthButtonY => m_Wrapper.m_GAME_NorthButtonY;
        public InputAction @SouthButtonA => m_Wrapper.m_GAME_SouthButtonA;
        public InputAction @WestButtonX => m_Wrapper.m_GAME_WestButtonX;
        public InputAction @EastButtonB => m_Wrapper.m_GAME_EastButtonB;
        public InputAction @MenueButton => m_Wrapper.m_GAME_MenueButton;
        public InputAction @ViewButton => m_Wrapper.m_GAME_ViewButton;
        public InputAction @TriggerL => m_Wrapper.m_GAME_TriggerL;
        public InputAction @TriggerR => m_Wrapper.m_GAME_TriggerR;
        public InputAction @LButton => m_Wrapper.m_GAME_LButton;
        public InputAction @RButton => m_Wrapper.m_GAME_RButton;
        public InputActionMap Get() { return m_Wrapper.m_GAME; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GAMEActions set) { return set.Get(); }
        public void SetCallbacks(IGAMEActions instance)
        {
            if (m_Wrapper.m_GAMEActionsCallbackInterface != null)
            {
                @LStick.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnLStick;
                @LStick.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnLStick;
                @LStick.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnLStick;
                @RStick.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnRStick;
                @RStick.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnRStick;
                @RStick.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnRStick;
                @CrossButton.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnCrossButton;
                @CrossButton.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnCrossButton;
                @CrossButton.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnCrossButton;
                @NorthButtonY.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnNorthButtonY;
                @NorthButtonY.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnNorthButtonY;
                @NorthButtonY.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnNorthButtonY;
                @SouthButtonA.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnSouthButtonA;
                @SouthButtonA.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnSouthButtonA;
                @SouthButtonA.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnSouthButtonA;
                @WestButtonX.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnWestButtonX;
                @WestButtonX.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnWestButtonX;
                @WestButtonX.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnWestButtonX;
                @EastButtonB.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnEastButtonB;
                @EastButtonB.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnEastButtonB;
                @EastButtonB.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnEastButtonB;
                @MenueButton.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnMenueButton;
                @MenueButton.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnMenueButton;
                @MenueButton.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnMenueButton;
                @ViewButton.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnViewButton;
                @ViewButton.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnViewButton;
                @ViewButton.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnViewButton;
                @TriggerL.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnTriggerL;
                @TriggerL.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnTriggerL;
                @TriggerL.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnTriggerL;
                @TriggerR.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnTriggerR;
                @TriggerR.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnTriggerR;
                @TriggerR.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnTriggerR;
                @LButton.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnLButton;
                @LButton.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnLButton;
                @LButton.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnLButton;
                @RButton.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnRButton;
                @RButton.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnRButton;
                @RButton.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnRButton;
            }
            m_Wrapper.m_GAMEActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LStick.started += instance.OnLStick;
                @LStick.performed += instance.OnLStick;
                @LStick.canceled += instance.OnLStick;
                @RStick.started += instance.OnRStick;
                @RStick.performed += instance.OnRStick;
                @RStick.canceled += instance.OnRStick;
                @CrossButton.started += instance.OnCrossButton;
                @CrossButton.performed += instance.OnCrossButton;
                @CrossButton.canceled += instance.OnCrossButton;
                @NorthButtonY.started += instance.OnNorthButtonY;
                @NorthButtonY.performed += instance.OnNorthButtonY;
                @NorthButtonY.canceled += instance.OnNorthButtonY;
                @SouthButtonA.started += instance.OnSouthButtonA;
                @SouthButtonA.performed += instance.OnSouthButtonA;
                @SouthButtonA.canceled += instance.OnSouthButtonA;
                @WestButtonX.started += instance.OnWestButtonX;
                @WestButtonX.performed += instance.OnWestButtonX;
                @WestButtonX.canceled += instance.OnWestButtonX;
                @EastButtonB.started += instance.OnEastButtonB;
                @EastButtonB.performed += instance.OnEastButtonB;
                @EastButtonB.canceled += instance.OnEastButtonB;
                @MenueButton.started += instance.OnMenueButton;
                @MenueButton.performed += instance.OnMenueButton;
                @MenueButton.canceled += instance.OnMenueButton;
                @ViewButton.started += instance.OnViewButton;
                @ViewButton.performed += instance.OnViewButton;
                @ViewButton.canceled += instance.OnViewButton;
                @TriggerL.started += instance.OnTriggerL;
                @TriggerL.performed += instance.OnTriggerL;
                @TriggerL.canceled += instance.OnTriggerL;
                @TriggerR.started += instance.OnTriggerR;
                @TriggerR.performed += instance.OnTriggerR;
                @TriggerR.canceled += instance.OnTriggerR;
                @LButton.started += instance.OnLButton;
                @LButton.performed += instance.OnLButton;
                @LButton.canceled += instance.OnLButton;
                @RButton.started += instance.OnRButton;
                @RButton.performed += instance.OnRButton;
                @RButton.canceled += instance.OnRButton;
            }
        }
    }
    public GAMEActions @GAME => new GAMEActions(this);

    // LOAD
    private readonly InputActionMap m_LOAD;
    private ILOADActions m_LOADActionsCallbackInterface;
    private readonly InputAction m_LOAD_Enter;
    public struct LOADActions
    {
        private @MainInputSystem m_Wrapper;
        public LOADActions(@MainInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Enter => m_Wrapper.m_LOAD_Enter;
        public InputActionMap Get() { return m_Wrapper.m_LOAD; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LOADActions set) { return set.Get(); }
        public void SetCallbacks(ILOADActions instance)
        {
            if (m_Wrapper.m_LOADActionsCallbackInterface != null)
            {
                @Enter.started -= m_Wrapper.m_LOADActionsCallbackInterface.OnEnter;
                @Enter.performed -= m_Wrapper.m_LOADActionsCallbackInterface.OnEnter;
                @Enter.canceled -= m_Wrapper.m_LOADActionsCallbackInterface.OnEnter;
            }
            m_Wrapper.m_LOADActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Enter.started += instance.OnEnter;
                @Enter.performed += instance.OnEnter;
                @Enter.canceled += instance.OnEnter;
            }
        }
    }
    public LOADActions @LOAD => new LOADActions(this);

    // EVENT
    private readonly InputActionMap m_EVENT;
    private IEVENTActions m_EVENTActionsCallbackInterface;
    private readonly InputAction m_EVENT_Menue;
    public struct EVENTActions
    {
        private @MainInputSystem m_Wrapper;
        public EVENTActions(@MainInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Menue => m_Wrapper.m_EVENT_Menue;
        public InputActionMap Get() { return m_Wrapper.m_EVENT; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(EVENTActions set) { return set.Get(); }
        public void SetCallbacks(IEVENTActions instance)
        {
            if (m_Wrapper.m_EVENTActionsCallbackInterface != null)
            {
                @Menue.started -= m_Wrapper.m_EVENTActionsCallbackInterface.OnMenue;
                @Menue.performed -= m_Wrapper.m_EVENTActionsCallbackInterface.OnMenue;
                @Menue.canceled -= m_Wrapper.m_EVENTActionsCallbackInterface.OnMenue;
            }
            m_Wrapper.m_EVENTActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Menue.started += instance.OnMenue;
                @Menue.performed += instance.OnMenue;
                @Menue.canceled += instance.OnMenue;
            }
        }
    }
    public EVENTActions @EVENT => new EVENTActions(this);

    // MENU
    private readonly InputActionMap m_MENU;
    private IMENUActions m_MENUActionsCallbackInterface;
    private readonly InputAction m_MENU_Select;
    private readonly InputAction m_MENU_Decision;
    public struct MENUActions
    {
        private @MainInputSystem m_Wrapper;
        public MENUActions(@MainInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_MENU_Select;
        public InputAction @Decision => m_Wrapper.m_MENU_Decision;
        public InputActionMap Get() { return m_Wrapper.m_MENU; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MENUActions set) { return set.Get(); }
        public void SetCallbacks(IMENUActions instance)
        {
            if (m_Wrapper.m_MENUActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_MENUActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_MENUActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_MENUActionsCallbackInterface.OnSelect;
                @Decision.started -= m_Wrapper.m_MENUActionsCallbackInterface.OnDecision;
                @Decision.performed -= m_Wrapper.m_MENUActionsCallbackInterface.OnDecision;
                @Decision.canceled -= m_Wrapper.m_MENUActionsCallbackInterface.OnDecision;
            }
            m_Wrapper.m_MENUActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Decision.started += instance.OnDecision;
                @Decision.performed += instance.OnDecision;
                @Decision.canceled += instance.OnDecision;
            }
        }
    }
    public MENUActions @MENU => new MENUActions(this);
    public interface IGAMEActions
    {
        void OnLStick(InputAction.CallbackContext context);
        void OnRStick(InputAction.CallbackContext context);
        void OnCrossButton(InputAction.CallbackContext context);
        void OnNorthButtonY(InputAction.CallbackContext context);
        void OnSouthButtonA(InputAction.CallbackContext context);
        void OnWestButtonX(InputAction.CallbackContext context);
        void OnEastButtonB(InputAction.CallbackContext context);
        void OnMenueButton(InputAction.CallbackContext context);
        void OnViewButton(InputAction.CallbackContext context);
        void OnTriggerL(InputAction.CallbackContext context);
        void OnTriggerR(InputAction.CallbackContext context);
        void OnLButton(InputAction.CallbackContext context);
        void OnRButton(InputAction.CallbackContext context);
    }
    public interface ILOADActions
    {
        void OnEnter(InputAction.CallbackContext context);
    }
    public interface IEVENTActions
    {
        void OnMenue(InputAction.CallbackContext context);
    }
    public interface IMENUActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnDecision(InputAction.CallbackContext context);
    }
}
