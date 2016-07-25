xcopy %~dp0bin\debug\*.dll %~dp0ext\unity-project\Assets\Scripts /Y
xcopy %~dp0bin\debug\*.cs %~dp0ext\unity-project\Assets\Scripts /Y
del %~dp0ext\unity-project\Assets\Scripts\ACG.Core.Tests.dll
del %~dp0ext\unity-project\Assets\Scripts\ACG.Plugins.Unity.dll