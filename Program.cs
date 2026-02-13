using System.Data;
using System.Diagnostics;

using Gtk;
using GTranslatorAPI;

ShowTranslation(GetTranslation(GetClipboardText()));

void ShowTranslation(string text)
{
    Application.Init();
    Window win = new Window("Translation");

    VBox vBox = new(false, 5);
    
    var textField = new TextView();
    textField.Buffer.Text = text;
    textField.Editable = false;
    vBox.PackStart(textField, true, true, 0);
    
    var copyBtn = new Button("copy");
    copyBtn.Clicked += delegate
    {
        Clipboard clipboard = Clipboard.Get(Gdk.Atom.Intern("CLIPBOARD", false));
        clipboard.Text = text;
    };
    vBox.PackStart(copyBtn, true, true, 0);
    win.DeleteEvent += (o, eventArgs) =>
    {
        Application.Quit();
        eventArgs.RetVal = true;
    };
    win.KeyPressEvent += (o, eventAgrs) =>
    {
        if (eventAgrs.Event.Key == Gdk.Key.Escape)
        {
            win.Close();
        }
    };
    
    win.Add(vBox);
    win.ShowAll();
    Application.Run();
}

string GetTranslation(string text)
{
    var translator = new GTranslatorAPIClient();
    var result = translator.Translate(Languages.en, Languages.ru, text);
    if (result == null)
    {
        throw new Exception("translation error");
    }
    return result.TranslatedText;
}

string GetClipboardText()
{
    var command = "xclip -o";
    if (Environment.GetEnvironmentVariable("XDG_SESSION_TYPE") == "wayland")
    {
        command = "wl-paste";
    }
    var process = new Process();
    process.StartInfo.FileName = command;
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.Start();

    string result = process.StandardOutput.ReadToEnd();
    process.WaitForExit();
    return result.Trim();
}



