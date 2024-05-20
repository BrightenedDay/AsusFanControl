# Asus Fan Control

**Credit goes to Karmel0x for finding this. (Seriously thank you!)**

### Download
Go to [releases](../../releases/latest)

### Run

<details>
    <summary>Command line: `AsusFanControl.exe`</summary>
    
    AsusFanControl.exe <args>
        --get-fan-speeds
        --set-fan-speeds=0-100 (percent value, 0 for turning off test mode)
        --get-fan-count
        --get-fan-speed=fanId (comma separated)
        --set-fan-speed=fanId:0-100 (comma separated, percent value, 0 for turning off test mode)
        --get-cpu-temp
        --get-gpu-ts1l-temp
        --get-gpu-ts1r-temp
        --get-highest-gpu-temp
</details>

GUI: `AsusFanControlGUI.exe`  

![ASUSFanControlGUI](https://github.com/BrightenedDay/AsusFanControl/assets/97611394/1e2481df-70f4-467c-a5d4-1a50a8508c2b)
![ASUSFanControlGUISettings](https://github.com/BrightenedDay/AsusFanControl/assets/97611394/ede4b27e-e926-4660-a166-4983a17f2fcd)


### Why need it?
My laptop does not support the [Fan Profile](https://github.com/Karmel0x/AsusFanControl/assets/25367564/924d990a-bf20-4b8d-bf9d-56c460174d99) option, but it often overheats. Looked for apps to control fans, but none is working.

### Compatibility
This program should work on any laptop with x64 windows where [Fan Diagnosis](https://github.com/Karmel0x/AsusFanControl/assets/25367564/7129833b-97af-4da8-9148-b71e49552ea4) in [MyASUS](https://apps.microsoft.com/store/detail/myasus/9N7R5S6B0ZZH) application is working as it is using same library.

Included `AsusWinIO64.dll` is licenced to `(c) ASUSTek COMPUTER INC.` which can be found in `C:\Windows\System32\DriverStore\FileRepository\asussci2.inf_amd64_-\ASUSSystemAnalysis\` if you have MyASUS installed.

Confirmed compatibility: 
- ASUS VivoBook 15 X512FL
- ASUS Tuf Gaming FX506HE
