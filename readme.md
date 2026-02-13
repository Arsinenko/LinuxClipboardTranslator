# Clipboard Translator

## En
[ru](readme_ru.md)

A simple C# application that captures text from your clipboard, translates it from English to Russian using the Google Translate API, and displays the result in a GTK-based window.

### Features

* **Automatic Translation:** Fetches text directly from the clipboard.
* **GTK Interface:** Clean display using `GtkSharp`.
* **Quick Copy:** Includes a button to copy the translation back to the clipboard.
* **Hotkeys:** Close the window instantly with the `Esc` key.

### Requirements

* **GTranslatorAPIClient:** Used for handling translation requests.
* **GtkSharp:** Required for the graphical user interface.
* **System Utilities:** You must have clipboard utilities installed for the app to read/write data:
* For **X11**: `xclip`
* For **Wayland**: `wl-clipboard` (provides `wl-paste`)



### Download

You can find the latest binaries here:
👉 **[releases](https://github.com/Arsinenko/LinuxClipboardTranslator/releases)**

