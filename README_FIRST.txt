
!!!ВАЖНО!!!

Для корректной работы и компиляции нужна поключаемая сборка Microsoft.Win32.Registry.dll.
Если ее нет то приложение не будет компилироваться. !!!
При надобности только ее можно взять тут: https://drive.google.com/file/d/1e-yM0qq92X75HwV6eJ75DXeAqxv9YDyK/view?usp=sharing
Версия исходного кода со сборкой лежит тут: https://github.com/friezze/autorun_red
Для компилятора ОБЯЗАТЕЛЬНЫМ параметром являеться  /r:Microsoft.Win32.Registry.dll
Пример правильной компиляции: C:\Windows\Microsoft.NET\Framework\v3.5\csc.exe /r:Microsoft.Win32.Registry.dll /out:a.exe *css

!!!ВАЖНО!!!