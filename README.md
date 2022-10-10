# unity-ar-anchor-example

An example of AR anchor integration in Unity using AR Foundation. Using this application, a 3D object can be anchored in an AR scene. This project is built using Unity version 2021.3.11f1 and is designed to run on Android devices (not tested in iOS).

## Supported Platforms
This project is designed for use on both iOS and Android, but it has only been tested on Android.

## Running Locally
Use the following steps to run locally:
1. Clone this repo
2. Open repo folder using Unity 2021.3.11f1
3. Install Text Mesh Pro

## Development
Setup steps to be able to include AR Foundation and build and deploy:
- Install AR Foundation located in the Package Manager under AR Foundation
- Install ARKit located in the Package Manager under AR Kit XR Plugin (required for iOS devices)
- Install ARCore located in the Package Manager under AR Core XR Plugin (required for Android devices)
- In Project Settings > XR Plug-in Management, set the Plug-in Provider on the Android tab to ARCore
- Ensure AR scenes contain an AR Session and AR Session Origin
- In Project Settings > Resolution and Presentation, disable Render Outside Safe Space
- For Android, in Project Settings > Other Settings, set Minimum API Level to Android API level 24 or higher (this is required to build for Android)
- For Android, in Project Settings > Other Settings, remove Vulkan from Graphics APIs (this is required to build for Android, need to uncheck Auto Graphics API first)
- For Android, in Project Settings > Other Settings, Set Scripting Backend to IL2CPP
- For Android, in Project Settings > Other Settings, Add ARM64 to Target Architectures

## Development Tools
- Created using Unity 2021.3.11f1
- Code edited using Visual Studio Code

## Credits
AR Setup is based on this tutorial:
https://www.youtube.com/watch?v=R3OCUE9TwZk

AR anchors based on this tutorial:
https://www.youtube.com/watch?v=kcqcUxVQu0o

Source code for above tutorial:
https://github.com/dilmerv/ARDraw

