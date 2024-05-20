# DeepLTranslator PowerToys PlugIn
Power Toys Translation Plug-in with DeepLTranslator
This plug-in is designed to use the DeepL API Free plan

![DeepL Plugin Introduce](https://github.com/patcher454/DeepLTranslatorPowerToys/assets/34996184/ba435959-6dd5-4315-94af-45a1b487306d)  

##How to use

Press the `Alt + Space` key to activate the Power Toys Run

If you type in the following, the translation results will be output.

```
@@{Target Language Code} {Sentences you want to translate}
```  

Enter the Enter key in the result to paste with Ctrl + V.

**@@(direct activation command) can be omitted if you enable the option to include in global results in the plug-in setting.**

## Supported Languages and Codes

```
AR,      // Arabic
BG,      // Bulgarian
CS,      // Czech
DA,      // Danish
DE,      // German
EL,      // Greek
EN,      // English (unspecified variant for backward compatibility; please select EN-GB or EN-US instead)
EN_GB,   // English (British)
EN_US,   // English (American)
ES,      // Spanish
ET,      // Estonian
FI,      // Finnish
FR,      // French
HU,      // Hungarian
ID,      // Indonesian
IT,      // Italian
JA,      // Japanese
KO,      // Korean
LT,      // Lithuanian
LV,      // Latvian
NB,      // Norwegian Bokmål
NL,      // Dutch
PL,      // Polish
PT,      // Portuguese (unspecified variant for backward compatibility; please select PT-BR or PT-PT instead)
PT_BR,   // Portuguese (Brazilian)
PT_PT,   // Portuguese (all Portuguese varieties excluding Brazilian Portuguese)
RO,      // Romanian
RU,      // Russian
SK,      // Slovak
SL,      // Slovenian
SV,      // Swedish
TR,      // Turkish
UK,      // Ukrainian
ZH,      // Chinese (simplified)
```

## Create a DeepL Account
This plug-in requires an API key for DeepL.  
Therefore, if you don't have an account with DeepL, please create an account  
[DeepL API](https://www.deepl.com/pro-api?cta=header-pro-api)  
[Sign Up](https://www.deepl.com/signup?cta=checkout)  

## Install instructions
This plug-in requires PowerToys.  

[PowerToys Download](https://learn.microsoft.com/ko-kr/windows/powertoys/install)  

PowerToys has been installed, download the plug-in zip file  

[DeepLTranslator Plugin releases](https://github.com/patcher454/DeepLTranslatorPowerToys/releases/)

![image](https://github.com/patcher454/DeepLTranslatorPowerToys/assets/34996184/a67ebe69-2ba7-4c05-814e-be1bb5bfd259)  

Please decompress the zip file to the path below  
```
C:\Program Files\PowerToys\RunPlugins
```
OR  
```
C:\Users\{username}\AppData\Local\PowerToys\RunPlugins
```  
If the decompression is complete, please exit and re-start PowerToys

![image](https://github.com/patcher454/DeepLTranslatorPowerToys/assets/34996184/143849c9-4288-4af2-acc0-24f59e272f33)  
  
After running the Power Toys, put in the API as shown in the picture  

**When you enter the key, put it in the format below**  

```
DeepL-Auth-Key {API KEY}
```
You can check the API key [here](https://www.deepl.com/your-account/keys)

## How to build

```
Community.PowerToys.Run.Plugin.DeepLTranslator\DLL
```
Replace the dll file in the folder with the dll file in the version you want (The default build specification for the project is x64.)  
So if you want to build with ARM, replace it with ARM version
