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
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""aeed3e2b-ef42-4e99-948b-bbc79c3ce58c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""a6f37680-78a5-4fde-8c82-d6e1a1e4f9f1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Index"",
                    ""type"": ""Button"",
                    ""id"": ""64cab0ac-c035-4124-96df-466e92b2b78e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""f452d2be-9cc6-45e0-809b-74afbcb24ac9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""502cc48b-f191-49fc-b0a9-0c9f2dad21aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Item"",
                    ""type"": ""Button"",
                    ""id"": ""5b1f71e6-7c81-401a-9f83-0ac0a029d3f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""6bb9e85f-e22d-450d-b0cb-22828992509d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e9bb0272-2c53-4563-8ff8-77ad1f7ea829"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80700c75-20e0-42b8-ba1d-07c9fb20ad08"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""049799f4-5f01-41c2-ba44-0bce0b8fb0df"",
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
                    ""id"": ""ecb5acbb-c0df-4d63-872c-c2540f03308e"",
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
                    ""id"": ""49a08237-bb71-4b7e-9915-837de56dcd29"",
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
                    ""id"": ""4ea6aace-026f-4bc6-aa3b-b6e5bb801425"",
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
                    ""id"": ""efd644ac-d42c-438d-a340-1f0c71a6a338"",
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
                    ""id"": ""db209761-7262-49d7-857c-9358428d0b0e"",
                    ""path"": ""<SwitchProControllerHID>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4a4e635-165e-436d-9368-8a2ead7be758"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d037ff33-3b59-4f65-9736-b7259d2f7695"",
                    ""path"": ""<DualShockGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15544aec-68e7-412f-92d9-831d4f55067e"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a121ec1-826f-42c8-ad9a-dac6fc84690b"",
                    ""path"": ""<DualShockGamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Index"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f56303c-30d5-45c0-a6ae-04ddd517b512"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Index"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b06e1a1-bede-443c-9cd2-cc6a832cf3c2"",
                    ""path"": ""<SwitchProControllerHID>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Index"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05c37d34-92ea-4d95-bb82-260cc7fcbd5c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Index"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0381bc09-be33-454b-97c8-63d57291a504"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a88e6dfa-f626-471b-b859-0aa19c1bedbd"",
                    ""path"": ""<DualShockGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59ce981c-1eac-449a-978b-f35f49dea3bd"",
                    ""path"": ""<SwitchProControllerHID>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11bda516-c421-463c-9171-7e5f09070cac"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""977cb66b-06dd-4d74-8c9e-4961bde4386b"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""678d5cb5-bac2-42d3-a2cd-c34a89fe6a38"",
                    ""path"": ""<DualShockGamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79f9b047-6493-45d6-a5d2-e341d78ebcb7"",
                    ""path"": ""<SwitchProControllerHID>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abed48da-368b-4295-83f3-de3b86b18570"",
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
                    ""id"": ""44dda4ef-98af-4f67-89b8-ae1e559a044c"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23c7ad78-0336-4188-a252-0cd2d608b27e"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ef47b5f-7e11-4031-b2fd-c3406bb15ac5"",
                    ""path"": ""<SwitchProControllerHID>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32c6e8a5-f222-45da-b234-c70de874998b"",
                    ""path"": ""<DualShockGamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d5c307d-5dca-46b5-a0ef-26d450c4b308"",
                    ""path"": ""<DualShockGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8807f8cc-9ac3-4fbe-931a-9a9372ffd5ab"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc0435a5-807a-40cc-a2d5-8107e913a522"",
                    ""path"": ""<SwitchProControllerHID>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6a825ee-c747-4ad9-a59c-dcc033e6bf31"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
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
                    ""name"": ""Menu"",
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
                    ""action"": ""Menu"",
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
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""6572f027-5234-4350-aaa6-54b545317b53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""bbe38790-1920-4955-9386-7813fad22206"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""High"",
                    ""type"": ""Button"",
                    ""id"": ""71fd9ab0-07bb-451d-82c9-137c6359d17f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Low"",
                    ""type"": ""Button"",
                    ""id"": ""9cfed702-692e-46a5-92ee-b7150c536932"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Apply"",
                    ""type"": ""Button"",
                    ""id"": ""87386d23-42ac-4226-9210-28215d27ed11"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""b2a889b3-9fdc-4427-95b1-46f7ea804df3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""771a1344-9ba3-4ec9-9079-c86111e2955f"",
                    ""path"": ""<DualShockGamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a469b565-d6cd-4a74-b0fc-45041e98f960"",
                    ""path"": ""<DualShockGamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14540c61-0084-4112-b878-47eea14756aa"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b61a3f1-a78b-4614-8bcb-a547c919ffbf"",
                    ""path"": ""<XInputController>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e05c0ac2-7166-457a-bd10-29e75d7bf40e"",
                    ""path"": ""<SwitchProControllerHID>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ba24785-48a2-4ed8-bc0b-d5d5b69761b5"",
                    ""path"": ""<SwitchProControllerHID>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09e0cf09-d33c-4b24-8ac8-ff202de36c96"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5b76c53-4a8b-40bd-87f4-eddb41aec007"",
                    ""path"": ""<DualShockGamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3f73a33-8fa7-42c1-89ff-9ee8e0eaad50"",
                    ""path"": ""<DualShockGamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57bd2648-3c4a-4961-bed9-ac364283196a"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88b323f7-832e-4012-a5f7-1d0a8ab2476c"",
                    ""path"": ""<XInputController>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79267b3f-6eb5-40b9-9c4b-c98e4688a19a"",
                    ""path"": ""<SwitchProControllerHID>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15ff6df3-34fd-432d-8a6e-aa5a1d018105"",
                    ""path"": ""<SwitchProControllerHID>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a250dc5-ac0d-4d4a-99d3-68aae3e8de7e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae166949-256e-4cff-960b-67ad7eee3a8e"",
                    ""path"": ""<DualShockGamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""High"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29e726c3-e4e9-4ef9-a388-d72430e846d9"",
                    ""path"": ""<XInputController>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""High"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c382166-5030-4522-8fd2-a9f6a26e0a7f"",
                    ""path"": ""<SwitchProControllerHID>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""High"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""510c836f-eef1-44bc-b4d6-ed875c0d589a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""High"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5419e967-e5aa-4dc5-b62f-8a0614955a64"",
                    ""path"": ""<DualShockGamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Low"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""921c3b1a-87c8-4853-a3d3-19ca60b41462"",
                    ""path"": ""<XInputController>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Low"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab873e11-8b25-4143-a012-493c949d375f"",
                    ""path"": ""<SwitchProControllerHID>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Low"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4915a05b-558c-4d2e-9c39-f99ac7a3cbc6"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Low"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79aca9f8-5325-45f7-9583-56af5c8a399c"",
                    ""path"": ""<DualShockGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Apply"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9fa0e8c-5614-4b79-8165-b59308f76328"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Apply"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e03e9c0-bde5-454c-b056-c93c5df2dcab"",
                    ""path"": ""<SwitchProControllerHID>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Apply"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30318b45-dc6a-4c80-99c2-110b9b52aae8"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Apply"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58879579-7cb0-44db-b79e-18790688e352"",
                    ""path"": ""<DualShockGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21c4e99a-753c-46ea-bf93-c2b6609c6dec"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0753c909-2704-473b-bf6d-a2dd76f14968"",
                    ""path"": ""<SwitchProControllerHID>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48009b5a-3ed2-4235-85f1-f097f50a158a"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
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
        m_GAME_Move = m_GAME.FindAction("Move", throwIfNotFound: true);
        m_GAME_Aim = m_GAME.FindAction("Aim", throwIfNotFound: true);
        m_GAME_Index = m_GAME.FindAction("Index", throwIfNotFound: true);
        m_GAME_Fire = m_GAME.FindAction("Fire", throwIfNotFound: true);
        m_GAME_Jump = m_GAME.FindAction("Jump", throwIfNotFound: true);
        m_GAME_Item = m_GAME.FindAction("Item", throwIfNotFound: true);
        m_GAME_Menu = m_GAME.FindAction("Menu", throwIfNotFound: true);
        // LOAD
        m_LOAD = asset.FindActionMap("LOAD", throwIfNotFound: true);
        m_LOAD_Enter = m_LOAD.FindAction("Enter", throwIfNotFound: true);
        // EVENT
        m_EVENT = asset.FindActionMap("EVENT", throwIfNotFound: true);
        m_EVENT_Menu = m_EVENT.FindAction("Menu", throwIfNotFound: true);
        // MENU
        m_MENU = asset.FindActionMap("MENU", throwIfNotFound: true);
        m_MENU_Up = m_MENU.FindAction("Up", throwIfNotFound: true);
        m_MENU_Down = m_MENU.FindAction("Down", throwIfNotFound: true);
        m_MENU_High = m_MENU.FindAction("High", throwIfNotFound: true);
        m_MENU_Low = m_MENU.FindAction("Low", throwIfNotFound: true);
        m_MENU_Apply = m_MENU.FindAction("Apply", throwIfNotFound: true);
        m_MENU_Escape = m_MENU.FindAction("Escape", throwIfNotFound: true);
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
    private readonly InputAction m_GAME_Move;
    private readonly InputAction m_GAME_Aim;
    private readonly InputAction m_GAME_Index;
    private readonly InputAction m_GAME_Fire;
    private readonly InputAction m_GAME_Jump;
    private readonly InputAction m_GAME_Item;
    private readonly InputAction m_GAME_Menu;
    public struct GAMEActions
    {
        private @MainInputSystem m_Wrapper;
        public GAMEActions(@MainInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_GAME_Move;
        public InputAction @Aim => m_Wrapper.m_GAME_Aim;
        public InputAction @Index => m_Wrapper.m_GAME_Index;
        public InputAction @Fire => m_Wrapper.m_GAME_Fire;
        public InputAction @Jump => m_Wrapper.m_GAME_Jump;
        public InputAction @Item => m_Wrapper.m_GAME_Item;
        public InputAction @Menu => m_Wrapper.m_GAME_Menu;
        public InputActionMap Get() { return m_Wrapper.m_GAME; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GAMEActions set) { return set.Get(); }
        public void SetCallbacks(IGAMEActions instance)
        {
            if (m_Wrapper.m_GAMEActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnAim;
                @Index.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnIndex;
                @Index.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnIndex;
                @Index.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnIndex;
                @Fire.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnFire;
                @Jump.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnJump;
                @Item.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnItem;
                @Item.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnItem;
                @Item.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnItem;
                @Menu.started -= m_Wrapper.m_GAMEActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_GAMEActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_GAMEActionsCallbackInterface.OnMenu;
            }
            m_Wrapper.m_GAMEActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Index.started += instance.OnIndex;
                @Index.performed += instance.OnIndex;
                @Index.canceled += instance.OnIndex;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Item.started += instance.OnItem;
                @Item.performed += instance.OnItem;
                @Item.canceled += instance.OnItem;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
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
    private readonly InputAction m_EVENT_Menu;
    public struct EVENTActions
    {
        private @MainInputSystem m_Wrapper;
        public EVENTActions(@MainInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Menu => m_Wrapper.m_EVENT_Menu;
        public InputActionMap Get() { return m_Wrapper.m_EVENT; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(EVENTActions set) { return set.Get(); }
        public void SetCallbacks(IEVENTActions instance)
        {
            if (m_Wrapper.m_EVENTActionsCallbackInterface != null)
            {
                @Menu.started -= m_Wrapper.m_EVENTActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_EVENTActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_EVENTActionsCallbackInterface.OnMenu;
            }
            m_Wrapper.m_EVENTActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
            }
        }
    }
    public EVENTActions @EVENT => new EVENTActions(this);

    // MENU
    private readonly InputActionMap m_MENU;
    private IMENUActions m_MENUActionsCallbackInterface;
    private readonly InputAction m_MENU_Up;
    private readonly InputAction m_MENU_Down;
    private readonly InputAction m_MENU_High;
    private readonly InputAction m_MENU_Low;
    private readonly InputAction m_MENU_Apply;
    private readonly InputAction m_MENU_Escape;
    public struct MENUActions
    {
        private @MainInputSystem m_Wrapper;
        public MENUActions(@MainInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_MENU_Up;
        public InputAction @Down => m_Wrapper.m_MENU_Down;
        public InputAction @High => m_Wrapper.m_MENU_High;
        public InputAction @Low => m_Wrapper.m_MENU_Low;
        public InputAction @Apply => m_Wrapper.m_MENU_Apply;
        public InputAction @Escape => m_Wrapper.m_MENU_Escape;
        public InputActionMap Get() { return m_Wrapper.m_MENU; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MENUActions set) { return set.Get(); }
        public void SetCallbacks(IMENUActions instance)
        {
            if (m_Wrapper.m_MENUActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_MENUActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_MENUActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_MENUActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_MENUActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_MENUActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_MENUActionsCallbackInterface.OnDown;
                @High.started -= m_Wrapper.m_MENUActionsCallbackInterface.OnHigh;
                @High.performed -= m_Wrapper.m_MENUActionsCallbackInterface.OnHigh;
                @High.canceled -= m_Wrapper.m_MENUActionsCallbackInterface.OnHigh;
                @Low.started -= m_Wrapper.m_MENUActionsCallbackInterface.OnLow;
                @Low.performed -= m_Wrapper.m_MENUActionsCallbackInterface.OnLow;
                @Low.canceled -= m_Wrapper.m_MENUActionsCallbackInterface.OnLow;
                @Apply.started -= m_Wrapper.m_MENUActionsCallbackInterface.OnApply;
                @Apply.performed -= m_Wrapper.m_MENUActionsCallbackInterface.OnApply;
                @Apply.canceled -= m_Wrapper.m_MENUActionsCallbackInterface.OnApply;
                @Escape.started -= m_Wrapper.m_MENUActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_MENUActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_MENUActionsCallbackInterface.OnEscape;
            }
            m_Wrapper.m_MENUActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @High.started += instance.OnHigh;
                @High.performed += instance.OnHigh;
                @High.canceled += instance.OnHigh;
                @Low.started += instance.OnLow;
                @Low.performed += instance.OnLow;
                @Low.canceled += instance.OnLow;
                @Apply.started += instance.OnApply;
                @Apply.performed += instance.OnApply;
                @Apply.canceled += instance.OnApply;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
            }
        }
    }
    public MENUActions @MENU => new MENUActions(this);
    public interface IGAMEActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnIndex(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnItem(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
    }
    public interface ILOADActions
    {
        void OnEnter(InputAction.CallbackContext context);
    }
    public interface IEVENTActions
    {
        void OnMenu(InputAction.CallbackContext context);
    }
    public interface IMENUActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnHigh(InputAction.CallbackContext context);
        void OnLow(InputAction.CallbackContext context);
        void OnApply(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
    }
}
