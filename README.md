# DeepLTranslator PowerToys Plugin

This plugin allows you to use PowerToys Run for translations via the DeepL API.
![DeepL Plugin Introduce](https://github.com/patcher454/DeepLTranslatorPowerToys/assets/34996184/ba435959-6dd5-4315-94af-45a1b487306d)  

### How to Use

1. **Activate PowerToys Run:** Press `Alt + Space`.
2. **Enter Translation Command:** Type your translation request in the following format:
   ```
   @@{Target Language Code} {Sentences you want to translate}
   ```

   - Example for translating English to Korean:
     ```
     @@ko hello!
     ```
   - Example for translating Korean to English:
     ```
     @@en 안녕하세요!
     ```

3. **Paste the Translation Result:** Press `Enter` to paste the result using `Ctrl + V`.

   **Note:** You can omit the `@@` prefix if you enable the option to include results globally in the plugin settings.

### Supported Languages and Codes

| Code | Language                | Code | Language                                     |
|------|-------------------------|------|----------------------------------------------|
| ar   | Arabic                  | it   | Italian                                      |
| bg   | Bulgarian               | ja   | Japanese                                     |
| cs   | Czech                   | ko   | Korean                                       |
| da   | Danish                  | lt   | Lithuanian                                   |
| de   | German                  | lv   | Latvian                                      |
| el   | Greek                   | nb   | Norwegian Bokmål                             |
| en   | English                 | nl   | Dutch                                        |
| en_gb| English (British)       | pl   | Polish                                       |
| en_us| English (American)      | pt   | Portuguese                                   |
| es   | Spanish                 | pt_br| Portuguese (Brazilian)                       |
| et   | Estonian                | pt_pt| Portuguese (all varieties except Brazilian)  |
| fi   | Finnish                 | ro   | Romanian                                     |
| fr   | French                  | ru   | Russian                                      |
| hu   | Hungarian               | sk   | Slovak                                       |
| id   | Indonesian              | sl   | Slovenian                                    |
| sv   | Swedish                 | tr   | Turkish                                      |
| uk   | Ukrainian               | zh   | Chinese (simplified)                         |

### Creating a DeepL Account

1. **Sign Up for an Account:** Visit [DeepL API](https://www.deepl.com/pro-api?cta=header-pro-api) and [Sign Up](https://www.deepl.com/signup?cta=checkout).
2. **Get Your API Key:** Obtain your API key from your [DeepL Account](https://www.deepl.com/your-account/keys).

### Installation Instructions

1. **Install PowerToys:**
   - Download it from [PowerToys Download](https://learn.microsoft.com/en-us/windows/powertoys/install).

2. **Download and Extract the Plugin:**
   - Download the plugin zip file from [DeepLTranslator Plugin releases](https://github.com/patcher454/DeepLTranslatorPowerToys/releases/).
   - Extract the zip file to:
     ```
     %LOCALAPPDATA%/Microsoft/PowerToys/PowerToys Run/Plugins
     ```
     OR
     ```
     C:\Program Files\PowerToys\RunPlugins
     ```
     OR
     ```
     C:\Users\%USERNAME%\AppData\Local\PowerToys\RunPlugins
     ```
3. **Restart PowerToys:** Exit and restart PowerToys.

4. **Enter API Key:**
   - In PowerToys settings, enter your API key in the format:
     ```
     DeepL-Auth-Key {API KEY}
     ```
     ![image](https://github.com/user-attachments/assets/4a867356-9ceb-4b8d-a83d-3645941191fc)

### Recommendations  

- **DeepL API Load Prevention Policy**  
  - Due to recent policy changes in the DeepL API, it is necessary to avoid too many API calls within a short time.  
  - To minimize API usage, translation requests are processed sequentially, ensuring the next request begins only after the current one is completed.  
  - If text is entered too quickly, some characters may be Ignored.  
  
- **Solution**  
  - Increase the value of the **"Input Smoothing > Immediate plugins"** setting. This ensures sufficient intervals between API calls, preventing characters from being skipped.  
  - Suggested value: 300ms - 400ms (In my experience)

   ![image](https://github.com/user-attachments/assets/036f932b-f8db-4878-8f46-2e6f3d521fc1)

  

### How to Build

1. **Locate the DLL Folder:**
   ```
   Community.PowerToys.Run.Plugin.DeepLTranslator\DLL
   ```
2. **Replace the DLL File:** Replace the DLL file in the folder with the one for your desired version (default build is x64; for ARM, use the ARM version).
